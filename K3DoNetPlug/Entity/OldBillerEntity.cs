using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    class OldBillerEntity : IEntity
    {
        public OldBillerEntity(BaseBiller biller)
        {
            this.Biller = biller;
        }

        #region IEntity 成员

        private IEntityItem _entityInstanceCatch;
        /// <summary>
        /// 老单单据体，下标只能为0
        /// </summary>
        /// <value></value>
        public IEntityItem this[int entityIndex]
        {
            get
            {
                if (entityIndex != 0)
                {
                    throw new IndexOutOfRangeException("无法获取单据体，下标越界");
                }
                if (this._entityInstanceCatch == null)
                {
                    this._entityInstanceCatch = new OldBillerEntityItem(this.Biller, this, entityIndex);
                }
                return this._entityInstanceCatch;
            }
        }

        /// <summary>
        /// 获取单据中单据体数量
        /// </summary>
        public int Count
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// 单据对像
        /// </summary>
        public IBiller Biller { get; private set; }

        #endregion
    }
}
