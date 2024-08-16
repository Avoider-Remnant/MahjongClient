using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameWideSystems.UIManagement;

namespace GameWideSystems.GameStateManagement
{
    public class GameStateManager
    {
        private class GameStateToken
        {
            public IGameStateController GameStateController;
            public IGameStateSerializationData GameStateSerializationData;

            public GameStateToken(IGameStateController gameStateController)
            {
                GameStateController = gameStateController;
            }
        }

        private readonly Stack<GameStateToken> _gameStates = new();
        
        
        public async UniTask AppendGameState(IGameStateController gameStateController, CancellationToken cancellationToken = default)
        {
            if (_gameStates.TryPeek(out GameStateToken gameStateToken))
            {
                bool isSaved = await gameStateToken.GameStateController.TryGetSaveState(out IGameStateSerializationData serializationData, cancellationToken);
                if (isSaved)
                {
                    gameStateToken.GameStateSerializationData = serializationData;
                }
                
                await gameStateToken.GameStateController.Unload(cancellationToken);
            }

            _gameStates.Push(new GameStateToken(gameStateController));
            await gameStateController.Initialize(cancellationToken);
        }

        public async UniTask CloseCurrentGameState(bool reloadPrevious, CancellationToken cancellationToken = default)
        {
            // Last state will "restart" game, so it should be always present
            if (_gameStates.Count == 1)
            {
                return;
            }
            
            await _gameStates.Pop()
                .GameStateController
                .Close(cancellationToken);

            if (!reloadPrevious)
            {
                return;
            }
            
            await _gameStates.Peek()
                .GameStateController
                .Load(_gameStates.Peek().GameStateSerializationData, cancellationToken);
        }

        public async UniTask CloseAll(CancellationToken cancellationToken = default)
        {
            while (_gameStates.Count > 1)
            {
                await _gameStates.Pop().GameStateController.Close(cancellationToken);
            }

            await _gameStates.Peek()
                .GameStateController.Load(_gameStates.Peek().GameStateSerializationData, cancellationToken);
        }
    }
}