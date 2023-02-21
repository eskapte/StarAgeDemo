using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityBackground : MonoBehaviour
{
    private MeshRenderer meshRender;
    private PlayerController playerController;
    private Vector3 playerPosition;

    private readonly float offsetK = 0.005f;

    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        playerPosition = playerController.GetPlayerPosition();
        var material = meshRender.material;
        var offset = material.mainTextureOffset;
        offset.y = -playerPosition.z * offsetK;
        offset.x = -playerPosition.x * offsetK;
        material.mainTextureOffset = offset;
    }
}
