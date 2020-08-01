using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K3DoNetPlug.Model
{
    /// <summary>
    /// 标记为K3字段
    /// </summary>
    public class K3FieldAttribute : Attribute
    {
        public string Name;

        public K3FieldTypeEnum[] K3FieldType=new K3FieldTypeEnum[0];

        /// <summary>
        /// 物料类别
        /// </summary>
        public ItemTypeEnum ItemType;

        private IK3FieldSetValueFunc _k3FieldSetValueFunc;

        /// <summary>
        /// 自定义Model与Ui值转换函数，默认原进原出
        /// </summary>
        public IK3FieldSetValueFunc k3FieldSetValueFunc
        {
            get
            {
                if (this._k3FieldSetValueFunc != null)
                {
                    return this._k3FieldSetValueFunc;
                }

                if (this.K3FieldSetValueFuncType != null)
                {
                    this._k3FieldSetValueFunc = this.K3FieldSetValueFuncType.Assembly.CreateInstance(this.K3FieldSetValueFuncType.FullName) as IK3FieldSetValueFunc;
                }

                if (this._k3FieldSetValueFunc == null)
                {
                    this._k3FieldSetValueFunc = new K3FieldSetValueFuncDefault();
                }

                return this._k3FieldSetValueFunc;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Type K3FieldSetValueFuncType;

        /// <summary>
        /// 默认双向绑定All,模型名称与字段名称一致
        /// 可省略不写该属性，模型不写任何属性默认为该值
        /// </summary>
        public K3FieldAttribute()
        {
            this.K3FieldType = new K3FieldTypeEnum[] { K3FieldTypeEnum.All };
        }

        /// <summary>
        ///  k3对应UI的字段名称
        ///  注意是编程的key英文，不是中文的caption
        /// </summary>
        /// <param name="name"></param>
        public K3FieldAttribute(string name)
        {
            this.Name = name;
            this.K3FieldType = new K3FieldTypeEnum[] { K3FieldTypeEnum.All };
        }

        public K3FieldAttribute(params K3FieldTypeEnum[] k3FieldType)
        {
            this.K3FieldType = k3FieldType;
        }

        /// <summary>
        /// 使用默认名称
        /// </summary>
        /// <param name="k3FieldType">类型</param>
        public K3FieldAttribute(ItemTypeEnum itemType,params K3FieldTypeEnum[] k3FieldType)
        {
            this.K3FieldType = k3FieldType;
            this.ItemType = itemType;
        }

        /// <summary>
        /// 字段模型对应的UI字段名
        /// </summary>
        /// <param name="name"></param>
        /// <param name="k3ColumnType"></param>
        public K3FieldAttribute(string name,ItemTypeEnum itemTypen,params K3FieldTypeEnum[] k3FieldType)
        {
            this.Name = name;
            this.K3FieldType = k3FieldType;
            this.ItemType = itemTypen;
        }
    }
}
