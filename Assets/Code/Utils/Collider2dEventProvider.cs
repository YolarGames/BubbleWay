using System;
using UnityEngine;

namespace Utils
{
	public class Collider2dEventProvider : MonoBehaviour
	{
		public event Action<Collision2D> OnCollisionEnterEvent = delegate { };
		public event Action<Collision2D> OnCollisionExitEvent = delegate { };
		public event Action<Collision2D> OnCollisionStayEvent = delegate { };
		public event Action<Collider2D> OnTriggerEnterEvent = delegate { };
		public event Action<Collider2D> OnTriggerExitEvent = delegate { };
		public event Action<Collider2D> OnTriggerStayEvent = delegate { };

		private void OnCollisionEnter2D(Collision2D collision)
		{
			OnCollisionEnterEvent(collision);
		}

		private void OnCollisionExit2D(Collision2D collision)
		{
			OnCollisionExitEvent(collision);
		}

		private void OnCollisionStay2D(Collision2D collision)
		{
			OnCollisionStayEvent(collision);
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			OnTriggerEnterEvent(col);
		}

		private void OnTriggerExit2D(Collider2D col)
		{
			OnTriggerExitEvent(col);
		}

		private void OnTriggerStay2D(Collider2D col)
		{
			OnTriggerStayEvent(col);
		}
	}
}