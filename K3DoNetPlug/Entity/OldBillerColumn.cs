using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public class OldBillerColumn:IColumn
    {

        public OldBillerColumn(IBiller biller, IEntityItem parent)
        {
            this.Biller=biller;
            this.m_BillTransfer = biller.M_BillTransfer as k3BillTransfer.Bill;
            this.Parent = parent;
        }

        /// <summary>
        /// 单据体对象
        /// </summary>
        private k3BillTransfer.Bill m_BillTransfer { get; set; }

        #region IColumn 成员

        /// <summary>
        /// 单据体列数
        /// </summary>
        /// <value></value>
        public int Count
        {
            get
            {
                return Convert.ToInt32(VBDoNetPlugInstance.GetOldBillerInstance().Column_GetCount(this.m_BillTransfer));
            }
        }

        /// <summary>
        /// 缓存
        /// </summary>
        private Dictionary<string, int> _nameToIndexCatch;

        /// <summary>
        /// 列名对应索引号缓存
        /// </summary>
        /// <value></value>
        public Dictionary<string, int> NameToIndex
        {
            get
            {
                if (this._nameToIndexCatch == null)
                {
                    
                    this._nameToIndexCatch = new Dictionary<string, int>();
                    int maxColumnsIndex = Convert.ToInt32(VBDoNetPlugInstance.GetOldBillerInstance().Column_GetCount(this.m_BillTransfer));
                    //获取缓存信息
                    for (short index = 1; index <= maxColumnsIndex; index++)
                    {
                        string name = VBDoNetPlugInstance.GetOldBillerInstance().Column_GetName(this.m_BillTransfer, index);
                        if (!string.IsNullOrEmpty(name))
                        {
                            this._nameToIndexCatch.Add(name.ToLower(), index-1);
                        }
                    }
                }
                return this._nameToIndexCatch;
            }
        }

        /// <summary>
        /// 单据体对像
        /// </summary>
        /// <value></value>
        public IBiller Biller { get; private set; }

        private Dictionary<int, IColumnItem> _columnItemInstanceCatch=new Dictionary<int,IColumnItem>();
        public IColumnItem this[int index]
        {
            get
            {
                if (index < 0 || this.Count < index)
                {
                    throw new IndexOutOfRangeException("列下标越界");
                }

                IColumnItem returnValue;
                if (this._columnItemInstanceCatch.ContainsKey(index))
                {
                    returnValue = this._columnItemInstanceCatch[index];
                }
                else
                {
                    returnValue = new OldBillerColumnItem(this.Biller, this, index);
                    this._columnItemInstanceCatch.Add(index, returnValue);
                }
                return returnValue;
            }
        }

        public IColumnItem this[string name]
        {
            get
            {
                name = name.ToLower();
                if (!this.NameToIndex.ContainsKey(name))
                {
                    throw new IndexOutOfRangeException("下标越界");
                }
                return this[this.NameToIndex[name]];
            }
        }

        /// <summary>
        /// 单据体
        /// </summary>
        /// <value></value>
        public IEntityItem Parent { get; private set; }

        #endregion

        #region IColumn 成员


        private Dictionary<int, string> _indexToName;
        public Dictionary<int, string> IndexToName
        {
            get
            {
                if (this._indexToName == null)
                {
                    this._indexToName = new Dictionary<int, string>();
                    foreach (KeyValuePair<string, int> nameToIndex in this.NameToIndex)
                    {
                        this._indexToName.Add(nameToIndex.Value, nameToIndex.Key);
                    }
                }
                return this._indexToName;
            }
        }

        #endregion

        #region IColumn 成员


        /// <summary>
        /// 根据名称获取索引
        /// </summary>
        /// <contractEntity name="name"></contractEntity>
        /// <returns></returns>
        public int GetIndex(string name)
        {
            name = name.ToLower();
            if (!this.NameToIndex.ContainsKey(name))
            {
                return -1;
            }
            return this.NameToIndex[name];
        }

        /// <summary>
        /// 根据索引获取列名
        /// </summary>
        /// <contractEntity name="index"></contractEntity>
        /// <returns></returns>
        public string GetName(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            return this.IndexToName[index];
        }

        #endregion
    }
}
