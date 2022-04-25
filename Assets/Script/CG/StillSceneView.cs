using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StillSceneView : MonoBehaviour
{
    [SerializeField]
    private Button scenePlay;
    [SerializeField]
    private Button itemBlind;

    //↓イベント再生条件
    //[SerializeField]
    //private int startStill;
    //[SerializeField]
    //private int endStill;
    //[SerializeField]
    //private int month = 1;
    //[SerializeField]
    //private int day = 1;
    //[SerializeField]
    //private int liedAff;
    //[SerializeField]
    //private int kleinAff;
    //[SerializeField]
    //private int novelMenu;
    //[SerializeField]
    //private int resetPos;

    private bool setBlind;
    //private int[] itemNumber = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    private void Start()
    {
        setBlind = true;

        //scenePlay.onClick.AddListener(PlaySceneCG);
        itemBlind.onClick.AddListener(BlindUI);
    }

    private void BlindUI()
    {
        if (setBlind)
        {
            this.gameObject.SetActive(false);
            setBlind = false;
        }
    }

    private void PlaySceneCG()
    {
        /*
        PlayerPrefs.SetInt("LogNow", 1);
        
        //変数で変える
        PlayerPrefs.SetInt("NovelMenu", novelMenu);
        PlayerPrefs.SetInt("ResetPos", resetPos);
        PlayerPrefs.SetInt("StartLine", startStill);
        PlayerPrefs.SetInt("EndLine", endStill);
        int[] startDate = { month, day };
        PlayerPrefsX.SetIntArray("Date", startDate);
		PlayerPrefs.SetFloat("LiedHeart", liedAff);
		PlayerPrefs.SetFloat("KleinHeart", kleinAff);
        
        //基本的に変えない
        PlayerPrefs.SetString("BackgroundClip", "");
        PlayerPrefs.SetInt("LiedFail", 0);
        PlayerPrefs.SetInt("KleinFail", 0);
        PlayerPrefs.SetInt("WhichFile", 0);
        PlayerPrefs.SetInt("MiniGame", 0);
        PlayerPrefsX.SetIntArray("ItemNumber", itemNumber);
        
        SceneManager.LoadScene("Novel");
         */
    }

    public void ShowUI()
    {
        this.gameObject.SetActive(true);
        setBlind = true;
    }

    public bool GetSetBlind()
    {
        return setBlind;
    }
}
