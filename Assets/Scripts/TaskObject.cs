using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObject : MonoBehaviour
{ 
    public float NoiseRange;
    public bool Done;

    public AudioSource nAudio;
    public Animator animator;


    private void Update()
    {
        if (Done)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Invoke("ResetCollider", 3);
            Done = false;

        }
    }


    public void ResetCollider()
    {

        gameObject.GetComponent<BoxCollider>().enabled = true;

    }

}
