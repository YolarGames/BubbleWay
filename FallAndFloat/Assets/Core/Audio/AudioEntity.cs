using UnityEngine;
using YolarUtils.Extension;

namespace Core.Audio
{
	public class AudioEntity : MonoBehaviour
	{
		private AudioSource _source;
		public bool IsPlaying => _source?.isPlaying ?? false;

		private void Update()
		{
			if (_source.IsNull())
				return;

			if (IsPlaying)
				return;

			Deactivate();
		}

		public void Init(AudioSource source) =>
			_source = source;

		public void PlayOneShot(AudioClip clip)
		{
			gameObject.name = clip.name;
			gameObject.SetActive(true);
			_source.PlayOneShot(clip);
		}

		private void Deactivate()
		{
			gameObject.SetActive(false);
			gameObject.name = "inactive";
		}
	}
}