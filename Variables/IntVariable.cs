using UnityEngine;

namespace Die4Games.ModularScript.Variables
{
    [CreateAssetMenu(fileName = "New Int Variable", menuName = "Die4Games/ModularScript/Variables/Int")]
    public class IntVariable : BaseVariable<int>
    {
        public override void AddValue(int value)
        {
            Value += value;
        }
    }
}