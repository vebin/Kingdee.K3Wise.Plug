using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public class OldBillerClassFactory:AbstractClassFactory
    {
        private BaseBiller _currentBiller;

        public OldBillerClassFactory(BaseBiller currentBiller)
        {
            this._currentBiller = currentBiller;
        }

        public override TypeBiller GetTypeBillerInstance()
        {
            return TypeBiller.OldBiller;
        }

        public override IHead GetHeadInstance()
        {
            return new OldBillerHead(this._currentBiller);
        }

        public override IEntity GetEntityInstance()
        {
            return new OldBillerEntity(this._currentBiller);
        }

        public override K3ClassEvents.BillEvent GetNewBillOjbcet()
        {
            return null;
        }

        public override k3BillTransfer.Bill GetOldBillOjbect()
        {
            return this._currentBiller.M_BillTransfer as k3BillTransfer.Bill;
        }
    }
}
