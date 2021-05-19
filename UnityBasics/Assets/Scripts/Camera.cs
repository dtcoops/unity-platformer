using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private int cameraAxisZ = -6; 

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = playerGameObject.transform.position;
        this.transform.position = new Vector3(playerPosition.x, playerPosition.y, cameraAxisZ);
    }
}
