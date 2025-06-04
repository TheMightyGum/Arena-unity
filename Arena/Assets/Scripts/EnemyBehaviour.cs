using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Transform Visuals;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector3 lastCamPos;
    private Camera mainCam;
    private int lastDirection = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Visuals = this.transform.GetChild(0);
        animator = Visuals.GetComponent<Animator>();
        spriteRenderer = Visuals.GetComponent<SpriteRenderer>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Visuals.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);

        if (mainCam.transform.position != lastCamPos || transform.hasChanged)
        {
            lastCamPos = mainCam.transform.position;
            transform.hasChanged = false;

            Vector3 toCam = mainCam.transform.position - transform.position;
            float angle = Vector3.SignedAngle(toCam, -transform.forward, Vector3.up);
            angle =  angle + 180 % 360; //Just accept it
            int dir = Mathf.FloorToInt(angle / 45); //Returns 0-7

            print("Before: " + dir);
            if (dir > 4)
            {
                dir = 8 - dir; //5 -> 3, 6 -> 2, 7 -> 1
                spriteRenderer.flipX = true;
            }
            else spriteRenderer.flipX = false;
            print("After: " + dir);
            
            if (dir != lastDirection) 
            {
                lastDirection = dir;
                animator.SetInteger("Direction", dir);
            }
        }
    }
}
