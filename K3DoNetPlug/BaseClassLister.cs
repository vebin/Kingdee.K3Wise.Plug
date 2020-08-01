using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K3ClassEvents;

namespace K3DoNetPlug
{
    public class BaseClassLister
    {
        public BaseClassEvent BaseLister { get; private set; }

        private DBUnit _DBUnitInstance;
        public DBUnit DBUnitInstance
        {
            get
            {
                if (_DBUnitInstance == null)
                {
                    this._DBUnitInstance = new DBUnit(this);
                }
                return this._DBUnitInstance;
            }
        }
        public void Show(object m_BillTransfer)
        {
            this.BaseLister = m_BillTransfer as BaseClassEvent;
            DBUnit.InitGlobalConnString(this.DBUnitInstance.ConnString);
            Initialize();
        }

        public virtual void Initialize()
        {

        }
    }
}
