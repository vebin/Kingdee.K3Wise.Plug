using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public interface IItemInfo
    {
        /// <summary>
        /// 内码
        /// </summary>
        string InterID { get; }

        /// <summary>
        /// 名称称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 代码
        /// </summary>
        string Number { get; }
    }
}
