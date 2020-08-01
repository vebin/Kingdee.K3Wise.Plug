using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public class NewBillerToolsButton:IToolsButton
    {
        public NewBillerToolsButton(BaseBiller biller, K3ClassEvents.MenuBar oMenuBar)
        {
            this.CurrentBiller = biller;
            this.m_BillTransfer = biller.M_BillTransfer as K3ClassEvents.BillEvent;
            this.OMenuBar = oMenuBar;
        }

        private K3ClassEvents.BillEvent m_BillTransfer;
        private K3ClassEvents.MenuBar OMenuBar;
        #region IMethod 成员

        public BaseBiller CurrentBiller { get; private set; }

        public void AddToolsButton(string name, string parent)
        {
            K3ClassEvents.BOSTool oTool=null;
            K3ClassEvents.BOSBand oBand=null;

            oTool = this.OMenuBar.BOSTools.Add(name);
            oTool.Caption = name;
            oTool.ShortcutKey = 0;
            oTool.Visible = true;
            oTool.Enabled = true;
            oTool.BeginGroup = false;
            for (int index = 1; index <= this.OMenuBar.BOSBands.Count; index++)
            {
                if (parent == this.OMenuBar.BOSBands[index].Caption)
                {
                    oBand = this.OMenuBar.BOSBands[index];
                }
            }
            if (oBand == null)
            {
                oBand = this.OMenuBar.BOSBands[this.OMenuBar.BOSBands.Count];
            }
            oBand.BOSTools.InsertAfter(-1, ref oTool);
        }
        #endregion
    }
}
