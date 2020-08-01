using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K3DoNetPlug.Model
{
    public class K3ColumnNotSetUiAttribute : K3ColumnAttribute
    {
        public K3ColumnNotSetUiAttribute(string name)
            :base(name)
        {
        }
    }
}
