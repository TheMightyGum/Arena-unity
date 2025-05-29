using UnityEngine;
using UnityEngine.InputSystem;

public class weaponCamera : MonoBehaviour
{

    InputAction attackAction;
    public Animator weaponAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = GameObject.FindWithTag("MainCamera").transform.position;
        gameObject.transform.rotation = GameObject.FindWithTag("MainCamera").transform.rotation;
        if (attackAction.WasPressedThisFrame())
        {
            weaponAnimator.SetTrigger("Attack");
        }
    }
}
