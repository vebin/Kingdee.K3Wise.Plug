using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public class NewBillerColumn:IColumn
    {
        public NewBillerColumn(IBiller biller, IEntityItem parent)
        {
            this.Biller = biller;
            this.Parent = parent;
            this.m_BillTransfer = this.Biller.M_BillTransfer as K3ClassEvents.BillEvent;
        }

        private K3ClassEvents.BillEvent m_BillTransfer;

        #region IColumn 成员

        /// <summary>
        /// 单据体对像
        /// </summary>
        /// <value></value>
        public IBiller Biller { get; private set; }

        /// <summary>
        /// 单据体列数
        /// </summary>
        /// <value></value>
        public int Count
        {
            get
            {
                return this.m_BillTransfer.BillEntrys[this.Parent.Index+1].get_BOSFields().Count;
            }
        }

        private Dictionary<int, IColumnItem> _columnItemInstanceCatch = new Dictionary<int, IColumnItem>();
        /// <summary>
        /// 单据头项
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        public IColumnItem this[int index]
        {
            get
            {
                if (index < 0 || this.Count-1 < index)
                {
                    throw new IndexOutOfRangeException("下标越界");
                }

                IColumnItem returnValue;
                if(this._columnItemInstanceCatch.ContainsKey(index))
                {
                    returnValue=this._columnItemInstanceCatch[index];
                }
                else
                {
                    returnValue=new NewBillerColumnItem(this.Biller,this,index);
                    this._columnItemInstanceCatch.Add(index,returnValue);
                }
                return returnValue;
            }
        }

        /// <summary>
        /// 单据头项
        /// </summary>
        /// <value></value>
        /// <returns></returns>
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

        private Dictionary<string, int> _nameToIndex;
        /// <summary>
        /// 列名对应索引号缓存
        /// </summary>
        /// <value></value>
        public Dictionary<string, int> NameToIndex
        {
            get
            {
                if (this._nameToIndex == null)
                {
                    this._nameToIndex = new Dictionary<string, int>();
                    int columnCount = this.Count;
                    int entityIndex = this.Parent.Index;
                    string name;
                    for (int index = 1; index <= columnCount; index++)
                    {
                        name = this.m_BillTransfer.BillEntrys[entityIndex+1].get_BOSFields()[index].FKey;
                        if (!string.IsNullOrEmpty(name))
                        {
                            this._nameToIndex.Add(name.ToLower(), index-1);
                        }
                    }
                }
                return this._nameToIndex;
            }
        }

        /// <summary>
        /// 单据体
        /// </summary>
        /// <value></value>
        public IEntityItem Parent { get; private set; }

        private Dictionary<int, string> _indexToName;
        /// <summary>
        /// 索引号对应列名
        /// </summary>
        /// <value></value>
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
            name=name.ToLower();
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
