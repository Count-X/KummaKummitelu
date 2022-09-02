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
            Ray ray = new Ray( cam.transform.position, cam.transform.forward.normalized);
            RaycastHit hit;

            Debug.DrawRay(cam.transform.position, cam.transform.forward.normalized, Color.red, 3f);
            Debug.Log("Pressed E");

            if (col.Raycast(ray, out hit, 10f))
            {
                Debug.Log("Interacted");
                audioS.Play();
            }
        }
    }
}
