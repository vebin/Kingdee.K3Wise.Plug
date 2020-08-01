using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K3DoNetPlug.Model
{
    public enum K3FieldTypeEnum
    {
        /// <summary>
        /// 双向绑定
        /// </summary>
        All=0,

        /// <summary>
        /// 绑定Ui值给Model
        /// </summary>
        UiToModel=1,

        /// <summary>
        /// 绑定Model值给Ui
        /// </summary>
        ModelToUi=2,

        /// <summary>
        /// Ui基础资料的Value值给Model
        /// </summary>
        Db_UiValueToModel=3,

        /// <summary>
        /// Ui基础资料的Name值给Model
        /// </summary>
        Db_UiNameToModel=4,

        /// <summary>
        /// Ui基础料料的Number值给Model
        /// </summary>
        Db_UiNumberToModel = 5,

        /// <summary>
        /// Model的为基础资料的名称，需要自动查询数据库获取到Number后再给Ui赋值
        /// </summary>
        Db_ModelNameToUi=6,

        /// <summary>
        /// Model基础资料的Number值给Ui
        /// </summary>
        Db_ModelNumberToUi=7,

        /// <summary>
        /// 双向都不绑定
        /// </summary>
        Nothing=8
    }
}
