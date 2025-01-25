using Infrastructure;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;
using YolarUtils.Extension;

namespace Input
{
	public class InputReader : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
	{
		public void OnPointerDown(PointerEventData eventData) =>
			GameEvents.InvokeOnBubbleBlow(GetScreenToWorldInputPoint(eventData));

		public void OnPointerUp(PointerEventData eventData) =>
			GameEvents.InvokeOnBubbleEndBlow();

		private static Vector3 GetScreenToWorldInputPoint(PointerEventData eventData) =>
			CameraUtils.Camera.ScreenToWorldPoint(eventData.position).SetZ(0);
	}
}