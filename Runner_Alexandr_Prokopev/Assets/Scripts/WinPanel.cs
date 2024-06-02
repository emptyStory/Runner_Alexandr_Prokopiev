using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
        PlayerController.crystals = 0;
        PlayerController.crystals_02 = 0;
        PlayerController.crystals_03 = 0;
        GameObject.FindGameObjectWithTag("Portal").GetComponent<Portals>().Portal.SetActive(false);
        GameObject.FindGameObjectWithTag("Portal").GetComponent<Portals>().Portal_02.SetActive(false);
        GameObject.FindGameObjectWithTag("Portal").GetComponent<Portals>().Portal_03.SetActive(false);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
        
    }

  
}
