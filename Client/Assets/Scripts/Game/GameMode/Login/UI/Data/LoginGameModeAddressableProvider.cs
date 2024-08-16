using UnityEngine;

namespace Game.GameMode.Login.UI.Data
{
    [CreateAssetMenu(menuName = "Game/TA/Structure/Log In Screen Addressable reference provider")]
    public class LoginGameModeAddressableProvider : ScriptableObject
    {
        [field: SerializeField] public string LogInScreenPrefab { get; private set; }
    }
}