using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    public Transform target;
    public Vector3 targetPosition2D;
    public float yDistance;
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            targetPosition2D = target.position;
            transform.position = new Vector3(targetPosition2D.x, targetPosition2D.y + yDistance, targetPosition2D.z);
        }
    }
}
