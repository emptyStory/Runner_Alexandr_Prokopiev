using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public GameObject Portal;
    public GameObject Portal_02;
    public GameObject Portal_03;

    public static int crystalsToWin = 7;

    void Update()
    {
        if (PlayerController.crystals >= crystalsToWin)
        {
            Portal.SetActive(true);
        }
        else if (PlayerController.crystals_02 >= crystalsToWin)
        {
            Portal_02.SetActive(true);
        }
        else if (PlayerController.crystals_03 >= crystalsToWin)
        {
            Portal_03.SetActive(true);
        } else
        {

        }
    }
}
