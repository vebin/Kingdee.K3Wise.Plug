using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public class NewBillerHeadItem:IHeadItem
    {
        public NewBillerHeadItem(IBiller biller, IHead parent,int index)
        {
            this.Biller = biller;
            this.Parent = parent;
            this.Index = index;
            this.m_BillTransfer = this.Biller.M_BillTransfer as K3ClassEvents.BillEvent;
        }

        private K3ClassEvents.BillEvent m_BillTransfer;

        private string _headName;
        /// <summary>
        /// 单据头名称
        /// </summary>
        private string HeadName
        {
            get
            {
                if (string.IsNullOrEmpty(this._headName))
                {
                    this._headName = this.Parent.IndexToName[this.Index];
                }
                return this._headName;
            }
        }
        #region IHeadItem 成员

        public IBiller Biller { get; private set; }

        public IHead Parent { get; private set; }

        public int Index { get; private set; }

        public object Value
        {
            get
            {
                return VBDoNetPlugInstance.GetNewBillerInstance().Head_GetValue(this.m_BillTransfer, this.HeadName);
            }
            set
            {
                //单据头忽略row参数
                this.m_BillTransfer.SetFieldValue(this.HeadName, value, -1);
            }
        }

        #endregion

        #region IItemInfo 成员

        public string InterID
        {
            get
            {
                return Convert.ToString(this.m_BillTransfer.GetFieldValue(this.HeadName, (short)(this.Index + 1), K3ClassEvents.Enu_ValueType.Enu_ValueType_FFLD));
            }
        }

        public string Name
        {
            get
            {
                return Convert.ToString(this.m_BillTransfer.GetFieldValue(this.HeadName,(short)(this.Index+1),K3ClassEvents.Enu_ValueType.Enu_ValueType_FDSP));
            }
        }

        public string Number
        {
            get
            {
                return Convert.ToString(this.m_BillTransfer.GetFieldValue(this.HeadName, (short)(this.Index + 1), K3ClassEvents.Enu_ValueType.Enu_ValueType_FFND));
            }
        }

        #endregion
    }
}
