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

    [HideInInspector] public int damageMod;
    [HideInInspector] public int magicDefMod;
    [HideInInspector] public int toHitMod;
    [HideInInspector] public int healthMod;
    [HideInInspector] public int charismaMod;
    [HideInInspector] public int maxWeight;

    public int HP;
    public int maxHP;
    public int Fatigue;
    public int maxFatigue;

    bool canUseMagic;
    public int SP;
    public int maxSP;

    public int gold;
    public int level;
    public int XP;

    public Image FatigueBar;
    public Image HPbar;
    public Image SPbar;
    public Sprite Overlay3;
    public Sprite Overlay2;

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

        damageMod = calcMod(STR);
        magicDefMod = calcMod(INT);
        toHitMod = calcMod(AGI);
        healthMod = calcMod(END);
        charismaMod = calcMod(PER);
        maxWeight = STR * 2;

        maxFatigue = STR + END;
        Fatigue = maxFatigue;

        canUseMagic = playerClass.canUseMagic;
        if (canUseMagic)
        {
            maxSP = (int)Mathf.Round(INT * playerClass.SPmultiplier);
            SP = maxSP;
            SetBarHud();
        }
        else
        {
            maxSP = 0;
            SP = 0;
            SetBarHud();
        }

        maxHP = 25 + Random.Range(1, playerClass.hitDie) + healthMod;
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

    void SetBarHud()
    {
        Transform parent = SPbar.transform.parent;
        Image back = parent.GetChild(0).GetComponent<Image>();
        Image overlay = parent.GetChild(4).GetComponent<Image>();
        if (canUseMagic)
        {
            SPbar.enabled = true;
            overlay.sprite = Overlay3;
            back.rectTransform.sizeDelta = new Vector2(174, 186);
            overlay.rectTransform.sizeDelta = new Vector2(174, 186);
        } else
        {
            SPbar.enabled = false;
            overlay.sprite = Overlay2;
            back.rectTransform.sizeDelta = new Vector2(114, 186);
            overlay.rectTransform.sizeDelta = new Vector2(114, 186);
        }
    }

    int calcMod(int value) { return Mathf.FloorToInt(value / 5) - 10; }
}
