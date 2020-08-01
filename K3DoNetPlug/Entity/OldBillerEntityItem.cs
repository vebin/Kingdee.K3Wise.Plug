using System;
using System.Collections.Generic;
using System.Text;
using K3DoNetPlug.Helper;

namespace K3DoNetPlug
{
    class OldBillerEntityItem:IEntityItem
    {
        ModelUtil modelUtil = new ModelUtil();

        public OldBillerEntityItem(IBiller biller, OldBillerEntity parent, int entityIndex)
        {
            this.Biller = biller;
            this.Parent = parent;
            this.Index = entityIndex;
        }

        #region IEntity 成员

        /// <summary>
        /// 单据体数据行
        /// </summary>
        /// <value></value>
        public IRow Row
        {
            get
            {
                return new OldBillerRow(this.Biller,this);
            }
        }

        /// <summary>
        /// 单据对像
        /// </summary>
        /// <value></value>
        public IBiller Biller { get; private set; }

        /// <summary>
        /// 所有单据体对像
        /// </summary>
        /// <value></value>
        public IEntity Parent{get;private set;}


        private IColumn _column;
        /// <summary>
        /// 单据列信息
        /// </summary>
        /// <value></value>
        public IColumn Column
        {
            get 
            {
                if (this._column == null)
                {
                    this._column=new OldBillerColumn(this.Biller,this);
                }
                return this._column;
            }
        }

        /// <summary>
        /// 所属单据索引号
        /// </summary>
        /// <value></value>
        public int Index { get; private set; }

        #endregion


        public void SetUiByModel(System.Collections.IList list)
        {
            modelUtil.SetModelToEntity(this,list);
        }


        public List<T> GetModelByUi<T>() where T : class
        {
            return modelUtil.SetEntityToModel<T>(this);
        }
    }
}
