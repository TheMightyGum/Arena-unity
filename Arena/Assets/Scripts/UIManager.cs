using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    InputAction openMenu;
    [SerializeField] GameObject statsMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openMenu = InputSystem.actions.FindAction("StatsMenu");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (openMenu.WasPressedThisFrame())
        {
            statsMenu.SetActive(!statsMenu.activeSelf);
            if (statsMenu.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            } else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
