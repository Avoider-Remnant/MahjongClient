using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace GameWideSystems.GameSceneManager
{
    public interface IGameSceneManager
    {
        public UniTask OpenScene(string sceneName, LoadSceneMode loadSceneMode, LoadingScreenParams 
            loadingScreenParams = null, CancellationToken cancellationToken = default);
        public UniTask UnloadScene(string sceneName, CancellationToken cancellationToken = default);
    }
}