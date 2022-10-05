using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class still5Script : MonoBehaviour
{
    [SerializeField]
    Button Play;
    // Start is called before the first frame update
    void Start()
    {
        Play.onClick.AddListener(PlayButton);
    }

    // Update is called once per frame
    void PlayButton()
    {
		PlayerPrefs.SetInt("LogNow", 1);

		PlayerPrefs.SetInt("MiniGame", 0);
		PlayerPrefs.SetInt("ResetPos", 116);//////////////////change each script pls(Enrico reminder)
		PlayerPrefs.SetInt("NovelMenu", 24);

		int[] startDate = { 12, 9 };//////////////////change each script pls(Enrico reminder)
		PlayerPrefsX.SetIntArray("Date", startDate);

		PlayerPrefs.SetInt("Money", 0);
		PlayerPrefs.SetFloat("LiedHeart", 60);//////////////////change each script pls(Enrico reminder)
		PlayerPrefs.SetFloat("KleinHeart", 0);//////////////////change each script pls(Enrico reminder)

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
