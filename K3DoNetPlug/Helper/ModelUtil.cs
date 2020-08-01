using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K3DoNetPlug.Dal;
using K3DoNetPlug.Core;
using System.Collections;
using K3DoNetPlug.Model;

namespace K3DoNetPlug.Helper
{
    public class ModelUtil
    {
        private BaseDataDao baseDataDao = new BaseDataDao();

        #region 界面绑定到模型

        /// <summary>
        /// 单据头绑定到模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="head"></param>
        /// <returns></returns>
        public T SetHeadToModel<T>(IHead head) where T:class
        {
            Type type = typeof(T); //获取类型
            var result=type.Assembly.CreateInstance(type.FullName) as T;
            var propertyInfoArray = type.GetProperties();
            //遍历所有属性
            foreach (var p in propertyInfoArray)
            {
                var cuestAttr = p.GetCustomAttributes(typeof(K3FieldAttribute), false);
                K3FieldAttribute k3Field;
                string fieldName;

                //不参与转换
                if(cuestAttr.Length > 0&&(cuestAttr[0] as K3FieldAttribute).K3FieldType.Contains(K3FieldTypeEnum.Nothing))
                {
                    continue;
                }

                if (cuestAttr.Length == 0)
                {
                    //如果什么都不填，使用默认转换
                    k3Field = new K3FieldAttribute();
                }
                else
                {
                    k3Field = cuestAttr[0] as K3FieldAttribute;
                }

                fieldName = k3Field.Name;
                //如果没有设置模型对应的UI字段名称，则UI字段名称与Model名称一致
                if(string.IsNullOrEmpty(fieldName))
                {
                    fieldName=p.Name;
                }

                //双向绑定
                if(k3Field.K3FieldType.Contains(K3FieldTypeEnum.All))
                {
                    p.SetValue(result, k3Field.k3FieldSetValueFunc.UiToModelValue(head[fieldName].Value), null);
                }

                //绑定Ui基资料的Value到Model
                if (k3Field.K3FieldType.Contains(K3FieldTypeEnum.Db_UiValueToModel))
                {
                    p.SetValue(result, k3Field.k3FieldSetValueFunc.UiToModelValue(head[fieldName].Value), null);
                }

                //绑定Ui基资料的Number到Model
                if (k3Field.K3FieldType.Contains(K3FieldTypeEnum.Db_UiNumberToModel))
                {
                    p.SetValue(result, k3Field.k3FieldSetValueFunc.UiToModelValue(head[fieldName].Number), null);
                }

                //绑定Ui基资料的Name到Model
                if (k3Field.K3FieldType.Contains(K3FieldTypeEnum.Db_UiNameToModel))
                {
                    p.SetValue(result, k3Field.k3FieldSetValueFunc.UiToModelValue(head[fieldName].Name), null);
                }
            }
            return result;
        }

        public List<T> SetEntityToModel<T>(IEntityItem entity) where T:class
        {
            List<T> list=new List<T>();

            for (int i = 0; i < entity.Row.Count; i++)
            {
                list.Add(SetEntityRowToModel<T>(entity.Row[i]));
            }
            return list;
        }

        private T SetEntityRowToModel<T>(IRowItem rowItem) where T : class
        {
            Type type = typeof(T); //获取类型
            var result = type.Assembly.CreateInstance(type.FullName) as T;
            var propertyInfoArray = type.GetProperties();
            //遍历所有属性
            foreach (var p in propertyInfoArray)
            {
                var cuestAttr = p.GetCustomAttributes(typeof(K3FieldAttribute), false);
                K3FieldAttribute k3Field;
                string fieldName;

                //不参与转换
                if (cuestAttr.Length > 0 && (cuestAttr[0] as K3FieldAttribute).K3FieldType.Contains(K3FieldTypeEnum.Nothing))
                {
                    continue;
                }

                if (cuestAttr.Length == 0)
                {
                    //如果什么都不填，使用默认转换
                    k3Field = new K3FieldAttribute();
                }
                else
                {
                    k3Field = cuestAttr[0] as K3FieldAttribute;
                }

                fieldName = k3Field.Name;
                //如果没有设置模型对应的UI字段名称，则UI字段名称与Model名称一致
                if (string.IsNullOrEmpty(fieldName))
                {
                    fieldName = p.Name;
                }

                //双向绑定
                if (k3Field.K3FieldType.Contains(K3FieldTypeEnum.All))
                {
                    p.SetValue(result, k3Field.k3FieldSetValueFunc.UiToModelValue(rowItem[fieldName].Value), null);
                }

                //绑定Ui基资料的Value到Model
                if (k3Field.K3FieldType.Contains(K3FieldTypeEnum.Db_UiValueToModel))
                {
                    p.SetValue(result, k3Field.k3FieldSetValueFunc.UiToModelValue(rowItem[fieldName].Value), null);
                }

                //绑定Ui基资料的Number到Model
                if (k3Field.K3FieldType.Contains(K3FieldTypeEnum.Db_UiNumberToModel))
                {
                    p.SetValue(result, k3Field.k3FieldSetValueFunc.UiToModelValue(rowItem[fieldName].Number), null);
                }

                //绑定Ui基资料的Name到Model
                if (k3Field.K3FieldType.Contains(K3FieldTypeEnum.Db_UiNameToModel))
                {
                    p.SetValue(result, k3Field.k3FieldSetValueFunc.UiToModelValue(rowItem[fieldName].Name), null);
                }
            }
            return result;
        }
        #endregion

