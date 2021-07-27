using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loading : MonoBehaviour

{
    public Image img;
    bool isFilled=true;
    private void Update()
    {
        img.fillAmount+=Time.deltaTime;
        if (img.fillAmount == 1)
        {
            StartCoroutine(Loading());
            isFilled = false;
        }
    }
    IEnumerator Loading()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
