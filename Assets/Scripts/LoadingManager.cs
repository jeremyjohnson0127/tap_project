using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour {
    public Image loadBar;
    float time = 0;
    public Image LoadTip;
    public Sprite[] tips;
    bool bShowTip = false;
    int bSplashEffect = 0;

    // Use this for initialization
    void Start () {
        time = Time.time;

        string dataSplashEffect = SaveLoadData.LoadData("SaveSplashEffect", true);
        if (dataSplashEffect == "") dataSplashEffect = bSplashEffect.ToString();
        bSplashEffect = int.Parse(dataSplashEffect);        
    }

    // Update is called once per frame
    void Update () {
        loadBar.fillAmount += 0.01f;
        if (loadBar.fillAmount >= 0.3 && !bShowTip && bSplashEffect == 1)
        {
            int ran = Random.Range(0, tips.Length);
            LoadTip.sprite = tips[ran];
            bShowTip = true;
            LoadTip.transform.parent.gameObject.SetActive(true);
        }

        if (loadBar.fillAmount >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	}
}
