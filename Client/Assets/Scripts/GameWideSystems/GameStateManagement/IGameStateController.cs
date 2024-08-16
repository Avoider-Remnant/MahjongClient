using System.Threading;
using Cysharp.Threading.Tasks;

namespace GameWideSystems.GameStateManagement
{
    public interface IGameStateController
    {
        public UniTask Initialize(CancellationToken cancellationToken = default);
        public UniTask Unload(CancellationToken cancellationToken = default);
        public UniTask Load(IGameStateSerializationData gameStateSerializationData, CancellationToken cancellationToken = default);
        public UniTask Close(CancellationToken cancellationToken = default);
        public UniTask<bool> TryGetSaveState(out IGameStateSerializationData gameStateSerializationData, 
            CancellationToken cancellationToken = default);
    }
}