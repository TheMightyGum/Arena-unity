using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public string enemyName;

    public int minHealth;
    public int maxHealth;

    public int minDamage;
    public int maxDamage;

    public int minExp;
    public int maxExp;

    public int STR;
    public int INT;
    public int WIL;
    public int AGI;
    public int END;
    public int PER;
    public int SPD;
    public int LUC;
}
