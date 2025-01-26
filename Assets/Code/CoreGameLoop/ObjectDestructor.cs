using UnityEngine;

namespace CoreGameLoop
{
	[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
	public class ObjectDestructor : MonoBehaviour
	{
		[SerializeField] private string _tag;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (_tag == string.Empty || CompareTag(_tag))
				Destroy(other.gameObject);
		}
	}
}