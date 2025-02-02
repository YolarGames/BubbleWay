using Infrastructure;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VContainer;
using YolarUtils.Extension;

namespace UI
{
	public class UiInputReader : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
	{
		private Camera _camera;
		public Graphic TargetGraphics { get; private set; }

		public void OnPointerDown(PointerEventData eventData) =>
			GameEvents.InvokeOnBubbleBlow(GetScreenToWorldInputPoint(eventData));

		public void OnPointerUp(PointerEventData eventData) =>
			GameEvents.InvokeOnBubbleEndBlow();

		[Inject]
		private void Construct(Camera cam)
		{
			_camera = cam;
			TargetGraphics = GetComponent<Graphic>();
		}

		private Vector3 GetScreenToWorldInputPoint(PointerEventData eventData) =>
			_camera.ScreenToWorldPoint(eventData.position).SetZ(0);
	}
}