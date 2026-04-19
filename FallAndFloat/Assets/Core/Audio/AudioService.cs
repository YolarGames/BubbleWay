using UnityEngine;
using UnityEngine.Scripting;

namespace Core.Audio
{
	[Preserve]
	public class AudioService : IAudioService
	{
		private readonly AudioSourcePool _oneShotPool;

		public AudioService(AudioServiceConfigSo config) =>
			_oneShotPool = new AudioSourcePool(config.SfxMixer);

		public void PlayOneShot(AudioClip clip)
		{
			AudioEntity entity = _oneShotPool.Get();
			entity.name = clip.name;
			entity.PlayOneShot(clip);
		}
	}

	public interface IAudioService
	{
		void PlayOneShot(AudioClip clip);
	}
}