using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{

    public Transform[] taskTransforms;

    public enum ETasks
    {
        CleanFireplace,
        FlowerVase,
        CleanPiano,
        CleanBShelf,
        CleanStatue,
        CleanTable,
    }

    // Start is called before the first frame update
    void Start()
    {
        taskTransforms = gameObject.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
