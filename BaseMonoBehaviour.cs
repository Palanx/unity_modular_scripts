using Die4Games.ModularScript.Events;
using Die4Games.ModularScript.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Die4Games.ModularScript
{
    public class BaseMonoBehaviour : MonoBehaviour, IOnChangeHandler
	{
        #region Fields
        [PropertySpace(50f), ToggleGroup("onChangeToggle", "On Change Events", Order = 9900)]
		public bool onChangeToggle = false;

		[ToggleGroup("onChangeToggle", Order = 9901)]
		public GameEvent OnChangeGameEvent;

		[ToggleGroup("onChangeToggle", Order = 9902)]
		public UnityEvent OnChangeUnityEvent;

		[ToggleGroup("onChangeToggle", Order = 9902)]
		public UnityAction OnChangeUnityAction;
        #endregion

        [ToggleGroup("onChangeToggle", Order = 9901), PropertyOrder(9903), Button("Trigger OnChange"), GUIColor(0.3f, 0.8f, 0.8f, 1f)]
		public virtual void OnChange()
		{
			OnChangeGameEvent?.Raise();
			OnChangeUnityEvent?.Invoke();
			OnChangeUnityAction?.Invoke();
		}
	}
}