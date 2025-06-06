using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Transform Visuals;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector3 lastCamPos;
    private Camera mainCam;
    private int lastDirection = 99;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Visuals = this.transform.GetChild(0);
        animator = Visuals.GetComponent<Animator>();
        spriteRenderer = Visuals.GetComponent<SpriteRenderer>();
        mainCam = Camera.main;
        animator.SetFloat("IsMoving", 0);
    }

    // Update is called once per frame
    void Update()
    {
        Visuals.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);

        if (mainCam.transform.position != lastCamPos || transform.hasChanged)
        {
            lastCamPos = mainCam.transform.position;
            transform.hasChanged = false;

            Vector3 camVec = Vector3.Scale(mainCam.transform.position, new Vector3(1, 0, 1)); //Gives vector to player with y = 0
            Vector3 enemyVec = Vector3.Scale(transform.position, new Vector3(1, 0, 1)); //Gives vector to enemy with y = 0
            Vector3 toCam = camVec - enemyVec; //Vectore from player to enemy

            float angle = Vector3.SignedAngle(toCam, transform.forward, Vector3.up);
            angle = (angle + 180 + 22.5f) % 360; // -180 to 180 -> 0 to 360
            //print(angle);
            int dir = Mathf.FloorToInt(angle / 45); //Returns 0-7
            //print("Before: " + dir);

            if (dir > 4)
            {
                dir = 8 - dir; //5 -> 3, 6 -> 2, 7 -> 1
                spriteRenderer.flipX = true;
            }
            else spriteRenderer.flipX = false;
            //print("After: " + dir);
            
            if (dir != lastDirection) 
            {
                lastDirection = dir;
                animator.SetFloat("Direction", dir);
            }
        }
    }
}
