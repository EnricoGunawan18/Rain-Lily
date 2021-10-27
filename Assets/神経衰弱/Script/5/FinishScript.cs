using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    MemoryGameScript memorygamescript;

    [SerializeField]
    public GameObject Finish;
    [SerializeField]
    public GameObject ScoreSheet;
    [SerializeField]
    public GameObject PauseDeactivate;
    [SerializeField]
    public GameObject finishScreen;

    public float timeReadyStart = 0;
    public float timeFromStart = 0;

    [SerializeField]
    public Text ScoreTotal;

    [SerializeField]
    public Image[] Star;

    [SerializeField]
    public Text MoneyGet;

    public float recentScore;

    public float totalScore;

    float score1;
    float score2;
    float score3;
    float score4;
    float score5;


    bool timeStopper = false;

    void Start()
    {
        memorygamescript = GameObject.Find("MemoryGameScript").GetComponent<MemoryGameScript>();


        timeReadyStart = Time.time;

        for (int i = 0; i < 5; i++)
        {
            Star[i].color = new Color32(100, 100, 100, 255);
        }

    }

    void Update()
    {
        int miniGame = PlayerPrefs.GetInt("MiniGame");

        if (finishScreen.GetComponent<FinishScript>().enabled == true && timeStopper == false)
        {
            PauseDeactivate.SetActive(false);

            timeFromStart = memorygamescript.timer;

            score1 = PlayerPrefs.GetFloat("Score1");
            score2 = PlayerPrefs.GetFloat("Score2");
            score3 = PlayerPrefs.GetFloat("Score3");
            score4 = PlayerPrefs.GetFloat("Score4");

            PlayerPrefs.SetFloat("Score5", memorygamescript.scoreNow);
            score5 = PlayerPrefs.GetFloat("Score5");

            totalScore = score1 + score2 + score3 + score4 + score5;
            PlayerPrefs.SetFloat("ScoreAll", totalScore);
            recentScore = PlayerPrefs.GetFloat("ScoreAll");
            ScoreTotal.text = PlayerPrefs.GetFloat("ScoreAll").ToString();


            timeStopper = true;
        }

        float starter = Time.time - timeReadyStart - timeFromStart;

        if (starter <= 2)
        {
            Finishing();
        }

        else if (starter > 2 && starter <= 6)
        {
            Scoring();
        }

        else if (miniGame == 1 || miniGame == 2 || miniGame == 3)
        {
            PlayerPrefs.SetInt("NovelMenu", 0);
            SceneManager.LoadScene("Novel");
        }

        else
        {
            SceneManager.LoadScene("TitleScreen");
        }

        if (recentScore >= 0)
        {
            Star[0].color = new Color32(255, 255, 255, 255);
            MoneyGet.text = "‹à‰Ý100Šl“¾‚µ‚Ü‚µ‚½";
        }
        if (recentScore >= 900)
        {
            Star[1].color = new Color32(255, 255, 255, 255);
            MoneyGet.text = "‹à‰Ý300Šl“¾‚µ‚Ü‚µ‚½";

        }
        if (recentScore >= 1500)
        {
            Star[2].color = new Color32(255, 255, 255, 255);
            MoneyGet.text = "‹à‰Ý500Šl“¾‚µ‚Ü‚µ‚½";

        }
        if (recentScore >= 3000)
        {
            Star[3].color = new Color32(255, 255, 255, 255);
            MoneyGet.text = "‹à‰Ý700Šl“¾‚µ‚Ü‚µ‚½";

        }
        if (recentScore >= 6000)
        {
            Star[4].color = new Color32(255, 255, 255, 255);
            MoneyGet.text = "‹à‰Ý1000Šl“¾‚µ‚Ü‚µ‚½";

        }

    }


    public void Finishing()
    {
        Finish.SetActive(true);
        //Time.timeScale = 0f;
        ScoreSheet.SetActive(false);
    }
    public void Scoring()
    {
        ScoreSheet.SetActive(true);
        //Time.timeScale = 0f;
        Finish.SetActive(false);
    }
}