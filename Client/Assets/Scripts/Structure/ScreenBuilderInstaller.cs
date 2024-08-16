using Game.GameMode.Login.UI.ScreenBuilders;
using UnityEngine;
using Zenject;

namespace Structure.GameInstalling
{
    [CreateAssetMenu(menuName = "Game/Dev/Project Wide/Structure/Screen Builder Installer")]
    public class ScreenBuilderInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LogInScreenBuilder>().To<LogInScreenBuilder>().AsSingle();
        }
        
    }
}