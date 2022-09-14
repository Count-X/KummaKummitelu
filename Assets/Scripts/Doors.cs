using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{

    public bool DoubleDoor;

    public Transform Player;

    private Quaternion cRot;
    private Quaternion oRot;

    void Start()
    {
        cRot = transform.rotation;
        oRot = new Quaternion(transform.rotation.x, transform.rotation.y - 90f, transform.rotation.z, transform.rotation.w);
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, Player.position) <= 7.5f)
        {
            if(transform.eulerAngles.y <= -90f)
            transform.Rotate(oRot.eulerAngles * Time.deltaTime);
        }
        else
        {
            if(transform.eulerAngles.y >= 0f)
            transform.Rotate(cRot.eulerAngles * Time.deltaTime);
        }
    }
}
