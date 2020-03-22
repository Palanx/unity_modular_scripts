using Die4Games.ModularScript.Events;
using Die4Games.ModularScript.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Die4Games.ModularScript
{
    public class BaseScriptableObject : ScriptableObject, IOnChangeHandler
	{
        #region Fields
        [ToggleGroup("hasID", "Has ID", Order = -99)]
		public bool hasID = false;
		[Tooltip("The items will be stored under this id."), ToggleGroup("hasID", Order = -99), SerializeField]
		private int _id;

		[PropertyOrder(9905)]
		public bool resetInRuntime = false;

		[PropertySpace(SpaceBefore = 40f), ToggleGroup("onChangeToggle", "On Change Events", Order = 9900)]
		public bool onChangeToggle = false;
		[ToggleGroup("onChangeToggle", Order = 9901)]
		public GameEvent OnChangeScriptableObject;
		[ToggleGroup("onChangeToggle", Order = 9902)]
		public UnityEvent OnChangeEvent;
		[ToggleGroup("onChangeToggle", Order = 9903)]
		public UnityAction OnChangeAction;
        #endregion

        #region Properties
        public int ID { get => _id; }
		#endregion

		[ToggleGroup("onChangeToggle", Order = 9901), PropertyOrder(9903), Button("Trigger OnChange"), GUIColor(0.3f, 0.8f, 0.8f, 1f)]
		public void OnChange()
		{
			OnChangeScriptableObject?.Raise();
			OnChangeEvent?.Invoke();
			OnChangeAction?.Invoke();
		}
    }
}


