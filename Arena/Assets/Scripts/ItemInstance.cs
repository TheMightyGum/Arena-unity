using UnityEngine;

public abstract class ItemInstance
{
    public BaseItem baseItem;
}

public class EquipmentInstance : ItemInstance
{
    public itemMaterials itemMaterials;

    public EquipmentInstance(BaseItem baseItem, itemMaterials itemMaterials)
    {
        this.baseItem = baseItem;
        this.itemMaterials = itemMaterials;
    }

    public string itemName()
    {
        if (!itemMaterials.isDefault || baseItem.type == ItemType.Armor)
        {
            return itemMaterials.name + " " + baseItem.name;
        }
        else
        {
            return baseItem.name;
        }
    }

    public int getMinDamage()
    {
        if (baseItem is Weapon weapon)
        {
            return weapon.minDamage + itemMaterials.bonusMinDamage;
        }
        else { return 0; }
    }
    public int getMaxDamage()
    {
        if (baseItem is Weapon weapon)
        {
            return weapon.maxDamage + itemMaterials.bonusMaxDamage;
        }
        else { return 0; }
    }
    public int getAC()
    {
        if (baseItem is Armor armor)
        {
            return armor.baseAC + itemMaterials.bonusAC;
        }
        else { return 0; }
    }
}
