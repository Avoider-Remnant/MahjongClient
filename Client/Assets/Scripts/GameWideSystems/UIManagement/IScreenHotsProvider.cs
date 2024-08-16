using UnityEngine;

namespace GameWideSystems.UIManagement
{
    public interface IScreenHotsProvider
    {
        public Transform SystemHost { get; }
        public Transform GameHost { get; }

        public Transform GetHolderFor(ScreenHolderType screenHolderTypeType);

    }
}