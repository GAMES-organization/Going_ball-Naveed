using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Material[] skyboxs;
    public GameObject loading,PusePenal, FailDia;
    public static bool gamefail = false;
    public AudioSource btn;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("skyboxs lenght is  "+Random.Range(0,3));
       RenderSettings.skybox=skyboxs[Random.Range(0,3)];
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            AudioListener.volume = 0f;
        }
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            AudioListener.volume = 1f;
        }
        Time.timeScale = 1f;
        loading.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gamefail == true)
        {
            StartCoroutine(gameCor());
            gamefail = false;
        }

    }
    public void PauseScene()
    {
        btn.Play();
        PusePenal.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResScene()
    {
        AdsScript.instance.ShowInterstitial();
        btn.Play();
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex));
    }
    public void RestartScene()
    {
        AdsScript.instance.ShowInterstitial();
        btn.Play();
        Time.timeScale = 1f;
        loading.SetActive(true);
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex));
    }
    public void NextScene()
    {
        AdsScript.instance.ShowInterstitial();
        loading.SetActive(true);
        PlayerPrefs.SetInt("CurrentLevelP", PlayerPrefs.GetInt("CurrentLevelP") + 1);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        int x = Random.Range(1, 19);
        btn.Play();
        if (PlayerPrefs.GetInt("CurrentLevelP") > 20)
        {
            PlayerPrefs.GetInt("CurrentLevelP", x);
        }
        SceneManager.LoadScene(("RollerBall" + PlayerPrefs.GetInt("CurrentLevelP").ToString()));
    }
    public void SkipLevel()
    {
        btn.Play();
        loading.SetActive(true); 
        if (PlayerPrefs.GetInt("Level") == PlayerPrefs.GetInt("CurrentScene") && PlayerPrefs.GetInt("Level") < 10)
        {
            Debug.Log("zzzzzzzzzzzzzzzzzzzzzzzzz");
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        }
        SceneManager.LoadScene("LevelSelection");
    }
    public void Resume()
    {
        btn.Play();
        PusePenal.SetActive(false);
        Time.timeScale = 1f;
    }
    private IEnumerator LoadScene(int sceneIndex)
    {
        //Events.SceneUnload.Call();
        yield return new WaitForSeconds(0.1f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
    public void HomeScene()
    {
        AdsScript.instance.ShowInterstitial();
        btn.Play();
        Time.timeScale = 1f;
        loading.SetActive(true);
        SceneManager.LoadScene("MainMenu");
    }
    IEnumerator gameCor()
    {
        // wait for 1 second
        Debug.Log("coroutineA created");
        yield return new WaitForSeconds(1.0f);
        FailDia.SetActive(true);
    }

}
