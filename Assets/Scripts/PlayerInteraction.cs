using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public Camera cam;
    public TMP_Text interactText;
    public Transform Enemy;
    public TaskObject TaskValues = null;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward.normalized);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 10f))
        {
           
            TaskValues = hit.collider.gameObject.GetComponent<TaskObject>();
            interactText.gameObject.SetActive(true);
          

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("raycasting E");
                //audioS.Play();
                // Tähän Mitä tapahtuu kun pelaaja interaktioi, Refrenssi scriptiin mahdollisesti
                if (TaskValues.nAudio != null)
                {
                    TaskValues.nAudio.Play();
                }
                if(TaskValues.animator != null)
                {
                    //animator play
                    TaskValues.animator.Play("kirja");
                    Debug.Log("animation plays");
                }
                if (EnemyHearing.hearing.hearingRange - TaskValues.NoiseRange <= 0)
                {
                    EnemyNavigation.EnemyNav.eAgnt.ResetPath();
                    EnemyNavigation.EnemyNav.eAgnt.destination = TaskValues.gameObject.transform.position;
                }
            }
        }
        else
        {
            
            interactText.gameObject.SetActive(false);
        }
    }
}
