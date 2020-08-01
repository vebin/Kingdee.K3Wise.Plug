using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public interface ICell : IItemInfo, IBaseCell
    {
        /// <summary>
        /// 单据对像
        /// </summary>
        IBiller Biller { get; }

        /// <summary>
        /// 所属行号
        /// </summary>
        int RowIndex { get; }

        /// <summary>
        /// 所属列号
        /// </summary>
        int CellIndex { get; }

        /// <summary>
        /// 单元格所属行对像
        /// </summary>
        IRowItem Parent { get; }


        /// <summary>
        /// 获取整型
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        int IntValueOrDefault(int defaultValue);

        /// <summary>
        /// 获取浮点数
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        double DoubleValueOrDefault(double defaultValue);

        /// <summary>
        /// 可空整理
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        int? IntNullAbleValueOrDefault();

        /// <summary>
        /// 可空整型
        /// </summary>
        /// <returns></returns>
        int? DoubleNullAbleValueOrDefault();


       /// <summary>
       /// 获取列名
       /// </summary>
       /// <returns></returns>
        string GetColumnName();
    }
}
