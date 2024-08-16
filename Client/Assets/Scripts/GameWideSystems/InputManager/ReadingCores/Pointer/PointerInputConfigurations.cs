using UnityEngine;

namespace GameWideSystems.InputManager.ReadingCores.Pointer
{
    [CreateAssetMenu(fileName = "New pointer input configurations", menuName = "Game/Dev/Manager Configurations/Input Configurations/Pointer Settings", order = 0)]
    public class PointerInputConfigurations : ScriptableObject
    {
        [field: SerializeField] public float TapToLongPressThreshold { get; private set; }
    }
}