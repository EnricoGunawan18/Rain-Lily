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
	public Button[] Files;
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

		Files[0].onClick.AddListener(FirstFile);
		Files[1].onClick.AddListener(SecondFile);
		Files[2].onClick.AddListener(ThirdFile);
		Files[3].onClick.AddListener(FourthFile);
		Files[4].onClick.AddListener(FifthFile);
		Files[5].onClick.AddListener(SixthFile);
		Files[6].onClick.AddListener(SeventhFile);
		Files[7].onClick.AddListener(EighthFile);
		Files[8].onClick.AddListener(NinthFile);
		Files[9].onClick.AddListener(TenthFile);
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


	public void FirstFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 1);

		int log = PlayerPrefs.GetInt("1Log");
		int pos = PlayerPrefs.GetInt("1Pos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu1");
		int[] date = PlayerPrefsX.GetIntArray("Date1");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber1");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart1");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart1");
		int money = PlayerPrefs.GetInt("Money1");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber1");
		int cookNumber = PlayerPrefs.GetInt("CookNumber1");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber1");
		int LiedFail = PlayerPrefs.GetInt("LiedFail1");
		int KleinFail = PlayerPrefs.GetInt("KleinFail1");
		string backgroundclip = PlayerPrefs.GetString("BackgroundClip1");
		string nameSave = PlayerPrefs.GetString("PlayerName1");

		PlayerPrefs.SetString("PlayerName", nameSave);
		PlayerPrefs.SetInt("LiedFail", LiedFail);
		PlayerPrefs.SetInt("KleinFail", KleinFail);
		PlayerPrefs.SetInt("CleanNumber", cleanNumber);
		PlayerPrefs.SetInt("CookNumber", cookNumber);
		PlayerPrefs.SetInt("ShopNumber", shopNumber);
		PlayerPrefs.SetInt("Money", money);
		PlayerPrefs.SetFloat("LiedHeart", liedAff);
		PlayerPrefs.SetFloat("KleinHeart", kleinAff);
		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		PlayerPrefsX.SetIntArray("Date", date);
		PlayerPrefs.SetInt("NovelMenu", novelMenu);
		PlayerPrefs.SetInt("LogNow", log);
		PlayerPrefs.SetInt("ResetPos", pos);
		PlayerPrefs.SetString("BackgroundClip", backgroundclip);

		LoadingScreen.SetActive(true);
		SceneManager.LoadScene("Novel");
	}


	public void SecondFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 2);

		int log = PlayerPrefs.GetInt("2Log");
		int pos = PlayerPrefs.GetInt("2Pos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu2");
		int[] date = PlayerPrefsX.GetIntArray("Date2");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber2");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart2");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart2");
		int money = PlayerPrefs.GetInt("Money2");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber2");
		int cookNumber = PlayerPrefs.GetInt("CookNumber2");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber2");
		int LiedFail = PlayerPrefs.GetInt("LiedFail2");
		int KleinFail = PlayerPrefs.GetInt("KleinFail2");
		string backgroundclip = PlayerPrefs.GetString("BackgroundClip2");
		string nameSave = PlayerPrefs.GetString("PlayerName2");

		PlayerPrefs.SetString("PlayerName", nameSave);
		PlayerPrefs.SetInt("LiedFail", LiedFail);
		PlayerPrefs.SetInt("KleinFail", KleinFail);
		PlayerPrefs.SetInt("CleanNumber", cleanNumber);
		PlayerPrefs.SetInt("CookNumber", cookNumber);
		PlayerPrefs.SetInt("ShopNumber", shopNumber);
		PlayerPrefs.SetInt("Money", money);
		PlayerPrefs.SetFloat("LiedHeart", liedAff);
		PlayerPrefs.SetFloat("KleinHeart", kleinAff);
		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		PlayerPrefsX.SetIntArray("Date", date);
		PlayerPrefs.SetInt("NovelMenu", novelMenu);
		PlayerPrefs.SetInt("LogNow", log);
		PlayerPrefs.SetInt("ResetPos", pos);
		PlayerPrefs.SetString("BackgroundClip", backgroundclip);

		LoadingScreen.SetActive(true);
		SceneManager.LoadScene("Novel");
	}


	public void ThirdFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 3);

		int log = PlayerPrefs.GetInt("3Log");
		int pos = PlayerPrefs.GetInt("3Pos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu3");
		int[] date = PlayerPrefsX.GetIntArray("Date3");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber3");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart3");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart3");
		int money = PlayerPrefs.GetInt("Money3");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber3");
		int cookNumber = PlayerPrefs.GetInt("CookNumber3");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber3");
		int LiedFail = PlayerPrefs.GetInt("LiedFail3");
		int KleinFail = PlayerPrefs.GetInt("KleinFail3");
		string backgroundclip = PlayerPrefs.GetString("BackgroundClip3");
		string nameSave = PlayerPrefs.GetString("PlayerName3");

		PlayerPrefs.SetString("PlayerName", nameSave);
		PlayerPrefs.SetInt("LiedFail", LiedFail);
		PlayerPrefs.SetInt("KleinFail", KleinFail);
		PlayerPrefs.SetInt("CleanNumber", cleanNumber);
		PlayerPrefs.SetInt("CookNumber", cookNumber);
		PlayerPrefs.SetInt("ShopNumber", shopNumber);
		PlayerPrefs.SetInt("Money", money);
		PlayerPrefs.SetFloat("LiedHeart", liedAff);
		PlayerPrefs.SetFloat("KleinHeart", kleinAff);
		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		PlayerPrefsX.SetIntArray("Date", date);
		PlayerPrefs.SetInt("NovelMenu", novelMenu);
		PlayerPrefs.SetInt("LogNow", log);
		PlayerPrefs.SetInt("ResetPos", pos);
		PlayerPrefs.SetString("BackgroundClip", backgroundclip);
		
		LoadingScreen.SetActive(true);
		SceneManager.LoadScene("Novel");
	}


	public void FourthFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 4);

		int log = PlayerPrefs.GetInt("4Log");
		int pos = PlayerPrefs.GetInt("4Pos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu4");
		int[] date = PlayerPrefsX.GetIntArray("Date4");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber4");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart4");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart4");
		int money = PlayerPrefs.GetInt("Money4");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber4");
		int cookNumber = PlayerPrefs.GetInt("CookNumber4");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber4");
		int LiedFail = PlayerPrefs.GetInt("LiedFail4");
		int KleinFail = PlayerPrefs.GetInt("KleinFail4");
		string backgroundclip = PlayerPrefs.GetString("BackgroundClip4");
		string nameSave = PlayerPrefs.GetString("PlayerName4");

		PlayerPrefs.SetString("PlayerName", nameSave);
		PlayerPrefs.SetInt("LiedFail", LiedFail);
		PlayerPrefs.SetInt("KleinFail", KleinFail);
		PlayerPrefs.SetInt("CleanNumber", cleanNumber);
		PlayerPrefs.SetInt("CookNumber", cookNumber);
		PlayerPrefs.SetInt("ShopNumber", shopNumber);
		PlayerPrefs.SetInt("Money", money);
		PlayerPrefs.SetFloat("LiedHeart", liedAff);
		PlayerPrefs.SetFloat("KleinHeart", kleinAff);
		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		PlayerPrefsX.SetIntArray("Date", date);
		PlayerPrefs.SetInt("NovelMenu", novelMenu);
		PlayerPrefs.SetInt("LogNow", log);
		PlayerPrefs.SetInt("ResetPos", pos);
		PlayerPrefs.SetString("BackgroundClip", backgroundclip);
		
		LoadingScreen.SetActive(true);
		SceneManager.LoadScene("Novel");
	}


	public void FifthFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 5);

		int log = PlayerPrefs.GetInt("5Log");
		int pos = PlayerPrefs.GetInt("5Pos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu5");
		int[] date = PlayerPrefsX.GetIntArray("Date5");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber5");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart5");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart5");
		int money = PlayerPrefs.GetInt("Money5");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber5");
		int cookNumber = PlayerPrefs.GetInt("CookNumber5");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber5");
		int LiedFail = PlayerPrefs.GetInt("LiedFail5");
		int KleinFail = PlayerPrefs.GetInt("KleinFail5");
		string backgroundclip = PlayerPrefs.GetString("BackgroundClip5");
		string nameSave = PlayerPrefs.GetString("PlayerName5");

		PlayerPrefs.SetString("PlayerName", nameSave);
		PlayerPrefs.SetInt("LiedFail", LiedFail);
		PlayerPrefs.SetInt("KleinFail", KleinFail);
		PlayerPrefs.SetInt("CleanNumber", cleanNumber);
		PlayerPrefs.SetInt("CookNumber", cookNumber);
		PlayerPrefs.SetInt("ShopNumber", shopNumber);
		PlayerPrefs.SetInt("Money", money);
		PlayerPrefs.SetFloat("LiedHeart", liedAff);
		PlayerPrefs.SetFloat("KleinHeart", kleinAff);
		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		PlayerPrefsX.SetIntArray("Date", date);
		PlayerPrefs.SetInt("NovelMenu", novelMenu);
		PlayerPrefs.SetInt("LogNow", log);
		PlayerPrefs.SetInt("ResetPos", pos);
		PlayerPrefs.SetString("BackgroundClip", backgroundclip);
		
		LoadingScreen.SetActive(true);
		SceneManager.LoadScene("Novel");
	}


	public void SixthFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 6);

		int log = PlayerPrefs.GetInt("6Log");
		int pos = PlayerPrefs.GetInt("6Pos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu6");
		int[] date = PlayerPrefsX.GetIntArray("Date6");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber6");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart6");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart6");
		int money = PlayerPrefs.GetInt("Money6");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber6");
		int cookNumber = PlayerPrefs.GetInt("CookNumber6");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber6");
		int LiedFail = PlayerPrefs.GetInt("LiedFail6");
		int KleinFail = PlayerPrefs.GetInt("KleinFail6");
		string backgroundclip = PlayerPrefs.GetString("BackgroundClip6");
		string nameSave = PlayerPrefs.GetString("PlayerName6");

		PlayerPrefs.SetString("PlayerName", nameSave);
		PlayerPrefs.SetInt("LiedFail", LiedFail);
		PlayerPrefs.SetInt("KleinFail", KleinFail);
		PlayerPrefs.SetInt("CleanNumber", cleanNumber);
		PlayerPrefs.SetInt("CookNumber", cookNumber);
		PlayerPrefs.SetInt("ShopNumber", shopNumber);
		PlayerPrefs.SetInt("Money", money);
		PlayerPrefs.SetFloat("LiedHeart", liedAff);
		PlayerPrefs.SetFloat("KleinHeart", kleinAff);
		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		PlayerPrefsX.SetIntArray("Date", date);
		PlayerPrefs.SetInt("NovelMenu", novelMenu);
		PlayerPrefs.SetInt("LogNow", log);
		PlayerPrefs.SetInt("ResetPos", pos);
		PlayerPrefs.SetString("BackgroundClip", backgroundclip);
		
		LoadingScreen.SetActive(true);
		SceneManager.LoadScene("Novel");
	}

	public void SeventhFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 7);

		int log = PlayerPrefs.GetInt("7Log");
		int pos = PlayerPrefs.GetInt("7Pos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu7");
		int[] date = PlayerPrefsX.GetIntArray("Date7");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber7");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart7");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart7");
		int money = PlayerPrefs.GetInt("Money7");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber7");
		int cookNumber = PlayerPrefs.GetInt("CookNumber7");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber7");
		int LiedFail = PlayerPrefs.GetInt("LiedFail7");
		int KleinFail = PlayerPrefs.GetInt("KleinFail7");
		string backgroundclip = PlayerPrefs.GetString("BackgroundClip7");
		string nameSave = PlayerPrefs.GetString("PlayerName7");

		PlayerPrefs.SetString("PlayerName", nameSave);
		PlayerPrefs.SetInt("LiedFail", LiedFail);
		PlayerPrefs.SetInt("KleinFail", KleinFail);
		PlayerPrefs.SetInt("CleanNumber", cleanNumber);
		PlayerPrefs.SetInt("CookNumber", cookNumber);
		PlayerPrefs.SetInt("ShopNumber", shopNumber);
		PlayerPrefs.SetInt("Money", money);
		PlayerPrefs.SetFloat("LiedHeart", liedAff);
		PlayerPrefs.SetFloat("KleinHeart", kleinAff);
		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		PlayerPrefsX.SetIntArray("Date", date);
		PlayerPrefs.SetInt("NovelMenu", novelMenu);
		PlayerPrefs.SetInt("LogNow", log);
		PlayerPrefs.SetInt("ResetPos", pos);
		PlayerPrefs.SetString("BackgroundClip", backgroundclip);
		
		LoadingScreen.SetActive(true);
		SceneManager.LoadScene("Novel");
	}


	public void EighthFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 8);

		int log = PlayerPrefs.GetInt("8Log");
		int pos = PlayerPrefs.GetInt("8Pos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu8");
		int[] date = PlayerPrefsX.GetIntArray("Date8");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber8");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart8");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart8");
		int money = PlayerPrefs.GetInt("Money8");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber8");
		int cookNumber = PlayerPrefs.GetInt("CookNumber8");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber8");
		int LiedFail = PlayerPrefs.GetInt("LiedFail8");
		int KleinFail = PlayerPrefs.GetInt("KleinFail8");
		string backgroundclip = PlayerPrefs.GetString("BackgroundClip8");
		string nameSave = PlayerPrefs.GetString("PlayerName8");

		PlayerPrefs.SetString("PlayerName", nameSave);
		PlayerPrefs.SetInt("LiedFail", LiedFail);
		PlayerPrefs.SetInt("KleinFail", KleinFail);
		PlayerPrefs.SetInt("CleanNumber", cleanNumber);
		PlayerPrefs.SetInt("CookNumber", cookNumber);
		PlayerPrefs.SetInt("ShopNumber", shopNumber);
		PlayerPrefs.SetInt("Money", money);
		PlayerPrefs.SetFloat("LiedHeart", liedAff);
		PlayerPrefs.SetFloat("KleinHeart", kleinAff);
		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		PlayerPrefsX.SetIntArray("Date", date);
		PlayerPrefs.SetInt("NovelMenu", novelMenu);
		PlayerPrefs.SetInt("LogNow", log);
		PlayerPrefs.SetInt("ResetPos", pos);
		PlayerPrefs.SetString("BackgroundClip", backgroundclip);
		
		LoadingScreen.SetActive(true);
		SceneManager.LoadScene("Novel");
	}


	public void NinthFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 9);

		int log = PlayerPrefs.GetInt("9Log");
		int pos = PlayerPrefs.GetInt("9Pos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu9");
		int[] date = PlayerPrefsX.GetIntArray("Date9");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber9");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart9");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart9");
		int money = PlayerPrefs.GetInt("Money9");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber9");
		int cookNumber = PlayerPrefs.GetInt("CookNumber9");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber9");
		int LiedFail = PlayerPrefs.GetInt("LiedFail9");
		int KleinFail = PlayerPrefs.GetInt("KleinFail9");
		string backgroundclip = PlayerPrefs.GetString("BackgroundClip9");
		string nameSave = PlayerPrefs.GetString("PlayerName9");

		PlayerPrefs.SetString("PlayerName", nameSave);
		PlayerPrefs.SetInt("LiedFail", LiedFail);
		PlayerPrefs.SetInt("KleinFail", KleinFail);
		PlayerPrefs.SetInt("CleanNumber", cleanNumber);
		PlayerPrefs.SetInt("CookNumber", cookNumber);
		PlayerPrefs.SetInt("ShopNumber", shopNumber);
		PlayerPrefs.SetInt("Money", money);
		PlayerPrefs.SetFloat("LiedHeart", liedAff);
		PlayerPrefs.SetFloat("KleinHeart", kleinAff);
		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		PlayerPrefsX.SetIntArray("Date", date);
		PlayerPrefs.SetInt("NovelMenu", novelMenu);
		PlayerPrefs.SetInt("LogNow", log);
		PlayerPrefs.SetInt("ResetPos", pos);
		PlayerPrefs.SetString("BackgroundClip", backgroundclip);
		
		LoadingScreen.SetActive(true);
		SceneManager.LoadScene("Novel");
	}


	public void TenthFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 10);

		int log = PlayerPrefs.GetInt("10Log");
		int pos = PlayerPrefs.GetInt("10Pos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu10");
		int[] date = PlayerPrefsX.GetIntArray("Date10");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber10");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart10");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart10");
		int money = PlayerPrefs.GetInt("Money10");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber10");
		int cookNumber = PlayerPrefs.GetInt("CookNumber10");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber10");
		int LiedFail = PlayerPrefs.GetInt("LiedFail10");
		int KleinFail = PlayerPrefs.GetInt("KleinFail10");
		string backgroundclip = PlayerPrefs.GetString("BackgroundClip10");
		string nameSave = PlayerPrefs.GetString("PlayerName10");

		PlayerPrefs.SetString("PlayerName", nameSave);
		PlayerPrefs.SetInt("LiedFail", LiedFail);
		PlayerPrefs.SetInt("KleinFail", KleinFail);
		PlayerPrefs.SetInt("CleanNumber", cleanNumber);
		PlayerPrefs.SetInt("CookNumber", cookNumber);
		PlayerPrefs.SetInt("ShopNumber", shopNumber);
		PlayerPrefs.SetInt("Money", money);
		PlayerPrefs.SetFloat("LiedHeart", liedAff);
		PlayerPrefs.SetFloat("KleinHeart", kleinAff);
		PlayerPrefsX.SetIntArray("ItemNumber", ItemNumber);
		PlayerPrefsX.SetIntArray("Date", date);
		PlayerPrefs.SetInt("NovelMenu", novelMenu);
		PlayerPrefs.SetInt("LogNow", log);
		PlayerPrefs.SetInt("ResetPos", pos);
		PlayerPrefs.SetString("BackgroundClip", backgroundclip);
		
		LoadingScreen.SetActive(true);
		SceneManager.LoadScene("Novel");
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

