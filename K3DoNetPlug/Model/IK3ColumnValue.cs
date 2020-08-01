using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K3DoNetPlug.Model
{
    /// <summary>
    /// 自定义基础数据绑定模型接口
    /// </summary>
    public interface IK3ColumnValue
    {
        /// <summary>
        /// 反回自定义获取数据的值
        /// </summary>
        /// <returns></returns>
        string GetValue();
    }
}
