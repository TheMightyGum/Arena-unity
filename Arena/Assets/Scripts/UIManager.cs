using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

public class UIManager : MonoBehaviour
{
    InputAction openMenu;
    [SerializeField] GameObject statsMenu;
    [SerializeField] Image fadeout;
    public float fadeTime;
    public float darkTime;
    public bool isPaused;
    public bool isFading;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openMenu = InputSystem.actions.FindAction("StatsMenu");

        statsMenu.SetActive(false);

        fadeout.gameObject.SetActive(false);
        setFadeAlpha(0f);

        isPaused = false;
        isFading = false;
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (openMenu.WasPressedThisFrame() && !isFading)
        {
            if (statsMenu.activeSelf) //If already in menu
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }

    public void OpenMenu() { StartCoroutine(FadeInto(statsMenu, true)); }
    public void CloseMenu() { StartCoroutine(FadeInto(statsMenu, false)); }

    public IEnumerator FadeInto(GameObject menu, bool setActive)
    {
        if (setActive)
        {
            isPaused = true;
            Time.timeScale = 0f;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        fadeout.gameObject.SetActive(true);
        isFading = true;
        float _time = 0f;
        while(_time < fadeTime)
        {
            _time += Time.unscaledDeltaTime;
            setFadeAlpha(_time / fadeTime);
            yield return null;
        }
        menu.SetActive(setActive);
        _time += darkTime;
        while (_time > 0)
        {
            _time -= Time.unscaledDeltaTime;
            setFadeAlpha(_time / fadeTime);
            yield return null;
        }
        isFading = false;
        fadeout.gameObject.SetActive(false);

        if (setActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    void setFadeAlpha(float alpha) { fadeout.color = new Color(fadeout.color.r, fadeout.color.g, fadeout.color.b, alpha); }
}
