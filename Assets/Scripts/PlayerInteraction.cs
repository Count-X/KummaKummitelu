using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction playerInt;
    public Camera cam;
    public TMP_Text interactText;
    public Transform Enemy;
    public TaskObject TaskValues = null;

    private void Start()
    {
        if(playerInt == null)
        {
            playerInt = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward.normalized);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5f) && hit.collider.CompareTag("Task") | hit.collider.CompareTag("Door"))
        {
           
            TaskValues = hit.collider.gameObject.GetComponent<TaskObject>();
            interactText.text = TaskValues.interactText;
            interactText.gameObject.SetActive(true);
          

            if (Input.GetKeyDown(KeyCode.E) && hit.collider.CompareTag("Task"))
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
                    TaskValues.animator.Play("kirja");
                }
                EnemyHearing.hearing.Hear(TaskValues.NoiseRange, TaskValues.transform);
                TaskValues.Done = true;
                Tasks.tasksSingleton.CheckObjectives();
            }
            else if (Input.GetKeyDown(KeyCode.E) && hit.collider.CompareTag("Door"))
            {
                TaskValues.Open = true;
                EnemyHearing.hearing.Hear(10f, hit.collider.gameObject.transform);
            }
        }
        else
        {
            interactText.gameObject.SetActive(false);
        }
    }
}
