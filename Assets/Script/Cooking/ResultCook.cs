using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Threading.Tasks;

public class ResultCook : MonoBehaviour
{
    [SerializeField]
    private Button retry;
    [SerializeField]
    private Button end;
    [SerializeField]
    private int retryScene = 2;
    [SerializeField]
    private GameObject resultObject;
    [SerializeField]
    private Text text;
    [SerializeField]
    private Text gold;
    [SerializeField]
    private int baseScore = 1000;
    [SerializeField]
    private int upScore = 500;
    [SerializeField]
    private Image star;
    [SerializeField]
    private Image star_s;
    [SerializeField]
    private Click_right_BGM _sound;

    [Space(10)]

    [SerializeField]
    private GameObject finish;
    private bool frag;
    int gameMoneyGet;
    float liedPlus;
    float kleinPlus;
    int affPlusLied;
    int affPlusKlein;

    private ScoreHome home = new ScoreHome();
    private GameManage game = new GameManage();
    private Image[] stock = new Image[5];

    public void ResultAwake()
    {
        gameMoneyGet = PlayerPrefs.GetInt("Money");
        frag = false;
        Time.timeScale = 1f;
        game.SetGameStop(false);
        resultObject.SetActive(false);
        retry.onClick.AddListener(Retry);
        end.onClick.AddListener(Quit);
    }

    public void ResultUpdate()
    {
        if (game.TimeValue <= -360f&&!frag)
        {
            GetTime();
            frag = true;
        }
    }

    async void ResultSW(bool sw)
    {
        if (sw)
        {
            finish.SetActive(true);
            _sound.Finish_effect();
            finish.transform.DOMoveX(0, 2.0f)
                .SetEase(Ease.OutQuad);
            await Task.Delay(3000);
            _sound.Start_bgm();
            Time.timeScale = 0f;
        }
        finish.SetActive(false);
        resultObject.SetActive(sw);
    }

    private void GetTime()
    {
        game.SetGameStop(true);
        ResultSW(true);
        if (home.GetCookScore < baseScore)
        {
            Star_create(0);
            gold.text = "金貨100獲得しました";
            if (affPlusLied == 2)
            {
                liedPlus = 3;
            }
            if (affPlusKlein == 2)
            {
                kleinPlus = 3;
            }
            gameMoneyGet += 100;
        }
        else if (home.GetCookScore < baseScore + upScore)
        {
            Star_create(1);
            gold.text = "金貨300獲得しました";
            if (affPlusLied == 2)
            {
                liedPlus = 4;
            }
            if (affPlusKlein == 2)
            {
                kleinPlus = 4;
            }
            gameMoneyGet += 300;
        }
        else if (home.GetCookScore < baseScore + upScore * 2)
        {
            Star_create(2);
            gold.text = "金貨500獲得しました";
            if (affPlusLied == 2)
            {
                liedPlus = 5;
            }
            if (affPlusKlein == 2)
            {
                kleinPlus = 5;
            }
            gameMoneyGet += 500;
        }
        else if (home.GetCookScore < baseScore + upScore * 3)
        {
            Star_create(3);
            gold.text = "金貨700獲得しました";
            if (affPlusLied == 2)
            {
                liedPlus = 6;
            }
            if (affPlusKlein == 2)
            {
                kleinPlus = 6;
            }
            gameMoneyGet += 700;
        }
        else
        {
            Star_create(4);
            gold.text = "金貨1000獲得しました";
            if (affPlusLied == 2)
            {
                liedPlus = 7;
            }
            if (affPlusKlein == 2)
            {
                kleinPlus = 7;
            }
            gameMoneyGet += 1000;
        }
        text.text = "" + home.GetCookScore;
    }

    private void Star_create(int num)
    {
        Vector3 _position = new Vector3(-240f, -70f, 0f);
        Transform _patent = resultObject.transform;
        int star_gap = 120;

        for (int i = 0; i < 5; i++)
        {
            if (i > num)
            {
                stock[i] = Instantiate(star_s, _position, Quaternion.identity);
            }
            else
            {
                stock[i] = Instantiate(star, _position, Quaternion.identity);
            }
            stock[i].transform.SetParent(_patent, false);
            _position.x += star_gap;
        }
    }

    private void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene_cook");
    }

    private void Quit()
    {
        Time.timeScale = 1;
        int score = home.GetCookScore;
        int miniGame = PlayerPrefs.GetInt("MiniGame");

        if (miniGame == 5)
        {
            int cookTimes = PlayerPrefs.GetInt("CookNumber");
            cookTimes += 1;
            PlayerPrefs.SetInt("CookNumber", cookTimes);

            /////////////////////////////////////gameshow
            float liedHeart = PlayerPrefs.GetFloat("LiedHeart");
            liedHeart += liedPlus;
            PlayerPrefs.SetFloat("LiedHeart", liedHeart);
            float kleinHeart = PlayerPrefs.GetFloat("KleinHeart");
            kleinHeart += kleinPlus;
            PlayerPrefs.SetFloat("KleinHeart", kleinHeart);

            /////////////////////////////////////

            PlayerPrefs.SetString("BackgroundClip", "");

            PlayerPrefs.SetInt("Money", gameMoneyGet);
            PlayerPrefs.SetInt("NovelMenu", 13);
			PlayerPrefs.SetInt("ChapterScreen", 0);
            SceneManager.LoadScene("Novel");
        }
        else if (miniGame == 2)
        {
            PlayerPrefs.SetString("BackgroundClip", "");
            PlayerPrefs.SetInt("NovelMenu", 0);
			PlayerPrefs.SetInt("ChapterScreen", 0);
            SceneManager.LoadScene("Novel");
        }
        else
        {
            PlayerPrefs.SetInt("ScoreCook", score);
            SceneManager.LoadScene("TitleScreen");
        }
    }
}
