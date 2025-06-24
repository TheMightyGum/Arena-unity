using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [SerializeField] UIManager manager;
    CharacterController characterController;
    InputAction moveAction;
    InputAction jumpAction;
    InputAction lookAction;

    public new Camera camera;

    Vector3 velocity;
    float xRotation;

    public int runSpeed = 6;
    public int airSpeed = 2;
    [Range(0f, 3f)]
    public float airControl = 2f;
    public int sensitivity = 30;
    public int jumpHeight = 10;
    public int gravity = -20;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        lookAction = InputSystem.actions.FindAction("Look");
    }

    void Update()
    {
        if (manager.isPaused) return;
        Vector3 move = moveAction.ReadValue<Vector2>().x * transform.right + moveAction.ReadValue<Vector2>().y * transform.forward;
        Vector2 look = lookAction.ReadValue<Vector2>() * Time.deltaTime * sensitivity;

        if (characterController.isGrounded) //On the ground
        {
            velocity.x = move.x * runSpeed;
            velocity.z = move.z * runSpeed;
            if (jumpAction.IsPressed()) //If space pressed, set initial jump velocity. Else reset velocity
            {
                velocity.y = jumpHeight;
            }
            else
            {
                velocity.y = 0;
            }
        }
        else
        { //In air
            velocity.y += gravity * Time.deltaTime; //Apply gravity
        }
        characterController.Move(velocity * Time.deltaTime); //Moves player

        //Mouse rotation
        characterController.transform.Rotate(0, look.x, 0);
        xRotation -= look.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        
    }
}