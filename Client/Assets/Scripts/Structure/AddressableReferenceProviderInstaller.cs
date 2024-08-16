using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Structure.GameInstalling
{
    
    /// <summary>
    /// Basically self installer for any objects 
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Dev/Project Wide/Structure/Addressable reference provider installer")]
    public class AddressableReferenceProviderInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private List<ScriptableObject> _dataObject = new ();

        public override void InstallBindings()
        {
            foreach (var item in _dataObject)
            {
                Container.Bind(item.GetType()).FromInstance(item).AsSingle();
            }
            
        }
    }
}