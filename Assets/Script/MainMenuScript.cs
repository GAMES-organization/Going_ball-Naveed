using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject sitting,on,off;
    public AudioSource btn;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            PlayerPrefs.SetInt("Music", 0);
            PlayerPrefs.SetInt("Sound", 1);
        }
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            on.SetActive(true);
            off.SetActive(false);
            AudioListener.volume = 0f;
        }
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            off.SetActive(true);
            on.SetActive(false);
            AudioListener.volume = 1f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        int x=0;
        x = Random.Range(1, 19);
        btn.Play();
        if(PlayerPrefs.GetInt("CurrentLevelP")>20)
        {
            PlayerPrefs.GetInt("CurrentLevelP",x);
        }
         SceneManager.LoadScene(("RollerBall"+PlayerPrefs.GetInt("CurrentLevelP").ToString()));
        // SceneManager.LoadScene("LevelSelection");
    }
    public void Sitting()
    {
        btn.Play();
        sitting.SetActive(true);
    }
    public void back()
    {
        btn.Play();
        sitting.SetActive(false);
    }
    public void musicOn()
    {
        btn.Play();
        off.SetActive(true);
        on.SetActive(false);
        AudioListener.volume = 1f;
        PlayerPrefs.SetInt("Music", 0);
    }
    public void musicOff()
    {
        btn.Play();
        on.SetActive(true);
        off.SetActive(false);
        AudioListener.volume = 0f;
        PlayerPrefs.SetInt("Music", 1);
    }
    public void LinkOpen(string x)
    {
        Application.OpenURL(x);
    }
}
