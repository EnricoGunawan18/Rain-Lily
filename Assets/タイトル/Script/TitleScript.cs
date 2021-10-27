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
	public Text MemoryHS;

	public GameObject TitleScreen;
	public GameObject GameScreen;
	public GameObject NowSaveScreen;

	public static float highScore = 0;
	public bool newFile = false;

	// Start is called before the first frame update
	void Start()
	{
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
	}

	public void NewGameStart()
	{
		NowSaveScreen.SetActive(true);
		TitleScreen.SetActive(false);
		newFile = true;
	}

	public void LoadGameStart()
	{
		NowSaveScreen.SetActive(true);
		TitleScreen.SetActive(false);
	}

	public void GameClicked()
	{
		TitleScreen.SetActive(false);
		GameScreen.SetActive(true);
	}

	public void MemoryGameClicked()
	{
		SceneManager.LoadScene("Stage1");
	}


	public void FirstFile()
    {
		PlayerPrefs.SetInt("WhichFile", 1);

		if(newFile == true)
        {
			PlayerPrefs.SetInt("FirstLog", 1);
			PlayerPrefs.SetInt("FirstPos", 0);

			PlayerPrefs.SetInt("LogNow", 1);
			PlayerPrefs.SetInt("MiniGame", 0);
			PlayerPrefs.SetInt("ResetPos", 0);
			PlayerPrefs.SetInt("NovelMenu", 0);
			PlayerPrefs.SetInt("NovelMenu1", 0);
			PlayerPrefs.SetString("Date", "Prologue");
			PlayerPrefs.SetString("Date1", "Prologue");

			SceneManager.LoadScene("Novel");
		}
		else
		{
			int log = PlayerPrefs.GetInt("FirstLog");
			int pos = PlayerPrefs.GetInt("FirstPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu1");
			string date = PlayerPrefs.GetString("Date1");

			PlayerPrefs.SetString("Date", date);
			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);

			SceneManager.LoadScene("Novel");
		}
	}


	public void SecondFile()
	{
		PlayerPrefs.SetInt("WhichFile", 2);

		if (newFile == true)
		{
			PlayerPrefs.SetInt("SecondLog", 1);
			PlayerPrefs.SetInt("SecondPos", 0);

			PlayerPrefs.SetInt("LogNow", 1);
			PlayerPrefs.SetInt("MiniGame", 0);
			PlayerPrefs.SetInt("ResetPos", 0);
			PlayerPrefs.SetInt("NovelMenu", 0);
			PlayerPrefs.SetInt("NovelMenu2", 0);
			PlayerPrefs.SetString("Date", "Prologue");
			PlayerPrefs.SetString("Date2", "Prologue");


			SceneManager.LoadScene("Novel");
        }
        else
        {
			int log = PlayerPrefs.GetInt("SecondLog");
			int pos = PlayerPrefs.GetInt("SecondPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu2");
			string date = PlayerPrefs.GetString("Date2");

			PlayerPrefs.SetString("Date", date);

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);

			SceneManager.LoadScene("Novel");
		}

	}


	public void ThirdFile()
	{
		PlayerPrefs.SetInt("WhichFile", 3);

		if (newFile == true)
		{
			PlayerPrefs.SetInt("ThirdLog", 1);
			PlayerPrefs.SetInt("ThirdPos", 0);

			PlayerPrefs.SetInt("LogNow", 1);
			PlayerPrefs.SetInt("MiniGame", 0);
			PlayerPrefs.SetInt("ResetPos", 0);
			PlayerPrefs.SetInt("NovelMenu", 0);
			PlayerPrefs.SetInt("NovelMenu3", 0);
			PlayerPrefs.SetString("Date", "Prologue");
			PlayerPrefs.SetString("Date3", "Prologue");


			SceneManager.LoadScene("Novel");
		}
		else
		{
			int log = PlayerPrefs.GetInt("ThirdLog");
			int pos = PlayerPrefs.GetInt("ThirdPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu3");
			string date = PlayerPrefs.GetString("Date3");

			PlayerPrefs.SetString("Date", date);

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);

			SceneManager.LoadScene("Novel");
		}

	}


	public void FourthFile()
	{
		PlayerPrefs.SetInt("WhichFile", 4);

		if (newFile == true)
		{
			PlayerPrefs.SetInt("FourthLog", 1);
			PlayerPrefs.SetInt("FourthPos", 0);

			PlayerPrefs.SetInt("LogNow", 1);
			PlayerPrefs.SetInt("MiniGame", 0);
			PlayerPrefs.SetInt("ResetPos", 0);
			PlayerPrefs.SetInt("NovelMenu", 0);
			PlayerPrefs.SetInt("NovelMenu4", 0);
			PlayerPrefs.SetString("Date", "Prologue");
			PlayerPrefs.SetString("Date4", "Prologue");


			SceneManager.LoadScene("Novel");
		}
		else
		{
			int log = PlayerPrefs.GetInt("FourthLog");
			int pos = PlayerPrefs.GetInt("FourthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu4");
			string date = PlayerPrefs.GetString("Date4");

			PlayerPrefs.SetString("Date", date);

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);

			SceneManager.LoadScene("Novel");
		}

	}


	public void FifthFile()
	{
		PlayerPrefs.SetInt("WhichFile", 5);

		if (newFile == true)
		{
			PlayerPrefs.SetInt("FifthLog", 1);
			PlayerPrefs.SetInt("FifthPos", 0);

			PlayerPrefs.SetInt("LogNow", 1);
			PlayerPrefs.SetInt("MiniGame", 0);
			PlayerPrefs.SetInt("ResetPos", 0);
			PlayerPrefs.SetInt("NovelMenu", 0);
			PlayerPrefs.SetInt("NovelMenu5", 0);
			PlayerPrefs.SetString("Date", "Prologue");
			PlayerPrefs.SetString("Date5", "Prologue");


			SceneManager.LoadScene("Novel");
		}
		else
		{
			int log = PlayerPrefs.GetInt("FifthLog");
			int pos = PlayerPrefs.GetInt("FifthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu5");
			string date = PlayerPrefs.GetString("Date5");

			PlayerPrefs.SetString("Date", date);

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);

			SceneManager.LoadScene("Novel");
		}

	}


	public void SixthFile()
	{
		PlayerPrefs.SetInt("WhichFile", 6);

		if (newFile == true)
		{
			PlayerPrefs.SetInt("SixthLog", 1);
			PlayerPrefs.SetInt("SixthPos", 0);

			PlayerPrefs.SetInt("LogNow", 1);
			PlayerPrefs.SetInt("MiniGame", 0);
			PlayerPrefs.SetInt("ResetPos", 0);
			PlayerPrefs.SetInt("NovelMenu", 0);
			PlayerPrefs.SetInt("NovelMenu6", 0);
			PlayerPrefs.SetString("Date", "Prologue");
			PlayerPrefs.SetString("Date6", "Prologue");

			SceneManager.LoadScene("Novel");
		}
		else
		{
			int log = PlayerPrefs.GetInt("SixthLog");
			int pos = PlayerPrefs.GetInt("SixthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu6");
			string date = PlayerPrefs.GetString("Date6");

			PlayerPrefs.SetString("Date", date);

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);

			SceneManager.LoadScene("Novel");
		}

	}

	public void SeventhFile()
	{
		PlayerPrefs.SetInt("WhichFile", 7);

		if (newFile == true)
		{
			PlayerPrefs.SetInt("SeventhLog", 1);
			PlayerPrefs.SetInt("SeventhPos", 0);

			PlayerPrefs.SetInt("LogNow", 1);
			PlayerPrefs.SetInt("MiniGame", 0);
			PlayerPrefs.SetInt("ResetPos", 0);
			PlayerPrefs.SetInt("NovelMenu", 0);
			PlayerPrefs.SetInt("NovelMenu7", 0);
			PlayerPrefs.SetString("Date", "Prologue");
			PlayerPrefs.SetString("Date7", "Prologue");

			SceneManager.LoadScene("Novel");
		}
		else
		{
			int log = PlayerPrefs.GetInt("SeventhLog");
			int pos = PlayerPrefs.GetInt("SeventhPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu7");
			string date = PlayerPrefs.GetString("Date7");

			PlayerPrefs.SetString("Date", date);

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);

			SceneManager.LoadScene("Novel");
		}

	}


	public void EighthFile()
	{
		PlayerPrefs.SetInt("WhichFile", 8);

		if (newFile == true)
		{
			PlayerPrefs.SetInt("EighthLog", 1);
			PlayerPrefs.SetInt("EighthPos", 0);

			PlayerPrefs.SetInt("LogNow", 1);
			PlayerPrefs.SetInt("MiniGame", 0);
			PlayerPrefs.SetInt("ResetPos", 0);
			PlayerPrefs.SetInt("NovelMenu", 0);
			PlayerPrefs.SetInt("NovelMenu8", 0);
			PlayerPrefs.SetString("Date", "Prologue");
			PlayerPrefs.SetString("Date8", "Prologue");

			SceneManager.LoadScene("Novel");
		}
		else
		{
			int log = PlayerPrefs.GetInt("EighthLog");
			int pos = PlayerPrefs.GetInt("EighthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu8");
			string date = PlayerPrefs.GetString("Date8");

			PlayerPrefs.SetString("Date", date);

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);

			SceneManager.LoadScene("Novel");
		}

	}


	public void NinthFile()
	{
		PlayerPrefs.SetInt("WhichFile", 9);

		if (newFile == true)
		{
			PlayerPrefs.SetInt("NinthLog", 1);
			PlayerPrefs.SetInt("NinthPos", 0);

			PlayerPrefs.SetInt("LogNow", 1);
			PlayerPrefs.SetInt("MiniGame", 0);
			PlayerPrefs.SetInt("ResetPos", 0);
			PlayerPrefs.SetInt("NovelMenu", 0);
			PlayerPrefs.SetInt("NovelMenu9", 0);
			PlayerPrefs.SetString("Date", "Prologue");
			PlayerPrefs.SetString("Date9", "Prologue");

			SceneManager.LoadScene("Novel");
		}
		else
		{
			int log = PlayerPrefs.GetInt("NinthLog");
			int pos = PlayerPrefs.GetInt("NinthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu9");
			string date = PlayerPrefs.GetString("Date9");

			PlayerPrefs.SetString("Date", date);

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);

			SceneManager.LoadScene("Novel");
		}

	}


	public void TenthFile()
	{
		PlayerPrefs.SetInt("WhichFile", 10);

		if (newFile == true)
		{
			PlayerPrefs.SetInt("TenthLog", 1);
			PlayerPrefs.SetInt("TenthPos", 0);

			PlayerPrefs.SetInt("LogNow", 1);
			PlayerPrefs.SetInt("MiniGame", 0);
			PlayerPrefs.SetInt("ResetPos", 0);
			PlayerPrefs.SetInt("NovelMenu", 0);
			PlayerPrefs.SetInt("NovelMenu10", 0);
			PlayerPrefs.SetString("Date", "Prologue");
			PlayerPrefs.SetString("Date10", "Prologue");

			SceneManager.LoadScene("Novel");
		}
		else
		{
			int log = PlayerPrefs.GetInt("TenthLog");
			int pos = PlayerPrefs.GetInt("TenthPos");
			int novelMenu = PlayerPrefs.GetInt("NovelMenu10");
			string date = PlayerPrefs.GetString("Date10");

			PlayerPrefs.SetString("Date", date);

			PlayerPrefs.SetInt("NovelMenu", novelMenu);
			PlayerPrefs.SetInt("LogNow", log);
			PlayerPrefs.SetInt("ResetPos", pos);

			SceneManager.LoadScene("Novel");
		}

	}

	public void Back()
    {
		NowSaveScreen.SetActive(false);
		TitleScreen.SetActive(true);
		newFile = false;
	}
}

