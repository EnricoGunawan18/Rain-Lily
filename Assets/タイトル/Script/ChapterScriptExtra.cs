using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChapterScriptExtra : MonoBehaviour
{
    [SerializeField]
    string[] extraTitle;
    [SerializeField]
    string[] extraSub;
    [SerializeField]
    string[] extraDescription;

	[SerializeField]
	Button[] fileButton;
    [SerializeField]
    Text[] fileTitle;
    [SerializeField]
    Text[] fileSub;

    [SerializeField]
    Text fileDescription;

    bool[] isPressed = {false,false};
	int[] ResetPos = { 126, 128 };

	[SerializeField]
	GameObject LoadingScreen;

    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < extraTitle.Length; i++)
		{
			int number = i;
            fileTitle[i].text = extraTitle[i];
            fileSub[i].text = extraSub[i];
			fileButton[i].onClick.AddListener(() => ChapterButtonPressed(number));
		}
    }

    // Update is called once per frame
    void ChapterButtonPressed(int i)
    {
        if(isPressed[i] == false)
        {
            for(int j = 0; j < isPressed.Length;j++)
            {
                isPressed[j] = false;
            }
            fileDescription.text = extraDescription[i];
            isPressed[i] = true;
        }
        else
        {
			Debug.Log(i.ToString());

			PlayerPrefs.SetInt("LogNow", 1);

			PlayerPrefs.SetInt("MiniGame", 0);
			PlayerPrefs.SetInt("ResetPos", ResetPos[i]);
			PlayerPrefs.SetInt("NovelMenu", 0);

			int[] startDate = { 99 + i, 99 + i };///temp///
			PlayerPrefsX.SetIntArray("Date", startDate);

			PlayerPrefs.SetInt("Money", 0);
			PlayerPrefs.SetFloat("LiedHeart", 0);

			PlayerPrefs.SetInt("LiedFail", 0);
			PlayerPrefs.SetInt("KleinFail", 0);

			PlayerPrefs.SetInt("CleanNumber", 0);
			PlayerPrefs.SetInt("CookNumber", 0);
			PlayerPrefs.SetInt("ShopNumber", 0);
			PlayerPrefs.SetString("BackgroundClip", "");

			PlayerPrefs.SetString("PlayerName", "");

			int[] itemNumber = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

			PlayerPrefsX.SetIntArray("ItemNumber", itemNumber);

			PlayerPrefs.SetInt("WhichFile", 0);

			LoadingScreen.SetActive(true);
			PlayerPrefs.SetInt("ChapterScreen", 1);
			SceneManager.LoadScene("Novel");
        }
    }
}
