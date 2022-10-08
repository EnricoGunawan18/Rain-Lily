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
	GameObject[] Pages;

	[SerializeField]
	GameObject FilePanel;
	[SerializeField]
	GameObject LoadingScreen;

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

		for(int i = 0; i < 6; i++)
		{
			for(int j = 0; j < 6; j++)
			{
				Files[(i * 6) + j] = Pages[i].transform.Find($"File ({j})").transform.Find("Button").GetComponent<Button>();
			}
		}


		for(int i = 0; i < 36; i++)
		{
			Files[i].onClick.AddListener(delegate{FileClick(i);});
		}
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

	void FileClick(int num)
	{
		int startFrom = PlayerPrefs.GetInt("LogNow");

		PlayerPrefs.SetInt("WhichFile", 1);

		if (saveOrLoad == 1)
		{
			Debug.Log($"save{num}");

			if (loadDialogue.whichLineNow != 0)
			{
				PlayerPrefs.SetInt($"{num}Log", loadDialogue.whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt($"{num}Log", loadDialogue.whichLineNow);
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
			string nameSave = PlayerPrefs.GetString("PlayerName");
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");

			PlayerPrefs.SetString($"PlayerName{num}", nameSave);
			PlayerPrefs.SetInt($"LiedFail{num}", LiedFail);
			PlayerPrefs.SetInt($"KleinFail{num}", KleinFail);
			PlayerPrefs.SetInt($"CleanNumber{num}", cleanNumber);
			PlayerPrefs.SetInt($"CookNumber{num}", cookNumber);
			PlayerPrefs.SetInt($"ShopNumber{num}", shopNumber);
			PlayerPrefs.SetInt($"Money{num}", money);
			PlayerPrefs.SetFloat($"LiedHeart{num}", liedAff);
			PlayerPrefs.SetFloat($"KleinHeart{num}", kleinAff);
			PlayerPrefsX.SetIntArray($"Date{num}", date);
			PlayerPrefs.SetInt($"NovelMenu{num}", novelMenu);
			PlayerPrefs.SetInt($"{num}Pos", loadDialogue.resetPos);
			PlayerPrefsX.SetIntArray($"ItemNumber{num}", ItemNumber);
			PlayerPrefs.SetString($"BackgroundClip{num}", backgroundClip);
			ReturnToGame();
		}
		else if (saveOrLoad == 2)
		{
			Debug.Log($"load{num}");

			int log = PlayerPrefs.GetInt($"{num}Log");
			int pos = PlayerPrefs.GetInt($"{num}Pos");
			int novelMenu = PlayerPrefs.GetInt($"NovelMenu{num}");
			int[] date = PlayerPrefsX.GetIntArray($"Date{num}");
			int[] ItemNumber = PlayerPrefsX.GetIntArray($"ItemNumber{num}");
			float liedAff = PlayerPrefs.GetFloat($"LiedHeart{num}");
			float kleinAff = PlayerPrefs.GetFloat($"KleinHeart{num}");
			int money = PlayerPrefs.GetInt($"Money{num}");
			int cleanNumber = PlayerPrefs.GetInt($"CleanNumber{num}");
			int cookNumber = PlayerPrefs.GetInt($"CookNumber{num}");
			int shopNumber = PlayerPrefs.GetInt($"ShopNumber{num}");
			int LiedFail = PlayerPrefs.GetInt($"LiedFail{num}");
			int KleinFail = PlayerPrefs.GetInt($"KleinFail{num}");
			string backgroundclip = PlayerPrefs.GetString($"BackgroundClip{num}");
			string nameSave = PlayerPrefs.GetString($"PlayerName{num}");

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

			Time.timeScale = 1;
			LoadingScreen.SetActive(true);
			SceneManager.LoadScene("Novel");
		}
	}
}
