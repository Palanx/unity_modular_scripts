using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Die4Games.ModularScript.Events
{
	[AddComponentMenu("Die4Games/Events/GameEventListener")]
	public class GameEventListener : MonoBehaviour
    {
		public GameEvent Event;

		public List<UnityEvent> Responses = new List<UnityEvent>();

		public void OnEnable()
		{
			if (Event)
				Event.RegisterListener(this);
		}

		public void OnDisable()
		{
			if (Event)
				Event.UnregisterListener(this);
		}

		public void OnEventRaised()
		{
			foreach (UnityEvent currentResponse in Responses)
			{
				currentResponse.Invoke();
			}
		}
	}
}