using UnityEngine;
using UnityEngine.Audio;

namespace Core.Audio
{
	[CreateAssetMenu(fileName = "audio-service-config", menuName = "Fall And Float/Configs/AudioService config")]
	public class AudioServiceConfigSo : ScriptableObject
	{
		[field: SerializeField] public AudioMixerGroup SfxMixer { get; private set; }
		[field: SerializeField] public AudioMixerGroup MusicMixer { get; private set; }
	}
}