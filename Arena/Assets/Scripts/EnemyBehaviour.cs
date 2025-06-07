
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public EnemyStats stats;
    public int maxHealth;
    public int curHealth;

    private Transform Visuals;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector3 lastCamPos;
    private Camera mainCam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Boring GetComponent stuff
        Visuals = this.transform.GetChild(0);
        animator = Visuals.GetComponent<Animator>();
        spriteRenderer = Visuals.GetComponent<SpriteRenderer>();
        mainCam = Camera.main;
        animator.SetFloat("IsMoving", 0);

        maxHealth = Random.Range(stats.minHealth, stats.maxHealth + 1); //Sets maxHP
        curHealth = maxHealth; //When enemy spawns, current HP = max HP
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
            int dir = Mathf.FloorToInt(angle / 45); //Returns 0-7

            if (dir > 4)
            {
                dir = 8 - dir; //5 -> 3, 6 -> 2, 7 -> 1
                spriteRenderer.flipX = true;
            }
            else spriteRenderer.flipX = false;
            
            if (dir != animator.GetFloat("Direction")) 
            {
                animator.SetFloat("Direction", dir);
            }
        }
    }
}
