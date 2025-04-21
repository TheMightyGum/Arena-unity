using UnityEngine;
using UnityEngine.UI;

public class Attributes : MonoBehaviour
{
    public int STR;
    public int INT;
    public int WIL;
    public int AGI;
    public int SPD;
    public int END;
    public int PER;
    public int LUC;

    public float Health;
    public float maxHealth;
    public float Fatigue;
    float maxFatigue;
    public float SP;
    float maxSP;
    public float SPmultiplier;

    public Image FatigueBar;
    public Image HPbar;
    public Image SPbar;

    public void Start()
    {
        maxFatigue = STR + END;
        maxSP = (int)Mathf.Round(INT * SPmultiplier);
    }

    public void Update()
    {
        FatigueBar.rectTransform.sizeDelta = new Vector2(55f, (Fatigue / maxFatigue) * 156);
        HPbar.rectTransform.sizeDelta = new Vector2(55f, (Health / maxHealth) * 156);
        SPbar.rectTransform.sizeDelta = new Vector2(55f, (SP / maxSP) * 156);
    }
}
