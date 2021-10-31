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
        PlayerPrefs.SetFloat("DialogueSpeed", 25f);

        //reset//////////////////////////////////////////////////////////////////
        PlayerPrefs.SetFloat("ScoreAll", 0);
        PlayerPrefs.SetFloat("Score1", 0);
        PlayerPrefs.SetFloat("Score2", 0);
        PlayerPrefs.SetFloat("Score3", 0);
        PlayerPrefs.SetFloat("Score4", 0);
        PlayerPrefs.SetFloat("Score5", 0);
        PlayerPrefs.SetInt("MiniGame", 0);
        PlayerPrefs.SetInt("ResetPos", 0);
        PlayerPrefs.SetInt("NovelMenu", 0);

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
        PlayerPrefs.SetString("Date", "Prologue");

        PlayerPrefs.SetString("Date1", "Prologue");
        PlayerPrefs.SetString("Date2", "Prologue");
        PlayerPrefs.SetString("Date3", "Prologue");
        PlayerPrefs.SetString("Date4", "Prologue");
        PlayerPrefs.SetString("Date5", "Prologue");
        PlayerPrefs.SetString("Date6", "Prologue");
        PlayerPrefs.SetString("Date7", "Prologue");
        PlayerPrefs.SetString("Date8", "Prologue");
        PlayerPrefs.SetString("Date9", "Prologue");
        PlayerPrefs.SetString("Date10", "Prologue");

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


    }
}
