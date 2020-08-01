using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    class NewBillerRowItem:IRowItem
    {
        public NewBillerRowItem(IBiller biller, IRow parent, int index)
        {
            this.init(biller, parent, index);
        }

        public NewBillerRowItem(IBiller biller, IRow parent, int index, bool isNewRow)
        {
            this.init(biller, parent, index);
            this.IsNewRow = true;
        }

        /// <summary>
        /// 初始化变量
        /// </summary>
        /// <contractEntity name="biller"></contractEntity>
        /// <contractEntity name="parent"></contractEntity>
        /// <contractEntity name="index"></contractEntity>
        private void init(IBiller biller, IRow parent, int index)
        {
            this.Biller = biller;
            this.Parent = parent;
            this.Index = index;
            this.m_BillTransfer = this.Biller.M_BillTransfer as K3ClassEvents.BillEvent;
        }

        private K3ClassEvents.BillEvent m_BillTransfer;

        #region IRowItem 成员

        /// <summary>
        /// 单据对像
        /// </summary>
        /// <value></value>
        public IBiller Biller { get; private set; }

        /// <summary>
        /// 所属单据所有行号
        /// </summary>
        /// <value></value>
        public int Index { get; private set; }

        /// <summary>
        /// 单据行对像
        /// </summary>
        /// <value></value>
        public IRow Parent { get; private set; }

        private Dictionary<int, ICell> _cellInstanceCatch=new Dictionary<int,ICell>();
        /// <summary>
        /// Gets the <see cref="K3DoNetPlug.ICell"/> with the specified cell index.
        /// </summary>
        /// <value></value>
        public ICell this[int cellIndex]
        {
            get
            {
                ICell cellInstance;
                if (this._cellInstanceCatch.ContainsKey(cellIndex))
                {
                    cellInstance = this._cellInstanceCatch[cellIndex];
                }
                else
                {
                    cellInstance = new NewBillerCell(this.Biller, this, this.Index, cellIndex);
                    this._cellInstanceCatch.Add(cellIndex, cellInstance);
                }
                return cellInstance;

            }
        }

        /// <summary>
        /// 单元格对像
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        public ICell this[string name]
        {
            get
            {
                name=name.ToLower();
                if (!this.Parent.Parent.Column.NameToIndex.ContainsKey(name))
                {
                    throw new IndexOutOfRangeException("下标越界");
                }

                return this[this.Parent.Parent.Column.NameToIndex[name]];
            }
        }

        /// <summary>
        /// 是否是新增行
        /// </summary>
        /// <value></value>
        public bool IsNewRow { get; private set; }

        /// <summary>
        ///  新增行是否进行赋值
        /// </summary>
        public bool IsNewRowSetValue { get;internal set; }

        #endregion

        #region IEnumerable<ICell> 成员

        public IEnumerator<ICell> GetEnumerator()
        {
            int columnCount=this.Parent.Parent.Column.Count;
            for (int index = 0; index < columnCount; index++)
            {
                yield return this[index];
            }
        }

        #endregion

        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            int columnCount = this.Parent.Parent.Column.Count;
            for (int index = 0; index < columnCount; index++)
            {
                yield return this[index];
            }
        }

        #endregion
    }
}
