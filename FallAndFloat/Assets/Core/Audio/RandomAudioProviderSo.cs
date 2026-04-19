using System.Linq;
using UnityEngine;
using YolarUtils.Extension;

namespace Core.Audio
{
	[CreateAssetMenu(fileName = "RandomAudioProvider_name", menuName = "Audio/Random Audio Provider")]
	public class RandomAudioProviderSo : ScriptableObject
	{
		[SerializeField] private bool _excludeLastPlayed;
		[SerializeField] private AudioClip[] _audioClips;
		private AudioClip _lastPlayedClip;

		public static implicit operator AudioClip(RandomAudioProviderSo providerSo) =>
			providerSo.Get();

		private AudioClip Get()
		{
			Debug.Assert(_audioClips.Length != 0, "No audio clips provided");

			return _excludeLastPlayed
				? GetRandomExcludingLastPlayed()
				: _audioClips.GetRandom();
		}

		private AudioClip GetRandomExcludingLastPlayed()
		{
			if (_lastPlayedClip.NotNull())
				return GetClipsExcludingLastPlayed().GetRandom();

			AudioClip randomClip = _audioClips.GetRandom();
			_lastPlayedClip = randomClip;
			return randomClip;
		}

		private AudioClip[] GetClipsExcludingLastPlayed() =>
			_audioClips.Where(clip => clip != _lastPlayedClip).ToArray();
	}
}