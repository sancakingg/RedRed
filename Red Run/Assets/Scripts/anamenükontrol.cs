using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class anamenükontrol : MonoBehaviour
{
    
    void Start()
    {
        
    }

    public void butonsec(int gelenbuton)
    {
        if (gelenbuton==1)
        {
            if (PlayerPrefs.GetInt("kacincilevel")>1)
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("kacincilevel"));
            }
            else
            {
                SceneManager.LoadScene("level1");
            }
            
            Time.timeScale = 1;
        }
        else if (gelenbuton==2)
        {
            SceneManager.LoadScene("levels");
        }
        else if (gelenbuton==3)
        {
            Application.Quit();
        }
    }
}
