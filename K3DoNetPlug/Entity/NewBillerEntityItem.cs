using System;
using System.Collections.Generic;
using System.Text;
using K3DoNetPlug.Helper;

namespace K3DoNetPlug
{
    public class NewBillerEntityItem:IEntityItem
    {
        ModelUtil modelUtil = new ModelUtil();

        public NewBillerEntityItem(IBiller biller, IEntity parent, int index)
        {
            this.Biller = biller;
            this.Parent = parent;
            this.Index = index;
        }
        #region IEntity 成员

        public IBiller Biller { get; private set; }

        public int Index { get; private set; }

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
                    this._column = new NewBillerColumn(this.Biller,this);
                }
                return this._column;
            }
        }

        private IRow _row;
        /// <summary>
        /// 单据体数据行
        /// </summary>
        /// <value></value>
        public IRow Row
        {
            get
            {
                if (this._row == null)
                {
                    this._row = new NewBillerRow(this.Biller, this);
                }
                return this._row;
            }
        }

        public IEntity Parent { get; private set; }
        
        #endregion
        
        public void SetUiByModel(System.Collections.IList list)
        {
            modelUtil.SetModelToEntity(this, list);
        }


        public List<T> GetModelByUi<T>() where T : class
        {
            return modelUtil.SetEntityToModel<T>(this);
        }
    }
}
