using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    [SerializeField]
    public PlayerPrefsX playerPrefsX;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetInt("StartGame", 0);

        //which dialogue
        PlayerPrefs.SetInt("LogNow", 1);

        //dialogue speed
        PlayerPrefs.SetFloat("DialogueSpeed", 25f);

        //meia Image
        PlayerPrefs.SetInt("MeiaShow", 0);


        //reset//////////////////////////////////////////////////////////////////
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
       
        //int[] startDate = { 10,7 };
        int[] startDate = { 10, 10 };

        PlayerPrefsX.SetIntArray("Date", startDate);

        int[] empty = { 0, 0 };
        int[] a = new int[36];
        for( int i = 0; i < a.Length; i++)
        {
            a[i] = 0;
        }

        for( int i = 0; i < 36; i++)
        {
            PlayerPrefs.SetInt($"NovelMenu{i+1}", 0);
            PlayerPrefsX.SetIntArray($"Date{i+1}", empty);
            PlayerPrefsX.SetIntArray($"ItemNumber{i+1}", a);
            PlayerPrefs.SetInt($"Money{i+1}", 0);
            PlayerPrefs.SetFloat($"LiedHeart{i+1}", 0);
            PlayerPrefs.SetFloat($"KleinHeart{i+1}", 0);
            PlayerPrefs.SetInt($"LiedFail{i+1}", 0);
            PlayerPrefs.SetInt($"KleinFail{i+1}", 0);
            PlayerPrefs.SetInt($"CleanNumber{i+1}", 0);
            PlayerPrefs.SetInt($"CookNumber{i+1}", 0);
            PlayerPrefs.SetInt($"ShopNumber{i+1}", 0);
            PlayerPrefs.SetString($"BackgroundClip{i+1}", "");
            PlayerPrefs.SetString($"PlayerName{i}","");
        }

        PlayerPrefsX.SetIntArray("ItemNumber", a);

        PlayerPrefs.SetInt("Money", 0);
        PlayerPrefs.SetFloat("LiedHeart", 0);
        PlayerPrefs.SetFloat("KleinHeart", 100);


        PlayerPrefs.SetInt("LiedFail", 0);
        PlayerPrefs.SetInt("KleinFail", 0);

        PlayerPrefs.SetInt("CleanNumber", 0);
        PlayerPrefs.SetInt("CookNumber", 0);
        PlayerPrefs.SetInt("ShopNumber", 0);

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
        PlayerPrefs.SetString("BackgroundClip0", "");

        PlayerPrefs.SetString("BackgroundClip", "");

        PlayerPrefs.SetString("PlayerName", "");

        PlayerPrefs.SetFloat("ShopHighScore",0);
        PlayerPrefs.SetInt("CleanHighScore",0);
        PlayerPrefs.SetInt("CookHighScore",0);

        PlayerPrefs.SetFloat("ScoreAll", 0);
        PlayerPrefs.SetInt("ScoreCook", 0);
        PlayerPrefs.SetInt("ScoreClean", 0);

        for (int i = 1; i < 13; i++)
        {
            PlayerPrefs.SetInt("Still-" + i.ToString(), 1);
        }
    }
}
