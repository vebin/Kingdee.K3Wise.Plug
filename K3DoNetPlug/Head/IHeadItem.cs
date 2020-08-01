using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    /// <summary>
    /// 单据头项
    /// </summary>
    public interface IHeadItem:IItemInfo
    {
        /// <summary>
        /// 单据对像
        /// </summary>
        IBiller Biller { get; }

        /// <summary>
        /// 所有单据头对像
        /// </summary>
        IHead Parent { get; }

        /// <summary>
        /// 索引号
        /// </summary>
        int Index { get; }

        /// <summary>
        /// 单据头值
        /// </summary>
        object Value { get; set; }
    }
}
