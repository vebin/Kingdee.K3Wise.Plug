using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K3DoNetPlug.Core
{
    public class CoreException:Exception
    {
        public CoreException() { }

        public CoreException(string message) : base(message) { }
    }
}
