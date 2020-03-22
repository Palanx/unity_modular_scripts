using UnityEngine;

namespace Die4Games.ModularScript.Variables
{
    [CreateAssetMenu(fileName = "New Float Variable", menuName = "Die4Games/ModularScript/Variables/Float")]
    public class FloatVariable : BaseVariable<float>
    {
        public override void AddValue(float value)
        {
            Value += value;
        }
    }
}