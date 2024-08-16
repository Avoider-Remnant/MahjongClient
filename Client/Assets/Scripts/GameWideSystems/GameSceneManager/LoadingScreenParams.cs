namespace GameWideSystems.GameSceneManager
{
    public class LoadingScreenParams
    {
        public readonly ILoadingScreen LoadingScreen;
        public readonly bool IsLoadingScreenClosedAutomatically;

        public LoadingScreenParams(ILoadingScreen loadingScreen, bool isLoadingScreenClosedAutomatically)
        {
            LoadingScreen = loadingScreen;
            IsLoadingScreenClosedAutomatically = isLoadingScreenClosedAutomatically;
        }
    }
}