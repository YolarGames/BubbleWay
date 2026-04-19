using UnityEngine;
using UnityEngine.Audio;
using YolarUtils.Extension;

namespace Core.Audio
{
	public class AudioSourceFactory : IAudioSourceFactory
	{
		private readonly AudioMixerGroup _sfxMixer;
		private readonly Transform _audioSourceParent;

		public AudioSourceFactory(AudioMixerGroup sfxMixer)
		{
			_sfxMixer = sfxMixer;
			_audioSourceParent = new GameObject("[parent] audio sources").transform;
			_audioSourceParent.DontDestroyOnLoad();
		}

		public AudioEntity Create()
		{
			var go = new GameObject("audio entity");

			var source = go.AddComponent<AudioSource>();
			source.outputAudioMixerGroup = _sfxMixer;
			source.transform.SetParent(_audioSourceParent);

			var audioEntity = source.gameObject.AddComponent<AudioEntity>();
			audioEntity.Init(source);

			return audioEntity;
		}
	}

	public interface IAudioSourceFactory
	{
		AudioEntity Create();
	}
}