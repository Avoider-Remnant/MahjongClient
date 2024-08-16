using System.Threading;
using Cysharp.Threading.Tasks;
using Game.GameMode.Initializer;
using GameWideSystems.AudioManager;
using GameWideSystems.GameStateManagement;
using UnityEngine;
using Zenject;

namespace Game.GameInitialization
{
    public class GameInitializer : MonoBehaviour
    {
        private AudioManager _audioManager;
        private InitializationGameMode _initializationGameMode;
        private GameStateManager _gameStateManager;
        
        [Inject]
        private void Construct(AudioManager audioManager, InitializationGameMode initializationGameMode, GameStateManager gameStateManager)
        {
            _audioManager = audioManager;
            _initializationGameMode = initializationGameMode;
            _gameStateManager = gameStateManager;
        }
        
        private void Start()
        {
            Initialize(Application.exitCancellationToken).Forget();
        }
        
        private async UniTask Initialize(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Transform proceduralHolderTransform = FindAnyObjectByType<ProjectContext>().transform;
            
            _audioManager.Initialize(proceduralHolderTransform);

            await _gameStateManager.AppendGameState(_initializationGameMode, cancellationToken);
        }
        
    }
}