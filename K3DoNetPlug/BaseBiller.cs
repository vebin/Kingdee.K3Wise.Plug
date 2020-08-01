using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace K3DoNetPlug
{
    public abstract class BaseBiller:IBiller
    {
        public void Show(object m_BillTransfer)
        {
            this.M_BillTransfer = m_BillTransfer;
            
            //初始化单据标识
            this.BillerID = Guid.NewGuid();

            AbstractClassFactory classFactory = SingleClassFactory.GetClassFactory(this);
            this.BillerType = classFactory.GetTypeBillerInstance();
            this.Head = classFactory.GetHeadInstance();
            this.Entity = classFactory.GetEntityInstance();
            this.NewBillOjbect = classFactory.GetNewBillOjbcet();
            this.OldBillObject = classFactory.GetOldBillOjbect();
            registEvent();

            _entityColumnKeyDic = new Dictionary<int, string>();
            _entityColumnKeyDic.Add(0, "fitemid");

            if (BillerType == TypeBiller.NewBiller)
            {
                this.NewBillOjbect.AfterLoadBill += new K3ClassEvents.__BillEvent_AfterLoadBillEventHandler(NewBillOjbect_AfterLoadBill);
                this.NewBillOjbect.AfterNewBill += new K3ClassEvents.__BillEvent_AfterNewBillEventHandler(NewBillOjbect_AfterNewBill);
                this.NewBillOjbect.MenuBarClick += new K3ClassEvents.__BillEvent_MenuBarClickEventHandler(NewBillOjbect_MenuBarClick);
                this.NewBillOjbect.MenuBarInitialize += new K3ClassEvents.__BillEvent_MenuBarInitializeEventHandler(NewBillOjbect_MenuBarInitialize);
            }
            else
            {
                this.OldBillObject.BillInitialize += new k3BillTransfer.__Bill_BillInitializeEventHandler(OldBillObject_BillInitialize);
            }

            Initialize();
        }

        private string template;

        /// <summary>
        /// k3模板单据的名称
        /// </summary>
        public string TemplateName
        {
            get
            {
                if(!string.IsNullOrEmpty(this.template))
                {
                    return this.template;
                }

                this.template=K3DoNetPlug.VBDoNetPlugInstance.GetOldBillerInstance().GetTemplateName(this.OldBillObject);
                System.Diagnostics.Debug.WriteLine("单据模板名称"+this.template);
                return this.template;
            }
        }


        protected void SetGridCellFocus(int rowIndex, int columnIndex)
        {
            VBDoNetPlugInstance.GetOldBillerInstance().Grid_SetAction(this.OldBillObject,(short)rowIndex, (short)columnIndex);
        }

        public virtual string Version { get; private set; }

        public bool VerifyVersion()
        {
            return Version == this.NewBillOjbect.GetVariable("version").ToString();
        }

        void OldBillObject_BillInitialize()
        {
            DBUnit.InitGlobalConnString(this.DBUnitInstance.ConnString);
        }

        void NewBillOjbect_AfterNewBill()
        {
            DBUnit.InitGlobalConnString(this.DBUnitInstance.ConnString);
        }

        void NewBillOjbect_AfterLoadBill()
        {
            DBUnit.InitGlobalConnString(this.DBUnitInstance.ConnString);
        }

        public abstract void Initialize();

        public BaseBiller()
        { 
        }

        public BaseBiller(object m_BillTransfer)
        {
            this.Show(m_BillTransfer);
        }

        void NewBillOjbect_MenuBarClick(K3ClassEvents.BOSTool BOSTool, ref bool Cancel)
        {
            if (BOSTool.ToolName == "AboutPlug")
            {
                MessageBox.Show("系统组件版本" + this.Version);
            }
        }

        void NewBillOjbect_MenuBarInitialize(K3ClassEvents.MenuBar oMenuBar)
        {
            var item = oMenuBar.BOSTools.Add("AboutPlug");
            item.Caption = "关于插件";
            item.Enabled = true;
            item.Visible = true;
            item.ShortcutKey = 0;
            item.BeginGroup = true;

            var bb = oMenuBar.BOSBands["mnuHelp"];
            bb.BOSTools.InsertAfter(0, ref item);
        }

        /// <summary>
        /// 老单单据对像
        /// </summary>
        public k3BillTransfer.Bill OldBillObject;

        /// <summary>
        /// 新单单据对像
        /// </summary>
        public K3ClassEvents.BillEvent NewBillOjbect;

        delegate void RegistEvent();
        /// <summary>
        /// 注册事件
        /// </summary>
        RegistEvent registEvent
        {
            get
            {
                RegistEvent registEvent = new RegistEvent(RegistOldBillerEvent);
                registEvent += RegistNewBillerEvent;
                return registEvent;
            }
        }

        private Dictionary<int, string> _entityColumnKeyDic { get; set; }

        public virtual Dictionary<int, string> EntityColumnKeyDic
        {
            get
            {
                return _entityColumnKeyDic;
            }
        }

        ///// <summary>
        ///// 单据体关键列名，注：必须全部为小写才能与columnName匹配
        ///// </summary>
        //public virtual string EntityColumnKey
        //{
        //    get
        //    {
        //        return "fitemid";
        //    }
        //}

        /// <summary>
        /// 单据实例唯一标识符
        /// </summary>
        public Guid BillerID { get; private set; }

        /// <summary>
        /// K3单据对像
        /// </summary>
        public object M_BillTransfer { get; private set; }

        /// <summary>
        /// K3单据类型
        /// </summary>
        public TypeBiller BillerType { get; private set; }

        /// <summary>
        /// 单据头
        /// </summary>
        public IHead Head{get;private set;}

        public IEntity Entity { get; private set; }

        private DBUnit _DBUnitInstance;
        public DBUnit DBUnitInstance
        {
            get
            {
                if (_DBUnitInstance == null)
                {
                    this._DBUnitInstance = new DBUnit(this);
                }
                return this._DBUnitInstance;
            }
        }

        #region 单据事件处理
        /// <summary>
        /// 单据保存前事件
        /// </summary>
        public event EventDelegate.BeforeSave Before_Save;

        /// <summary>
        /// 单据加载完成时触发事件
        /// </summary>
        public event EventDelegate.AfterLoadBill After_LoadBiller;

        /// <summary>
        /// 单据体单元格失去焦点否触发事件.
        /// </summary>
        public event EventDelegate.AfterLevelCell After_LevelCell;

        /// <summary>
        /// 初始化单据按钮时触主事件，用于给单据增加按钮
        /// </summary>
        public event EventDelegate.OnInitToolsButton On_InitToolsButton;

        /// <summary>
        /// 单据按钮被点击后触发事件
        /// </summary>
        public event EventDelegate.OnToolsButtonClick On_ToolsButtonClick;

        /// <summary>
        /// 单据保存后触发事件
        /// </summary>
        public event EventDelegate.AfterSave After_Save;

        #region 注册老单事件

        private void RegistOldBillerEvent()
        {
            if (this.BillerType != TypeBiller.OldBiller)
            {
                return;
            }
            k3BillTransfer.Bill oldBiller = this.M_BillTransfer as k3BillTransfer.Bill;
            oldBiller.BeforeSave += new k3BillTransfer.__Bill_BeforeSaveEventHandler(oldBiller_BeforeSave);
            oldBiller.BillInitialize += new k3BillTransfer.__Bill_BillInitializeEventHandler(oldBiller_BillInitialize);
            oldBiller.LeveCell += new k3BillTransfer.__Bill_LeveCellEventHandler(oldBiller_LeveCell);
            oldBiller.UserMenuClick += new k3BillTransfer.__Bill_UserMenuClickEventHandler(oldBiller_UserMenuClick);
            oldBiller.EndSave += new k3BillTransfer.__Bill_EndSaveEventHandler(oldBiller_EndSave);
        }

        void oldBiller_EndSave(string BillNo)
        {
            if (this.After_Save != null)
            {
                this.After_Save();
            }
        }

        void oldBiller_UserMenuClick(int Index, string Caption)
        {
            if (this.On_ToolsButtonClick != null)
            {
                this.On_ToolsButtonClick(Caption);
            }
        }

        void oldBiller_LeveCell(int Col, int Row, int NewCol, int NewRow, ref bool Cancel)
        {
            if (this.Entity[0].Row.Count >= Row)
            {
                if (this.After_LevelCell != null)
                {
                    this.After_LevelCell(this.Entity[0].Row[Row - 1, Col - 1]);
                }
            }
            else
            {
                if (this.After_LevelCell != null)
                {
                    this.After_LevelCell(null);
                }
            }
        }

        private void oldBiller_BillInitialize()
        {
            if (this.After_LoadBiller != null)
            {
                this.After_LoadBiller();
            }
            if (this.On_InitToolsButton != null)
            {
                this.On_InitToolsButton(new OldBillerToolsButton(this));
            }
        }

        private void oldBiller_BeforeSave(bool bNew, ref int ReturnCode)
        {
            bool cancel=false;
            if (this.Before_Save != null)
            {
                this.Before_Save(ref cancel);
            }
            if (cancel)
            {
                ReturnCode = -1;
            }
            else
            {
                ReturnCode = 0;
            }
        }

        #endregion

        #region 注册新单事件

        private void RegistNewBillerEvent()
        {
            if (this.BillerType != TypeBiller.NewBiller)
            {
                return;
            }
            K3ClassEvents.BillEvent newBiller = this.M_BillTransfer as K3ClassEvents.BillEvent;
            newBiller.BeforeSave += new K3ClassEvents.__BillEvent_BeforeSaveEventHandler(newBiller_BeforeSave);
            newBiller.AfterNewBill += new K3ClassEvents.__BillEvent_AfterNewBillEventHandler(newBiller_AfterNewBill);
            newBiller.LostFocus += new K3ClassEvents.__BillEvent_LostFocusEventHandler(newBiller_LostFocus);
            newBiller.MenuBarInitialize += new K3ClassEvents.__BillEvent_MenuBarInitializeEventHandler(newBiller_MenuBarInitialize);
            newBiller.MenuBarClick += new K3ClassEvents.__BillEvent_MenuBarClickEventHandler(newBiller_MenuBarClick);
            newBiller.SaveBillSuccess += new K3ClassEvents.__BillEvent_SaveBillSuccessEventHandler(newBiller_SaveBillSuccess);
        }

        void newBiller_SaveBillSuccess(KFO.Dictionary dctData)
        {
            if (this.After_Save != null)
            {
                this.After_Save();
            }
        }

        void newBiller_MenuBarClick(K3ClassEvents.BOSTool BOSTool, ref bool Cancel)
        {
            if (this.On_ToolsButtonClick != null)
            {
                this.On_ToolsButtonClick(BOSTool.Caption);
            }
        }


        void newBiller_MenuBarInitialize(K3ClassEvents.MenuBar oMenuBar)
        {
            if(this.On_InitToolsButton!=null)
            this.On_InitToolsButton(new NewBillerToolsButton(this,oMenuBar));
        }

        void newBiller_LostFocus(string sKey, KFO.Dictionary dctData, object curDspValue, int Col, int Row, ref bool Cancel)
        {
            if (this.After_LevelCell == null)
            {
                return;
            }

            //row col为-1则为单据
            if (Row == -1 && Col == -1)
            {
                return;
            }
            int? currentEntityIndex=null;
            int entityCount=this.Entity.Count;
            for (int entityIndex = 0; entityIndex < entityCount; entityIndex++)
            {
                if (this.Entity[entityIndex].Column.NameToIndex.ContainsKey(sKey.ToLower()))
                {
                    currentEntityIndex = entityIndex;
                }
            }

            //单据头中不含skey数据则失去焦点的不是单据体，是单据头
            if (!currentEntityIndex.HasValue)
            {
                return;
            }

            if (Row > this.Entity[0].Row.Count)
            {
                this.After_LevelCell(null);
                return;
            }

            this.After_LevelCell(this.Entity[currentEntityIndex.Value].Row[Row - 1, this.Entity[currentEntityIndex.Value].Column.GetIndex(sKey)]);
        }

        void newBiller_AfterNewBill()
        {
            if (this.After_LoadBiller != null)
            {
                this.After_LoadBiller();
            }
        }

        void newBiller_BeforeSave(ref bool bCancel)
        {
            if (this.Before_Save != null)
            {
                this.Before_Save(ref bCancel);
            }
        }

        /// <summary>
        /// 从kfo对象获取字段的字段名称
        /// </summary>
        /// <param name="dct"></param>
        /// <returns></returns>
        protected string GetFieldName(KFO.Dictionary dct)
        {
            return dct.GetValue("FFieldName", null).ToString();
        }

        #endregion
        #endregion
    }
}
