using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K3DoNetPlug.Model
{
    /// <summary>
    /// 标记为k3基础资料的值字段，同时指定基础资料类型
    /// </summary>
    public class K3ColumnBaseDataValueAttribute : K3ColumnAttribute
    {
        public ItemTypeEnum ItemType { get; private set; }

        public K3ColumnBaseDataValueAttribute(ItemTypeEnum itemType,string name):base(name)
        {
            this.ItemType = itemType;
        }
    }
}
