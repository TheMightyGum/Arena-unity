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
    public Sprite maleBackground;
    public Sprite femaleBackground;
    public Sprite[] maleFaces;
    public Sprite[] femaleFaces;

    public StatBonus maleBonus;
    public StatBonus femaleBonus;

    public Sprite GetBackground(bool isMale) { return isMale ? maleBackground : femaleBackground; }
    public Sprite GetFace(bool isMale, int i) { return isMale ? maleFaces[i] : femaleFaces[i]; }
    public StatBonus GetBonus(bool isMale) { return isMale ? maleBonus : femaleBonus; }
}
