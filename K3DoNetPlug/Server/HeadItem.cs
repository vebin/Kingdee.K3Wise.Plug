using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug.Server
{
    public class HeadItem : IItemInfo
    {
        private string _name;

        private KFO.Dictionary _dctTableInfo;

        private KFO.Dictionary _dctData;

        private Head _parent;

        private string RealName
        {
            get
            {
                return ((KFO.Dictionary)this._dctTableInfo.GetValue("Map", "")).GetValue(this._name, "").ToString();
            }
        }

        public HeadItem(Head parent, KFO.Dictionary dctTableInfo, KFO.Dictionary dctData, string name)
        {
            this._parent = parent;
            this._dctTableInfo = dctTableInfo;
            this._dctData = dctData;
            this._name = name;
        }

        public string Value
        {
            get
            {
                return ((KFO.Dictionary)((KFO.Dictionary)this._dctData.GetValue("Page1", "")).GetValue(this.RealName, "")).GetValue("FFLD", "").ToString();
            }
        }

        public string InterID
        {
            get
            {
                return ((KFO.Dictionary)((KFO.Dictionary)this._dctData.GetValue("Page1", "")).GetValue(this.RealName, "")).GetValue("FFLD", "").ToString();
            }
        }

        public string Name
        {
            get
            {
                return ((KFO.Dictionary)((KFO.Dictionary)this._dctData.GetValue("Page1", "")).GetValue(this.RealName, "")).GetValue("FDSP", "").ToString();
            }
        }

        public string Number
        {
            get
            {
                return ((KFO.Dictionary)((KFO.Dictionary)this._dctData.GetValue("Page1", "")).GetValue(this.RealName, "")).GetValue("FFND", "").ToString();
            }
        }
    }
}
