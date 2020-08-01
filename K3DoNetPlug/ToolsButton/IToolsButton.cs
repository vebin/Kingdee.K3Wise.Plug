using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public interface IToolsButton
    {
        BaseBiller CurrentBiller { get; }
        void AddToolsButton(string name, string parent);
    }
}
