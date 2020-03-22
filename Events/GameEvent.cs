using Die4Games.ModularScript.Behaviours;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Die4Games.ModularScript.Events
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Die4Games/ModularScript/Events/GameEvent")]
    public class GameEvent : ScriptableObject, ISerializationCallbackReceiver
	{
		public List<GameEventListener> baseListeners = new List<GameEventListener>();
		public List<GameBehaviour> gameBehaviours = new List<GameBehaviour>();
		public UnityAction actions;
		internal bool hasBeenRaised = false;

		public void Raise()
		{
			foreach (GameEventListener _listener in baseListeners)
			{
				_listener?.OnEventRaised();
			}

			foreach (GameBehaviour _behaviour in gameBehaviours)
			{
				_behaviour?.Behave();
			}

			actions?.Invoke();
			hasBeenRaised = true;
		}

		public void RegisterAction(UnityAction newAction)
		{
			actions += newAction;
		}

		public void UnregisterAction(UnityAction newAction)
		{
			actions -= newAction;
		}

		public void RegisterListener(GameEventListener _eventableToAdd)
		{
			if (!baseListeners.Contains(_eventableToAdd))
			{
				baseListeners.Add(_eventableToAdd);
			}
		}

		public void RegisterListener(GameBehaviour _eventableToAdd)
		{
			if (!gameBehaviours.Contains(_eventableToAdd))
			{
				gameBehaviours.Add(_eventableToAdd);
			}
		}

		public void UnregisterListener(GameEventListener _eventableToRemove)
		{
			if (baseListeners.Contains(_eventableToRemove))
			{
				baseListeners.Remove(_eventableToRemove);
			}
		}

		public void UnregisterListener(GameBehaviour _eventableToRemove)
		{
			if (gameBehaviours.Contains(_eventableToRemove))
			{
				gameBehaviours.Remove(_eventableToRemove);
			}
		}

		public void OnAfterDeserialize()
		{
			baseListeners.Clear();
			gameBehaviours.Clear();
			hasBeenRaised = false;
		}

		public void OnBeforeSerialize()
		{
		}
	}
}