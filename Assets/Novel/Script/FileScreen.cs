using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FileScreen : MonoBehaviour
{
	[SerializeField]
	Button[] Files;
	[SerializeField]
	Button Save;
	[SerializeField]
	Button MenuSave;
	[SerializeField]
	Button Load;
	[SerializeField]
	Button MenuLoad;
	[SerializeField]
	Button Back;
	[SerializeField]
	GameObject FilePanel;

	LoadDialogue loadDialogue;

	public int saveOrLoad = 0;

	// Start is called before the first frame update
	void Start()
	{
		loadDialogue = GameObject.Find("LoadDialogue").GetComponent<LoadDialogue>();

		Save.onClick.AddListener(SavePanel);
		MenuSave.onClick.AddListener(SavePanel);
		Load.onClick.AddListener(LoadPanel);
		MenuLoad.onClick.AddListener(LoadPanel);
		Back.onClick.AddListener(ReturnToGame);

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
	}


	void SavePanel()
	{
		Time.timeScale = 0;
		saveOrLoad = 1;

		FilePanel.SetActive(true);
	}

	void LoadPanel()
	{
		Time.timeScale = 0;
		saveOrLoad = 2;

		FilePanel.SetActive(true);
	}

	void ReturnToGame()
	{
		Time.timeScale = 1;
		saveOrLoad = 0;

		FilePanel.SetActive(false);
	}

	void FirstFile()
	{
		int startFrom = PlayerPrefs.GetInt("LogNow");

		PlayerPrefs.SetInt("WhichFile", 1);

		if (saveOrLoad == 1)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("FirstLog", loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("FirstLog", loadDialogue.whichLineNow);
			}
			int novelMenu = PlayerPrefs.GetInt("NovelMenu");
			int[] date = PlayerPrefsX.GetIntArray("Date");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");
			string backgroundClip = PlayerPrefs.GetString("BackgroundClip");

			PlayerPrefs.SetInt("LiedFail1", LiedFail);
			PlayerPrefs.SetInt("KleinFail1", KleinFail);
			PlayerPrefs.SetInt("CleanNumber1", cleanNumber);
			PlayerPrefs.SetInt("CookNumber1", cookNumber);
			PlayerPrefs.SetInt("ShopNumber1", shopNumber);
			PlayerPrefs.SetInt("Money1", money);
			PlayerPrefs.SetFloat("LiedHeart1", liedAff);
			PlayerPrefs.SetFloat("KleinHeart1", kleinAff);
			PlayerPrefsX.SetIntArray("Date1", date);
			PlayerPrefs.SetInt("NovelMenu1", novelMenu);
			PlayerPrefs.SetInt("FirstPos", loadDialogue.resetPos);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber1", ItemNumber);
			PlayerPrefs.SetString("BackgroundClip1", backgroundClip);
			ReturnToGame();
		}
		else if (saveOrLoad == 2)
		{
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
			int LiedFail = PlayerPrefs.GetInt("LiedFail1");
			int KleinFail = PlayerPrefs.GetInt("KleinFail1");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip1");

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

			Time.timeScale = 1;
			SceneManager.LoadScene("Novel");
		}

	}

	void SecondFile()
	{
		int startFrom = PlayerPrefs.GetInt("LogNow");

		PlayerPrefs.SetInt("WhichFile", 2);

		if (saveOrLoad == 1)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("SecondLog", loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("SecondLog", loadDialogue.whichLineNow);
			}
			int novelMenu = PlayerPrefs.GetInt("NovelMenu");
			int[] date = PlayerPrefsX.GetIntArray("Date");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");
			string backgroundClip = PlayerPrefs.GetString("BackgroundClip");

			PlayerPrefs.SetInt("LiedFail2", LiedFail);
			PlayerPrefs.SetInt("KleinFail2", KleinFail);
			PlayerPrefs.SetInt("CleanNumber2", cleanNumber);
			PlayerPrefs.SetInt("CookNumber2", cookNumber);
			PlayerPrefs.SetInt("ShopNumber2", shopNumber);
			PlayerPrefs.SetInt("Money2", money);
			PlayerPrefs.SetFloat("LiedHeart2", liedAff);
			PlayerPrefs.SetFloat("KleinHeart2", kleinAff);
			PlayerPrefsX.SetIntArray("Date2", date);
			PlayerPrefs.SetInt("NovelMenu2", novelMenu);
			PlayerPrefs.SetInt("SecondPos", loadDialogue.resetPos);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber2", ItemNumber);
			PlayerPrefs.SetString("BackgroundClip2", backgroundClip);

			ReturnToGame();
		}
		else if (saveOrLoad == 2)
		{
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
			int LiedFail = PlayerPrefs.GetInt("LiedFail2");
			int KleinFail = PlayerPrefs.GetInt("KleinFail2");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip2");

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

			Time.timeScale = 1;
			SceneManager.LoadScene("Novel");
		}

	}

	void ThirdFile()
	{
		int startFrom = PlayerPrefs.GetInt("LogNow");

		PlayerPrefs.SetInt("WhichFile", 3);

		if (saveOrLoad == 1)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("ThirdLog", loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("ThirdLog", loadDialogue.whichLineNow);
			}
			int novelMenu = PlayerPrefs.GetInt("NovelMenu");
			int[] date = PlayerPrefsX.GetIntArray("Date");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");
			string backgroundClip = PlayerPrefs.GetString("BackgroundClip");

			PlayerPrefs.SetInt("LiedFail3", LiedFail);
			PlayerPrefs.SetInt("KleinFail3", KleinFail);
			PlayerPrefs.SetInt("CleanNumber3", cleanNumber);
			PlayerPrefs.SetInt("CookNumber3", cookNumber);
			PlayerPrefs.SetInt("ShopNumber3", shopNumber);
			PlayerPrefs.SetInt("Money3", money);
			PlayerPrefs.SetFloat("LiedHeart3", liedAff);
			PlayerPrefs.SetFloat("KleinHeart3", kleinAff);
			PlayerPrefsX.SetIntArray("Date3", date);
			PlayerPrefs.SetInt("NovelMenu3", novelMenu);
			PlayerPrefs.SetInt("ThirdPos", loadDialogue.resetPos);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber3", ItemNumber);
			PlayerPrefs.SetString("BackgroundClip3", backgroundClip);

			ReturnToGame();
		}
		else if (saveOrLoad == 2)
		{
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
			int LiedFail = PlayerPrefs.GetInt("LiedFail3");
			int KleinFail = PlayerPrefs.GetInt("KleinFail3");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip3");

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

			Time.timeScale = 1;
			SceneManager.LoadScene("Novel");
		}

	}

	void FourthFile()
	{
		int startFrom = PlayerPrefs.GetInt("LogNow");

		PlayerPrefs.SetInt("WhichFile", 4);

		if (saveOrLoad == 1)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("FourthLog", loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("FourthLog", loadDialogue.whichLineNow);
			}
			int novelMenu = PlayerPrefs.GetInt("NovelMenu");
			int[] date = PlayerPrefsX.GetIntArray("Date");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");
			string backgroundClip = PlayerPrefs.GetString("BackgroundClip");

			PlayerPrefs.SetInt("LiedFail4", LiedFail);
			PlayerPrefs.SetInt("KleinFail4", KleinFail);
			PlayerPrefs.SetInt("CleanNumber4", cleanNumber);
			PlayerPrefs.SetInt("CookNumber4", cookNumber);
			PlayerPrefs.SetInt("ShopNumber4", shopNumber);
			PlayerPrefs.SetInt("Money4", money);
			PlayerPrefs.SetFloat("LiedHeart4", liedAff);
			PlayerPrefs.SetFloat("KleinHeart4", kleinAff);
			PlayerPrefsX.SetIntArray("Date4", date);
			PlayerPrefs.SetInt("NovelMenu4", novelMenu);
			PlayerPrefs.SetInt("FourthPos", loadDialogue.resetPos);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber4", ItemNumber);
			PlayerPrefs.SetString("BackgroundClip4", backgroundClip);

			ReturnToGame();
		}
		else if (saveOrLoad == 2)
		{
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
			int LiedFail = PlayerPrefs.GetInt("LiedFail4");
			int KleinFail = PlayerPrefs.GetInt("KleinFail4");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip4");

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

			Time.timeScale = 1;
			SceneManager.LoadScene("Novel");
		}

	}

	void FifthFile()
	{
		int startFrom = PlayerPrefs.GetInt("LogNow");

		PlayerPrefs.SetInt("WhichFile", 5);

		if (saveOrLoad == 1)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("FifthLog", loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("FifthLog", loadDialogue.whichLineNow);
			}
			int novelMenu = PlayerPrefs.GetInt("NovelMenu");
			int[] date = PlayerPrefsX.GetIntArray("Date");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");
			string backgroundClip = PlayerPrefs.GetString("BackgroundClip");

			PlayerPrefs.SetInt("LiedFail5", LiedFail);
			PlayerPrefs.SetInt("KleinFail5", KleinFail);
			PlayerPrefs.SetInt("CleanNumber5", cleanNumber);
			PlayerPrefs.SetInt("CookNumber5", cookNumber);
			PlayerPrefs.SetInt("ShopNumber5", shopNumber);
			PlayerPrefs.SetInt("Money5", money);
			PlayerPrefs.SetFloat("LiedHeart5", liedAff);
			PlayerPrefs.SetFloat("KleinHeart5", kleinAff);
			PlayerPrefsX.SetIntArray("Date5", date);
			PlayerPrefs.SetInt("NovelMenu5", novelMenu);
			PlayerPrefs.SetInt("FifthPos", loadDialogue.resetPos);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber5", ItemNumber);
			PlayerPrefs.SetString("BackgroundClip5", backgroundClip);

			ReturnToGame();
		}
		else if (saveOrLoad == 2)
		{
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
			int LiedFail = PlayerPrefs.GetInt("LiedFail5");
			int KleinFail = PlayerPrefs.GetInt("KleinFail5");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip5");

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

			Time.timeScale = 1;
			SceneManager.LoadScene("Novel");
		}

	}

	void SixthFile()
	{
		int startFrom = PlayerPrefs.GetInt("LogNow");

		PlayerPrefs.SetInt("WhichFile", 6);

		if (saveOrLoad == 1)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("SixthLog", loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("SixthLog", loadDialogue.whichLineNow);
			}
			int novelMenu = PlayerPrefs.GetInt("NovelMenu");
			int[] date = PlayerPrefsX.GetIntArray("Date");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");
			string backgroundClip = PlayerPrefs.GetString("BackgroundClip");

			PlayerPrefs.SetInt("LiedFail6", LiedFail);
			PlayerPrefs.SetInt("KleinFail6", KleinFail);
			PlayerPrefs.SetInt("CleanNumber6", cleanNumber);
			PlayerPrefs.SetInt("CookNumber6", cookNumber);
			PlayerPrefs.SetInt("ShopNumber6", shopNumber);
			PlayerPrefs.SetInt("Money6", money);
			PlayerPrefs.SetFloat("LiedHeart6", liedAff);
			PlayerPrefs.SetFloat("KleinHeart6", kleinAff);
			PlayerPrefsX.SetIntArray("Date6", date);
			PlayerPrefs.SetInt("NovelMenu6", novelMenu);
			PlayerPrefs.SetInt("SixthPos", loadDialogue.resetPos);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber6", ItemNumber);
			PlayerPrefs.SetString("BackgroundClip6", backgroundClip);

			ReturnToGame();
		}
		else if (saveOrLoad == 2)
		{
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
			int LiedFail = PlayerPrefs.GetInt("LiedFail6");
			int KleinFail = PlayerPrefs.GetInt("KleinFail6");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip6");

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

			Time.timeScale = 1;
			SceneManager.LoadScene("Novel");
		}

	}

	void SeventhFile()
	{
		int startFrom = PlayerPrefs.GetInt("LogNow");

		PlayerPrefs.SetInt("WhichFile", 7);

		if (saveOrLoad == 1)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("SeventhLog", loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("SeventhLog", loadDialogue.whichLineNow);
			}
			int novelMenu = PlayerPrefs.GetInt("NovelMenu");
			int[] date = PlayerPrefsX.GetIntArray("Date");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");
			string backgroundClip = PlayerPrefs.GetString("BackgroundClip");

			PlayerPrefs.SetInt("LiedFail7", LiedFail);
			PlayerPrefs.SetInt("KleinFail7", KleinFail);
			PlayerPrefs.SetInt("CleanNumber7", cleanNumber);
			PlayerPrefs.SetInt("CookNumber7", cookNumber);
			PlayerPrefs.SetInt("ShopNumber7", shopNumber);
			PlayerPrefs.SetInt("Money7", money);
			PlayerPrefs.SetFloat("LiedHeart7", liedAff);
			PlayerPrefs.SetFloat("KleinHeart7", kleinAff);
			PlayerPrefsX.SetIntArray("Date7", date);
			PlayerPrefs.SetInt("NovelMenu7", novelMenu);
			PlayerPrefs.SetInt("SeventhPos", loadDialogue.resetPos);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber7", ItemNumber);
			PlayerPrefs.SetString("BackgroundClip7", backgroundClip);

			ReturnToGame();
		}
		else if (saveOrLoad == 2)
		{
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
			int LiedFail = PlayerPrefs.GetInt("LiedFail7");
			int KleinFail = PlayerPrefs.GetInt("KleinFail7");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip7");

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

			Time.timeScale = 1;
			SceneManager.LoadScene("Novel");
		}

	}

	void EighthFile()
	{
		int startFrom = PlayerPrefs.GetInt("LogNow");

		PlayerPrefs.SetInt("WhichFile", 8);

		if (saveOrLoad == 1)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("EighthLog", loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("EighthLog", loadDialogue.whichLineNow);
			}
			int novelMenu = PlayerPrefs.GetInt("NovelMenu");
			int[] date = PlayerPrefsX.GetIntArray("Date");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");
			string backgroundClip = PlayerPrefs.GetString("BackgroundClip");

			PlayerPrefs.SetInt("LiedFail8", LiedFail);
			PlayerPrefs.SetInt("KleinFail8", KleinFail);
			PlayerPrefs.SetInt("CleanNumber8", cleanNumber);
			PlayerPrefs.SetInt("CookNumber8", cookNumber);
			PlayerPrefs.SetInt("ShopNumber8", shopNumber);
			PlayerPrefs.SetInt("Money8", money);
			PlayerPrefs.SetFloat("LiedHeart8", liedAff);
			PlayerPrefs.SetFloat("KleinHeart8", kleinAff);
			PlayerPrefsX.SetIntArray("Date8", date);
			PlayerPrefs.SetInt("NovelMenu8", novelMenu);
			PlayerPrefs.SetInt("EighthPos", loadDialogue.resetPos);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber8", ItemNumber);
			PlayerPrefs.SetString("BackgroundClip8", backgroundClip);

			ReturnToGame();
		}
		else if (saveOrLoad == 2)
		{
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
			int LiedFail = PlayerPrefs.GetInt("LiedFail8");
			int KleinFail = PlayerPrefs.GetInt("KleinFail8");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip8");

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

			Time.timeScale = 1;
			SceneManager.LoadScene("Novel");
		}

	}

	void NinthFile()
	{
		int startFrom = PlayerPrefs.GetInt("LogNow");

		PlayerPrefs.SetInt("WhichFile", 9);

		if (saveOrLoad == 1)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("NinthLog", loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("NinthLog", loadDialogue.whichLineNow);
			}
			int novelMenu = PlayerPrefs.GetInt("NovelMenu");
			int[] date = PlayerPrefsX.GetIntArray("Date");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");
			string backgroundClip = PlayerPrefs.GetString("BackgroundClip");

			PlayerPrefs.SetInt("LiedFail9", LiedFail);
			PlayerPrefs.SetInt("KleinFail9", KleinFail);
			PlayerPrefs.SetInt("CleanNumber9", cleanNumber);
			PlayerPrefs.SetInt("CookNumber9", cookNumber);
			PlayerPrefs.SetInt("ShopNumber9", shopNumber);
			PlayerPrefs.SetInt("Money9", money);
			PlayerPrefs.SetFloat("LiedHeart9", liedAff);
			PlayerPrefs.SetFloat("KleinHeart9", kleinAff);
			PlayerPrefsX.SetIntArray("Date9", date);
			PlayerPrefs.SetInt("NovelMenu9", novelMenu);
			PlayerPrefs.SetInt("NinthPos", loadDialogue.resetPos);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber9", ItemNumber);
			PlayerPrefs.SetString("BackgroundClip9", backgroundClip);

			ReturnToGame();
		}
		else if (saveOrLoad == 2)
		{
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
			int LiedFail = PlayerPrefs.GetInt("LiedFail9");
			int KleinFail = PlayerPrefs.GetInt("KleinFail9");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip9");

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

			Time.timeScale = 1;
			SceneManager.LoadScene("Novel");
		}

	}

	void TenthFile()
	{
		int startFrom = PlayerPrefs.GetInt("LogNow");

		PlayerPrefs.SetInt("WhichFile", 10);

		if (saveOrLoad == 1)
		{
			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt("TenthLog", loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("TenthLog", loadDialogue.whichLineNow);
			}
			int novelMenu = PlayerPrefs.GetInt("NovelMenu");
			int[] date = PlayerPrefsX.GetIntArray("Date");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");
			string backgroundClip = PlayerPrefs.GetString("BackgroundClip");

			PlayerPrefs.SetInt("LiedFail10", LiedFail);
			PlayerPrefs.SetInt("KleinFail10", KleinFail);
			PlayerPrefs.SetInt("CleanNumber10", cleanNumber);			
			PlayerPrefs.SetInt("CookNumber10", cookNumber);
			PlayerPrefs.SetInt("ShopNumber10", shopNumber);
			PlayerPrefs.SetInt("Money10", money);
			PlayerPrefs.SetFloat("LiedHeart10", liedAff);
			PlayerPrefs.SetFloat("KleinHeart10", kleinAff);
			PlayerPrefsX.SetIntArray("Date10", date);
			PlayerPrefs.SetInt("NovelMenu10", novelMenu);
			PlayerPrefs.SetInt("TenthPos", loadDialogue.resetPos);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber10", ItemNumber);
			PlayerPrefs.SetString("BackgroundClip10", backgroundClip);

			ReturnToGame();
		}
		else if (saveOrLoad == 2)
		{
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
			int LiedFail = PlayerPrefs.GetInt("LiedFail10");
			int KleinFail = PlayerPrefs.GetInt("KleinFail10");
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip10");

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

			Time.timeScale = 1;
			SceneManager.LoadScene("Novel");
		}

	}
}
