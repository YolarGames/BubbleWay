using UnityEngine;

namespace UI
{
	public class House : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _fireParticles;

		public bool IsBurning { get; private set; }

		public void SetOnFire()
		{
			IsBurning = true;
			_fireParticles.Play();
		}
	}
}