using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.CoreModule;

public class Movement : MonoBehaviour
{
    public static Movement Mvmnt;

    public float Noise = 3f;
    public float fSpeed;
    public float sSpeed;

    public CapsuleCollider playerCollider;

    private float ogSSpeed;
    private float ogFSpeed;
    private float sNoise;
    private float cNoise;
    private float ogNoise;

    private Rigidbody rb;


    private void Start()
    {
        ogFSpeed = fSpeed;
        ogSSpeed = sSpeed;

        rb = gameObject.GetComponent<Rigidbody>();
        sNoise = Noise * 2;
        cNoise = Noise / 2;
        ogNoise = Noise;
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            fSpeed /= 2;
            sSpeed /= 2;

            playerCollider.height = 1.25f;
            Noise = cNoise;

        } else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            fSpeed *= 1.5f;
            fSpeed *= 1.5f;
            Noise = sNoise;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            fSpeed = ogFSpeed;
            sSpeed = ogSSpeed;

            playerCollider.height = 2f;
            Noise = ogNoise;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            fSpeed = ogFSpeed;
            sSpeed = ogSSpeed;
            Noise = ogNoise;
        }

        if (Input.GetAxis("Vertical") != 0f | Input.GetAxis("Horizontal") != 0f)
        EnemyHearing.hearing.Hear(Noise, transform);

        transform.position += transform.forward * Input.GetAxis("Vertical") * fSpeed;
        transform.position += transform.right * Input.GetAxis("Horizontal") * sSpeed;

    }


}
