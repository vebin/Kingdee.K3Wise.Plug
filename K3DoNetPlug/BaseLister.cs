using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K3DoNetPlug
{
    public class BaseLister
    {
        public K3ClassEvents.ListEvents Lister { get; private set; }

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
            this.Lister = m_BillTransfer as K3ClassEvents.ListEvents;
            DBUnit.InitGlobalConnString(this.DBUnitInstance.ConnString);
            Initialize();
        }

        public virtual void Initialize()
        {
 	        
        }
    }
}
