using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public  class OldBillerToolsButton:IToolsButton
    {
        public OldBillerToolsButton(BaseBiller biller)
        {
            this.CurrentBiller = biller;
            m_BillTransfer = biller.M_BillTransfer as k3BillTransfer.Bill;
        }

        private k3BillTransfer.Bill m_BillTransfer;

        #region IMethod 成员

        public BaseBiller CurrentBiller { get; private set; }

        public void AddToolsButton(string name,string parent)
        {
            this.m_BillTransfer.AddUserMenuItem(name,parent);
        }

        #endregion
    }
}
