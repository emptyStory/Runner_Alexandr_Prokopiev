using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,49 * Time.deltaTime, 0);
    }
}
