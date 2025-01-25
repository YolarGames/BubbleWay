using Infrastructure;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

namespace Input
{
	public class InputReader : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
	{
		public void OnPointerDown(PointerEventData eventData)
		{
			Vector3 screenToWorldPoint = StaticData.Camera.ScreenToWorldPoint(eventData.position);
			screenToWorldPoint.z = 0f;
			GameEvents.InvokeOnBubbleBlow(screenToWorldPoint);
		}

		public void OnPointerUp(PointerEventData eventData) =>
			GameEvents.InvokeOnBubbleEndBlow();
	}
}