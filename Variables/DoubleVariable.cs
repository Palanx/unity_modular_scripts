using UnityEngine;

namespace Die4Games.ModularScript.Variables
{
    [CreateAssetMenu(fileName = "New Double Variable", menuName = "Die4Games/ModularScript/Variables/Double")]
    public class DoubleVariable : BaseVariable<double>
    {
        public override void AddValue(double value)
        {
            Value += value;
        }
    }
}