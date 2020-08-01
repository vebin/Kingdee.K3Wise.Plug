using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K3DoNetPlug.Model
{
    /// <summary>
    /// 标记为k3基础资料字段，同时指定基础资料的类型
    /// </summary>
    public class K3ColumnBaseDataNameAttribute : K3ColumnAttribute
    {
        public ItemTypeEnum ItemType { get; private set; }

        public K3ColumnBaseDataNameAttribute(ItemTypeEnum itemType,string name):base(name)
        {
            this.ItemType = itemType;
        }
    }
}
