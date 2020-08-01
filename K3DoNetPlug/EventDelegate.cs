using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public class EventDelegate
    {
        /// <summary>
        /// 单据保存委托
        /// </summary>
        /// <contractEntity name="cancel">true保存,false取消保存</contractEntity>
        public delegate void BeforeSave(ref bool cancel);

        /// <summary>
        /// 单据加载后事件
        /// </summary>
        public delegate void AfterLoadBill();

        /// <summary>
        /// 单据失去焦点时触发事件
        /// </summary>
        /// <contractEntity name="cell">单元格</contractEntity>
        public delegate void AfterLevelCell(ICell cell);

        /// <summary>
        /// 初始化菜单，oMenuBar为NULL刚为老单，oMenuBar为K3ClassEvents.MenuBar刚为新单
        /// </summary>
        public delegate void OnInitToolsButton(IToolsButton toolsButton);

        /// <summary>
        /// 响应按按钮事件
        /// </summary>
        /// <contractEntity name="toolsButtonName">Name</contractEntity>
        public delegate void OnToolsButtonClick(string toolsButtonName);

        /// <summary>
        /// 单据保存完成后触发事件
        /// </summary>
        public delegate void AfterSave();
        
     }
}
