using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace GameWideSystems.GameSceneManager
{
    public class GameSceneManager : IGameSceneManager
    {
        public async UniTask OpenScene(
            string sceneName, 
            LoadSceneMode loadSceneMode, 
            LoadingScreenParams loadingScreenParams = null, CancellationToken cancellationToken = default)
        {
            if (loadingScreenParams is not null)
            {
                await LoadingWithProgressReporting(sceneName, loadSceneMode, loadingScreenParams, cancellationToken);
            }
            else
            {
                await LoadSceneInternal(sceneName, loadSceneMode, cancellationToken);
            }
        }

        public async UniTask UnloadScene(string sceneName, CancellationToken cancellationToken = default)
        {
            await SceneManager.UnloadSceneAsync(sceneName).ToUniTask(cancellationToken: cancellationToken);
        }

        private async UniTask LoadingWithProgressReporting(string sceneName, LoadSceneMode loadSceneMode, LoadingScreenParams loadingScreenParams, CancellationToken cancellationToken = default)
        {
            loadingScreenParams.LoadingScreen.Show();

            await SceneManager.LoadSceneAsync(sceneName, loadSceneMode)
                .ToUniTask(
                new Progress<float>(item => loadingScreenParams.LoadingScreen.UpdateProgress(item, null)), 
                cancellationToken: cancellationToken);
            
            if (loadingScreenParams.IsLoadingScreenClosedAutomatically)
            {
                loadingScreenParams.LoadingScreen.Hide();
            }
        }

        private async UniTask LoadSceneInternal(string sceneName, LoadSceneMode loadSceneMode, CancellationToken cancellationToken = default)
        {
            await SceneManager.LoadSceneAsync(sceneName, loadSceneMode).ToUniTask(cancellationToken: cancellationToken);
        }
        
    }
}