using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    /// <summary>
    /// 单据头
    /// </summary>
    public interface IHead
    {
        /// <summary>
        /// 单据对像
        /// </summary>
        IBiller Biller { get; }

        /// <summary>
        /// 列名对应索引号缓存
        /// </summary>
        Dictionary<string, int> NameToIndex { get; }

        /// <summary>
        /// 索引号对应列名
        /// </summary>
        Dictionary<int, string> IndexToName { get; }

        /// <summary>
        /// 单据头数组
        /// </summary>
        /// <contractEntity name="name">单据头项数据库存储字段名</contractEntity>
        /// <returns></returns>
        IHeadItem this[string name] { get; }

        /// <summary>
        /// 单据头项索经号
        /// </summary>
        /// <contractEntity name="index"></contractEntity>
        /// <returns></returns>
        IHeadItem this[int index] { get; }

        /// <summary>
        /// 单据头个数
        /// </summary>
        int Count { get;}

        /// <summary>
        /// 通过K3ColumnAttribute、K3ColumnBaseDataNameAttribute、K3ColumnBaseDataValueAttribute等标记
        /// </summary>
        /// <param name="model"></param>
        void SetUiByModel(object model);

        T GetModelByUi<T>() where T : class;
    }
}
