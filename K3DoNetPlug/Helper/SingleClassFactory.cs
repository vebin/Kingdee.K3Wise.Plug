using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public static class SingleClassFactory
    {
        public static AbstractClassFactory GetClassFactory(BaseBiller currentBiller)
        {
            k3BillTransfer.Bill oldBiller = currentBiller.M_BillTransfer as k3BillTransfer.Bill;
            K3ClassEvents.BillEvent newBiller = currentBiller.M_BillTransfer as K3ClassEvents.BillEvent;
            if (oldBiller == null && newBiller == null)
            {
                //转换单据失败，抛出异常
                throw new ExceptionInitBillerFail(currentBiller.M_BillTransfer);
            }

            if (oldBiller == null)
            {
                return new NewbillerClassFactory(currentBiller);
            }
            else
            {
                return new OldBillerClassFactory(currentBiller);
            }
        }
    }
}
