using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public Camera cam;
    public TMP_Text interactText;
    public Transform Enemy;
    public TaskObject TaskValues;
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
                //audioS.Play();
                // Tähän Mitä tapahtuu kun pelaaja interaktioi, Refrenssi scriptiin mahdollisesti
                if(TaskValues.nAudio != null)
                {
                    TaskValues.nAudio.Play();
                }
                if(TaskValues.animator != null)
                {
                    //animator play
                }
            }
        }
        else
        {
            
            interactText.gameObject.SetActive(false);
        }
    }
}
