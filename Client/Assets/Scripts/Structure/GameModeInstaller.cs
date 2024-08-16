using Game.GameMode.Initializer;
using Game.GameMode.Login;
using Game.GameMode.Login.ModeController;
using UnityEngine;
using Zenject;

namespace Structure.GameInstalling
{
    [CreateAssetMenu(menuName = "Game/Dev/Project Wide/Structure/Game Mode Installer")]
    public class GameModeInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InitializationGameMode>().To<InitializationGameMode>().AsSingle();
            Container.Bind<LogInGameMode>().To<LogInGameMode>().AsSingle();
            
        }
        
    }
}