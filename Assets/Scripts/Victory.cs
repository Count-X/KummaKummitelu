using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(Tasks.tasksSingleton.allDone == true)
        {
            Debug.Log("Won");
        }
        else
        {
            Debug.Log("Tasks not done");
        }
    }
}
