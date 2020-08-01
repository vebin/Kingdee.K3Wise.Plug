using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace K3DoNetPlug.Helper
{
    public partial class QueryView : Form
    {        
        #region 私有成员

        private List<Dictionary<string, string>> resultValue;

        private BaseBiller baseBiller;

        #endregion

        #region 公有成员，主要用于设置
        /// <summary>
        /// 是否多选
        /// </summary>
        public bool isMulitSelect { get; set; }

        /// <summary>
        /// 查询语句,{0}为过滤关键字传入值
        /// </summary>
        public string Query{get;set;}

        /// <summary>
        /// 显示表头字段名称,显示标题 
        /// </summary>
        public Dictionary<string, string> ShowTitle{get;set; }

        /// <summary>
        /// 设置不显示行
        /// </summary>
        public Dictionary<string, bool> IsVisible { get; set; }

        public DataGridView DataGridViewCtl
        {
            get
            {
                return this.dataGridViewMain;
            }
        }
        #endregion

        public new List<Dictionary<string,string>> Show()
        {
            base.ShowDialog();
            return resultValue;
        }

        public QueryView(BaseBiller baseBiller)
        {
            this.baseBiller = baseBiller;
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

            for (int rowIndex = 0; rowIndex < this.dataGridViewMain.Rows.Count; rowIndex++)
            {
                if(dataGridViewMain.Rows[rowIndex].Cells["IsSelected"].Value!=null&&(bool)dataGridViewMain.Rows[rowIndex].Cells["IsSelected"].Value)
                {
                    Dictionary<string, string> valueItem = new Dictionary<string, string>();
                    foreach (DataGridViewCell cell in dataGridViewMain.Rows[rowIndex].Cells)
                    {
                        valueItem.Add(dataGridViewMain.Columns[cell.ColumnIndex].Name, cell.Value.ToString());
                    }
                    result.Add(valueItem);
                }
            }
            resultValue = result;
            this.Close();
        }

        private void InitTitle()
        {
            if (!dataGridViewMain.Columns.Contains("IsSelected"))
            {
                dataGridViewMain.Columns.Insert(0,new DataGridViewCheckBoxColumn());
                dataGridViewMain.Columns[0].Name = "IsSelected";
                dataGridViewMain.Columns[0].HeaderText = "选择";
                dataGridViewMain.Columns[0].Frozen = true;
                dataGridViewMain.Columns[0].ReadOnly = false;
            }

            if (ShowTitle != null)
            {
                foreach (KeyValuePair<string, string> item in ShowTitle)
                {
                    if (dataGridViewMain.Columns.Contains(item.Key))
                    {
                        dataGridViewMain.Columns[item.Key].HeaderText = item.Value;
                        dataGridViewMain.Columns[item.Key].ReadOnly = true;
                    }
                    else
                    {
                        int columnIndex = dataGridViewMain.Columns.Add(new DataGridViewTextBoxColumn());
                        dataGridViewMain.Columns[columnIndex].Name = item.Key;
                        dataGridViewMain.Columns[columnIndex].HeaderText = item.Value;
                        dataGridViewMain.Columns[columnIndex].ReadOnly = true;
                    }
                }
            }

            if (IsVisible != null)
            {
                foreach (KeyValuePair<string, bool> item in IsVisible)
                {
                    if (dataGridViewMain.Columns.Contains(item.Key))
                    {
                        dataGridViewMain.Columns[item.Key].Visible = item.Value;
                    }
                }
            }
        }

        private void QueryView_Load(object sender, EventArgs e)
        {
            DataBinding();
        }

        private void DataBinding()
        {
            DataTable table = new DataTable();
            string sqlString = Query;
            if (Query.Contains("{0}"))
            {
                sqlString = string.Format(Query, textBoxKeyword.Text);
            }
            this.baseBiller.DBUnitInstance.Run(sqlString, out table);
            dataGridViewMain.DataSource = table;

            InitTitle();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataGridViewMain.Columns.Clear();
            DataBinding();
        }

        private void dataGridViewMain_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                return;
            }

            if (isMulitSelect)
            {
                dataGridViewMain.Rows[e.RowIndex].Cells["IsSelected"].Value = true;
                return;
            }

            try
            {
                for (int rowIndex = 0; rowIndex < dataGridViewMain.Rows.Count; rowIndex++)
                {
                    dataGridViewMain.Rows[rowIndex].Cells["IsSelected"].Value = false;
                }

                dataGridViewMain.Rows[e.RowIndex].Cells["IsSelected"].Value = true;
            }
            catch
            {
            }
        }
    }
}
