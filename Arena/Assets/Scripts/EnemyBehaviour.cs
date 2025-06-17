using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public EnemyStats stats;
    public int maxHealth;
    public int curHealth;

    [Range(0f, 360f)]
    public float FieldOfView = 180f;
    public float MaxViewRange = 15f;
    public float CheckInterval = .5f;
    public float PlayerProximity = 2f;

    public AudioClip ambientSound;
    float soundTime;
    float soundTimer;

    bool CanSeePlayer;
    float _time;

    Transform Visuals;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Vector3 lastCamPos;
    Camera mainCam;
    LayerMask layerMask;
    NavMeshAgent navMeshAgent;
    AudioSource AudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Boring GetComponent stuff
        Visuals = this.transform.GetChild(0);
        animator = Visuals.GetComponent<Animator>();
        spriteRenderer = Visuals.GetComponent<SpriteRenderer>();
        mainCam = Camera.main;
        layerMask = LayerMask.GetMask("Walls");
        navMeshAgent = GetComponent<NavMeshAgent>();
        AudioSource = GetComponent<AudioSource>();

        AudioSource.clip = ambientSound;
        resetSoundTimer();
        maxHealth = Random.Range(stats.minHealth, stats.maxHealth + 1); //Sets maxHP
        curHealth = maxHealth; //When enemy spawns, current HP = max HP

        navMeshAgent.speed = stats.SPD / 5;
        navMeshAgent.SetDestination(transform.position); //Sets target to move to to itself, so it wont move at the start

        _time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Visuals.rotation = Quaternion.Euler(0, mainCam.transform.rotation.eulerAngles.y, 0);

        if (mainCam.transform.position != lastCamPos || transform.hasChanged)
        {
            Animate();
        }

        //Checks if it can see you every "CheckInterval" seconds
        _time += Time.deltaTime;
        while (_time >= CheckInterval)
        {
            bool _CouldSeePlayer = CanSeePlayer;
            CanSeePlayer = IsPlayerVisible();
            if (_CouldSeePlayer && !CanSeePlayer) 
            {
                navMeshAgent.SetDestination(GetFlatVec3(mainCam.transform.position));
            }
            _time -= CheckInterval;
        }

        soundTime += Time.deltaTime;
        while (soundTime >= soundTimer)
        {
            AudioSource.Play();
            resetSoundTimer();
            soundTime -= soundTimer; 
        }
        
        //Move towards target IF not already at target
        float _dist = Vector3.Distance(GetFlatVec3(mainCam.transform.position), transform.position);
        bool _tooFar = PlayerProximity < _dist && CanSeePlayer; //Withing range of you while enemy can see you
        bool _notArrived = navMeshAgent.destination != transform.position && !CanSeePlayer; //Not at target while he cant see you

        if (_tooFar || _notArrived)
        {
            animator.SetFloat("IsMoving", 1);
            if (CanSeePlayer)
            {
                Vector3 playerpos = GetFlatVec3(mainCam.transform.position);
                navMeshAgent.SetDestination(playerpos - FromTo(transform.position, playerpos) * PlayerProximity);
            }
        }
        else
        {
            animator.SetFloat("IsMoving", 0);
            navMeshAgent.SetDestination(transform.position);
        }
        
        if ((PlayerProximity >= _dist || navMeshAgent.destination == transform.position) && CanSeePlayer) animator.SetBool("Staring", true);
        else animator.SetBool("Staring", false);        
    }

    public bool IsPlayerVisible()
    {
        Vector3 origin = transform.position + Vector3.up;
        Vector3 dir = FromTo(origin, mainCam.transform.position);
        float distance = Vector3.Distance(origin, mainCam.transform.position);
        Debug.DrawRay(origin, dir * distance, Color.red, CheckInterval);

        if (distance > MaxViewRange) return false; //If outside viewing range, enemy cant see you
        
        float angle = Vector3.Angle(transform.forward, dir);
        if (angle > FieldOfView / 2f) return false; //If outside fov, enemy cant see you

        if (Physics.Raycast(transform.position, dir, distance, layerMask)) return false; //If wall between enemy and player, enemy cant see you
        
        return true; //If none of above apply, enemy CAN see you
    }

    void Animate()
    {
        lastCamPos = mainCam.transform.position;
        transform.hasChanged = false;

        Vector3 camVec = GetFlatVec3(mainCam.transform.position); //Gives vector to player with y = 0
        Vector3 enemyVec = GetFlatVec3(transform.position); //Gives vector to enemy with y = 0
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
    void resetSoundTimer()
    {
        soundTimer = Random.Range(.5f, 5);
    }
    Vector3 GetFlatVec3(Vector3 pos) { return Vector3.Scale(pos, new Vector3(1, 0, 1)); } //Function that returns position with y=0
    Vector3 FromTo (Vector3 origin, Vector3 target) { return (target - origin).normalized; } //Gets vector from origin to target
}
