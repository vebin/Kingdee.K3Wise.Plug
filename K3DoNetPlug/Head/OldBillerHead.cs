using System;
using System.Collections.Generic;
using System.Text;
using K3DoNetPlug.Helper;

namespace K3DoNetPlug
{
    public class OldBillerHead:IHead
    {
        ModelUtil modelUtil = new ModelUtil();

        /// <summary>
        /// 老单单据头
        /// </summary>
        /// <contractEntity name="biller"></contractEntity>
        public OldBillerHead(BaseBiller biller)
        {
            this.Biller = biller;
            this.m_BillTransfer = this.Biller.M_BillTransfer as k3BillTransfer.Bill;
        }

        /// <summary>
        /// 老单单据对像
        /// </summary>
        private k3BillTransfer.Bill m_BillTransfer;
        #region IBiller 成员

        /// <summary>
        /// 单据头数组
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        public IHeadItem this[string name]
        {
            get
            {
                name = name.ToLower();
                if(!this.NameToIndex.ContainsKey(name))
                {
                    throw new IndexOutOfRangeException("头据头下标越界");
                }
                return this[this.NameToIndex[name]];
             }
        }

        private Dictionary<int, IHeadItem> _headInstanceCatch=new Dictionary<int,IHeadItem>();
        /// <summary>
        /// 单据头项索引号
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        public IHeadItem this[int index]
        {
            get
            {
                int maxIndex = Convert.ToInt32(VBDoNetPlugInstance.GetOldBillerInstance().Head_GetMaxIndex(this.m_BillTransfer));
                IHeadItem returnValue=null;
                //判断下标是否越界
                if (index < 0 || index > maxIndex)
                {
                    throw new IndexOutOfRangeException();
                }
                if (this._headInstanceCatch.ContainsKey(index))
                {
                    returnValue = this._headInstanceCatch[index];
                }
                else
                {
                    returnValue=new OldBillHeadItem(this.Biller,this,index);
                    this._headInstanceCatch.Add(index,returnValue);
                }

                return returnValue;
            }
        }

        /// <summary>
        /// 单据头索引长度
        /// </summary>
        /// <value></value>
        public int Count 
        {
            get
            {
                return Convert.ToInt32(VBDoNetPlugInstance.GetOldBillerInstance().Head_GetMaxIndex(this.m_BillTransfer));
            }
        }


        private Dictionary<string, int> _nameToIndexCatch;

        /// <summary>
        /// 列名对应索引号缓存
        /// </summary>
        /// <value></value>
        public Dictionary<string, int> NameToIndex
        {
            get
            {
                if (_nameToIndexCatch == null)
                {
                    this._nameToIndexCatch = new Dictionary<string, int>();
                    string headFieldName;
                    for (int index = 0; index < this.Count; index++)
                    {
                        headFieldName = VBDoNetPlugInstance.GetOldBillerInstance().Head_GetFieldName(this.m_BillTransfer, (short)index);
                        if(!string.IsNullOrEmpty(headFieldName))
                        {
                            this._nameToIndexCatch.Add(headFieldName.ToLower(),index);
                        }
                    }
                }
                return this._nameToIndexCatch;
            }
        }

        #endregion

        #region IHead 成员

        /// <summary>
        /// 单据对像
        /// </summary>
        /// <value></value>
        public IBiller Biller { get; private set; }

        #endregion

        #region IHead 成员


        private Dictionary<int, string> _indexToName;
        /// <summary>
        /// 索引号对应列名
        /// </summary>
        /// <value></value>
        public Dictionary<int, string> IndexToName
        {
            get
            {
                if(this._indexToName==null)
                {
                    this._indexToName=new Dictionary<int,string>();
                    foreach(KeyValuePair<string,int> item in this.NameToIndex)
                    {
                        this._indexToName.Add(item.Value,item.Key);
                    }
                }
                return this._indexToName;
            }
        }

        #endregion


        public void SetUiByModel(object model)
        {
            modelUtil.SetModelToHead(this, model);
        }


        public T GetModelByUi<T>() where T : class
        {
            return modelUtil.SetHeadToModel<T>(this);
        }
    }
}
