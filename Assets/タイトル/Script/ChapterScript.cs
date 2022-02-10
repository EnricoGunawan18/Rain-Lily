using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChapterScript : MonoBehaviour
{
	[SerializeField]
	TextAsset ChapterText;

	[SerializeField]
	Button[] FileButton;

	[SerializeField]
	Text[] FileChapterNumber;
	[SerializeField]
	Text[] FileTitle;

	[SerializeField]
	Text FileDescription;

	public ChapterLogs chapterLogs;
	string[] ChapterStrings;
	string[] ChapterRow;

	public List<ChapterLogs> chapterList;

	[SerializeField]
	GameObject ChapterScreen;
	[SerializeField]
	GameObject TitleScreen;

	[SerializeField]
	Button BackButton;

	[SerializeField]
	AudioSource ButtonAudioSource;

	bool[] isPressed = { false, false, false, false, false, false, false, false, false, false, false, false };
	int[] month = { 10, 10, 10, 10, 11, 11, 11, 11, 11, 12, 12, 12 };
	int[] day = { 7, 15, 20, 30, 8, 15, 17, 25, 30, 3, 6, 9 };
	int[] liedAff = { 0, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60 };
	int[] ResetPos = { 0, 10, 16, 20, 23, 28, 32, 34, 38, 42, 44, 48 };
	int[] menu = { 0, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };


	// Start is called before the first frame update
	void Start()
	{
		ChapterStrings = ChapterText.text.Split(new char[] { '$' });
		for (int i = 0; i < 12; i++)
		{
			ChapterRow = ChapterStrings[i + 1].Split(new char[] { ',' });
			chapterLogs = new ChapterLogs();
			chapterLogs.part = ChapterRow[0];
			chapterLogs.title = ChapterRow[1];
			chapterLogs.description = ChapterRow[2];

			string Filter = chapterLogs.part.Replace("\n", "");
			FileChapterNumber[i].text = Filter;
			FileTitle[i].text = chapterLogs.title;

			chapterList.Add(chapterLogs);
		}


		BackButton.onClick.AddListener(BackButtonPressed);
		for (int i = 0; i < 12; i++)
		{
			int number = i;
			FileButton[i].onClick.AddListener(() => ChapterButtonPressed(number));
		}
	}

	void ChapterButtonPressed(int i)
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		if (isPressed[i] == false)
		{
			Debug.Log(i);
			for (int j = 0; j < 12; j++)
			{
				isPressed[j] = false;
			}
			string Filter = chapterList[i].description.Replace("\"", "");
			FileDescription.text = Filter;
			isPressed[i] = true;
		}
		else
		{
			Debug.Log(i.ToString());

			PlayerPrefs.SetInt("LogNow", 1);

			PlayerPrefs.SetInt("MiniGame", 0);
			PlayerPrefs.SetInt("ResetPos", ResetPos[i]);
			PlayerPrefs.SetInt("NovelMenu", 0);

			int[] startDate = { month[i], day[i] };
			PlayerPrefsX.SetIntArray("Date", startDate);

			PlayerPrefs.SetInt("Money", 0);
			PlayerPrefs.SetFloat("LiedHeart", liedAff[i]);
			PlayerPrefs.SetFloat("KleinHeart", 0);

			PlayerPrefs.SetInt("LiedFail", 0);
			PlayerPrefs.SetInt("KleinFail", 0);

			PlayerPrefs.SetInt("CleanNumber", 0);
			PlayerPrefs.SetInt("CookNumber", 0);
			PlayerPrefs.SetInt("ShopNumber", 0);
			PlayerPrefs.SetString("BackgroundClip", "");

			int[] itemNumber = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

			PlayerPrefsX.SetIntArray("ItemNumber", itemNumber);

			PlayerPrefs.SetInt("WhichFile", 0);

			SceneManager.LoadScene("Novel");
		}
	}

	void BackButtonPressed()
	{
		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		ChapterScreen.SetActive(false);
		TitleScreen.SetActive(true);
	}
}
