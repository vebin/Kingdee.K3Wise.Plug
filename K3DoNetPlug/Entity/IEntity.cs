using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public interface IEntity
    {
        /// <summary>
        /// 单据对像
        /// </summary>
        IBiller Biller { get; }
        
        /// <summary>
        /// 单据体
        /// </summary>
        /// <contractEntity name="rowIndex"></contractEntity>
        /// <returns></returns>
        IEntityItem this[int index] { get; }

        /// <summary>
        /// 单据体数
        /// </summary>
        /// <value>The count.</value>
        int Count { get; }
    }
}
