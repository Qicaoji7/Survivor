using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class load_scene : MonoBehaviour
{
    AsyncOperation async;

    public static string targetScene;

    /*
    public Image getSlider;
    public Text getText;
    */
    private float target = 0;



    private void Start()
    {
        
        if (SceneManager.GetActiveScene().name != "Loading")
        {
            return;
        }
        async = SceneManager.LoadSceneAsync(targetScene);
        async.allowSceneActivation = false;
    }

    
    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Loading" && async == null)
        {
            return;
        }
       /*if (getSlider.fillAmount >= 0.99)
        {
            getSlider.fillAmount = 1;
            getText.text = "100%";
       */
            async.allowSceneActivation = true;
        /*
        }
        else
        {
            target = Mathf.Lerp(target, async.progress, Time.deltaTime);
            getSlider.fillAmount = target / 9 * 10;
            getText.text = ((int)(getSlider.fillAmount * 100)).ToString() + "%";
        }
        */
    }
}
