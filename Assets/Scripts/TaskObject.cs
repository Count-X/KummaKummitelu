using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObject : MonoBehaviour
{ 
    public float NoiseRange;
    public bool Done;

    public AudioSource nAudio;
    public Animator animator;

<<<<<<< Updated upstream
  
=======
    private void Update()
    {
        if (Done)
        {
            Destroy(gameObject.GetComponent<BoxCollider>());
        }
    }
>>>>>>> Stashed changes

}
