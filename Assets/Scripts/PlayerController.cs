using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 mousePosition;
    private float currentDistance;
    private Vector3 directionToPoint;
    private Vector3 lookDirection;

    public float speed = 5f;
    public float rotateSpeed = 3f;

    private AudioSource audioSource;

    public ParticleSystem engineFire;

    void Start()
    {
        currentDistance = 0;
        mousePosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetPointToMove(Input.mousePosition);
        }
        if (Input.touchCount > 0)
        {
            GetPointToMove(Input.GetTouch(0).position);
        }

        MoveToPoint();
    }

    void GetPointToMove(Vector3 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            mousePosition = new Vector3(hitInfo.point.x, 0, hitInfo.point.z);
        }
    }

    void MoveToPoint()
    {
        currentDistance = Vector3.Distance(transform.position, mousePosition);
        TurnEngine();

        if (currentDistance > 5)
            transform.Translate(speed * Time.deltaTime * Vector3.forward);
        else
            transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);

        RotateInMove();
    }

    void RotateInMove()
    {
        directionToPoint = mousePosition - transform.position;
        lookDirection = Vector3.RotateTowards(transform.forward, directionToPoint, rotateSpeed * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }

    void TurnEngine()
    {
        if (currentDistance > 0)
        {
            engineFire.Play();
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            engineFire.Stop();
            if (audioSource.isPlaying)
                audioSource.Stop();
        }
    }

    public Vector3 GetPlayerPosition()
    {
        return transform.position;
    }
}
