using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace K3DoNetPlug
{
    public interface IRow:IEnumerable<IRowItem>
    {
        /// <summary>
        /// 单据对像
        /// </summary>
        IBiller Biller { get; }
        
        /// <summary>
        /// 单据体对像
        /// </summary>
        IEntityItem Parent { get; }
        
        /// <summary>
        /// 单据体单元格对像
        /// </summary>
        /// <contractEntity name="rowIndex">行号</contractEntity>
        /// <contractEntity name="cellIndex">列号</contractEntity>
        /// <returns></returns>
        ICell this[int rowIndex, int cellIndex] { get; }

        /// <summary>
        /// 单据体单元格对像
        /// </summary>
        /// <contractEntity name="rowIndex">行号</contractEntity>
        /// <contractEntity name="name">列名</contractEntity>
        /// <returns></returns>
        ICell this[int rowIndex, string name] { get; }

        /// <summary>
        /// 单据体行对像
        /// </summary>
        /// <contractEntity name="rowIndex">行号</contractEntity>
        /// <returns></returns>
        IRowItem this[int index] { get; }

        /// <summary>
        /// 单据体数据行数
        /// </summary>
        int Count { get; }

        //void RemoveAll();

        //void Remove(int rowIndex);

        /// <summary>
        /// 新建数据行
        /// </summary>
        /// <returns></returns>
        IRowItem NewRow();
    }
}
