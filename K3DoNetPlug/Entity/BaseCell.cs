using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K3DoNetPlug
{
    public abstract class BaseCell : IBaseCell
    {

        public int IntValueOrDefault(int defaultValue)
        {
            try
            {
                return Convert.ToInt32(Value);
            }
            catch
            {
                return defaultValue;
            }
        }

        public double DoubleValueOrDefault(double defaultValue)
        {
            try
            {
                return Convert.ToDouble(Value);
            }
            catch
            {
                return defaultValue;
            }
        }

        public int? IntNullAbleValueOrDefault()
        {
            try
            {
                return Convert.ToInt32(Value);
            }
            catch
            {
                return null;
            }
        }

        public int? DoubleNullAbleValueOrDefault()
        {
            try
            {
                return Convert.ToInt32(Value);
            }
            catch
            {
                return null;
            }
        }

        #region IBaseCell 成员

        public abstract string Value { get; set; }

        #endregion
    }
}
