using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public class NewBillerCell : BaseCell,ICell
    {
        public NewBillerCell(IBiller biller, IRowItem parent, int rowIndex, int cellIndex)
        {
            this.Biller = biller;
            this.Parent = parent;
            this.RowIndex = rowIndex;
            this.CellIndex = cellIndex;
            this.m_BillTransfer = this.Biller.M_BillTransfer as K3ClassEvents.BillEvent;
        }

        private K3ClassEvents.BillEvent m_BillTransfer;
        private string _columnName;
        private string ColumnName
        {
            get
            {
                if (string.IsNullOrEmpty(this._columnName))
                {
                    this._columnName = this.Parent.Parent.Parent.Column.IndexToName[this.CellIndex];
                }
                return this._columnName;
            }
        }

        private void Verify()
        {
            int rowsCount = this.Parent.Parent.Count;
            int cellsCount = this.Parent.Parent.Parent.Column.Count;
            if (this.RowIndex < 0 || (this.Parent.IsNewRow && rowsCount < this.RowIndex) || (!this.Parent.IsNewRow && rowsCount <= this.RowIndex))
            {
                throw new IndexOutOfRangeException("行下标越界");
            }
            if (this.CellIndex < 0 || cellsCount <= this.CellIndex)
            {
                throw new IndexOutOfRangeException("列下载越界");
            }
        }

        #region ICell 成员

        /// <summary>
        /// 单据对像
        /// </summary>
        /// <value></value>
        public IBiller Biller { get; private set; }

        /// <summary>
        /// 所属行号
        /// </summary>
        /// <value></value>
        public int RowIndex{get;private set;}

        /// <summary>
        /// 所属列号
        /// </summary>
        /// <value></value>
        public int CellIndex{get;private set;}

        /// <summary>
        /// 单元格所属行对像
        /// </summary>
        /// <value></value>
        public IRowItem Parent{get;private set;}

        /// <summary>
        /// 单元格值
        /// </summary>
        /// <value></value>
        public override string Value
        {
            get
            {
                return VBDoNetPlugInstance.GetNewBillerInstance().Cell_GetValue(this.m_BillTransfer, (short)(RowIndex+1), this.ColumnName);
            }
            set
            {
                var isNewRowSetValue=(this.Parent as NewBillerRowItem).IsNewRowSetValue;
                if (!isNewRowSetValue & this.Parent.IsNewRow && this.Parent.Parent.Count != 0 && this.RowIndex == this.Parent.Parent.Count)
                {
                    string cellName=this.Parent.Parent.Parent.Column.IndexToName[this.CellIndex];
                    VBDoNetPlugInstance.GetNewBillerInstance().Row_NewRow(this.m_BillTransfer, (short)(this.Parent.Parent.Parent.Index + 2), (short)(this.RowIndex+1), cellName, value);
                }
                else
                {
                    this.m_BillTransfer.SetFieldValue(this.ColumnName, value, this.RowIndex + 1);
                }
                (this.Parent as NewBillerRowItem).IsNewRowSetValue = true;
            }
        }

        #endregion

        #region IItemInfo 成员

        /// <summary>
        /// 内码
        /// </summary>
        /// <value></value>
        public string InterID
        {
            get
            {                
                return Convert.ToString(this.m_BillTransfer.GetFieldValue(this.ColumnName, this.RowIndex + 1, K3ClassEvents.Enu_ValueType.Enu_ValueType_FFLD));
            }
        }

        /// <summary>
        /// 名称称
        /// </summary>
        /// <value></value>
        public string Name
        {
            get
            {                
                return Convert.ToString(this.m_BillTransfer.GetFieldValue(this.ColumnName, this.RowIndex + 1, K3ClassEvents.Enu_ValueType.Enu_ValueType_FDSP));
            }
        }

        /// <summary>
        /// 代码
        /// </summary>
        /// <value></value>
        public string Number
        {
            get
            {
                return Convert.ToString(this.m_BillTransfer.GetFieldValue(this.ColumnName, this.RowIndex + 1, K3ClassEvents.Enu_ValueType.Enu_ValueType_FFND));
            }
        }

        #endregion

        #region ICell 成员


        /// <summary>
        /// 获取列名
        /// </summary>
        /// <returns></returns>
        public string GetColumnName()
        {
            return this.Parent.Parent.Parent.Column.GetName(this.CellIndex);
        }

        #endregion
    }
}
