using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameWideSystems.AudioManager
{
    public class SFXPoolPlayer
    {
        private Queue<AudioSource> _freeAudioSources;

        public SFXPoolPlayer(AudioSource sfxAudioPrefab, int sfxPoolSize, Transform sfxPoolTransform)
        {
            _freeAudioSources = new Queue<AudioSource>(sfxPoolSize);
            
            for (int i = 0; i < sfxPoolSize; i++)
            {
                AudioSource audioSource = Object.Instantiate(sfxAudioPrefab, sfxPoolTransform);
                _freeAudioSources.Enqueue(audioSource);
                audioSource.gameObject.SetActive(false);
            }
            
        }

        public async UniTask PlaySFX(AudioClip clip, CancellationToken cancellationToken)
        {
            if (!_freeAudioSources.TryDequeue(out AudioSource audioSource))
            {
                return;
            }
            
            audioSource.gameObject.SetActive(true);
            audioSource.PlayOneShot(clip);
            
            await UniTask.WaitForSeconds(clip.length, cancellationToken: cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            
            audioSource.gameObject.SetActive(false);
            _freeAudioSources.Enqueue(audioSource);
            
        }
        
    }
}