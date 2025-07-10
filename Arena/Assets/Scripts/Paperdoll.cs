using UnityEngine;
using UnityEngine.UI;

public class Paperdoll : MonoBehaviour
{

    public int faceIndex;
    public int clothingIndex;
    [SerializeField] private Sprite[] maleShirts;
    [SerializeField] private Sprite[] femaleShirts;
    [SerializeField] private Sprite malePants;
    [SerializeField] private Sprite femalePants;

    [SerializeField] private Image clothingBottom;
    [SerializeField] private Image clothingTop;
    [SerializeField] private Image paperdollFace;
    [SerializeField] private Image paperdollBackground;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clothingIndex = Random.Range(0, maleShirts.Length);
    }

    public void updatePaperdoll(bool isMale, Races race)
    {
        clothingTop.sprite = isMale ? maleShirts[clothingIndex] : femaleShirts[clothingIndex];
        clothingBottom.sprite = isMale ? malePants : femalePants;
        paperdollBackground.sprite = race.GetBackground(isMale);
        paperdollFace.sprite = race.GetFace(isMale, faceIndex);
    }
}
