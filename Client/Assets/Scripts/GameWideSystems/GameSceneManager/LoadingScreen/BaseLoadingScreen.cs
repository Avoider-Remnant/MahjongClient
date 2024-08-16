using UnityEngine;

namespace GameWideSystems.GameSceneManager.LoadingScreen
{
    public class BaseLoadingScreen : MonoBehaviour, ILoadingScreen
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void UpdateProgress(float operationProgress, string message)
        {
            
        }
        
    }
}