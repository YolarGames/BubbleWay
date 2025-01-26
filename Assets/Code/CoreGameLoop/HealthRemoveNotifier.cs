using Infrastructure;
using StaticData;
using UnityEngine;

namespace CoreGameLoop
{
	public class HealthRemoveNotifier : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag(Tags.Meteor))
				GameEvents.InvokeOnDamage();
		}
	}
}