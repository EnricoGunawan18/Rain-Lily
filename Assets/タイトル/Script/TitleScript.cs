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
	public Button Game;
	public Button MemoryGame;
	public Button[] Files;
	public Button BackButton;
	public Button BackMiniGame;
	public Text MemoryHS;

	public GameObject TitleScreen;
	public GameObject GameScreen;
	public GameObject NowSaveScreen;

	[SerializeField]
	AudioSource ButtonAudioSource;

	public static float highScore = 0;
	public bool newFile = false;

	// Start is called before the first frame update
	void Start()
	{
		ButtonAudioSource.Stop();
		//reset//////////////////////////////////////////////////////////////////
		//PlayerPrefs.SetFloat("ScoreAll", 0);
		//PlayerPrefs.SetFloat("Score1", 0);
		//PlayerPrefs.SetFloat("Score2", 0);
		//PlayerPrefs.SetFloat("Score3", 0);
		//PlayerPrefs.SetFloat("Score4", 0);
		//PlayerPrefs.SetFloat("Score5", 0);
		//PlayerPrefs.SetInt("LogNow", 1);
		PlayerPrefs.SetFloat("DialogueSpeed", 25f);

		float scoreGet = PlayerPrefs.GetFloat("ScoreAll");

		if (highScore <= scoreGet)
		{
			highScore = scoreGet;
		}

		MemoryHS.text = "High Score : " + highScore;

		NewGame.onClick.AddListener(NewGameStart);
		LoadGame.onClick.AddListener(LoadGameStart);
		Game.onClick.AddListener(GameClicked);
		MemoryGame.onClick.AddListener(MemoryGameClicked);
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
	}

	public void NewGameStart()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("LogNow", 1);

		PlayerPrefs.SetInt("MiniGame", 0);
		PlayerPrefs.SetInt("ResetPos", 0);
		PlayerPrefs.SetInt("NovelMenu", 0);

		int[] startDate = { 10, 7 };
		PlayerPrefsX.SetIntArray("Date", startDate);

		PlayerPrefs.SetInt("Money", 0);
		PlayerPrefs.SetFloat("LiedHeart", 0);
		PlayerPrefs.SetFloat("KleinHeart", 0);

		PlayerPrefs.SetInt("CleanNumber", 0);
		PlayerPrefs.SetInt("CookNumber", 0);
		PlayerPrefs.SetInt("ShopNumber", 0);

		int[] itemNumber = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

		PlayerPrefsX.SetIntArray("ItemNumber", itemNumber);

		SceneManager.LoadScene("Novel");
	}

	public void LoadGameStart()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		NowSaveScreen.SetActive(true);
		TitleScreen.SetActive(false);
	}

	public void GameClicked()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		TitleScreen.SetActive(false);
		GameScreen.SetActive(true);
	}

	public void MemoryGameClicked()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("MiniGame", 0);
		SceneManager.LoadScene("Stage1");
	}


	public void FirstFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 1);

		int log = PlayerPrefs.GetInt("FirstLog");
		int pos = PlayerPrefs.GetInt("FirstPos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu1");
		int[] date = PlayerPrefsX.GetIntArray("Date1");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber1");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart1");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart1");
		int money = PlayerPrefs.GetInt("Money1");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber1");
		int cookNumber = PlayerPrefs.GetInt("CookNumber1");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber1");

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

		SceneManager.LoadScene("Novel");
	}


	public void SecondFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 2);

		int log = PlayerPrefs.GetInt("SecondLog");
		int pos = PlayerPrefs.GetInt("SecondPos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu2");
		int[] date = PlayerPrefsX.GetIntArray("Date2");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber2");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart2");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart2");
		int money = PlayerPrefs.GetInt("Money2");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber2");
		int cookNumber = PlayerPrefs.GetInt("CookNumber2");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber2");

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

		SceneManager.LoadScene("Novel");
	}


	public void ThirdFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 3);

		int log = PlayerPrefs.GetInt("ThirdLog");
		int pos = PlayerPrefs.GetInt("ThirdPos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu3");
		int[] date = PlayerPrefsX.GetIntArray("Date3");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber3");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart3");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart3");
		int money = PlayerPrefs.GetInt("Money3");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber3");
		int cookNumber = PlayerPrefs.GetInt("CookNumber3");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber3");

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

		SceneManager.LoadScene("Novel");
	}


	public void FourthFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 4);

		int log = PlayerPrefs.GetInt("FourthLog");
		int pos = PlayerPrefs.GetInt("FourthPos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu4");
		int[] date = PlayerPrefsX.GetIntArray("Date4");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber4");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart4");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart4");
		int money = PlayerPrefs.GetInt("Money4");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber4");
		int cookNumber = PlayerPrefs.GetInt("CookNumber4");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber4");

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

		SceneManager.LoadScene("Novel");
	}


	public void FifthFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 5);

		int log = PlayerPrefs.GetInt("FifthLog");
		int pos = PlayerPrefs.GetInt("FifthPos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu5");
		int[] date = PlayerPrefsX.GetIntArray("Date5");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber5");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart5");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart5");
		int money = PlayerPrefs.GetInt("Money5");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber5");
		int cookNumber = PlayerPrefs.GetInt("CookNumber5");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber5");

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

		SceneManager.LoadScene("Novel");
	}


	public void SixthFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 6);

		int log = PlayerPrefs.GetInt("SixthLog");
		int pos = PlayerPrefs.GetInt("SixthPos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu6");
		int[] date = PlayerPrefsX.GetIntArray("Date6");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber6");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart6");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart6");
		int money = PlayerPrefs.GetInt("Money6");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber6");
		int cookNumber = PlayerPrefs.GetInt("CookNumber6");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber6");

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

		SceneManager.LoadScene("Novel");
	}

	public void SeventhFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 7);

		int log = PlayerPrefs.GetInt("SeventhLog");
		int pos = PlayerPrefs.GetInt("SeventhPos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu7");
		int[] date = PlayerPrefsX.GetIntArray("Date7");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber7");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart7");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart7");
		int money = PlayerPrefs.GetInt("Money7");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber7");
		int cookNumber = PlayerPrefs.GetInt("CookNumber7");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber7");

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

		SceneManager.LoadScene("Novel");
	}


	public void EighthFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 8);

		int log = PlayerPrefs.GetInt("EighthLog");
		int pos = PlayerPrefs.GetInt("EighthPos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu8");
		int[] date = PlayerPrefsX.GetIntArray("Date8");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber8");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart8");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart8");
		int money = PlayerPrefs.GetInt("Money8");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber8");
		int cookNumber = PlayerPrefs.GetInt("CookNumber8");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber8");

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

		SceneManager.LoadScene("Novel");
	}


	public void NinthFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 9);

		int log = PlayerPrefs.GetInt("NinthLog");
		int pos = PlayerPrefs.GetInt("NinthPos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu9");
		int[] date = PlayerPrefsX.GetIntArray("Date9");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber9");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart9");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart9");
		int money = PlayerPrefs.GetInt("Money9");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber9");
		int cookNumber = PlayerPrefs.GetInt("CookNumber9");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber9");

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

		SceneManager.LoadScene("Novel");
	}


	public void TenthFile()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		PlayerPrefs.SetInt("WhichFile", 10);

		int log = PlayerPrefs.GetInt("TenthLog");
		int pos = PlayerPrefs.GetInt("TenthPos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu10");
		int[] date = PlayerPrefsX.GetIntArray("Date10");
		int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber10");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart10");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart10");
		int money = PlayerPrefs.GetInt("Money10");
		int cleanNumber = PlayerPrefs.GetInt("CleanNumber10");
		int cookNumber = PlayerPrefs.GetInt("CookNumber10");
		int shopNumber = PlayerPrefs.GetInt("ShopNumber10");

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

		SceneManager.LoadScene("Novel");
	}

	public void Back()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		GameScreen.SetActive(false);
		NowSaveScreen.SetActive(false);
		TitleScreen.SetActive(true);
		newFile = false;
	}
}

