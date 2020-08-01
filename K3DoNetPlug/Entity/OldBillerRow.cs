using System;
using System.Collections.Generic;
using System.Text;
using K3DoNetPlug.Helper;

namespace K3DoNetPlug
{
    public class OldBillerRow:IRow
    {
        public OldBillerRow(IBiller biller,IEntityItem parent)
        {
            this.Biller = biller;
            this.m_BillTransfer = biller.M_BillTransfer as k3BillTransfer.Bill;
            this.Parent = parent;
            if (!this.Parent.Column.NameToIndex.ContainsKey("fitemid"))
            {
                throw new Exception("本张单据不包含FItemId字段，确保您的单据对像覆盖了EntityColumnKey字段");
            }
        }

        private k3BillTransfer.Bill m_BillTransfer { get; set; }

        #region IRows 成员

        /// <summary>
        /// 单据对像
        /// </summary>
        /// <value></value>
        public IBiller Biller { get; private set; }

        //private List<ICell> _cellInstanceCatch=new List<ICell>();
        /// <summary>
        /// 单据体单元格对像
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        public ICell this[int rowIndex, int cellIndex]
        {
            get
            {
                //ICell returnValue=null;
                //foreach(ICell item in this._cellInstanceCatch)
                //{
                //    if (item.RowIndex == rowIndex && item.CellIndex == cellIndex)
                //    {
                //        returnValue = item;
                //        break;
                //    }
                //}

                //if (returnValue == null)
                //{
                //    returnValue = new OldBillerCell(this.Biller, this[rowIndex], rowIndex, cellIndex);
                //    this._cellInstanceCatch.Add(returnValue);
                //}

                //return returnValue;
                return this[rowIndex][cellIndex];
            }
        }

        private Dictionary<int, IRowItem> _rowInstanceCatch=new Dictionary<int,IRowItem>();
        /// <summary>
        /// 单据体行对像
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        public IRowItem this[int index]
        {
            get
            {
                if (index < 0 || this.Count < index)
                {
                    throw new IndexOutOfRangeException("下标越界");
                }

                IRowItem returnValue = null;
                if (!this._rowInstanceCatch.ContainsKey(index))
                {
                    returnValue=new OldBillerRowItem(this.Biller,this, index); 
                    this._rowInstanceCatch.Add(index,returnValue);
                }
                else
                {
                    returnValue=this._rowInstanceCatch[index];
                }
                return returnValue;
            }
        }

        private int? _columnKeyIndexCatch;

        private int columnKeyIndex
        {
            get
            {
                if (!this._columnKeyIndexCatch.HasValue)
                {
                    this._columnKeyIndexCatch = this.Parent.Column.NameToIndex[((BaseBiller)this.Biller).EntityColumnKeyDic[0].ToLower()];
                }
                return this._columnKeyIndexCatch.Value;
            }
        }
        /// <summary>
        /// 单据体数据行数
        /// </summary>
        /// <value></value>
        public int Count
        {
            get
            {
                //K3单据体最多技持2000条分录
                //for (int rowIndex = 0; rowIndex < 2001; rowIndex++)
                //{
                //    if (string.IsNullOrEmpty(this.m_BillTransfer.GetGridText(rowIndex + 1, this.columnKeyIndex + 1)))
                //    {
                //        return rowIndex;
                //    }
                //}
                //throw new IndexOutOfRangeException("获取单据最大数据行时出错，确保您的单据对像覆盖了EntityColumnKey字段");

                var maxRow=Convert.ToInt32(VBDoNetPlugInstance.GetOldBillerInstance().Row_GetCount(m_BillTransfer));

                if (string.IsNullOrEmpty(this.m_BillTransfer.GetGridText(maxRow, this.columnKeyIndex + 1)))
                {
                    var result= maxRow-2;
                    if (result < 0)
                    {
                        for (int rowIndex = 0; rowIndex < 2001; rowIndex++)
                        {
                            if (string.IsNullOrEmpty(this.m_BillTransfer.GetGridText(rowIndex + 1, this.columnKeyIndex + 1)))
                            {
                                return rowIndex;
                            }
                        }
                        throw new IndexOutOfRangeException("获取单据最大数据行时出错，确保您的单据对像覆盖了EntityColumnKey字段");
                    }
                    return maxRow;
                }

                return maxRow;
            }
        }

        /// <summary>
        /// 单据体单元格对像
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        public ICell this[int rowIndex, string name]
        {
            get
            {
                name = name.ToLower();
                if (!this.Parent.Column.NameToIndex.ContainsKey(name))
                {
                    throw new IndexOutOfRangeException("下标越界");
                }
                return this[rowIndex, this.Parent.Column.NameToIndex[name]];
            }
        }

        /// <summary>
        /// 单据体对像
        /// </summary>
        /// <value></value>
        public IEntityItem Parent { get; private set; }

        /// <summary>
        /// 新建数据行
        /// </summary>
        /// <returns></returns>
        public IRowItem NewRow()
        {
            IRowItem returnValue;
            if (this.Count == 0)
            {
                if (string.IsNullOrEmpty(this[0][((BaseBiller)this.Biller).EntityColumnKeyDic[0].ToLower()].Value))
                {
                    return this[0];
                }

            }
            if (VBDoNetPlugInstance.GetOldBillerInstance().Row_GetIsNeedNewRow(this.m_BillTransfer))
            {
                VBDoNetPlugInstance.GetOldBillerInstance().Row_NewRow(this.m_BillTransfer);
            }
            returnValue = new OldBillerRowItem(this.Biller, this, this.Count,true);
            return returnValue;
        }

        #endregion


        #region IEnumerable<IRow> 成员

        IEnumerator<IRowItem> IEnumerable<IRowItem>.GetEnumerator()
        {
            int rowsCount = this.Count;
            for (int index = 0; index < rowsCount; index++)
            {
                yield return this[index];
            }
        }

        #endregion

        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            int rowsCount = this.Count;
            for (int index = 0; index < rowsCount; index++)
            {
                yield return this[index];
            }
        }

        #endregion

        #region IRow 成员


        //public void RemoveAll()
        //{
        //    while (this.Count > 0)
        //    {
        //        VBDoNetPlugInstance.GetOldBillerInstance().Row_Del(this.m_BillTransfer, 1);
        //    }
        //}

        //#endregion

        //#region IRow 成员


        //public void Remove(int rowIndex)
        //{
        //    if (rowIndex < 0 || rowIndex >= this.Count)
        //    {
        //        throw new IndexOutOfRangeException("下标越界");
        //    }
        //    VBDoNetPlugInstance.GetOldBillerInstance().Row_Del(this.m_BillTransfer, rowIndex+1);
        //}

        #endregion
    }
}
