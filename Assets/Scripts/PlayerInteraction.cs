using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    //public Unity API Types
    public Camera cam;
    public TMP_Text interactText;
    public Transform Enemy;
    public TaskObject TaskValues = null;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward.normalized);
        RaycastHit hit;

        //The whole process of interaction and the noise that interaction makes
        if(Physics.Raycast(ray, out hit, 10f))
        {
            TaskValues = hit.collider.gameObject.GetComponent<TaskObject>();

            if (hit.collider.gameObject.CompareTag("Interactable"))
            {
                interactText.gameObject.SetActive(true);
            }
            else
            {
                interactText.gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                float Dist = Vector3.Distance(transform.position, Enemy.position);
                // Tähän Mitä tapahtuu kun pelaaja interaktioi, Refrenssi scriptiin mahdollisesti


                if(TaskValues.nAudio != null)
                {
                    TaskValues.nAudio.Play();
                }
                if(TaskValues.animator != null)
                {
                    //animator play
                }
                //if statement to see if the enemy hears you
                if (TaskValues.NoiseRange >= Dist)
                {
                    EnemyNavigation.EnemyNav.eAgnt.ResetPath();
                    EnemyNavigation.EnemyNav.eAgnt.destination = TaskValues.gameObject.transform.position;
                }
            }
        }
        
    }
}
