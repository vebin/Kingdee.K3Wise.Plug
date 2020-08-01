using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public class OldBillHeadItem:IHeadItem
    {
        public OldBillHeadItem(IBiller biller,IHead parent,int index)
        {
            this.Biller = biller;
            this.m_BillTransfer = this.Biller.M_BillTransfer as k3BillTransfer.Bill;
            this.Parent = parent;
            this.Index = index;
        }
        
        private k3BillTransfer.Bill m_BillTransfer { get; set; }


        #region IHeadItem 成员

        public int Index { get; private set; }

        /// <summary>
        /// 内码
        /// </summary>
        /// <value></value>
        public string InterID
        {
            get
            {
                return Convert.ToString(VBDoNetPlugInstance.GetOldBillerInstance().Head_GetInterID(this.m_BillTransfer, (short)Index));
            }
        }

        /// <summary>
        /// 名称称
        /// </summary>
        /// <value></value>
        public string Name
        {
            get
            {
                return Convert.ToString(VBDoNetPlugInstance.GetOldBillerInstance().Head_GetName(this.m_BillTransfer, (short)Index));
            }
        }

        /// <summary>
        /// 代码
        /// </summary>
        /// <value></value>
        public string Number
        {
            get
            {
                return Convert.ToString(VBDoNetPlugInstance.GetOldBillerInstance().Head_GetNumber(this.m_BillTransfer, (short)Index));
            }
        }

        /// <summary>
        /// 单据头值
        /// </summary>
        /// <value></value>
        public object Value
        {
            get
            {
                return this.m_BillTransfer.GetHeadText(this.Index);
            }
            set
            {
                this.m_BillTransfer.SetHead(this.Index, value, 0, "");
            }
        }

        /// <summary>
        /// 单据对像
        /// </summary>
        /// <value></value>
        public IBiller Biller { get; private set; }

        /// <summary>
        /// 所有单据头对像
        /// </summary>
        /// <value></value>
        public IHead Parent { get; private set; }

        #endregion
    }
}
