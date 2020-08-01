using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public class NewBillerColumnItem:IColumnItem
    {
        public NewBillerColumnItem(IBiller biller, IColumn parent, int index)
        {
            this.Biller = biller;
            this.Parent = parent;
            this.Index = index;
            this.m_BillTransfer = this.Biller.M_BillTransfer as K3ClassEvents.BillEvent;
        }

        private K3ClassEvents.BillEvent m_BillTransfer;

        #region IColumnItem 成员

        /// <summary>
        /// 单据对像
        /// </summary>
        /// <value></value>
        public IBiller Biller { get; private set; }

        /// <summary>
        /// Column对像
        /// </summary>
        /// <value></value>
        public IColumn Parent { get; private set; }

        /// <summary>
        /// 列名
        /// </summary>
        /// <value></value>
        public string Name
        {
            get
            {
                return this.m_BillTransfer.BillHeads[1].get_BOSFields()[Index+1].FieldName;
            }
        }

        /// <summary>
        /// 列索引号
        /// </summary>
        /// <value></value>
        public int Index { get; private set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        /// <value></value>
        public string HeadText
        {
            get
            {
                return this.m_BillTransfer.BillHeads[1].get_BOSFields()[Index+1].Caption;
            }
        }

        #endregion
    }
}
