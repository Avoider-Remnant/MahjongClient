using GameWideSystems.InputManager;
using GameWideSystems.InputManager.ReadingCores;
using GameWideSystems.InputManager.ReadingCores.Pointer;
using UnityEngine;
using Zenject;

namespace Structure.GameInstalling
{
    [CreateAssetMenu(menuName = "Game/Dev/Project Wide/Structure/Input Installer")]
    public class InputInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PointerInputConfigurations PointerInputConfigurations;
        
        public override void InstallBindings()
        {
            InstallInputs();
        }
        
        private void InstallInputs()
        {
            Container.Bind<PointerInputConfigurations>().FromInstance(PointerInputConfigurations).AsSingle();

            Container.Bind<IInputHost>().To<InputHost>().FromNew().AsSingle().NonLazy();
            Container.Bind<IInputReadingCore>().To<PointerCore>().FromNew().AsSingle().NonLazy();
            Container.Bind<InputReader>().To<InputReader>().FromNew().AsSingle().NonLazy();

            Container.BindInterfacesTo<IInputReadingCore>().FromResolve().AsSingle();
        }
        
    }
}