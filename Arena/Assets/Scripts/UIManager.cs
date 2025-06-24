using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    InputAction openMenu;
    [SerializeField] GameObject statsMenu;
    public bool isPaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openMenu = InputSystem.actions.FindAction("StatsMenu");

        isPaused = false;
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (openMenu.WasPressedThisFrame())
        {
            if (statsMenu.activeSelf)
            {
                statsMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                isPaused = false;
                Time.timeScale = 1f;
            } else
            {
                statsMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                isPaused = true;
                Time.timeScale = 0f;
            }
        }
    }
}
