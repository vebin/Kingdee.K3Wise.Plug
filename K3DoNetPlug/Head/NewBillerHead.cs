using System;
using System.Collections.Generic;
using System.Text;
using K3DoNetPlug.Dal;
using K3DoNetPlug.Core;
using K3DoNetPlug.Helper;

namespace K3DoNetPlug
{
    public class NewBillerHead:IHead
    {
        ModelUtil modelUtil = new ModelUtil();

        public NewBillerHead(IBiller biller)
        {
            this.Biller=biller;
            this.m_BillTransfer=this.Biller.M_BillTransfer as K3ClassEvents.BillEvent;
        }

        private K3ClassEvents.BillEvent m_BillTransfer;

        #region IHead 成员

        public IBiller Biller{get;private set;}

        private Dictionary<string,int> _nameToIndex;
        /// <summary>
        /// 列名对应索引号缓存
        /// </summary>
        /// <value></value>
        public Dictionary<string, int> NameToIndex
        {
            get
            {
                if(this._nameToIndex==null)
                {
                    this._nameToIndex = new Dictionary<string, int>();
                    int countCatch=this.Count;
                    string sKey;
                    for(int index=1;index<=countCatch;index++)
                    {
                        sKey=this.m_BillTransfer.BillHeads[1].get_BOSFields()[index].FKey;
                        if(!string.IsNullOrEmpty(sKey))
                        {
                            this._nameToIndex.Add(sKey.ToLower(), index);
                        };
                    }
                }
                return this._nameToIndex;
            }
        }

        /// <summary>
        /// 单据头数组
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        public IHeadItem this[string name]
        {
            get
            {
                name=name.ToLower();
                if(!NameToIndex.ContainsKey(name))
                {
                    throw new IndexOutOfRangeException("下标越界");
                }

                return this[this.NameToIndex[name]];
            }
        }

        private Dictionary<int,IHeadItem> _headItemInstanceCatch=new Dictionary<int,IHeadItem>();
        /// <summary>
        /// 单据头项索经号
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        public IHeadItem this[int index]
        {
            get
            {
                IHeadItem headItemInstance=null;
                if(this._headItemInstanceCatch.ContainsKey(index))
                {
                    headItemInstance=this._headItemInstanceCatch[index];
                }
                else
                {
                    headItemInstance=new NewBillerHeadItem(this.Biller,this,index);
                    this._headItemInstanceCatch.Add(index,headItemInstance);
                }
                return headItemInstance;
            }
        }

        /// <summary>
        /// 单据头个数
        /// </summary>
        /// <value></value>
        public int Count
        {
            get
            {
                return this.m_BillTransfer.BillHeads[1].get_BOSFields().Count;
            }
        }


        private Dictionary<int, string> _indexToName;
        /// <summary>
        /// 索引号对应列名
        /// </summary>
        /// <value></value>
        public Dictionary<int, string> IndexToName
        {
            get
            {
                if (_indexToName == null)
                {
                    this._indexToName = new Dictionary<int, string>();
                    foreach (KeyValuePair<string, int> item in this.NameToIndex)
                    {
                        this._indexToName.Add(item.Value, item.Key);
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
