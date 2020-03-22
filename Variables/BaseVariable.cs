using UnityEngine;

namespace Die4Games.ModularScript.Variables
{
	public abstract class BaseVariable<T> : BaseScriptableObject, ISerializationCallbackReceiver
	{
		[Multiline]
		public string DeveloperDescription = "";
		[SerializeField]
		protected T _value = default;
		[System.NonSerialized]
		protected T initValue = default;

		protected virtual T Value
		{
			get => _value;
			set
			{
				_value = value;
				OnChange();
			}
		}

		public T GetValue()
		{
			return Value;
		}

		public void SetValue(T value)
		{
			Value = value;
		}

		public abstract void AddValue(T value);

		public static implicit operator T(BaseVariable<T> var)
		{
			return var.Value;
		}

		public void OnAfterDeserialize()
		{
			if (resetInRuntime)
				_value = initValue;
		}

		public void OnBeforeSerialize() { }
	}
}
