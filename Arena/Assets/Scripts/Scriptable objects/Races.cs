using UnityEngine;

[CreateAssetMenu(fileName = "Races", menuName = "Scriptable Objects/Races")]
public class Races : ScriptableObject
{
    public string RaceName;
    public StatBonus maleBonus;
    public StatBonus femaleBonus;

    [System.Serializable]
    public struct StatBonus
    {
        public int STR;
        public int INT;
        public int WIL;
        public int AGI;
        public int SPD;
        public int END;
        public int PER;
        public int LUC;
    }
}
