using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDynamicObstruction : MonoBehaviour
{
    private float speedCoefficient = -1f;
    private float speedCoefficient_02 = 2f;

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * speedCoefficient, transform.position.y, transform.position.z);
        if (transform.position.x == -0.5f)
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * speedCoefficient_02, transform.position.y, transform.position.z);
        }
    }
}
