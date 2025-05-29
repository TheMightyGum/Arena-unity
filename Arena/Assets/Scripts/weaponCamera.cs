using UnityEngine;
using UnityEngine.InputSystem;

public class weaponCamera : MonoBehaviour
{
    public AudioClip attackSound;
    public Animator weaponAnimator;
    InputAction attackAction;
    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = attackSound;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = GameObject.FindWithTag("MainCamera").transform.position;
        gameObject.transform.rotation = GameObject.FindWithTag("MainCamera").transform.rotation;
        if (attackAction.WasPressedThisFrame())
        {
            weaponAnimator.SetTrigger("Attack");
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.Play();
        }
    }
}
