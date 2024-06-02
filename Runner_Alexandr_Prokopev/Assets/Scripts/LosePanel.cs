using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    public void RestartLevel()
    {
        
        if (PlayerController.crystals >= Portals.crystalsToWin)
        {
            GameObject.FindGameObjectWithTag("Portal").GetComponent<Portals>().Portal.SetActive(false);

        } else if (PlayerController.crystals_02 >= Portals.crystalsToWin)
        {
            GameObject.FindGameObjectWithTag("Portal").GetComponent<Portals>().Portal_02.SetActive(false);

        } else if (PlayerController.crystals_03 >= Portals.crystalsToWin)
        {
            GameObject.FindGameObjectWithTag("Portal").GetComponent<Portals>().Portal_03.SetActive(false);
        }

        PlayerController.crystals = 0;
        PlayerController.crystals_02 = 0;
        PlayerController.crystals_03 = 0;

        SceneManager.LoadScene(1);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
        
    }
}
