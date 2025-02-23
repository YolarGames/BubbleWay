using UnityEngine;

namespace GameLoop
{
	[RequireComponent(typeof(BoxCollider2D))]
	public class ObjectDestructor : MonoBehaviour
	{
		[SerializeField] private string _tag;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (_tag == string.Empty || other.CompareTag(_tag))
				Destroy(other.gameObject);
		}
	}
}