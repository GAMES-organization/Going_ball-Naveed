using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionScript : MonoBehaviour
{
    public GameObject loading;
    public List<Button> TotalLevels = new List<Button>();
    public GameObject[] LockImages;
    public AudioSource btn;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            AudioListener.volume = 0f;
        }
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            AudioListener.volume = 1f;
        }
        if (PlayerPrefs.GetInt("Level") == 0)
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        if (TotalLevels.Count > 0)
        {
            // foreach (Button btn in TotalLevels)
            // {
            // 	btn.interactable = false;
            // }
            for (int i = 0; i < (PlayerPrefs.GetInt("Level")); i++)
            {
                TotalLevels[i].interactable = true;
                LockImages[i].SetActive(false);
                //curntLevel[i].SetActive(true);
                if (i == 20)
                {
                    break;
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void back()
    {
        btn.Play();
        loading.SetActive(true);
        SceneManager.LoadScene("MainMenu");
    }
    public void level1()
    {
        btn.Play();
        loading.SetActive(true);
        SceneManager.LoadScene("RollerBall1");
        PlayerPrefs.SetInt("CurrentScene", 1);
        Debug.Log("slfsdlfsdlf" + "CurrentScene");
    }
    public void level2()
    {
        btn.Play();
        loading.SetActive(true);
        SceneManager.LoadScene("RollerBall2");
        PlayerPrefs.SetInt("CurrentScene", 2);
    }
    public void level3()
    {
        btn.Play();
        loading.SetActive(true);
        SceneManager.LoadScene("RollerBall3");
        PlayerPrefs.SetInt("CurrentScene", 3);
    }
    public void level4()
    {
        btn.Play();
        loading.SetActive(true);
        SceneManager.LoadScene("RollerBall4");
        PlayerPrefs.SetInt("CurrentScene", 4);
    }
    public void level5()
    {
        btn.Play();
        loading.SetActive(true);
        SceneManager.LoadScene("RollerBall5");
        PlayerPrefs.SetInt("CurrentScene", 5);
    }
    public void level6()
    {
        btn.Play();
        loading.SetActive(true);
        SceneManager.LoadScene("RollerBall6");
        PlayerPrefs.SetInt("CurrentScene", 6);
    }
    public void level7()
    {
        btn.Play();
        loading.SetActive(true);
        SceneManager.LoadScene("RollerBall7");
        PlayerPrefs.SetInt("CurrentScene", 7);
    }
    public void level8()
    {
        btn.Play();
        loading.SetActive(true);
        SceneManager.LoadScene("RollerBall8");
        PlayerPrefs.SetInt("CurrentScene", 8);
    }
    public void level9()
    {
        btn.Play();
        loading.SetActive(true);
        SceneManager.LoadScene("RollerBall9");
        PlayerPrefs.SetInt("CurrentScene", 9);
    }
    public void level10()
    {
        btn.Play();
        loading.SetActive(true);
        SceneManager.LoadScene("RollerBall10");
        PlayerPrefs.SetInt("CurrentScene", 10);
    }
}
