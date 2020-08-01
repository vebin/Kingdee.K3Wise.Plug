using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K3DoNetPlug.Model
{
    public interface IK3FieldSetValueFunc
    {
        /// <summary>
        /// 模型赋值给UI
        /// </summary>
        /// <returns></returns>
        object ModelToUiValue(object input);

        /// <summary>
        /// Ui赋值给模型
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        object UiToModelValue(object input);
    }
}
