using RPSLS.Game;
using UnityEngine;

namespace RPSLS.Config
{
    [CreateAssetMenu(fileName = "UnitConfig", menuName = "Game/Unit Config", order = 1)]
    public class UnitConfig : ScriptableObject
    {
        public UnitType UnitType;
        public string UnitName;
        public Sprite UnitIcon;
        public AudioClip UnitSound;
    }
}