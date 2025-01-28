using Infrastructure;
using UnityEngine;
using UnityEngine.EventSystems;
using YolarUtils.Extension;

namespace Input
{
	public class InputReader : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
	{
		private static Camera s_camera;

		public void OnPointerDown(PointerEventData eventData) =>
			GameEvents.InvokeOnBubbleBlow(GetScreenToWorldInputPoint(eventData));

		public void OnPointerUp(PointerEventData eventData) =>
			GameEvents.InvokeOnBubbleEndBlow();

		private static Vector3 GetScreenToWorldInputPoint(PointerEventData eventData)
		{
			s_camera ??= Camera.main;
			return s_camera.ScreenToWorldPoint(eventData.position).SetZ(0);
		}
	}
}