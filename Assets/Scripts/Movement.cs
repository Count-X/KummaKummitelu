using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.CoreModule;

public class Movement : MonoBehaviour
{

    public float fSpeed;
    public float sSpeed;

    public CapsuleCollider playerCollider;

    private float ogSSpeed;
    private float ogFSpeed;

    private Rigidbody rb;


    private void Start()
    {
        ogFSpeed = fSpeed;
        ogSSpeed = sSpeed;

        rb = gameObject.GetComponent<Rigidbody>();
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            fSpeed /= 2;
            sSpeed /= 2;

            playerCollider.height = 1.25f;

        } else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            fSpeed *= 1.5f;
            fSpeed *= 1.5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            fSpeed = ogFSpeed;
            sSpeed = ogSSpeed;

            playerCollider.height = 2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            fSpeed = ogFSpeed;
            sSpeed = ogSSpeed;
        }

        transform.position += transform.forward * Input.GetAxis("Vertical") * fSpeed;
        transform.position += transform.right * Input.GetAxis("Horizontal") * sSpeed;

    }


}
