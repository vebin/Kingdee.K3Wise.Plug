using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public class ExceptionInitBillerFail:Exception
    {
        public ExceptionInitBillerFail(object biller)
        {
            if (biller as k3BillTransfer.Bill!= null)
            {
                this.CurrentBillerType = TypeBiller.OldBiller;
                return;
            }
        }

        public TypeBiller? CurrentBillerType { get; set; }

        public new string Message
        {
            get
            {
                return "初始人单据失败";
            }
        }
    }
}
