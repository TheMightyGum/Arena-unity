using UnityEngine;

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

[CreateAssetMenu(fileName = "Races", menuName = "Scriptable Objects/Races")]
public class Races : ScriptableObject
{
    public StatBonus maleBonus;
    public StatBonus femaleBonus;

    public StatBonus GetBonus(bool isMale)
    {
        return isMale ? maleBonus : femaleBonus;
    }
}
