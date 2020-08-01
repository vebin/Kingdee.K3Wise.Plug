using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public class OldBillerCell : BaseCell,ICell
    {
        public OldBillerCell(IBiller biller, IRowItem parent, int rowIndex, int cellIndex)
        {
            this.Biller = biller;
            this.RowIndex = rowIndex;
            this.CellIndex = cellIndex;
            this.m_BillTransfer = this.Biller.M_BillTransfer as k3BillTransfer.Bill;
            this.Parent = parent;
        }

        /// <summary>
        /// 操作行索引号
        /// </summary>
        public int RowIndex { get;private set; }

        /// <summary>
        /// 操作列索引号
        /// </summary>
        public int CellIndex { get;private set; }

        /// <summary>
        /// 单据对像
        /// </summary>
        private k3BillTransfer.Bill m_BillTransfer;

        /// <summary>
        /// 校验Get操作索引范围
        /// </summary>
        private void VerifyGetIndex()
        {
            int rowsCount=this.Parent.Parent.Count;
            int cellsCount=this.Parent.Parent.Parent.Column.Count;
            if (this.RowIndex < 0 || (this.Parent.IsNewRow&&rowsCount<this.RowIndex)||(!this.Parent.IsNewRow&&rowsCount < this.RowIndex))
            {
                throw new IndexOutOfRangeException("行下标越界");
            }
            if (this.CellIndex < 0 || cellsCount  < this.CellIndex)
            {
                throw new IndexOutOfRangeException("列下载越界");
            }
        }

        ///// <summary>
        ///// 校验Set操作索引范围
        ///// </summary>
        //private void VerifySetIndex()
        //{
        //    int rowsCount = this.Parent.Parent.Count;
        //    int cellsCount = this.Parent.Parent.Parent.Columns.Count;
        //    if (RowIndex < 0 || RowIndex > rowsCount)
        //    {
        //        throw new IndexOutOfRangeException("下标越界，可接受下标范围，0-rowCount");
        //    }
        //    //判断是否为新增行
        //    if (RowIndex == rowsCount)
        //    {
        //        VBDoNetPlugInstance.GetOldBillerInstance().InsertRow(this.m_BillTransfer);
        //    }
        //}

        #region ICell 成员

        public IBiller Biller { get; private set; }

        /// <summary>
        /// 单元格值
        /// </summary>
        /// <value>The value.</value>
        public override string Value
        {
            get
            {
                VerifyGetIndex();
                return this.m_BillTransfer.GetGridText(this.RowIndex+1, this.CellIndex+1);
            }
            set
            {
                this.VerifyGetIndex();
                this.m_BillTransfer.SetGridText(this.RowIndex+1, this.CellIndex+1, value, 0, "");            
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
                this.VerifyGetIndex();
                return Convert.ToString(VBDoNetPlugInstance.GetOldBillerInstance().Cell_GetInterID(this.m_BillTransfer, this.RowIndex + 1, this.CellIndex+1));
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
                this.VerifyGetIndex();
                return Convert.ToString(VBDoNetPlugInstance.GetOldBillerInstance().Cell_GetName(this.m_BillTransfer, this.RowIndex + 1, this.CellIndex+1));
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
                this.VerifyGetIndex();
                return Convert.ToString(VBDoNetPlugInstance.GetOldBillerInstance().Cell_GetNumber(this.m_BillTransfer, this.RowIndex + 1, this.CellIndex+1));
            }
        }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public IRowItem Parent { get; private set; }

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
