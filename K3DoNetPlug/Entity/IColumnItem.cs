using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public interface IColumnItem
    {
        /// <summary>
        /// 单据对像
        /// </summary>
        IBiller Biller { get; }

        /// <summary>
        /// Column对像
        /// </summary>
        IColumn Parent { get; }

        /// <summary>
        /// 列名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 列索引号
        /// </summary>
        int Index { get; }

        /// <summary>
        /// 显示名称
        /// </summary>
        string HeadText { get; }
    }
}
