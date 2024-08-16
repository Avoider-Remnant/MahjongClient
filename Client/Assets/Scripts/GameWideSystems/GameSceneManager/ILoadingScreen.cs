namespace GameWideSystems.GameSceneManager
{
    public interface ILoadingScreen
    {
        public void Show();
        public void Hide();
        public void UpdateProgress(float operationProgress, string message);
    }
}