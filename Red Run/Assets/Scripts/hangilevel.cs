using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class hangilevel : MonoBehaviour
{
    
    GameObject leveller;
    GameObject kilitler;
    void Start()
    {
        leveller = GameObject.Find("leveller");
        kilitler = GameObject.Find("kilitler");

        for (int i = 0; i < PlayerPrefs.GetInt("kacincilevel"); i++)
        {
            leveller.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }

        for (int i = 0; i <PlayerPrefs.GetInt("kacincilevel"); i++)
        {
            kilitler.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void gb(int gbtn)
    {
       
        if (gbtn==0)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("kacincilevel"); i++)
            {
                leveller.transform.GetChild(i).GetComponent<Button>().interactable = false;
            }
            for (int i = 0; i < PlayerPrefs.GetInt("kacincilevel"); i++)
            {
                kilitler.transform.GetChild(i).gameObject.SetActive(true);
            }
            PlayerPrefs.DeleteAll();
        }

        if (gbtn == 1)
        {
            SceneManager.LoadScene("Ana Menü");
        }
        else if (gbtn==2)
        {
            SceneManager.LoadScene("level1");
            Time.timeScale = 1;
        }
        else if (gbtn == 3)
        {
            SceneManager.LoadScene("level2");
            Time.timeScale = 1;
        }
        else if (gbtn == 4)
        {
            SceneManager.LoadScene("level3");
            Time.timeScale = 1;
        }
        else if (gbtn == 5)
        {
            SceneManager.LoadScene("level4");
            Time.timeScale = 1;
        }
        else if (gbtn == 6)
        {
            SceneManager.LoadScene("level5");
            Time.timeScale = 1;
        }
        else if (gbtn == 7)
        {
            SceneManager.LoadScene("level6");
            Time.timeScale = 1;
        }
        else if (gbtn == 8)
        {
            SceneManager.LoadScene("level7");
            Time.timeScale = 1;
        }
        else if (gbtn == 9)
        {
            SceneManager.LoadScene("level8");
            Time.timeScale = 1;
        }
        else if (gbtn == 10)
        {
            SceneManager.LoadScene("level9");
            Time.timeScale = 1;
        }
        else if (gbtn == 11)
        {
            SceneManager.LoadScene("level10");
            Time.timeScale = 1;
        }
        else if (gbtn == 12)
        {
            SceneManager.LoadScene("level11");
            Time.timeScale = 1;
        }
        else if (gbtn == 13)
        {
            SceneManager.LoadScene("level12");
            Time.timeScale = 1;
        }
        else if (gbtn == 14)
        {
            SceneManager.LoadScene("level13");
            Time.timeScale = 1;
        }
        else if (gbtn == 15)
        {
            SceneManager.LoadScene("level14");
            Time.timeScale = 1;
        }
        else if (gbtn == 16)
        {
            SceneManager.LoadScene("level15");
            Time.timeScale = 1;
        }
        else if (gbtn == 17)
        {
            SceneManager.LoadScene("level16");
            Time.timeScale = 1;
        }
        else if (gbtn == 18)
        {
            SceneManager.LoadScene("level17");
            Time.timeScale = 1;
        }
        else if (gbtn == 19)
        {
            SceneManager.LoadScene("level18");
            Time.timeScale = 1;
        }
        else if (gbtn == 20)
        {
            SceneManager.LoadScene("level19");
            Time.timeScale = 1;
        }
        else if (gbtn == 21)
        {
            SceneManager.LoadScene("level20");
            Time.timeScale = 1;

        }
    }
}
