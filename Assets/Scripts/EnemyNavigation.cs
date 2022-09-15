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

    public Transform playerSpot;
    public NavMeshAgent eAgnt;
    public Transform lastSpot;
    public Collider col;

    public float waitTime = 3f;
    public float Distance = 6f;
    public bool hasLight = false;
    public bool doWait = false;

    public enum Modes
    {
        Patrol,
        Chase,
        Waiting,
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
        SetSpeed(2f);
        eAgnt.autoBraking = false;

        col = GetComponent<Collider>();
        //GotoNextPoint();
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
        if (hasLight == true)
        {
            Distance = 9f;
        }

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
                Debug.Log("Patrol");
                eModes = Modes.Patrol;
                
            }

        }

        //SetTarget(pAgent.transform);

        switch (eModes)
        {
            case Modes.Chase:
                eAgnt.SetDestination(playerSpot.position);
                //SetSpeed(eAgnt.speed * 1.5f);
                break;
            case Modes.Patrol:
                if (!eAgnt.pathPending && eAgnt.remainingDistance < 1f)
                    GotoNextPoint();
                break;
            case Modes.Waiting:
                //Debug.Log("Waiting");
                eAgnt.isStopped = true;
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
            Debug.Log("Hit");
            Health.helth.health -= Attack;
        } 
    }
    public IEnumerator Wait()
    {
        Debug.Log("In Wait");

        yield return new WaitForSeconds(waitTime);
        //eModes = Modes.Patrol;
        eAgnt.isStopped = false;
        doWait = false;
        /*if (Timer >= 5f)
        {
            Debug.Log("Waited");
            //eAgnt.destination = transform.position;
            return Modes.Patrol;
            
        }
        else
        {
            Timer += Time.deltaTime;
            Debug.Log(Timer);
            return Modes.Null;
        }*/
    }
}
