using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    public static EnemyNavigation EnemyNav;

    public Transform[] points;

    private int destPoint = 0;
    private int Attack = 1;
    private float Timer;
    private float ChaseSpeed;

    public Transform playerSpot;
    public NavMeshAgent eAgnt;
    //public Transform lastSpot;
    public Collider col;
    public Animator anim;
    public TaskObject NavTaskValues;

    public float waitTime = 3f;
    public float Distance = 6f;
    public bool doWait = false;
    public float Speed = 3f;

    public enum Modes
    {
        Patrol,
        Chase,
        Waiting,
        Attacking,
        Null
    }

    public Modes eModes;

    // Start is called before the first frame update
    void Start()
    {
        if(EnemyNav == null)
        {
            EnemyNav = this;
        }
        else
        {
            Destroy(gameObject);
        }
        eAgnt = gameObject.GetComponent<NavMeshAgent>();
        SetSpeed(Speed);
        eAgnt.autoBraking = false;

        col = GetComponent<Collider>();
        //GotoNextPoint();

        Physics.IgnoreLayerCollision(3, 7);

        ChaseSpeed = Speed * 2;
    }

    void GotoNextPoint()
    {
        eAgnt.ResetPath();
        if (points.Length == 0)
            return;
            
        eAgnt.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }

    // Update is called once per frame
    void Update()
    {

        bool canSeeP = CapabilityOfSight();
        if (canSeeP == true)
        {
            Debug.Log("Chasing");
            eModes = Modes.Chase;
            doWait = true;

        }
        else 
        {
            if(doWait)
            {
                eModes = Modes.Waiting;
            }
            else
            {
                //Debug.Log("Patrol");
                eModes = Modes.Patrol;
                
            }

        }

        //SetTarget(pAgent.transform);

        switch (eModes)
        {
            case Modes.Chase:
                eAgnt.SetDestination(playerSpot.position);
                anim.Play("Running");
                SetSpeed(ChaseSpeed);
                break;
            case Modes.Patrol:
                if (!eAgnt.pathPending && eAgnt.remainingDistance < 1f)
                    GotoNextPoint();
                    anim.Play("Walk");
                break;
            case Modes.Waiting:
                //Debug.Log("Waiting");
                eAgnt.isStopped = true;
                anim.Play("Idle");
                StartCoroutine("Wait");
                break;
        }
    }


    public bool CapabilityOfSight()
    {
        if (Vector3.Distance(transform.position, playerSpot.position) <= Distance)
        {
            Vector3 AtoB = playerSpot.position - transform.position;
            if (Vector3.Dot(AtoB, eAgnt.transform.forward) >= 0.5f)
            {
                if (Physics.Linecast(transform.position, playerSpot.position))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void SetSpeed(float Speed)
    {
        eAgnt.speed = Speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.Play("Attack");
            Health.helth.health -= Attack * Health.helth.health;
        } 
    }
    public IEnumerator Wait()
    {
        Debug.Log("In Wait");

        yield return new WaitForSeconds(waitTime);
        //eModes = Modes.Patrol;
        eAgnt.isStopped = false;
        doWait = false;
    }
    public void CloseToDoor(Transform door)
    {
        if (door.gameObject.CompareTag("Door"))
        {
            door.gameObject.GetComponent<TaskObject>().Open |= Vector3.Distance(transform.position, door.position) <= 3f;
        }
    }
}
