using UnityEngine;

[CreateAssetMenu(fileName = "itemMaterials", menuName = "Scriptable Objects/itemMaterials")]
public class itemMaterials : ScriptableObject
{
    public string materialName;

    public int bonusToHit;
    public int bonusMinDamage;
    public int bonusMaxDamage;

    public int bonusAC;
    public int deteriorationRate; //Percentage from damage dealt removed from condition

    public int metalTier; //0:mundane weapon, 1:Harms ice golems, 2:Harms Medusa & Stone Golem, 3:Harms everything
    public bool effectiveAgainstVampires; //Deals double damage
}
