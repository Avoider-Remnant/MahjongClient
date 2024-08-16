using System.Threading;
using Cysharp.Threading.Tasks;
using Game.GameMode.Login.UI.Data;
using Game.GameMode.Login.UI.Screens;
using GameWideSystems.UIManagement;
using GameWideSystems.UIManagement.Screen;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.GameMode.Login.UI.ScreenBuilders
{
    public class LogInScreenBuilder : IUIScreenBuilder
    {
        private LoginGameModeAddressableProvider _loginGameModeAddressableProvider;
        public ScreenType ScreenType => ScreenType.Screen;

        public LogInScreenBuilder(LoginGameModeAddressableProvider loginGameModeAddressableProvider)
        {
            _loginGameModeAddressableProvider = loginGameModeAddressableProvider;
        }
        
        public async UniTask<IUIScreen> Build(Transform screenHolder, IScreenParams screenParams, CancellationToken cancellationToken)
        {
            GameObject screen = await Addressables.InstantiateAsync(_loginGameModeAddressableProvider.LogInScreenPrefab, screenHolder).ToUniTask(cancellationToken: cancellationToken);

            LogInScreen logInScreen = screen.GetComponent<LogInScreen>();
            
            logInScreen.Initialize(screenParams);
            
            return logInScreen;
        }
    }
}