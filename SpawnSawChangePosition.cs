using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSawChangePosition : MonoBehaviour
{
    public float speed;
    public Vector2 dir;


    void FixedUpdate()
    {
        transform.Translate(speed * dir * Time.deltaTime, Space.World);
    }
}
