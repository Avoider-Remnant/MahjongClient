namespace GameWideSystems.UIManagement.Screen
{
    public interface IScreenSerializationData
    {
        public IUIScreenBuilder ScreenBuilder { get; }
        public IScreenParams ScreenParams { get; }
    }
}