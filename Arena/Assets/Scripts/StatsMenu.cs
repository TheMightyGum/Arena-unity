using UnityEngine;
using TMPro;

public class StatsMenu : MonoBehaviour
{
    public Attributes Attributes;

    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text raceText;
    [SerializeField] private TMP_Text classText;
    [SerializeField] private TMP_Text strText;
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private TMP_Text weightText;
    [SerializeField] private TMP_Text intText;
    [SerializeField] private TMP_Text spText;
    [SerializeField] private TMP_Text wilText;
    [SerializeField] private TMP_Text magicDefText;
    [SerializeField] private TMP_Text agiText;
    [SerializeField] private TMP_Text toHitText;
    [SerializeField] private TMP_Text toDefText;
    [SerializeField] private TMP_Text spdText;
    [SerializeField] private TMP_Text endText;
    [SerializeField] private TMP_Text hpModText;
    [SerializeField] private TMP_Text healModText;
    [SerializeField] private TMP_Text perText;
    [SerializeField] private TMP_Text charismaText;
    [SerializeField] private TMP_Text lucText;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text fatigueText;
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private TMP_Text xpText;
    [SerializeField] private TMP_Text levelText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        nameText.text = Attributes.playerName;
        raceText.text = Attributes.playerRace.name;
        classText.text = Attributes.playerClass.name;
        strText.text = Attributes.STR.ToString();
        damageText.text = displaySign(Attributes.damageMod);
        weightText.text = Attributes.maxWeight.ToString();
        intText.text = Attributes.INT.ToString();
        spText.text = Attributes.SP.ToString() + "/" + Attributes.maxSP.ToString();
        wilText.text = Attributes.WIL.ToString();
        magicDefText.text = displaySign(Attributes.magicDefMod);
        agiText.text = Attributes.AGI.ToString();
        toHitText.text = displaySign(Attributes.toHitMod);
        toDefText.text = displaySign(Attributes.toHitMod);
        spdText.text = Attributes.SPD.ToString();
        endText.text = Attributes.END.ToString();
        hpModText.text = displaySign(Attributes.healthMod);
        healModText.text = displaySign(Attributes.healthMod);
        perText.text = Attributes.PER.ToString();
        charismaText.text = displaySign(Attributes.charismaMod);
        lucText.text = Attributes.LUC.ToString();
        hpText.text = Attributes.HP.ToString() + "/" + Attributes.maxHP.ToString();
        fatigueText.text = Attributes.Fatigue.ToString() + "/" + Attributes.maxFatigue.ToString();
        goldText.text = Attributes.gold.ToString();
        xpText.text = Attributes.XP.ToString();
        levelText.text = Attributes.level.ToString();
    }

    string displaySign(int value) { return value >= 0 ? "+" + value.ToString() : value.ToString(); }
}
