using UnityEngine;

namespace Die4Games.ModularScript.Variables
{
    [CreateAssetMenu(fileName = "New String Variable", menuName = "Die4Games/ModularScript/Variables/String")]
    public class StringVariable : BaseVariable<string>
    {
        public override void AddValue(string value)
        {
            Value += value;
        }
    }
}