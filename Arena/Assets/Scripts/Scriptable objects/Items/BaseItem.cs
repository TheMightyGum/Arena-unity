using UnityEngine;

public enum ItemType { Weapon, Armor, questItem, potion }

public abstract class BaseItem : ScriptableObject
{
    public string itemName;
    public ItemType type;
    public float weight;
}

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public class Weapon : BaseItem
{
    public int minDamage;
    public int maxDamage;
    public bool isTwoHanded;
}

public enum ArmorLocation {Head, LeftShoulder, RightShoulder, Chest, Hands, Legs, Feet}
public enum ArmorType {Leather, Chain, Plate}
[CreateAssetMenu(fileName = "Armor", menuName = "Scriptable Objects/Armor")]
public class Armor : BaseItem
{
    public int baseAC;
    public ArmorLocation armorLocation;
    public ArmorType armorType;
}
