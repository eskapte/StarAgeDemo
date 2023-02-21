using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsAxisRotate : MonoBehaviour
{
    public float rotateSpeed = 1f;
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
