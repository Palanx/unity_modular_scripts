using System;

namespace Die4Games.ModularScript.Variables
{
    [Serializable]
    public class DoubleReference
    {
        public bool UseConstant = true;
        public double ConstantValue;
        public DoubleVariable Variable;

        public DoubleReference()
        { }

        public DoubleReference(double value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public double Value
        {
            get { return UseConstant ? ConstantValue : Variable; }
        }

        public static implicit operator double(DoubleReference reference)
        {
            return reference.Value;
        }
    }
}