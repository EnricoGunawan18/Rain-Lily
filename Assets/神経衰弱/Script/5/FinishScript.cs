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

	bool countMoneyStop = false;

	bool timeStopper = false;

	int gameMoneyGet;

	float liedHeart;
	float kleinHeart;

	void Start()
	{
		memorygamescript = GameObject.Find("MemoryGameScript").GetComponent<MemoryGameScript>();

		gameMoneyGet = PlayerPrefs.GetInt("Money");
		liedHeart = PlayerPrefs.GetFloat("LiedHeart");
		kleinHeart = PlayerPrefs.GetFloat("KleinHeart");

		timeReadyStart = Time.time;

		for (int i = 0; i < 5; i++)
		{
			Star[i].color = new Color32(100, 100, 100, 255);
		}

	}

	void Update()
	{
		int miniGame = PlayerPrefs.GetInt("MiniGame");
		int affUpLied = PlayerPrefs.GetInt("AffUpLied");
		int affUpKlein = PlayerPrefs.GetInt("AffUpKlein");

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
			ScoreTotal.text = totalScore.ToString();


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

		else if ( miniGame == 3)
		{
			PlayerPrefs.SetString("BackgroundClip", "");
			PlayerPrefs.SetInt("NovelMenu", 0);
			SceneManager.LoadScene("Novel");
		}

		else if (miniGame == 6)
		{
			int shopTimes = PlayerPrefs.GetInt("ShopNumber");
			shopTimes += 1;
			PlayerPrefs.SetInt("ShopNumber", shopTimes);
			PlayerPrefs.SetFloat("LiedHeart", liedHeart);
			PlayerPrefs.SetFloat("KleinHeart", kleinHeart);
			PlayerPrefs.SetInt("Money", gameMoneyGet);
			PlayerPrefs.SetInt("NovelMenu", 11);
			PlayerPrefs.SetString("BackgroundClip", "");
			SceneManager.LoadScene("Novel");
		}

		else
		{
			PlayerPrefs.SetFloat("ScoreAll", totalScore);

			SceneManager.LoadScene("TitleScreen");
		}

		if (totalScore >= 6000 && countMoneyStop == false)
		{
			countMoneyStop = true;
			gameMoneyGet += 1000;
			if (affUpLied == 3)
			{
				liedHeart += 7;
			}
			if (affUpKlein == 3)
			{
				kleinHeart += 7;
			}

			Star[0].color = new Color32(255, 255, 255, 255);
			Star[1].color = new Color32(255, 255, 255, 255);
			Star[2].color = new Color32(255, 255, 255, 255);
			Star[3].color = new Color32(255, 255, 255, 255);
			Star[4].color = new Color32(255, 255, 255, 255);
			MoneyGet.text = "金貨1000獲得しました";

		}
		else if (totalScore >= 3000 && countMoneyStop == false)
		{
			countMoneyStop = true;
			gameMoneyGet += 700;
			if (affUpLied == 3)
			{
				liedHeart += 6;
			}
			if (affUpKlein == 3)
			{
				kleinHeart += 8;
			}

			Star[0].color = new Color32(255, 255, 255, 255);
			Star[1].color = new Color32(255, 255, 255, 255);
			Star[2].color = new Color32(255, 255, 255, 255);
			Star[3].color = new Color32(255, 255, 255, 255);
			MoneyGet.text = "金貨700獲得しました";

		}
		else if (totalScore >= 1500 && countMoneyStop == false)
		{
			countMoneyStop = true;
			gameMoneyGet += 500;
			if (affUpLied == 3)
			{
				liedHeart += 5;
			}
			if (affUpKlein == 3)
			{
				kleinHeart += 5;
			}

			Star[0].color = new Color32(255, 255, 255, 255);
			Star[1].color = new Color32(255, 255, 255, 255);
			Star[2].color = new Color32(255, 255, 255, 255);
			MoneyGet.text = "金貨500獲得しました";

		}
		else if (totalScore >= 900 && countMoneyStop == false)
		{
			countMoneyStop = true;
			gameMoneyGet += 300;
			if (affUpLied == 3)
			{
				liedHeart += 4;
			}
			if (affUpKlein == 3)
			{
				kleinHeart += 4;
			}

			Star[0].color = new Color32(255, 255, 255, 255);
			Star[1].color = new Color32(255, 255, 255, 255);
			MoneyGet.text = "金貨300獲得しました";

		}
		else if( countMoneyStop == false)
		{
			countMoneyStop = true;
			gameMoneyGet += 100;
			if (affUpLied == 3)
			{
				liedHeart += 3;
			}
			if (affUpKlein == 3)
			{
				kleinHeart += 3;
			}

			Star[0].color = new Color32(255, 255, 255, 255);
			MoneyGet.text = "金貨100獲得しました";

		}

	}


	public void Finishing()
	{
		Finish.SetActive(true);
		ScoreSheet.SetActive(false);
	}
	public void Scoring()
	{
		ScoreSheet.SetActive(true);
		Finish.SetActive(false);
	}
}