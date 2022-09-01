using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.CoreModule;

public class Movement : MonoBehaviour
{

    public float fSpeed;
    public float sSpeed;
    public float rotateSH = 2.0f;
    public float rotateSV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float ogSSpeed;
    private float ogFSpeed;

    private Rigidbody rb;
    private Camera cam;

    private void Start()
    {
        ogFSpeed = fSpeed;
        ogSSpeed = sSpeed;
        //rb = gameObject.GetComponent<Rigidbody>();
        cam = gameObject.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            fSpeed /= 2;
            sSpeed /= 2;
        } else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            fSpeed *= 1.5f;
            fSpeed *= 1.5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            fSpeed = ogFSpeed;
            sSpeed = ogSSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            fSpeed = ogFSpeed;
            sSpeed = ogSSpeed;
        }

        yaw += rotateSH * Input.GetAxis("Mouse X");
        pitch -= rotateSV * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -80, 80);
        transform.position += transform.forward * Input.GetAxis("Vertical") * fSpeed;
        transform.position += transform.right * Input.GetAxis("Horizontal") * sSpeed;
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    }
}
