using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K3DoNetPlug.CommonForm
{
    public partial class FormBaseData : Form
    {
        public List<int> ItemIDList { get; private set; }

        public DBUnit DBUnitInstances { get;private set; }

        public int ICClassTypeID { get; private set; }

        public FormBaseData(DBUnit dbUnit)
        {
            this.DBUnitInstances = dbUnit;
            InitializeComponent();
        }

        public static List<int> Show(DBUnit dbUnit,int icclassTypeID)
        {
            FormBaseData form = new FormBaseData(dbUnit);
            form.ICClassTypeID = icclassTypeID;
            form.ItemIDList = new List<int>();
            form.ShowDialog();
            return form.ItemIDList;
        }

        public FormBaseData()
        {
            InitializeComponent();
        }

        private void FormBaseData_Load(object sender, EventArgs e)
        {
            initTree();
        }

        private void initTree()
        {
            DataTable table;
            DBUnitInstances.Run(@"SELECT  t1.FItemID,t1.FParentID,t1.FNumber,t1.FName,t1.FDetail,t1.FShortNumber 
                                    From t_item t1  WHERE  FItemClassID = {0} AND t1.FDeleteD=0  AND (  t1.FDetail=0  and t1.FParentID =  0)",out table,ICClassTypeID.ToString());
            TreeNode root=new TreeNode()
            {
                Name="root",
                Text="基础资料",
                Tag = new ItemEntity()
                {
                    ItemID = 0,
                    Name = "root",
                    Number = "0"
                },
            };
            root.Expand();

            for(int rowIndex=0;rowIndex<table.Rows.Count;rowIndex++)
            {
                var item=table.Rows[rowIndex];
                var child = new TreeNode()
                {
                    Name = item["FNumber"].ToString(),
                    Text = item["FName"].ToString(),
                    Tag = new ItemEntity()
                    {
                        ItemID=Convert.ToInt32(item["FItemID"]),
                        Name=item["FName"].ToString(),
                        Number=item["FNumber"].ToString()
                    },
                };
                child.Nodes.Add(new TreeNode());
                root.Nodes.Add(child);
            }

            treeViewMain.Nodes.Add(root);
        }

        private void treeViewMain_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            ItemEntity itemEntity = (ItemEntity)e.Node.Tag;
            
            if (itemEntity.ItemID == 0)
            {
                return;
            }

            if (e.Node.Nodes.Count != 0&&(e.Node.Nodes[0].Tag as ItemEntity)!=null)
            {
                return;
            }

            DataTable table;
            DBUnitInstances.Run(@"SELECT  t1.FItemID,t1.FParentID,t1.FNumber,t1.FName,t1.FDetail,t1.FShortNumber 
                                    From t_item t1  WHERE  FItemClassID = {0} AND t1.FDeleteD=0  AND (  t1.FDetail=0  and t1.FParentID = {1} )", out table, ICClassTypeID.ToString(), itemEntity.ItemID.ToString());
            e.Node.Nodes.Clear();
            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
            {
                var item = table.Rows[rowIndex];
                var child = new TreeNode()
                {
                    Name = item["FNumber"].ToString(),
                    Text = item["FName"].ToString(),
                    Tag = new ItemEntity() 
                    {
                        ItemID=Convert.ToInt32(item["FItemID"].ToString()),
                        Name=item["FName"].ToString(),
                        Number=item["FNumber"].ToString()
                    }
                };
                child.Nodes.Add(new TreeNode());
                e.Node.Nodes.Add(child);
            }
        }

        private void treeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadListData("", ((ItemEntity)e.Node.Tag).Number);
        }

        private void dataGridViewMain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var row=dataGridViewMain.Rows[e.RowIndex];
            var itemID = row.Cells["FItemID"].Value.ToString();
            var newRow = dataGridViewSelected.Rows[dataGridViewSelected.Rows.Add()];
            for (int cellIndex = 0; cellIndex < row.Cells.Count; cellIndex++)
            {
                newRow.Cells[cellIndex].Value = row.Cells[cellIndex].Value;
            }
            
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            LoadListData(textBoxKeyword.Text, "");
        }

        private void LoadListData(string keyword,string itemNumber)
        {
            DataTable table;

            string sqlString= @"
            SELECT t1.FNumber,
                   --t1.FLevel,
                   --t1.FAccessory,
                   t1.FName,
                   --t1.FShortNumber,
                   t1.FFullName,
                   t1.FItemID
                   --t1.FUseSign,
                   --t1.FChkUserID,
                   --T888.FName AS FChkUserName,
                    --t1.FDetail,
                   --t1.FDeleteD,
                   --t3.FModel
            FROM   dbo.t_Item t1
                   LEFT JOIN t_ICItem t3
                        ON  t1.FItemID = t3.FItemID
                   LEFT JOIN t_User T888
                        ON  t1.FChkUserID = T888.FUserID
            WHERE  t1.FItemID IN (SELECT t1.FItemID
                                  FROM   t_Item t1 WITH(INDEX(uk_Item2))
                                         LEFT JOIN t_ICItem x2
                                              ON  t1.FItemID = x2.FItemID
                                  WHERE  FItemClassID = {0}
                                         AND t1.FDetail = 1";
            sqlString=string.Format(sqlString,ICClassTypeID.ToString());
            if (!string.IsNullOrEmpty(itemNumber))
            {
                sqlString = sqlString + "\n" + "AND (t1.FNumber LIKE '{0}.%') AND t1.FDeleteD = 0)";
                sqlString = string.Format(sqlString, itemNumber);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                sqlString = sqlString + "AND (t1.FName like '%{0}%' OR t1.FNumber like '%{0}%'))";
                sqlString=string.Format(sqlString,keyword);
            }
            DBUnitInstances.Run(sqlString,out table);

            dataGridViewMain.DataSource = table;
        }

        private void dataGridViewSelected_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewSelected.Rows.Remove(dataGridViewSelected.Rows[e.RowIndex]);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            for(int rowIndex=0;rowIndex<dataGridViewSelected.Rows.Count;rowIndex++)
            {
                this.ItemIDList.Add(Convert.ToInt32(dataGridViewSelected.Rows[rowIndex].Cells["SFItemID"].Value));
            }
            this.Close();
        }
    }
}
