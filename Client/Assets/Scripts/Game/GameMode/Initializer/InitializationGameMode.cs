using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.GameMode.Login.UI.ScreenBuilders;
using GameWideSystems.GameStateManagement;
using GameWideSystems.UIManagement;

namespace Game.GameMode.Initializer
{
    public class InitializationGameMode : IGameStateController
    {
        private LogInScreenBuilder _logInScreenBuilder;
        private UIManager _uiManager;

        public InitializationGameMode(LogInScreenBuilder logInScreenBuilder, UIManager uiManager)
        {
            _logInScreenBuilder = logInScreenBuilder;
            _uiManager = uiManager;
        }

        public async UniTask Initialize(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _uiManager.OpenScreen(_logInScreenBuilder, null, cancellationToken: cancellationToken);
        }

        public UniTask Unload(CancellationToken cancellationToken = default)
        {
            return UniTask.CompletedTask;
        }
        
        public UniTask Load(IGameStateSerializationData gameStateSerializationData, CancellationToken cancellationToken = default)
        {
            return UniTask.CompletedTask;
        }

        public UniTask Close(CancellationToken cancellationToken = default)
        {
            throw new Exception("Attempting to close game initializer");
        }

        public UniTask<bool> TryGetSaveState(out IGameStateSerializationData gameStateSerializationData,
            CancellationToken cancellationToken = default)
        {
            gameStateSerializationData = null;
            return UniTask.FromResult<bool>(false);
        }
    }
}