using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K3DoNetPlug.Model
{
    /// <summary>
    /// 默认的数据处理函数，即原进原出
    /// </summary>
    public class K3FieldSetValueFuncDefault:IK3FieldSetValueFunc
    {
        public object ModelToUiValue(object input)
        {
            return input;
        }

        public object UiToModelValue(object input)
        {
            return input;
        }
    }
}
