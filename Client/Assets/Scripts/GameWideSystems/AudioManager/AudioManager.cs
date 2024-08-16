using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameWideSystems.AudioManager
{
    public class AudioManager
    {
        private SFXPoolPlayer _sfxPlayer;
        private AudioSource _musicPlayer;
        private AudioManagerConfigurations _audioManagerConfigurations;

        public AudioManager(AudioManagerConfigurations audioManagerConfigurations)
        {
            _audioManagerConfigurations = audioManagerConfigurations;
        }

        public void Initialize(Transform managerRoot)
        { 
            Transform audioManagerTransform = new GameObject("AudioManager").transform;
            audioManagerTransform.SetParent(managerRoot);

            InitializeSFXPool(audioManagerTransform);
            InitializeMusicPlayer(audioManagerTransform);

        }
        
        public UniTask PlaySFX(AudioClip audioClip, CancellationToken cancellationToken)
        {
            return _sfxPlayer.PlaySFX(audioClip, cancellationToken);
        }

        public void PlayMusic(AudioClip audioClip)
        {
            _musicPlayer.clip = audioClip;
        }
        
        private void InitializeSFXPool(Transform parent)
        {
            GameObject sfxPool = new("SFX audio pool");
            
            sfxPool.transform.SetParent(parent);
            
            _sfxPlayer = new SFXPoolPlayer(_audioManagerConfigurations.SFXAudioPrefab, _audioManagerConfigurations.SFXPoolSize, 
                sfxPool.transform);
        }

        private void InitializeMusicPlayer(Transform parent)
        {
            GameObject musicPool = new("Music source holder");
            musicPool.transform.SetParent(parent);

            Object.Instantiate(_audioManagerConfigurations.MusicAudioPrefab, musicPool.transform);
        }
        
        
    }
}