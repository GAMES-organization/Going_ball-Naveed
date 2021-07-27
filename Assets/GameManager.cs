using System.Collections.Generic;
using System.Collections;
using UnityEngine;
public class GameManager : MonoBehaviour

{
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            return instance;
        }
    }

    private static GameManager instance = null;
    void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //use your playerprefs and code
            if (!PlayerPrefs.HasKey("CurrentLevelP"))
            {
                PlayerPrefs.SetInt("CurrentLevelP", 1);
            }
            if (!PlayerPrefs.HasKey("Levelno"))
            {
                PlayerPrefs.SetInt("Levelno", 1);
            }
        }
    }

}
