using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamics_Obstructions : MonoBehaviour
{
    private Animator anim;
    

    float speedCoefficient = -1f;
    float speedCoefficient_02 = 2f;


    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("Walk_Anim");
    }


    public void FixedUpdate()
    {

        transform.position = new Vector3(transform.position.x + Time.deltaTime * speedCoefficient, transform.position.y, transform.position.z);
        if (transform.position.x == -0.5f)
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * speedCoefficient_02, transform.position.y, transform.position.z);
        }
        
    }

                
}
