using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Camera cam;
    public Collider col;
    public AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(cam.transform.forward.normalized, cam.transform.position);
            RaycastHit hit;

            Debug.Log("Pressed E");

            if (Physics.Raycast(ray, out hit, 10f))
            {
                Debug.Log("Interacted");
                audioS.Play();
            }
        }
    }
}
