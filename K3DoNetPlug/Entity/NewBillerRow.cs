using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public class NewBillerRow:IRow
    {
        public NewBillerRow(IBiller biller, IEntityItem parent)
        {
            this.Biller = biller;
            this.Parent = parent;
            this.m_BillTransfer=this.Biller.M_BillTransfer as K3ClassEvents.BillEvent;

        }

        private K3ClassEvents.BillEvent m_BillTransfer;

        #region IRow 成员

        /// <summary>
        /// 单据对像
        /// </summary>
        /// <value></value>
        public IBiller Biller { get; private set; }

        /// <summary>
        /// 单据体对像
        /// </summary>
        /// <value></value>
        public IEntityItem Parent { get; private set; }

        /// <summary>
        /// 单据体单元格对像
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        public ICell this[int rowIndex, int cellIndex]
        {
            get
            {
                //ICell cellInstance = null;
                ////查找实例缓存
                //foreach (ICell cell in this._cellInstanceCatch)
                //{
                //    if (cell.RowIndex == rowIndex && cell.CellIndex == cellIndex)
                //    {
                //        cellInstance = cell;
                //        break;
                //    }
                //}

                ////判断实例缓存是否存在
                //if (cellInstance == null)
                //{
                //    cellInstance = new NewBillerCell(this.Biller, this[rowIndex], rowIndex, cellIndex);
                //    this._cellInstanceCatch.Add(cellInstance);
                //}
                //return cellInstance;
                return this[rowIndex][cellIndex];
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
                name=name.ToLower();
                if (!this.Parent.Column.NameToIndex.ContainsKey(name))
                {
                    throw new IndexOutOfRangeException("下标越界");
                }

                return this[rowIndex, this.Parent.Column.NameToIndex[name]];
            }
        }

        private Dictionary<int, IRowItem> _rowItemCatch=new Dictionary<int,IRowItem>();
        /// <summary>
        /// 单据体行对像
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        public IRowItem this[int index]
        {
            get
            {
                if (index < 0 || this.Count <= index)
                {
                    throw new IndexOutOfRangeException("下标越界");
                }
                IRowItem rowItemInstance = null;
                if (!this._rowItemCatch.ContainsKey(index))
                {
                    rowItemInstance = new NewBillerRowItem(this.Biller, this, index);
                    this._rowItemCatch.Add(index, rowItemInstance);
                }
                else
                {
                    rowItemInstance = this._rowItemCatch[index];
                }
                return rowItemInstance;
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
                int rowCount=m_BillTransfer.Data.GetValue("Page"+(this.Parent.Index+2).ToString()).Size;
                for (int rowIndex = 0; rowIndex < this.Parent.Column.IndexToName.Count; rowIndex++)
                {
                    var keyName=this.Parent.Column.IndexToName[rowIndex];
                    if(keyName=="fentryid2"||keyName=="fid2"||keyName=="findex2")
                    {
                        continue;
                    }
                    if (keyName == "fentryid3" || keyName == "fid3" || keyName == "findex3")
                    {
                        continue;
                    }
                    var columnInfo = this.m_BillTransfer.BillEntrys[this.Parent.Index + 1].get_BOSFields()[rowIndex + 1];


                    if (columnInfo.MustInput)
                    {
                        if (string.IsNullOrEmpty(VBDoNetPlugInstance.GetNewBillerInstance().Cell_GetValue(this.m_BillTransfer, (short)(rowCount), keyName)))
                        {
                            return rowCount-1;
                        }
                        else
                        {
                            return rowCount;
                        }

                    }
                }
                return rowCount;
                //for(int rowIndex=0;rowIndex<2001;rowIndex++)
                //{
                //    try
                //    {
                        //bool allRowCellIsNull = true;
                        //for (var i = 0; i < this.Parent.Column.IndexToName.Count;i++ )
                        //{
                        //    string keyName=this.Parent.Column.IndexToName[i];
                        //    if (keyName!="fentryid2"&&keyName!="fid2"&&keyName!="findex2"
                        //        &&!String.IsNullOrEmpty(VBDoNetPlugInstance.GetNewBillerInstance().Cell_GetValue(this.m_BillTransfer, (short)(rowIndex + 1), keyName)))
                        //    {
                        //        allRowCellIsNull = false;
                        //        break;
                        //    }
                        //}
                        //if (allRowCellIsNull)
                        //{
                        //    return rowIndex;
                        //}
                        //if (String.IsNullOrEmpty(VBDoNetPlugInstance.GetNewBillerInstance().Cell_GetValue(this.m_BillTransfer, (short)(rowIndex + 1), ((BaseBiller)this.Biller).EntityColumnKeyDic[this.Parent.Index])))
                        //{
                        //    return rowIndex;
                        //}
                    //}
                //    catch
                //    {
                //        return rowIndex;
                //    }
                //}
                //throw new IndexOutOfRangeException();
                //int rowCount=this.m_BillTransfer.BillEntrys[this.Parent.Index + 1].GridMaxDataRowNum;

                ///*单据体中无数据时GridMaxDataRowNum的返回值为1，录入第一行数据后GridMaxDataRowNum的值也为1
                // * 以下判断GridMaxDataRowNum返回1时，单据体第一行是否填充数据
                // */
                //if(rowCount==1)
                //{
                //    rowCount = VBDoNetPlugInstance.GetNewBillerInstance().Row_GetCount(this.m_BillTransfer, (short)(this.Parent.Index + 1));
                //}
                //return rowCount;
            }
        }

        public void RemoveAll()
        {
            while(this.Count>0)
            {
                ((BaseBiller)this.Biller).NewBillOjbect.RemoveRow(false, this.Parent.Index+2, 1);
            }
        }

        /// <summary>
        /// 新建数据行
        /// </summary>
        /// <returns></returns>
        public IRowItem NewRow()
        {
            //VBDoNetPlugInstance.GetNewBillerInstance().Row_NewRow(this.m_BillTransfer, (short)(this.Parent.Index + 2), (short)(this.Count+1));
            return new NewBillerRowItem(this.Biller, this, this.Count, true);
        }

        #endregion

        #region IEnumerable<IRowItem> 成员

        public IEnumerator<IRowItem> GetEnumerator()
        {
            for (int index = 0; index < this.Count; index++)
            {
                yield return this[index];
            }
        }

        #endregion

        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            for (int index = 0; index < this.Count; index++)
            {
                yield return this[index];
            }
        }

        #endregion

        #region IRow 成员


        public void Remove(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= this.Count)
            {
                throw new IndexOutOfRangeException("下标越界");
            }
            ((BaseBiller)this.Biller).NewBillOjbect.RemoveRow(false, this.Parent.Index + 2, rowIndex+1);
        }

        #endregion
    }
}
