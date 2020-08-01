using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEntityItem
    {
        /// <summary>
        /// 单据对像
        /// </summary>
        IBiller Biller { get; }

        /// <summary>
        /// 所属单据索引号
        /// </summary>
        int Index { get; }

        /// <summary>
        /// 单据列信息
        /// </summary>
        IColumn Column { get; }

        /// <summary>
        /// 单据体数据行
        /// </summary>
        IRow Row{get;}

        /// <summary>
        /// 所有单据体对像
        /// </summary>
        IEntity Parent { get; }

        void SetUiByModel(System.Collections.IList list);

        List<T> GetModelByUi<T>() where T:class;
    }
}
