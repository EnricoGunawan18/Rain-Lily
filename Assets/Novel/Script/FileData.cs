using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileData : MonoBehaviour
{
    [SerializeField]
    Image[] Base;
    [SerializeField]
    Button[] Data;

    [SerializeField]
    Sprite[] Sprite;

    [SerializeField]
    Text[] Date;

    float[] Lied = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    float[] Klein = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    int[][] dateFile;

    // Start is called before the first frame update
    void OnEnable()
    {
        dateFile = new int[10][];

        dateFile[0] = PlayerPrefsX.GetIntArray("Date1");
        dateFile[1] = PlayerPrefsX.GetIntArray("Date2");
        dateFile[2] = PlayerPrefsX.GetIntArray("Date3");
        dateFile[3] = PlayerPrefsX.GetIntArray("Date4");
        dateFile[4] = PlayerPrefsX.GetIntArray("Date5");
        dateFile[5] = PlayerPrefsX.GetIntArray("Date6");
        dateFile[6] = PlayerPrefsX.GetIntArray("Date7");
        dateFile[7] = PlayerPrefsX.GetIntArray("Date8");
        dateFile[8] = PlayerPrefsX.GetIntArray("Date9");
        dateFile[9] = PlayerPrefsX.GetIntArray("Date10");


        Lied[0] = PlayerPrefs.GetFloat("LiedHeart1");
        Klein[0] = PlayerPrefs.GetFloat("KleinHeart1");

        Lied[1] = PlayerPrefs.GetFloat("LiedHeart2");
        Klein[1] = PlayerPrefs.GetFloat("KleinHeart2");

        Lied[2] = PlayerPrefs.GetFloat("LiedHeart3");
        Klein[2] = PlayerPrefs.GetFloat("KleinHeart3");

        Lied[3] = PlayerPrefs.GetFloat("LiedHeart4");
        Klein[3] = PlayerPrefs.GetFloat("KleinHeart4");

        Lied[4] = PlayerPrefs.GetFloat("LiedHeart5");
        Klein[4] = PlayerPrefs.GetFloat("KleinHeart5");

        Lied[5] = PlayerPrefs.GetFloat("LiedHeart6");
        Klein[5] = PlayerPrefs.GetFloat("KleinHeart6");

        Lied[6] = PlayerPrefs.GetFloat("LiedHeart7");
        Klein[6] = PlayerPrefs.GetFloat("KleinHeart7");

        Lied[7] = PlayerPrefs.GetFloat("LiedHeart8");
        Klein[7] = PlayerPrefs.GetFloat("KleinHeart8");

        Lied[8] = PlayerPrefs.GetFloat("LiedHeart9");
        Klein[8] = PlayerPrefs.GetFloat("KleinHeart9");

        Lied[9] = PlayerPrefs.GetFloat("LiedHeart10");
        Klein[9] = PlayerPrefs.GetFloat("KleinHeart10");



        for (int i = 0; i < 10; i++)
        {
            if (dateFile[i][0] == 0)
            {
                Base[i].sprite = null;
                Base[i].color = new Color(0,0,0,0);

                Date[i].text = "EMPTY";
                Data[i].interactable = false;
            }
            else
            {
                Base[i].color = new Color(255, 255, 255, 255);

                Date[0].text = dateFile[0][0].ToString() + "/" + dateFile[0][1].ToString();
                Date[1].text = dateFile[1][0].ToString() + "/" + dateFile[1][1].ToString();
                Date[2].text = dateFile[2][0].ToString() + "/" + dateFile[2][1].ToString();
                Date[3].text = dateFile[3][0].ToString() + "/" + dateFile[3][1].ToString();
                Date[4].text = dateFile[4][0].ToString() + "/" + dateFile[4][1].ToString();
                Date[5].text = dateFile[5][0].ToString() + "/" + dateFile[5][1].ToString();
                Date[6].text = dateFile[6][0].ToString() + "/" + dateFile[6][1].ToString();
                Date[7].text = dateFile[7][0].ToString() + "/" + dateFile[7][1].ToString();
                Date[8].text = dateFile[8][0].ToString() + "/" + dateFile[8][1].ToString();
                Date[9].text = dateFile[9][0].ToString() + "/" + dateFile[9][1].ToString();

                if (Lied[i] < Klein[i])
                {
                    Base[i].sprite = Sprite[1];
                }
                else
                {
                    Base[i].sprite = Sprite[0];
                }
            }
        }
    }
}
