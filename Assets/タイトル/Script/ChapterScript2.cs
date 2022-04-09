using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChapterScript2 : MonoBehaviour
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
	AudioSource ButtonAudioSource;

	bool[] isPressed = { false, false, false, false, false, false, false, false, false, false, false, false };
	int[] month = { 10, 10, 10, 10, 11, 11, 11, 11, 11, 12, 12, 12 };
	int[] day = { 7, 16, 18, 25, 3, 10, 15, 20, 27, 3, 7, 9 };
	int[] kleinAff = { 0, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60 };
	int[] ResetPos = { 0, 58, 62, 66, 72, 76, 28, 85, 91, 42, 98, 48 };
	int[] menu = { 0, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 };


	// Start is called before the first frame update
	void Start()
	{
		ChapterStrings = ChapterText.text.Split(new char[] { '$' });

		for (int i = 0; i < 12; i++)
		{
			if (i == 0)
			{
				ChapterRow = ChapterStrings[i + 1].Split(new char[] { ',' });
			}
			else
			{
				ChapterRow = ChapterStrings[i + 12].Split(new char[] { ',' });
			}

			chapterLogs = new ChapterLogs();
			chapterLogs.part = ChapterRow[0];
			chapterLogs.title = ChapterRow[1];
			chapterLogs.description = ChapterRow[2];

			string Filter = chapterLogs.part.Replace("\n", "");
			FileChapterNumber[i].text = Filter;
			FileTitle[i].text = chapterLogs.title;

			chapterList.Add(chapterLogs);
		}

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
			PlayerPrefs.SetFloat("KleinHeart", kleinAff[i]);
			PlayerPrefs.SetFloat("LiedHeart", 0);

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
}
