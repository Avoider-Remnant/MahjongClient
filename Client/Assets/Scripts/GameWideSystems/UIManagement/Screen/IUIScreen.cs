using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameWideSystems.UIManagement.Screen
{
    public interface IUIScreen
    {
        public CanvasGroup RootCanvasGroup { get; }
        public ScreenType ScreenType { get; }
        public IUIScreenBuilder ScreenBuilder { get; }

        public void Initialize(IScreenParams screenParams);
        public UniTask OnBeforeOpen(CancellationToken cancellationToken);
        public UniTask OnOpen(CancellationToken cancellationToken);
        public UniTask OnClose(CancellationToken cancellationToken);
        public UniTask OnCloseSilently(CancellationToken cancellationToken);
        public UniTask OnOverlayRemoved(IScreenSerializationData closedOverlay, CancellationToken cancellationToken) { return UniTask.CompletedTask;}
        public UniTask OnBecomeOverlaid(CancellationToken cancellationToken) { return UniTask.CompletedTask;}
        public (bool isSerialized, IScreenSerializationData serializationData) TrySerializeScreen();
        public UniTask DeserializeScreen(IScreenSerializationData screenSerializationData);
        public void SetScreenBuilder(IUIScreenBuilder screenBuilder);

    }
}