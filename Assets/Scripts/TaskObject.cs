using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObject : MonoBehaviour
{ 
    public float NoiseRange;
    public bool Done;
    public bool Open;
    public bool boolen = true;
    public string interactText;
    public string animatorName;

    public AudioSource nAudio;
    public Animator animator;
    public BoxCollider bCollider;

    private float Timer;

    private void Start()
    {
        bCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (Open)
        {
            bCollider.enabled = false;
            nAudio.Play();
            animator.SetTrigger("Opening");
            Invoke("ResetCollider", 3);
            Open = false;

        }

        if (Done)
        {
            Destroy(bCollider);
        }

            EnemyNavigation.EnemyNav.CloseToDoor(transform);
        

    }


    public void ResetCollider()
    {

        gameObject.GetComponent<BoxCollider>().enabled = true;

    }

}
