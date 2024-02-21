using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowController : MonoBehaviour
{
    public Transform cameraPos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = new Vector3(cameraPos.position.x, cameraPos.position.y, cameraPos.position.z);
        transform.position = playerPos;
    }
}
