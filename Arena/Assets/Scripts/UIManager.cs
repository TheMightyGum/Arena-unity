using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{

    InputAction openMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openMenu = InputSystem.actions.FindAction("StatsMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if (openMenu.WasPressedThisFrame())
        {
            Transform menu = transform.GetChild(2);
            menu.gameObject.SetActive(!menu.gameObject.activeSelf);
        }
    }
}
