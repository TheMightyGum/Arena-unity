using UnityEngine;

[CreateAssetMenu(fileName = "Classes", menuName = "Scriptable Objects/Classes")]
public class Classes : ScriptableObject
{
    public int hitDie;
    public int levelRate;

    public bool canUseMagic;
    public float SPmultiplier;

    public int thieveryEfficiency;
}
