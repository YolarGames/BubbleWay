using System.Linq;
using Features.Bubbles;
using UnityEngine;

namespace Features.Meteors
{
	internal sealed class MeteorIcy : Meteor
	{
		[SerializeField] private GameObject[] _iceFragments;
		[SerializeField] private ParticleSystem _iceParticles;

		protected override void InteractWithBubble(Bubble bubble)
		{
			if (IsIceRemoved())
				base.InteractWithBubble(bubble);
			else
			{
				RemoveIce();
				bubble.Pop();
			}
		}

		private void RemoveIce()
		{
			GameObject fragment = _iceFragments.First(fragment => fragment.activeSelf);
			fragment.SetActive(false);
			Instantiate(_iceParticles, fragment.transform.position, fragment.transform.rotation);
		}

		private bool IsIceRemoved() =>
			_iceFragments.All(fragment => !fragment.activeSelf);
	}
}