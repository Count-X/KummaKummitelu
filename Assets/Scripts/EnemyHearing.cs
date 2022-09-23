using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHearing : MonoBehaviour
{
    public static EnemyHearing hearing;

    public float hearingRange;

    void Start()
    {
        if(hearing == null) {
            hearing = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Hear(float heardNoise, Transform noisePos)
    {
        hearingRange = Vector3.Distance(transform.position, noisePos.position);
        if (hearingRange - heardNoise <= 0f)
        {
            //Debug.Log("Heard");
            EnemyNavigation.EnemyNav.eAgnt.ResetPath();
            EnemyNavigation.EnemyNav.eAgnt.destination = noisePos.position;
        }
    }
}
