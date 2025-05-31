using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public AudioClip attackSound;
    Animator weaponAnimator;
    InputAction attackAction;
    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
        weaponAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = attackSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackAction.WasPressedThisFrame() && weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            weaponAnimator.SetTrigger("Attack" + Random.Range(1, 7));
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.Play();
        }
    }

    // Call when the weapon checks if it hits an enemy
    public void WeaponHit()
    {
        print("Now the code checks what I hit!!");
    }
}
