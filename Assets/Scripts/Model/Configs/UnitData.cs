using System.Collections.Generic;
using UnityEngine;

namespace RPSLS.Config
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "Game/Unit Data", order = 1)]
    public class UnitData : ScriptableObject
    {
        public List<UnitConfig> Data;
        public float PlayerTurnTimer;
    }
}