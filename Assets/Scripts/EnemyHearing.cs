using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHearing : MonoBehaviour
{
    public static EnemyHearing hearing;

    public float hearingRange = 100f;

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
}
