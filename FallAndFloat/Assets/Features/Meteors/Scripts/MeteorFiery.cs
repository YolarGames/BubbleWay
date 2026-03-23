using System.Collections;
using Features.Bubbles;
using PrimeTween;
using UnityEngine;
using YolarUtils.Extension;

namespace Features.Meteors
{
	[SelectionBase, RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
	internal sealed class MeteorFiery : Meteor
	{
		[SerializeField] private ParticleSystem _fireParticles;
		[SerializeField] private AudioClip _fireExtinguish;
		private static readonly WaitForSeconds s_waitForBubbleDisappear = new(0.2f);

		protected override void InteractWithBubble(Bubble bubble)
		{
			if (!IsFittingSize(bubble))
			{
				bubble.Pop();
				return;
			}

			if (_fireParticles.isPlaying)
			{
				_fireParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
				StartCoroutine(PopBubble(bubble));
				return;
			}

			base.InteractWithBubble(bubble);
		}

		private IEnumerator PopBubble(Bubble bubble)
		{
			bubble.transform.SetParent(transform);
			bubble.SetConsumedMeteorState();
			_fireExtinguish.Play();

			yield return s_waitForBubbleDisappear;

			Tween.Scale(bubble.transform, Vector3.zero, 0.5f);
		}
	}
}