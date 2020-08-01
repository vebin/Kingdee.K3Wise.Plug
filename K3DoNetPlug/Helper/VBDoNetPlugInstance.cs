using System;
using System.Collections.Generic;
using System.Text;

namespace K3DoNetPlug
{
    public static class VBDoNetPlugInstance
    {
        private static VBDoNetPlug.OldBiller _oldBillerSingleInstance;

        /// <summary>
        /// 单件初始化
        /// </summary>
        static VBDoNetPlugInstance()
        {
            _oldBillerSingleInstance = new VBDoNetPlug.OldBiller();
        }

        public static VBDoNetPlug.OldBiller GetOldBillerInstance()
        {
            return _oldBillerSingleInstance;
        }

        private static VBDoNetPlug.NewBiller _newBillerInstance = new VBDoNetPlug.NewBiller();

        public static VBDoNetPlug.NewBiller GetNewBillerInstance()
        {
            return _newBillerInstance;
        }
    }
}
