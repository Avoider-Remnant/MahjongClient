using GameWideSystems.AudioManager;
using GameWideSystems.GameSceneManager;
using GameWideSystems.GameStateManagement;
using GameWideSystems.LocalizationWrapper;
using GameWideSystems.SessionManager;
using GameWideSystems.UIManagement;
using UnityEngine;
using Zenject;
using Logger = GameWideSystems.Logger.Logger;

namespace Structure.GameInstalling
{
    [CreateAssetMenu(menuName = "Game/Dev/Project Wide/Structure/System Installer")]
    public class GameWideSystemsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private AudioManagerConfigurations _audioManagerConfigurations;
        [SerializeField] private GameObject _uiManagementPrefab;
        
        public override void InstallBindings()
        {
            InstallLogger();
            InstallAudioManager();
            InstallGameSceneMana();
            InstallGameStateManager();
            InstallLocalization();
            InstallUIManager();
            InstallSession();
        }

        private void InstallSession()
        {
            Container.Bind<SessionContainer>().To<SessionContainer>().AsSingle();
            Container.Bind<ISessionBuilder>().To<SessionBuilder>().AsSingle();
        }

        private void InstallUIManager()
        {
            Container.Bind<IScreenHotsProvider>().FromComponentInNewPrefab(_uiManagementPrefab).AsSingle().NonLazy();
            Container.Bind<UIManager>().To<UIManager>().AsSingle();
        }

        private void InstallLocalization()
        {
            Container.Bind<ILocalizationManager>().To<LocalizationManager>().AsSingle();
        }

        private void InstallLogger()
        {
            Container.Bind<Logger>().ToSelf().AsSingle();
        }

        private void InstallAudioManager()
        {
            Container.Bind<AudioManagerConfigurations>().FromInstance(_audioManagerConfigurations).AsSingle();
            Container.Bind<AudioManager>().To<AudioManager>().AsSingle().NonLazy();
        }
        
        private void InstallGameSceneMana()
        {
            Container.Bind<IGameSceneManager>().To<GameSceneManager>().AsSingle().NonLazy();
        }

        private void InstallGameStateManager()
        {
            Container.Bind<GameStateManager>().To<GameStateManager>().AsSingle();
        }
        
        
    }
}