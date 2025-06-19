using UnityEngine;
using UnityEngine.UI;

public class Attributes : MonoBehaviour
{
    public string playerName;
    public Races playerRace;
    public Classes playerClass;
    public bool isMale = true;

    public int STR = 40;
    public int INT = 40;
    public int WIL = 40;
    public int AGI = 40;
    public int SPD = 40;
    public int END = 40;
    public int PER = 40;
    public int LUC = 40;

    public int HP;
    public int maxHP;
    public int Fatigue;
    int maxFatigue;

    bool canUseMagic;
    public int SP;
    int maxSP;

    public int level;
    public int XP;

    public Image FatigueBar;
    public Image HPbar;
    public Image SPbar;

    public void Start()
    {
        StatBonus statBonus = playerRace.GetBonus(isMale);
        STR = 40 + statBonus.STR;
        INT = 40 + statBonus.INT;
        WIL = 40 + statBonus.WIL;
        AGI = 40 + statBonus.AGI;
        SPD = 40 + statBonus.SPD;
        END = 40 + statBonus.END;
        PER = 40 + statBonus.PER;
        LUC = 40 + statBonus.LUC;

        maxFatigue = STR + END;
        Fatigue = maxFatigue;

        canUseMagic = playerClass.canUseMagic;
        if (canUseMagic)
        {
            maxSP = (int)Mathf.Round(INT * playerClass.SPmultiplier);
            SP = maxSP;
        }
        else
        {
            SP = 0;
        }

        maxHP = 25 + Random.Range(1, playerClass.hitDie); //TODO END health bonus
        HP = maxHP;

        level = 1;
        XP = 0;
    }

    public void Update()
    {
        //Updates HUD bars
        FatigueBar.rectTransform.sizeDelta = new Vector2(55f, ((float)Fatigue / maxFatigue) * 156);
        HPbar.rectTransform.sizeDelta = new Vector2(55f, ((float)HP / maxHP) * 156);
        if (canUseMagic) SPbar.rectTransform.sizeDelta = new Vector2(55f, ((float)SP / maxSP) * 156);
    }
}
