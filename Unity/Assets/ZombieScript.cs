using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    private NavMeshAgent agent;
    private Spawner sp;

    public Transform Target;
    public float RotationSpeed;
    public float MovementSpeed;
    public float IdleTime;
    public float ChaseTime;
    public float DespawnTime;
    public float Damage;
    public float AttackCD;
    public Vector3 moleculePosition;
    public string moleculeName;

    private int hits = 1;
    private float currIdleTime = 0.0f;
    private float currChaseTime = 0.0f;
    private float currDespawnTime = 0.0f;
    public float currAttackTime = 0.0f;

    // values for rotating to face player
    private Quaternion lookRotation;
    private Vector3 direction;

    enum States
    {
        IDLE,
        ATTACK,
        CHASE,
        DAMAGED
    }
    States currState = States.IDLE;

    private void Awake()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Target = GameObject.FindGameObjectWithTag("Player").transform;

        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //anim.Play("Z_FallingBack");
            --hits;
            if (hits == 0)
            {
                sp.ZombieDead();
            }
        }

        if (hits <= 0 && gameObject.activeSelf)
        {
            FadeOut();
        }

        if (currAttackTime > 0)
        {
            currAttackTime -= Time.deltaTime;
        }

        switch (currState)
        {
            case States.IDLE:
                {
                    currIdleTime += Time.deltaTime;
                    if (currIdleTime >= IdleTime)
                    {
                        //anim.Play("Z_Walk_InPlace");
                        currState = States.CHASE;
                        currIdleTime = 0.0f;
                    }

                    break;
                }
            case States.ATTACK:
                {
                    if ((Target.position - transform.position).magnitude >= 1.5f)
                    {
                        //anim.Play("Z_Idle");
                        currState = States.IDLE;
                    }

                    break;
                }
            case States.CHASE:
                {
                    if (agent == null) return;

                    if (agent.enabled)
                    {
                        agent.destination = Target.position;
                    }
                    //direction = (Target.position - transform.position).normalized;
                    //transform.position += direction * MovementSpeed * Time.deltaTime;

                    PerformLookAtRotation();

                    if ((Target.position - transform.position).magnitude <= 1.0f)
                    {
                        //anim.Play("Z_Attack");
                        currState = States.ATTACK;
                    }

                    //currChaseTime += Time.deltaTime;
                    //if (currChaseTime >= ChaseTime)
                    //{
                    //    //anim.Play("Z_Idle");
                    //    currState = States.IDLE;
                    //    currChaseTime = 0.0f;
                    //}
                    break;
                }
            case States.DAMAGED:
                {
                    currDespawnTime += Time.deltaTime;
                    if (currDespawnTime >= DespawnTime)
                    {
                        GameObject.Destroy(gameObject);
                    }
                    break;
                }
        }
    }

    //restarts the objects values
    public void ReInit(WindowBuilder chokePointTarget)
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renderers)
        {
            Color c = rend.material.color;
            c.a = 1;
            rend.material.color = c;
        }

        Target = chokePointTarget.transform;
        hits = Random.Range(1, 2);
        gameObject.transform.position = sp.gameObject.transform.position;
        agent.enabled = true;
        gameObject.SetActive(true);
    }

    void PerformLookAtRotation()
    {
        //find the vector pointing from our position to the target
        direction = (Target.position - transform.position).normalized;

        //create the rotation we need to be in to look at the target
        lookRotation = Quaternion.LookRotation(direction);

        //rotate us over time according to speed until we are in the required rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * RotationSpeed);
    }

    private void FadeOut()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renderers)
        {
            Color c = rend.material.color;
            c.a -= Time.deltaTime;
            rend.material.color = c;

            if (c.a <= 0)
            {
                gameObject.SetActive(false);
            }
        }

    }

    public void SetSpawner(Spawner sp)
    {
        this.sp = sp;
    }

    private void OnTriggerEnter(Collider collision)
    {
       

        if (collision.gameObject.tag == moleculeName)
        {
            --hits;
            if (hits == 0)
            {
                sp.ZombieDead();
                agent.enabled = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with something");

        if (collision.gameObject.tag == "Weapon")
        {
            Debug.Log("HITTING ZOMBIE");
            anim.Play("Z_FallingBack");
            currState = States.DAMAGED;
        }


        if (collision.gameObject.tag == moleculeName)
        {
            print(collision.gameObject.tag + " vs " + moleculeName);
            --hits;
            if (hits == 0)
            {
                sp.ZombieDead();
            }
        }
    }
}
