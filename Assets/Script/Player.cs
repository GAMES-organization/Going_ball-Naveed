using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject FailDia, Ball,compDia;
    public GameObject[]  Bpostion;
    public Text levelNum;
    public Rigidbody rb;
    //public Transform Player;
    int count;
    // Start is called before the first frame update
    private void Awake()
    {
        levelNum = GameObject.FindGameObjectWithTag("leveltxt").GetComponent<Text>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        AdsScript.instance.ShowSmartBanner();
        levelNum.text = PlayerPrefs.GetInt("CurrentLevelP").ToString();
        count = 0;
        PlayerPrefs.SetInt("Currentlevel",-1);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("other");
        if(other.tag == "Finish")
        {
            count ++; 
            //PlayerPrefs.SetInt("Currentlevel", PlayerPrefs.GetInt("Currentlevel") + 1);
            Debug.Log("Finish"      + count);
            if (count < 3)
            {
                rb.isKinematic = true;
                StartCoroutine(coroutineA());
                //Levels[PlayerPrefs.GetInt("Currentlevel")].SetActive(true);
                Ball.transform.position = Bpostion[PlayerPrefs.GetInt("Currentlevel")].transform.position;
                Ball.transform.rotation = Bpostion[PlayerPrefs.GetInt("Currentlevel")].transform.rotation;
            }
        }
        if (other.tag == "Post")
        {
            PlayerPrefs.SetInt("Currentlevel", PlayerPrefs.GetInt("Currentlevel") + 1);
            Debug.Log("Finish" + count);
        }
        if (count >= 3)
        {
            Debug.Log("faildia" + count);
            FailDia.SetActive(true);
        }
        if (other.tag == "Complete")
        {
            rb.isKinematic = true;
            compDia.SetActive(true);
            Debug.Log("adfsdfsdafsdafasd");
            if (PlayerPrefs.GetInt("Level") == PlayerPrefs.GetInt("CurrentScene") && PlayerPrefs.GetInt("Level") < 10)
            {
                Debug.Log("zzzzzzzzzzzzzzzzzzzzzzzzz");
            }
         }

    }
    IEnumerator coroutineA()
    {
        // wait for 1 second
        Debug.Log("coroutineA created");
        yield return new WaitForSeconds(0.2f);
        rb.isKinematic = false;
    }
}
