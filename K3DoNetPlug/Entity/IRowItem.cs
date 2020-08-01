using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public interface IRowItem:IEnumerable<ICell>
    {
        /// <summary>
        /// 单据对像
        /// </summary>
        IBiller Biller { get; }

        /// <summary>
        /// 所属单据所有行号
        /// </summary>
        int Index { get; }

        /// <summary>
        /// 单据行对像
        /// </summary>
        IRow Parent { get; }
        
        /// <summary>
        /// 单元格对像
        /// </summary>
        /// <contractEntity name="cellIndex">列号</contractEntity>
        /// <returns></returns>
        ICell this[int index] { get; }

        /// <summary>
        /// 单元格对像
        /// </summary>
        /// <contractEntity name="name">列名</contractEntity>
        /// <returns></returns>
        ICell this[string name] { get; }
        
        /// <summary>
        /// 是否是新增行
        /// </summary>
        bool IsNewRow { get; }
    }
}