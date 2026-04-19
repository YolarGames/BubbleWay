using System.Collections.Generic;
using System.Linq;
using UnityEngine.Audio;
using YolarUtils.Extension;

namespace Core.Audio
{
	internal class AudioSourcePool
	{
		private readonly AudioSourceFactory _factory;
		private readonly List<AudioEntity> _entities;

		public AudioSourcePool(AudioMixerGroup sfxMixer)
		{
			_factory = new AudioSourceFactory(sfxMixer);
			_entities = new List<AudioEntity>(16);
		}

		public AudioEntity Get()
		{
			AudioEntity freeSource = GetFirstFreeEntity();

			if (freeSource.NotNull())
				return freeSource;

			freeSource = _factory.Create();
			_entities.Add(freeSource);
			return freeSource;
		}

		private AudioEntity GetFirstFreeEntity() =>
			_entities.FirstOrDefault(source => !source.IsPlaying);
	}
}