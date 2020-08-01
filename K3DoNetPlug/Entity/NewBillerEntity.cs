using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public class NewBillerEntity:IEntity
    {
        public NewBillerEntity(IBiller biller)
        {
            this.Biller = biller;
            this.m_BillTransfer = biller.M_BillTransfer as K3ClassEvents.BillEvent;
        }

        private K3ClassEvents.BillEvent m_BillTransfer;

        #region IEntity 成员

        /// <summary>
        /// 单据对像
        /// </summary>
        /// <value></value>
        public IBiller Biller { get; private set; }

        private Dictionary<int, IEntityItem> _entityInstanceCatch=new Dictionary<int,IEntityItem>();
        /// <summary>
        /// 单据体
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        public IEntityItem this[int index]
        {
            get
            {
                if (index < 0 || this.Count <= index)
                {
                    throw new IndexOutOfRangeException("下标越界");
                }

                IEntityItem returnValue;
                if(this._entityInstanceCatch.ContainsKey(index))
                {
                    returnValue=this._entityInstanceCatch[index];
                }
                else
                {
                    returnValue=new NewBillerEntityItem(this.Biller,this,index);
                    this._entityInstanceCatch.Add(index,returnValue);
                }
                return returnValue;
            }
        }

        /// <summary>
        /// 单据体数
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return m_BillTransfer.BillEntrys.Count;
            }
        }

        #endregion
    }
}
