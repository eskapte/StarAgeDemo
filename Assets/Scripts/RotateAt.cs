using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAt : MonoBehaviour
{
    public GameObject rotateAt;
    public float speed;

    void Update()
    {
        transform.RotateAround(rotateAt.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
