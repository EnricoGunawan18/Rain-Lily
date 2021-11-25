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

	int gameMoneyGet;

	void Start()
	{
		memorygamescript = GameObject.Find("MemoryGameScript").GetComponent<MemoryGameScript>();

		gameMoneyGet = PlayerPrefs.GetInt("Money");

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

		else if (miniGame == 2 || miniGame == 3)
		{
			PlayerPrefs.SetInt("NovelMenu", 0);
			SceneManager.LoadScene("Novel");
		}

		else if (miniGame == 5)
		{
			PlayerPrefs.SetInt("NovelMenu", 13);
			SceneManager.LoadScene("Novel");
		}

		else if (miniGame == 6)
		{
			int shopTimes = PlayerPrefs.GetInt("ShopNumber");
			shopTimes += 1;
			PlayerPrefs.SetInt("ShopNumber", shopTimes);

			PlayerPrefs.SetInt("Money", gameMoneyGet);
			PlayerPrefs.SetInt("NovelMenu", 11);
			SceneManager.LoadScene("Novel");
		}

		else
		{
			SceneManager.LoadScene("TitleScreen");
		}

		if (recentScore >= 6000)
		{
			gameMoneyGet += 1000;
			Star[0].color = new Color32(255, 255, 255, 255);
			Star[1].color = new Color32(255, 255, 255, 255);
			Star[2].color = new Color32(255, 255, 255, 255);
			Star[3].color = new Color32(255, 255, 255, 255);
			Star[4].color = new Color32(255, 255, 255, 255);
		}
		else if (recentScore >= 3000)
		{
			gameMoneyGet += 700;
			Star[0].color = new Color32(255, 255, 255, 255);
			Star[1].color = new Color32(255, 255, 255, 255);
			Star[2].color = new Color32(255, 255, 255, 255);
			Star[3].color = new Color32(255, 255, 255, 255);

		}
		else if (recentScore >= 1500)
		{
			gameMoneyGet += 500;
			Star[0].color = new Color32(255, 255, 255, 255);
			Star[1].color = new Color32(255, 255, 255, 255);
			Star[2].color = new Color32(255, 255, 255, 255);

		}
		else if (recentScore >= 900)
		{
			gameMoneyGet += 300;
			Star[0].color = new Color32(255, 255, 255, 255);
			Star[1].color = new Color32(255, 255, 255, 255);

		}
		else
		{
			gameMoneyGet += 100;
			Star[0].color = new Color32(255, 255, 255, 255);
		}
		MoneyGet.text = "金貨" + gameMoneyGet.ToString() + "獲得しました";

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