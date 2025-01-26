using UnityEngine;

namespace CoreGameLoop
{
	[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
	public class ObjectDestructor : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D other) =>
			Destroy(other.gameObject);
	}
}