using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
	[SerializeField]
	public Button NewGame;
	public Button LoadGame;
	public Button Chapter;
	public Button Game;
	public Button MemoryGame;
	public Button BackButton;
	public Button BackMiniGame;
	public Button StartGame;

	[SerializeField]
	Button Options;

	public Image MiniGameBG;
	public Sprite[] MiniGameBGSprite;

	[SerializeField]
	Button CG;
	[SerializeField]
	Button PuzzleButton;
	[SerializeField]
	Button CookButton;

	public GameObject Titles;
	public GameObject TitleScreen;
	public GameObject GameScreen;
	public GameObject NowSaveScreen;
	public GameObject ChapterScreen;
	public GameObject NameInsert;
	public GameObject LoadingScreen;

	[SerializeField]
	public GameObject[] PlayMark;

	public InputField NameInputField;

	[SerializeField]
	AudioSource ButtonAudioSource;

	public bool newFile = false;
	bool[] clicked = { false, false, false };

	[SerializeField]
	Text Score;
	public int highScoreClean;
	public int highScoreCook;
	public float highScoreShop;


	// Start is called before the first frame update
	void Start()
	{
		ButtonAudioSource.Stop();

		highScoreClean = PlayerPrefs.GetInt("CleanHighScore");
		highScoreCook = PlayerPrefs.GetInt("CookHighScore");
		highScoreShop = PlayerPrefs.GetFloat("ShopHighScore");

		LoadingScreen.SetActive(false);

		//////Clean MiniGame
		int scoreCleanGet = PlayerPrefs.GetInt("ScoreClean");

		if (highScoreClean <= scoreCleanGet)
		{
			highScoreClean = scoreCleanGet;
			PlayerPrefs.SetInt("ScoreClean", highScoreClean);
		}


		//////Cook MiniGame
		int scoreCookGet = PlayerPrefs.GetInt("ScoreCook");

		if (highScoreCook <= scoreCookGet)
		{
			highScoreCook = scoreCookGet;
			PlayerPrefs.SetInt("ScoreCook", highScoreCook);
		}

		//////Shop MiniGame
		float scoreShopGet = PlayerPrefs.GetFloat("ScoreAll");

		if (highScoreShop <= scoreShopGet)
		{
			highScoreShop = scoreShopGet;
			PlayerPrefs.SetFloat("ScoreAll", highScoreShop);
		}

		NewGame.onClick.AddListener(NewGameStart);
		LoadGame.onClick.AddListener(LoadGameStart);
		Game.onClick.AddListener(GameClicked);
		Chapter.onClick.AddListener(ChapterClicked);
		Options.onClick.AddListener(OptionsClicked);
		StartGame.onClick.AddListener(NameIsFilled);
		TitleScreen.SetActive(true);
		GameScreen.SetActive(false);

		BackButton.onClick.AddListener(Back);
		BackMiniGame.onClick.AddListener(Back);

		CG.onClick.AddListener(CGOpen);

		MemoryGame.onClick.AddListener(MemoryGameClicked);
		CookButton.onClick.AddListener(CookClicked);
		PuzzleButton.onClick.AddListener(PuzzleClicked);
	}

	public void NewGameStart()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		NameInsert.SetActive(true);
		TitleScreen.SetActive(false);

	}

	public void NameIsFilled()
	{
		string Name = NameInputField.text;

		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetString("BackgroundClip", "");

		PlayerPrefs.SetInt("LogNow", 1);

		PlayerPrefs.SetInt("MiniGame", 0);
		PlayerPrefs.SetInt("ResetPos", 0);
		PlayerPrefs.SetInt("NovelMenu", 0);

		int[] startDate = { 10, 7 };
		PlayerPrefsX.SetIntArray("Date", startDate);

		PlayerPrefs.SetInt("Money", 0);
		PlayerPrefs.SetFloat("LiedHeart", 0);
		PlayerPrefs.SetFloat("KleinHeart", 0);

		PlayerPrefs.SetInt("LiedFail", 0);
		PlayerPrefs.SetInt("KleinFail", 0);


		PlayerPrefs.SetInt("CleanNumber", 0);
		PlayerPrefs.SetInt("CookNumber", 0);
		PlayerPrefs.SetInt("ShopNumber", 0);

		PlayerPrefs.SetString("PlayerName", Name);

		int[] itemNumber = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

		PlayerPrefsX.SetIntArray("ItemNumber", itemNumber);

		PlayerPrefs.SetInt("WhichFile", 0);

		LoadingScreen.SetActive(true);

		SceneManager.LoadScene("Novel");
	}

	public void LoadGameStart()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		NowSaveScreen.SetActive(true);
		TitleScreen.SetActive(false);
	}

	public void ChapterClicked()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		Time.timeScale = 1;

		ChapterScreen.SetActive(true);
		TitleScreen.SetActive(false);
	}

	public void GameClicked()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		Score.text = "00000";

		TitleScreen.SetActive(false);
		GameScreen.SetActive(true);
	}

	void OptionsClicked()
	{
		PlayerPrefs.SetInt("OptionsReturn", 0);
		DontDestroyOnLoad(Titles);
		SceneManager.LoadScene("Options");
	}

	public void PuzzleClicked()
	{
		if (clicked[0] == false)
		{

			string scoreShow = "";
			int zero = 10000;

			for (int i = 0; i < 4; i++)
			{
				if (highScoreClean < zero)
				{
					scoreShow += "0";
				}
				zero /= 10;
			}

			Score.text = scoreShow + highScoreClean.ToString();

			MiniGameBG.sprite = MiniGameBGSprite[0];

			PlayMark[0].SetActive(true);
			PlayMark[1].SetActive(false);
			PlayMark[2].SetActive(false);

			clicked[0] = true;
			clicked[1] = false;
			clicked[2] = false;
		}
		else
		{
			ButtonAudioSource.Stop();
			ButtonAudioSource.Play();

			PlayerPrefs.SetInt("MiniGame", 0);
			SceneManager.LoadScene("Scene_pazzle");
		}
	}

	public void CookClicked()
	{
		if (clicked[1] == false)
		{

			string scoreShow = "";
			int zero = 10000;

			for (int i = 0; i < 4; i++)
			{
				if (highScoreCook < zero)
				{
					scoreShow += "0";
				}
				zero /= 10;
			}

			Score.text = scoreShow + highScoreCook.ToString();

			MiniGameBG.sprite = MiniGameBGSprite[1];

			PlayMark[0].SetActive(false);
			PlayMark[1].SetActive(true);
			PlayMark[2].SetActive(false);

			clicked[0] = false;
			clicked[1] = true;
			clicked[2] = false;
		}
		else
		{
			ButtonAudioSource.Stop();
			ButtonAudioSource.Play();

			PlayerPrefs.SetInt("MiniGame", 0);
			SceneManager.LoadScene("Scene_cook");
		}
	}

	public void MemoryGameClicked()
	{
		if (clicked[2] == false)
		{

			string scoreShow = "";
			int zero = 10000;

			for (int i = 0; i < 4; i++)
			{
				if (highScoreShop < zero)
				{
					scoreShow += "0";
				}
				zero /= 10;
			}

			Score.text = scoreShow + highScoreShop.ToString();

			MiniGameBG.sprite = MiniGameBGSprite[2];

			PlayMark[0].SetActive(false);
			PlayMark[1].SetActive(false);
			PlayMark[2].SetActive(true);

			clicked[0] = false;
			clicked[1] = false;
			clicked[2] = true;
		}
		else
		{
			ButtonAudioSource.Stop();
			ButtonAudioSource.Play();

			PlayerPrefs.SetInt("MiniGame", 0);
			SceneManager.LoadScene("Stage1");
		}
	}

	public void Back()
	{
		////MINIGAME SCREEN
		for (int i = 0; i < 3; i++)
		{
			clicked[i] = false;
			PlayMark[i].SetActive(false);
		}
		MiniGameBG.sprite = MiniGameBGSprite[0];

		////BASIC STUFF
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		GameScreen.SetActive(false);
		NowSaveScreen.SetActive(false);
		NameInsert.SetActive(false);
		TitleScreen.SetActive(true);
		newFile = false;
	}

	void CGOpen()
	{
		DontDestroyOnLoad(Titles);
		SceneManager.LoadScene("Scene_CG");
	}
}

