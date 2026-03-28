using Features.Bubbles;
using Features.Meteors;
using UnityEngine;
using VContainer;

namespace Features.Abilities
{
	internal class PerfectCatch : Ability
	{
		private BubbleSpawner _bubbleSpawner;

		public override void Use()
		{
			Meteor[] meteors = FindObjectsByType<Meteor>(FindObjectsSortMode.None);

			foreach (Meteor meteor in meteors)
				_bubbleSpawner.BlowBubbleAt(meteor.transform.position.x, meteor.Size);
		}

		public override void Cleanup() { }

		[Inject]
		private void Construct(BubbleSpawner bubbleSpawner) =>
			_bubbleSpawner = bubbleSpawner;
	}
}