using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K3DoNetPlug
{
    public interface IBiller
    {
        IEntity Entity { get; }

        IHead Head{get;}

        object M_BillTransfer { get; }
    }
}
