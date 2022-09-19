using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObject : MonoBehaviour
{ 
    public float NoiseRange;
    public bool Done;
    public bool Open;
    public string interactText;

    public AudioSource nAudio;
    public Animator animator;


    private void Update()
    {
        if (Open)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Invoke("ResetCollider", 3);
            Open = false;

        }
    }


    public void ResetCollider()
    {

        gameObject.GetComponent<BoxCollider>().enabled = true;

    }

}