        #region 模型绑定到界面

        /// <summary>
        /// 模型绑定到数据行
        /// </summary>
        /// <param name="row"></param>
        /// <param name="model"></param>
        private void SetModelToEntityRow(IRowItem row, object model)
        {
            Type type = model.GetType(); //获取类型
            var propertyInfoArray = type.GetProperties();
            foreach (var p in propertyInfoArray)
            {
                var cuestAttr = p.GetCustomAttributes(typeof(K3FieldAttribute), false);
                K3FieldAttribute k3Field;
                string fieldName;
                var value = p.GetValue(model, null);//当前Model字段值



                if (cuestAttr.Length == 0)
                {
                    //如果什么都不填，使用默认转换
                    k3Field = new K3FieldAttribute();
                }
                else
                {
                    k3Field = cuestAttr[0] as K3FieldAttribute;
                }               
                
                //不参与转换
                if (k3Field.K3FieldType.Contains(K3FieldTypeEnum.Nothing))
                {
                    continue;
                }

                fieldName = k3Field.Name;
                //如果没有设置模型对应的UI字段名称，则UI字段名称与Model名称一致
                if (string.IsNullOrEmpty(fieldName))
                {
                    fieldName = p.Name;
                }

                //双向绑定，如果不设置K3FieldType也表示为默认双向绑定
                if (k3Field.K3FieldType.Length==0||k3Field.K3FieldType.Contains(K3FieldTypeEnum.All))
                {                    //如果为空则给空值
                    if (value == null || string.IsNullOrEmpty(value.ToString()))
                    {
                        row[fieldName].Value = "";
                        continue;
                    }
                    row[fieldName].Value = k3Field.k3FieldSetValueFunc.ModelToUiValue(value).ToString() ;
                }

                //模型的基础资料值为Name
                if (k3Field.K3FieldType.Contains(K3FieldTypeEnum.Db_ModelNameToUi))
                {
                    //如果为空则给空值
                    if (value == null || string.IsNullOrEmpty(value.ToString()))
                    {
                        row[fieldName].Value = "";
                        continue;
                    }
                    row[fieldName].Value = k3Field.k3FieldSetValueFunc.ModelToUiValue(this.baseDataDao.GetListByName(k3Field.ItemType, value.ToString())[0].FNumber).ToString();
                }

                //模型的基础资料值为Number
                if (k3Field.K3FieldType.Contains(K3FieldTypeEnum.Db_ModelNumberToUi))
                {
                    row[fieldName].Value = k3Field.k3FieldSetValueFunc.ModelToUiValue(value).ToString();
   
                }
            }
        }

        /// <summary>
        /// 模型绑定到单据体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="List"></param>
        public void SetModelToEntity(IEntityItem entity, IList List)
        {
            foreach (var item in List)
            {
                var row = entity.Row.NewRow();
                SetModelToEntityRow(row, item);
            }
        }

        /// <summary>
        /// 模型绑定到单据头
        /// </summary>
        /// <param name="head"></param>
        /// <param name="model"></param>
        public void SetModelToHead(IHead head, object model)
        {
            Type type = model.GetType(); //获取类型
            var propertyInfoArray = type.GetProperties();
            foreach (var p in propertyInfoArray)
            {
                var cuestAttr = p.GetCustomAttributes(typeof(K3FieldAttribute), false);
                K3FieldAttribute k3Field;
                string fieldName;
                var value = p.GetValue(model, null);//当前Model字段值

                //不参与转换
                if (cuestAttr.Length > 0 && (cuestAttr[0] as K3FieldAttribute).K3FieldType.Contains(K3FieldTypeEnum.Nothing))
                {
                    continue;
                }

                if (cuestAttr.Length == 0)
                {
                    //如果什么都不填，使用默认转换
                    k3Field = new K3FieldAttribute();
                }
                else
                {
                    k3Field = cuestAttr[0] as K3FieldAttribute;
                }

                value = k3Field.k3FieldSetValueFunc.ModelToUiValue(value);

                fieldName = k3Field.Name;
                //如果没有设置模型对应的UI字段名称，则UI字段名称与Model名称一致
                if (string.IsNullOrEmpty(fieldName))
                {
                    fieldName = p.Name;
                }

                //双向绑定
                if (k3Field.K3FieldType.Contains(K3FieldTypeEnum.All))
                {                    //如果为空则给空值
                    if (value == null || string.IsNullOrEmpty(value.ToString()))
                    {
                        head[fieldName].Value = "";
                        continue;
                    }
                    head[fieldName].Value = value.ToString();
                }

                //模型的基础资料值为Name
                if (k3Field.K3FieldType.Contains(K3FieldTypeEnum.Db_ModelNameToUi))
                {
                    //如果为空则给空值
                    if (value == null || string.IsNullOrEmpty(value.ToString()))
                    {
                        head[fieldName].Value = "";
                        continue;
                    }
                    head[fieldName].Value = this.baseDataDao.GetListByName(k3Field.ItemType, value.ToString())[0].FName;
                }

                //模型的基础资料值为Number
                if (k3Field.K3FieldType.Contains(K3FieldTypeEnum.Db_ModelNumberToUi))
                {
                    head[fieldName].Value = value.ToString();

                }
            }
        }
        #endregion
    }
}
