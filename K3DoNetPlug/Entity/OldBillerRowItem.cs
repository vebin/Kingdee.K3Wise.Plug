using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public class OldBillerRowItem:IRowItem
    {
        public OldBillerRowItem(IBiller biller,IRow parent, int rowIndex)
        {
            this.Init(biller,parent,rowIndex);
        }

        public OldBillerRowItem(IBiller biller, IRow parent, int rowIndex, bool isNewRow)
        {
            this.Init(biller, parent, rowIndex);
            this.IsNewRow = true;
        }

        private void Init(IBiller biller, IRow parent, int rowIndex)
        {        
            this.Biller=biller;
            this.Index=rowIndex;
            this.m_BillTransfer = this.Biller.M_BillTransfer as k3BillTransfer.Bill;
            this.Parent = parent;
        }

        private k3BillTransfer.Bill m_BillTransfer { get; set; }


        private bool _isNewRow=false;
        /// <summary>
        /// 标记是否为新增行
        /// </summary>
        public bool IsNewRow
        {
            get
            {
                return this._isNewRow;
            }
            private set
            {
                this._isNewRow = value;
            }
        }

        #region IRow 成员

        /// <summary>
        /// 单据对像
        /// </summary>
        /// <value></value>
        public IBiller Biller { get; private set; }

        /// <summary>
        /// 单元格对像
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        public ICell this[int cellIndex]
        {
            get
            {
                return new OldBillerCell(this.Biller,this ,this.Index, cellIndex);
            }
        }

        /// <summary>
        /// 单据行对像
        /// </summary>
        /// <value></value>
        public IRow Parent { get; private set; }

        /// <summary>
        /// 单元格对像
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        public ICell this[string name]
        {
            get
            {
                name = name.ToLower();
                if (!this.Parent.Parent.Column.NameToIndex.ContainsKey(name))
                {
                    throw new IndexOutOfRangeException("列下标越界");
                }
                return this[this.Parent.Parent.Column.NameToIndex[name]];
            }
        }


        /// <summary>
        /// 所属单据所在行号
        /// </summary>
        /// <value></value>
        public int Index { get; set; }

        #endregion


        #region IEnumerable<ICell> 成员

        public IEnumerator<ICell> GetEnumerator()
        {
            int cellCount = this.Parent.Parent.Column.Count;
            for (int index = 0; index < cellCount; index++)
            {
                yield return this[index];
            }
        }

        #endregion

        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            int cellCount = this.Parent.Parent.Column.Count;
            for (int index = 0; index < cellCount; index++)
            {
                yield return this[index];
            }
        }

        #endregion
    }
}
