using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public abstract class AbstractClassFactory
    {
        public abstract TypeBiller GetTypeBillerInstance();
        public abstract IHead GetHeadInstance();
        public abstract IEntity GetEntityInstance();
        public abstract k3BillTransfer.Bill GetOldBillOjbect();
        public abstract K3ClassEvents.BillEvent GetNewBillOjbcet();
    }
}
