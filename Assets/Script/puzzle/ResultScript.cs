using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Threading.Tasks;

public class ResultScript : MonoBehaviour
{
    [SerializeField]
    private Button retry;
    [SerializeField]
    private Button end;
    [SerializeField]
    private int retryScene = 1;
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
    private Click_right_BGM _effect;

    [Space(10)]

    [SerializeField]
    private GameObject finish;
    int gameMoneyGet;
    float liedPlus;

    private ScoreHome home = new ScoreHome();
    private PazzleCookMAnager game = new PazzleCookMAnager();
    private bool stop_W;
    private Image[] stock = new Image[5];
    private int star_gap;

    void Awake()
    {
        gameMoneyGet = PlayerPrefs.GetInt("Money");
        Time.timeScale = 1f;
        star_gap = 120;
        stop_W = true;
        game.SetGameStop(false);
        resultObject.SetActive(false);
        retry.onClick.AddListener(Retry);
        end.onClick.AddListener(Quit);
    }

	private void Update()
	{
		if (stop_W)
        {
            GetTime();
        }
	}

	async void ResultSW(bool sw)
    {
        if (sw)
        {
            _effect.Finish_effect();
            finish.transform.DOMoveX(0,2.0f)
                .SetEase(Ease.OutQuad);
            await Task.Delay(3000);
            _effect.Start_bgm();
            Time.timeScale = 0f;
        }
        resultObject.SetActive(sw);
    }

    private void GetTime()
    {
        if (game.TimeValue <= -360f)
        {
            stop_W = false;
            game.SetGameStop(true);
            ResultSW(true);
            if (home.GetPazzleScore < baseScore)
            {
                Star_create(0);
                gold.text = "金貨100獲得しました";
                liedPlus = 3;
                gameMoneyGet += 100;
            }
            else if (home.GetPazzleScore < baseScore+upScore)
            {
                Star_create(1);
                gold.text = "金貨300獲得しました";
                liedPlus = 4;
                gameMoneyGet += 300;
            }
            else if (home.GetPazzleScore < baseScore+upScore*2)
            {
                Star_create(2);
                gold.text = "金貨500獲得しました";
                liedPlus = 5;
                gameMoneyGet += 500;
            }
            else if (home.GetPazzleScore < baseScore+upScore*3)
            {
                Star_create(3);
                gold.text = "金貨700獲得しました";
                liedPlus = 6;
                gameMoneyGet += 700;
            }
            else
            {
                Star_create(4);
                gold.text = "金貨1000獲得しました";
                liedPlus = 7;
                gameMoneyGet += 1000;
            }
            text.text = "" + home.GetPazzleScore;
        }
    }

    private void Star_create(int num)
    {
        Vector3 _position = new Vector3(-240f, -70f, 0f);
        Transform _patent = resultObject.transform;

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
        SceneManager.LoadScene("Scene_pazzle");
    }

    private void Quit()
    {
        Time.timeScale = 1;
        int score = home.GetPazzleScore;
        int miniGame = PlayerPrefs.GetInt("MiniGame");

        if (miniGame == 4)
        {
            int cleanTimes = PlayerPrefs.GetInt("CleanNumber");
            cleanTimes += 1;
            PlayerPrefs.SetInt("CleanNumber", cleanTimes);

            /////////////////////////////////////gameshow
            float liedHeart = PlayerPrefs.GetFloat("LiedHeart");
            liedHeart += liedPlus;
            PlayerPrefs.SetFloat("LiedHeart", liedHeart);
            /////////////////////////////////////

            PlayerPrefs.SetInt("Money", gameMoneyGet);
            PlayerPrefs.SetInt("NovelMenu", 13);
            SceneManager.LoadScene("Novel");
        }
        else if (miniGame == 1)
        {
            PlayerPrefs.SetInt("NovelMenu", 0);
            SceneManager.LoadScene("Novel");
        }
        else
        {
            PlayerPrefs.SetInt("ScoreClean", score);
            SceneManager.LoadScene("TitleScreen");
        }
    }
}
