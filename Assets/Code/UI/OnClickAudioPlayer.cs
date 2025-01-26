using Audio;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
	public class OnClickAudioPlayer : MonoBehaviour, IPointerUpHandler
	{
		[SerializeField] private RandomAudioProviderSo _audioProvider;

		public void OnPointerUp(PointerEventData eventData) =>
			AudioSource.PlayClipAtPoint(_audioProvider.GetRandom(), transform.position);
	}
}