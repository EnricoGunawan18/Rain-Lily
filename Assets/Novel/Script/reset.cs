using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    [SerializeField]
    public PlayerPrefsX playerPrefsX;
    // Start is called before the first frame update
    void Start()
    {
        //which dialogue
        PlayerPrefs.SetInt("LogNow", 1);

        //dialogue speed
        PlayerPrefs.SetFloat("DialogueSpeed", 10f);

        //reset//////////////////////////////////////////////////////////////////
        PlayerPrefs.SetFloat("ScoreAll", 0);
        PlayerPrefs.SetInt("ScoreClean", 0);
        PlayerPrefs.SetFloat("ShopHighScore", 0);
        PlayerPrefs.SetInt("CleanHighScore", 0);

        PlayerPrefs.SetFloat("Score1", 0);
        PlayerPrefs.SetFloat("Score2", 0);
        PlayerPrefs.SetFloat("Score3", 0);
        PlayerPrefs.SetFloat("Score4", 0);
        PlayerPrefs.SetFloat("Score5", 0);
        PlayerPrefs.SetInt("MiniGame", 0);
        PlayerPrefs.SetInt("ResetPos", 0);
        //PlayerPrefs.SetInt("ResetPos", 26);
        PlayerPrefs.SetInt("NovelMenu", 12);
        //PlayerPrefs.SetInt("NovelMenu", 0);

        PlayerPrefs.SetInt("NovelMenu1", 0);
        PlayerPrefs.SetInt("NovelMenu2", 0);
        PlayerPrefs.SetInt("NovelMenu3", 0);
        PlayerPrefs.SetInt("NovelMenu4", 0);
        PlayerPrefs.SetInt("NovelMenu5", 0);
        PlayerPrefs.SetInt("NovelMenu6", 0);
        PlayerPrefs.SetInt("NovelMenu7", 0);
        PlayerPrefs.SetInt("NovelMenu8", 0);
        PlayerPrefs.SetInt("NovelMenu9", 0);
        PlayerPrefs.SetInt("NovelMenu10", 0);
       
        //int[] startDate = { 10,7 };
        int[] startDate = { 10, 10 };

        PlayerPrefsX.SetIntArray("Date", startDate);

        int[] empty = { 0, 0 };
        PlayerPrefsX.SetIntArray("Date1", empty);
        PlayerPrefsX.SetIntArray("Date2", empty);
        PlayerPrefsX.SetIntArray("Date3", empty);
        PlayerPrefsX.SetIntArray("Date4", empty);
        PlayerPrefsX.SetIntArray("Date5", empty);
        PlayerPrefsX.SetIntArray("Date6", empty);
        PlayerPrefsX.SetIntArray("Date7", empty);
        PlayerPrefsX.SetIntArray("Date8", empty);
        PlayerPrefsX.SetIntArray("Date9", empty);
        PlayerPrefsX.SetIntArray("Date10", empty);

        int[] a = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        PlayerPrefsX.SetIntArray("ItemNumber", a);

        PlayerPrefsX.SetIntArray("ItemNumber1", a);
        PlayerPrefsX.SetIntArray("ItemNumber2", a);
        PlayerPrefsX.SetIntArray("ItemNumber3", a);
        PlayerPrefsX.SetIntArray("ItemNumber4", a);
        PlayerPrefsX.SetIntArray("ItemNumber5", a);
        PlayerPrefsX.SetIntArray("ItemNumber6", a);
        PlayerPrefsX.SetIntArray("ItemNumber7", a);
        PlayerPrefsX.SetIntArray("ItemNumber8", a);
        PlayerPrefsX.SetIntArray("ItemNumber9", a);
        PlayerPrefsX.SetIntArray("ItemNumber10", a);

        PlayerPrefs.SetInt("Money", 0);
        PlayerPrefs.SetFloat("LiedHeart", 0);
        PlayerPrefs.SetFloat("KleinHeart", 100);

        PlayerPrefs.SetInt("Money1", 0);
        PlayerPrefs.SetFloat("LiedHeart1", 0);
        PlayerPrefs.SetFloat("KleinHeart1", 0);
        PlayerPrefs.SetInt("Money2", 0);
        PlayerPrefs.SetFloat("LiedHeart2", 0);
        PlayerPrefs.SetFloat("KleinHeart2", 0);
        PlayerPrefs.SetInt("Money3", 0);
        PlayerPrefs.SetFloat("LiedHeart3", 0);
        PlayerPrefs.SetFloat("KleinHeart3", 0);
        PlayerPrefs.SetInt("Money4", 0);
        PlayerPrefs.SetFloat("LiedHeart4", 0);
        PlayerPrefs.SetFloat("KleinHeart4", 0);
        PlayerPrefs.SetInt("Money5", 0);
        PlayerPrefs.SetFloat("LiedHeart5", 0);
        PlayerPrefs.SetFloat("KleinHeart5", 0);
        PlayerPrefs.SetInt("Money6", 0);
        PlayerPrefs.SetFloat("LiedHeart6", 0);
        PlayerPrefs.SetFloat("KleinHeart6", 0);
        PlayerPrefs.SetInt("Money7", 0);
        PlayerPrefs.SetFloat("LiedHeart7", 0);
        PlayerPrefs.SetFloat("KleinHeart7", 0);
        PlayerPrefs.SetInt("Money8", 0);
        PlayerPrefs.SetFloat("LiedHeart8", 0);
        PlayerPrefs.SetFloat("KleinHeart8", 0);
        PlayerPrefs.SetInt("Money9", 0);
        PlayerPrefs.SetFloat("LiedHeart9", 0);
        PlayerPrefs.SetFloat("KleinHeart9", 0);
        PlayerPrefs.SetInt("Money10", 0);
        PlayerPrefs.SetFloat("LiedHeart10", 0);
        PlayerPrefs.SetFloat("KleinHeart10", 0);

        PlayerPrefs.SetInt("LiedFail", 0);
        PlayerPrefs.SetInt("KleinFail", 0);

        PlayerPrefs.SetInt("LiedFail1", 0);
        PlayerPrefs.SetInt("KleinFail1", 0);
        PlayerPrefs.SetInt("LiedFail2", 0);
        PlayerPrefs.SetInt("KleinFail2", 0);
        PlayerPrefs.SetInt("LiedFail3", 0);
        PlayerPrefs.SetInt("KleinFail3", 0);
        PlayerPrefs.SetInt("LiedFail4", 0);
        PlayerPrefs.SetInt("KleinFail4", 0);
        PlayerPrefs.SetInt("LiedFail5", 0);
        PlayerPrefs.SetInt("KleinFail5", 0);
        PlayerPrefs.SetInt("LiedFail6", 0);
        PlayerPrefs.SetInt("KleinFail6", 0);
        PlayerPrefs.SetInt("LiedFail7", 0);
        PlayerPrefs.SetInt("KleinFail7", 0);
        PlayerPrefs.SetInt("LiedFail8", 0);
        PlayerPrefs.SetInt("KleinFail8", 0);
        PlayerPrefs.SetInt("LiedFail9", 0);
        PlayerPrefs.SetInt("KleinFail9", 0);
        PlayerPrefs.SetInt("LiedFail10", 0);
        PlayerPrefs.SetInt("KleinFail10", 0);


        PlayerPrefs.SetInt("CleanNumber", 0);
        PlayerPrefs.SetInt("CookNumber", 0);
        PlayerPrefs.SetInt("ShopNumber", 0);

        PlayerPrefs.SetInt("CleanNumber1", 0);
        PlayerPrefs.SetInt("CookNumber1", 0);
        PlayerPrefs.SetInt("ShopNumber1", 0);
        PlayerPrefs.SetInt("CleanNumber2", 0);
        PlayerPrefs.SetInt("CookNumber2", 0);
        PlayerPrefs.SetInt("ShopNumber2", 0);
        PlayerPrefs.SetInt("CleanNumber3", 0);
        PlayerPrefs.SetInt("CookNumber3", 0);
        PlayerPrefs.SetInt("ShopNumber3", 0);
        PlayerPrefs.SetInt("CleanNumber4", 0);
        PlayerPrefs.SetInt("CookNumber4", 0);
        PlayerPrefs.SetInt("ShopNumber4", 0);
        PlayerPrefs.SetInt("CleanNumber5", 0);
        PlayerPrefs.SetInt("CookNumber5", 0);
        PlayerPrefs.SetInt("ShopNumber5", 0);
        PlayerPrefs.SetInt("CleanNumber6", 0);
        PlayerPrefs.SetInt("CookNumber6", 0);
        PlayerPrefs.SetInt("ShopNumber6", 0);
        PlayerPrefs.SetInt("CleanNumber7", 0);
        PlayerPrefs.SetInt("CookNumber7", 0);
        PlayerPrefs.SetInt("ShopNumber7", 0);
        PlayerPrefs.SetInt("CleanNumber8", 0);
        PlayerPrefs.SetInt("CookNumber8", 0);
        PlayerPrefs.SetInt("ShopNumber8", 0);
        PlayerPrefs.SetInt("CleanNumber9", 0);
        PlayerPrefs.SetInt("CookNumber9", 0);
        PlayerPrefs.SetInt("ShopNumber9", 0);
        PlayerPrefs.SetInt("CleanNumber10", 0);
        PlayerPrefs.SetInt("CookNumber10", 0);
        PlayerPrefs.SetInt("ShopNumber10", 0);

        PlayerPrefs.SetInt("WhichFile", 0);
        PlayerPrefs.SetInt("ZeroLog", 1);
        PlayerPrefs.SetInt("ZeroPos", 0);
        PlayerPrefs.SetInt("LiedFail0", 0);
        PlayerPrefs.SetInt("KleinFail0", 0);
        PlayerPrefs.SetInt("Money0", 0);
        PlayerPrefs.SetFloat("LiedHeart0", 0);
        PlayerPrefs.SetFloat("KleinHeart0", 0);
        PlayerPrefs.SetInt("CleanNumber0", 0);
        PlayerPrefs.SetInt("CookNumber0", 0);
        PlayerPrefs.SetInt("ShopNumber0", 0);

        PlayerPrefs.SetInt("NovelMenu0",0);
        PlayerPrefsX.SetIntArray("ItemNumber0", a);
        PlayerPrefsX.SetIntArray("Date0", startDate);

        PlayerPrefs.SetString("BackgroundClip", "");
        PlayerPrefs.SetString("BackgroundClip1", "");
        PlayerPrefs.SetString("BackgroundClip2", "");
        PlayerPrefs.SetString("BackgroundClip3", "");
        PlayerPrefs.SetString("BackgroundClip4", "");
        PlayerPrefs.SetString("BackgroundClip5", "");
        PlayerPrefs.SetString("BackgroundClip6", "");
        PlayerPrefs.SetString("BackgroundClip7", "");
        PlayerPrefs.SetString("BackgroundClip8", "");
        PlayerPrefs.SetString("BackgroundClip9", "");
        PlayerPrefs.SetString("BackgroundClip10", "");
        PlayerPrefs.SetString("BackgroundClip0", "");

    }
}
