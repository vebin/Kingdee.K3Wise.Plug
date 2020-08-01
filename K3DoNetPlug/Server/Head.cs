using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug.Server
{
    public class Head
    {
        private KFO.Dictionary _dctTableInfo;

        private KFO.Dictionary _dctData;

        public Head(KFO.Dictionary dctTableInfo, KFO.Dictionary dctData) 
        {
            this._dctTableInfo = dctTableInfo;
            this._dctData = dctData;
        }

        public HeadItem this[string name]
        {
            get
            {
                return new HeadItem(this,this._dctTableInfo,this._dctData,name);
            }
        }
    }
}
