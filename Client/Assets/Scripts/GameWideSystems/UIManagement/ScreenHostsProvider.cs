using System;
using UnityEngine;

namespace GameWideSystems.UIManagement
{
    public class ScreenHostsProvider : MonoBehaviour, IScreenHotsProvider
    {
        [field: SerializeField] public Transform SystemHost { get; private set; }
        [field: SerializeField] public Transform GameHost { get; private set; }
        
        public Transform GetHolderFor(ScreenHolderType screenHolderTypeType)
        {
            return screenHolderTypeType switch
            {
                ScreenHolderType.Game => GameHost,
                ScreenHolderType.System => SystemHost,
                _ => throw new ArgumentOutOfRangeException(nameof(screenHolderTypeType), screenHolderTypeType, null)
            };
        }
    }
}