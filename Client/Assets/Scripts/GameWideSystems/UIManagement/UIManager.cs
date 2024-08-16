using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameWideSystems.UIManagement.Screen;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GameWideSystems.UIManagement
{
    public class UIManager
    {
        private readonly IScreenHotsProvider _screenHosts;
        private Stack<IUIScreen> _gameScreens = new();
        private Dictionary<Type, IUIScreen> _systemScreens;
        
        private Dictionary<Type, IUIScreen> _preloadedScreens;
        
        public UIManager(IScreenHotsProvider screenHosts)
        {
            _screenHosts = screenHosts;
        }

        public async UniTask OpenScreen(
            IUIScreenBuilder screenBuilder,
            IScreenParams screenParams,
            bool awaitClosure = false,
            bool isClosedSilently = false,
            CancellationToken cancellationToken = default)
        {
            Transform tileHolder = _screenHosts.GameHost;
            IUIScreen gameObject = await screenBuilder.Build(tileHolder, screenParams, cancellationToken);
            gameObject.RootCanvasGroup.gameObject.SetActive(false);

            if (screenBuilder.ScreenType == ScreenType.Screen)
            {
                if (!isClosedSilently)
                {
                    await CloseAllPopUps(false, awaitClosure, cancellationToken);
                    cancellationToken.ThrowIfCancellationRequested();
                }
                else
                {
                    CloseAllPopUps(true, awaitClosure, cancellationToken).Forget();
                }
            }
            
            await gameObject.RootCanvasGroup.gameObject.GetComponent<IUIScreen>().OnOpen(cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
        }

        public async UniTask DeserializeScreen(
            List<IScreenSerializationData> screenSerializationDatas, 
            CancellationToken cancellationToken = default)
        {
            await CloseAllPopUps(true, true, cancellationToken);
            
            foreach (IScreenSerializationData item in screenSerializationDatas)
            {
                await item.ScreenBuilder.Build(_screenHosts.GameHost, item.ScreenParams, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }
        
        public List<IScreenSerializationData> GetScreenSerializationDatas()
        {
            List<IScreenSerializationData> result = _gameScreens
                .Select(item => item.TrySerializeScreen())
                .Where(item => item.isSerialized)
                .Select(item => item.serializationData)
                .ToList();

            result.Reverse();

            return result;
        }

        public async UniTask CloseAllPopUps(
            bool isClosedSilently, 
            bool awaitClosure, 
            CancellationToken cancellationToken)
        {
            while (_gameScreens.TryPeek(out IUIScreen screen) && screen.ScreenType == ScreenType.PopUp)
            {
                IUIScreen uiScreen = _gameScreens.Pop();
                await CloseScreen(uiScreen, isClosedSilently, awaitClosure, cancellationToken);
            }
        }

        public async UniTask CloseTopScreen(
            bool isClosedSilently, 
            bool awaitClosure, 
            CancellationToken cancellationToken)
        {
            if (_gameScreens.Count == 0)
            {
                return;
            }
            
            IUIScreen uiScreen = _gameScreens.Pop();
            
            if (awaitClosure)
            {
                await CloseScreenInternal(uiScreen, isClosedSilently, cancellationToken);
            }
            else
            {
                CloseScreenInternal(uiScreen, isClosedSilently, cancellationToken).Forget();
            }
        }

        private async UniTask CloseScreen(
            IUIScreen uiScreen, 
            bool isClosedSilently, 
            bool awaitClosure, 
            CancellationToken cancellationToken)
        {
            if (awaitClosure)
            {
                await CloseScreenInternal(uiScreen, isClosedSilently, cancellationToken);
            }
            else
            {
                CloseScreenInternal(uiScreen, isClosedSilently, cancellationToken).Forget();
            }
        }

        private async UniTask CloseScreenInternal(
            IUIScreen uiScreen, 
            bool isClosedSilently, 
            CancellationToken cancellationToken)
        {
            if (isClosedSilently)
            {
                await uiScreen.OnCloseSilently(cancellationToken);
            }
            else
            {
                await uiScreen.OnClose(cancellationToken);
            }
            
            Addressables.ReleaseInstance(uiScreen.RootCanvasGroup.gameObject);
        }
        
    }
}