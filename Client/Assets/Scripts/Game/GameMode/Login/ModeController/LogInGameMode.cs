using System.Threading;
using Cysharp.Threading.Tasks;
using GameWideSystems.GameStateManagement;

namespace Game.GameMode.Login.ModeController
{
    public class LogInGameMode : IGameStateController
    {
        public UniTask Initialize(CancellationToken cancellationToken = default)
        {
            
            
            
            return UniTask.CompletedTask;
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
            return UniTask.CompletedTask;
        }

        public UniTask<bool> TryGetSaveState(out IGameStateSerializationData gameStateSerializationData,
            CancellationToken cancellationToken = default)
        {
            gameStateSerializationData = null;
            return UniTask.FromResult(true);
        }
    }
}