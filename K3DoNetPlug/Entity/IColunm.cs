using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    /// <summary>
    /// 单据体列信息
    /// </summary>
    public interface IColumn
    {
        /// <summary>
        /// 单据体对像
        /// </summary>
        IBiller Biller { get; }

        /// <summary>
        /// 单据体列数
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 单据头项
        /// </summary>
        /// <contractEntity name="index"></contractEntity>
        /// <returns></returns>
        IColumnItem this[int index] { get; }

        /// <summary>
        /// 单据头项
        /// </summary>
        /// <contractEntity name="name"></contractEntity>
        /// <returns></returns>
        IColumnItem this[string name] { get; }

        /// <summary>
        /// 列名对应索引号缓存
        /// </summary>
        Dictionary<string, int> NameToIndex { get; }
        
        /// <summary>
        /// 索引号对应列名
        /// </summary>
        Dictionary<int, string> IndexToName { get; }

        /// <summary>
        /// 根据名称获取索引
        /// </summary>
        /// <contractEntity name="name"></contractEntity>
        /// <returns></returns>
        int GetIndex(string name);

        /// <summary>
        /// 根据索引获取列名
        /// </summary>
        /// <contractEntity name="index"></contractEntity>
        /// <returns></returns>
        string GetName(int index);

        /// <summary>
        /// 单据体
        /// </summary>
        IEntityItem Parent { get; }

    }
}
