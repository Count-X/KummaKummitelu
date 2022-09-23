using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tasks : MonoBehaviour
{
    public static Tasks tasksSingleton;

    public TaskObject[] taskObjects;
    public bool[] bools;
    public bool allDone;
    public Collider winCol;
    public TMP_Text taskDoneText;

    // Start is called before the first frame update
    void Start()
    {
        if(tasksSingleton == null)
        {
            tasksSingleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //winCol.enabled = false;
    }

    public void CheckObjectives()
    {
        for(int i = 0; i < taskObjects.Length; i++)
        {
            
            bools[i] = taskObjects[i].Done;

            if (bools[i] == false)
            {
                allDone = false;
                Debug.Log("Not Yet");
                break;
            }

            else
                allDone = true;
                
        }
        if(allDone == true)
        {
            Debug.Log("Won");
            taskDoneText.enabled = true;
        }
    }
}
