
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.UI.Image;

public class EnemyBehaviour : MonoBehaviour
{
    public EnemyStats stats;
    public int maxHealth;
    public int curHealth;

    [Range(0f, 360f)]
    public float FieldOfView = 180f;
    public float MaxViewRange = 15f;
    public float CheckInterval = 1f;

    float _time;

    Transform Visuals;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Vector3 lastCamPos;
    Camera mainCam;
    public LayerMask layerMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Boring GetComponent stuff
        Visuals = this.transform.GetChild(0);
        animator = Visuals.GetComponent<Animator>();
        spriteRenderer = Visuals.GetComponent<SpriteRenderer>();
        mainCam = Camera.main;
        animator.SetFloat("IsMoving", 0);
        //layerMask = (1 >> LayerMask.NameToLayer("Walls"));

        maxHealth = Random.Range(stats.minHealth, stats.maxHealth + 1); //Sets maxHP
        curHealth = maxHealth; //When enemy spawns, current HP = max HP

        _time = 0f;
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
            Vector3 toCam = camVec - enemyVec; //Vector from player to enemy

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

        _time += Time.deltaTime;
        while (_time >= CheckInterval)
        {
            //if (PlayerIsVisible()) print("I can see you!!!");
            //else print("Couldn't find you :(");
            print(PlayerIsVisible());
            _time -= CheckInterval;
        }
    }

    public bool PlayerIsVisible()
    {
        Vector3 origin = transform.position + Vector3.up;
        Vector3 dir = (mainCam.transform.position - origin).normalized;
        float distance = Vector3.Distance(origin, mainCam.transform.position);
        Debug.DrawRay(origin, dir * distance, Color.red, 1);

        if (distance > MaxViewRange) return false; //If outside viewing range, enemy cant see you
        
        float angle = Vector3.Angle(transform.forward, dir);
        if (angle > FieldOfView / 2f) return false; //If outside fov, enemy cant see you

        if (Physics.Raycast(transform.position, dir, distance, layerMask)) return false; //If wall between enemy and player, enemy cant see you
        
        return true; //If none of above apply, enemy CAN see you
    }
}
