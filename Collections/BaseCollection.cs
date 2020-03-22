using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Die4Games.ModularScript.Interfaces;

namespace Die4Games.ModularScript.Collections
{
	public abstract class BaseCollection<T> : BaseScriptableObject, IOnChangeHandler, ISerializationCallbackReceiver, IEnumerable<T>
	{
		public T this[int index]
		{
			get
			{
				return _list[index];
			}
			set
			{
				_list[index] = value;
			}
		}

		[SerializeField]
		private List<T> _list = new List<T>();

		public List<T> List
		{
			get
			{
				return _list;
			}
		}

		public Type Type
		{
			get
			{
				return typeof(T);
			}
		}

		public int Count { get { return List.Count; } }

		public virtual bool Add(T obj)
		{
			if (!_list.Contains(obj))
				_list.Add(obj);
			else
				return false;

			OnChange();
			return true;
		}

		public virtual void Insert(int index, T value)
		{
			_list.Insert(index, value);

			OnChange();
		}

		public virtual bool Remove(T obj)
		{
			if (_list.Contains(obj))
				_list.Remove(obj);
			else
				return false;

			OnChange();
			return true;
		}

		public virtual void RemoveAt(int index)
		{
			_list.RemoveAt(index);

			OnChange();
		}

		public virtual void Clear()
		{
			_list.Clear();

			OnChange();
		}

		public virtual bool Contains(T value)
		{
			return _list.Contains(value);
		}

		/// <summary>
		/// Returns if the list contains an item of ID. It required a type of AnvilScriptableObject
		/// This has a lot of casts, use with caution.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool ContainsByID(int id)
		{
			if (!(this is BaseScriptableObject))
			{
				Debug.LogError($"Cannot 'ContainsByID' on '{this.name}' of type '{this.GetType()}' is not an BaseScriptableObject, failsafed to false", this);
				return false;
			}

			return _list.Exists((x) => ((BaseScriptableObject)(object)x).ID == id);
		}

		/// <summary>
		/// Get the Item by ID, required type AnvilScriptableObject.
		/// This has a lot of casts, use with caution.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public T GetByID(int id)
		{
			if (!(this is BaseScriptableObject))
			{
				Debug.LogError($"Cannot 'GetByID' on '{this.name}' of type '{this.GetType()}' is not an BaseScriptableObject, failsafed to default", this);
				return default;
			}

			return _list.Find((x) => ((BaseScriptableObject)(object)x).ID == id);
		}

		/// <summary>
		/// Get the Item by ID, required type AnvilScriptableObject.
		/// This has a lot of casts, use with caution.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public List<T> GetAllByID(int id)
		{
			if (!(this is BaseScriptableObject))
			{
				Debug.LogError($"Cannot 'GetAllByID' on '{this.name}' of type '{this.GetType()}' is not an BaseScriptableObject, failsafed to default", this);
				return default;
			}

			return _list.FindAll((x) => ((BaseScriptableObject)(object)x).ID == id);
		}

		public T GetRandomItem()
		{
			return _list[UnityEngine.Random.Range(0, _list.Count - 1)];
		}

		public int IndexOf(T value)
		{
			return _list.IndexOf(value);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _list.GetEnumerator();
		}

		public override string ToString()
		{
			return "Collection<" + typeof(T) + ">(" + Count + ")";
		}

		public T[] ToArray()
		{
			return _list.ToArray();
		}

		public void OnBeforeSerialize() {
		}

		public void OnAfterDeserialize()
		{
			if (resetInRuntime)
				_list.Clear();
		}
	}
}
