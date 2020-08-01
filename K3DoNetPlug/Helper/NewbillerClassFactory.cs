using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public class NewbillerClassFactory:AbstractClassFactory
    {
        private BaseBiller _currentBiller;
        public NewbillerClassFactory(BaseBiller currentBiller)
        {
            this._currentBiller = currentBiller;
        }

        public override TypeBiller GetTypeBillerInstance()
        {
            return TypeBiller.NewBiller;
        }

        public override IHead GetHeadInstance()
        {
            return new NewBillerHead(this._currentBiller);
        }

        public override IEntity GetEntityInstance()
        {
            return new NewBillerEntity(this._currentBiller);
        }

        public override K3ClassEvents.BillEvent GetNewBillOjbcet()
        {
            return this._currentBiller.M_BillTransfer as K3ClassEvents.BillEvent;
        }

        public override k3BillTransfer.Bill GetOldBillOjbect()
        {
            return null;
        }
    }
}
