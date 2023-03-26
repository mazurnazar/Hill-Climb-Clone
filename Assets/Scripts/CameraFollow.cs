using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform car;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - car.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = car.position + offset;
    }
}
