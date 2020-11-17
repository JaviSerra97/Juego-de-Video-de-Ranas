using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float leftLimit;
    public float rightLimit;
    public float botLimit;
    public float topLimit;

    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z); // Camera follows the player with specified offset position

        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            transform.position.y,
            Mathf.Clamp(transform.position.z, botLimit, topLimit)
            ) ;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(leftLimit, 0, topLimit), new Vector3(rightLimit, 0, topLimit));
        Gizmos.DrawLine(new Vector3(rightLimit, 0, topLimit), new Vector3(rightLimit, 0, botLimit));
        Gizmos.DrawLine(new Vector3(rightLimit, 0, botLimit), new Vector3(leftLimit, 0, botLimit));
        Gizmos.DrawLine(new Vector3(leftLimit, 0, botLimit), new Vector3(leftLimit, 0, topLimit));
    }
}
