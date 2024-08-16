using UnityEngine;

namespace GameWideSystems.AudioManager
{
    [CreateAssetMenu(menuName = "Game/Dev/Manager Configurations/Audio Manager Configurations")]
    public class AudioManagerConfigurations : ScriptableObject
    {
        [field: SerializeField] public AudioSource SFXAudioPrefab { get; private set; }
        [field: SerializeField] public int SFXPoolSize { get; private set; }

        [field: SerializeField] public AudioSource MusicAudioPrefab { get; private set; }
        
    }
}