using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{

    public Transform tDoor;

    private Quaternion OpenRot;
    private Quaternion ClosedRot;

    void Start()
    {
        OpenRot.y = tDoor.eulerAngles.y + 90f;
        ClosedRot = tDoor.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tDoor.Rotate(tDoor.rotation.x, tDoor.rotation.y + 90f, tDoor.rotation.z);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tDoor.Rotate(tDoor.rotation.x, tDoor.rotation.y - 90f, tDoor.rotation.z);
        }
    }
}
