using System.Threading;
using Cysharp.Threading.Tasks;
using GameWideSystems.UIManagement;
using GameWideSystems.UIManagement.Screen;
using UnityEngine;

namespace Game.GameMode.Login.UI.Screens
{
    public class LogInScreen : MonoBehaviour, IUIScreen
    {
        [field: SerializeField] public CanvasGroup RootCanvasGroup { get; private set; }
        
        public ScreenType ScreenType => ScreenType.Screen;
        public IUIScreenBuilder ScreenBuilder { get; }

        public void Initialize(IScreenParams screenParams)
        {
            
        }

        public UniTask OnBeforeOpen(CancellationToken cancellationToken)
        {
            
            
            
            return UniTask.CompletedTask;
        }

        public UniTask OnOpen(CancellationToken cancellationToken)
        {
            gameObject.SetActive(true);
            return UniTask.CompletedTask;
        }

        public UniTask OnClose(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public UniTask OnCloseSilently(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public (bool isSerialized, IScreenSerializationData serializationData) TrySerializeScreen()
        {
            throw new System.NotImplementedException();
        }

        public UniTask DeserializeScreen(IScreenSerializationData screenSerializationData)
        {
            throw new System.NotImplementedException();
        }

        public void SetScreenBuilder(IUIScreenBuilder screenBuilder)
        {
            throw new System.NotImplementedException();
        }
    }
}