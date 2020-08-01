using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    class OldBillerColumnItem:IColumnItem
    {
        public OldBillerColumnItem(IBiller biller, IColumn parent, int index)
        {
            this.Biller = biller;
            this.Parent = parent;
            this.Index = index;
            this.m_BillTransfer = biller.M_BillTransfer as k3BillTransfer.Bill;
        }

        private k3BillTransfer.Bill m_BillTransfer;

        #region IColumn 成员

        public string Name
        {
            get
            {
                return this.Parent.IndexToName[this.Index];
            }
        }

        public int Index { get; private set; }

        public string HeadText
        {
            get
            {
                return this.m_BillTransfer.GetGridText(0, this.Index);
            }
        }

        public IColumn Parent { get; private set; }

        public IBiller Biller { get; private set; }

        #endregion
    }
}
