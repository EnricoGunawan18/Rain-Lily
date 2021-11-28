using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffectionScript : MonoBehaviour
{
    [SerializeField]
    TextAsset[] Lied;
    [SerializeField]
    TextAsset[] Klein;

    [SerializeField]
    Scrollbar LiedBar;
    [SerializeField]
    Scrollbar KleinBar;

    [SerializeField]
    Text[] TextField;

    string[] data;
    string[] row;

    List<Dialogue> LiedList;
    List<Dialogue> KleinList;

    Dialogue dial;

    int[] LiedHeartNeed = { 100, 90, 85, 80, 70, 60, 55, 50, 40, 30, 20 };
    int[] KleinHeartNeed = { 100, 90, 85, 80, 65, 60, 55, 50, 40, 30, 20 };

    void OnEnable()
    {
        float LiedAffection = PlayerPrefs.GetFloat("LiedHeart");
        float KleinAffection = PlayerPrefs.GetFloat("KleinHeart");
        int countClean = PlayerPrefs.GetInt("CleanNumber");
        int countCook = PlayerPrefs.GetInt("CookNumber");
        int countShop = PlayerPrefs.GetInt("ShopNumber");
        int[] date = PlayerPrefsX.GetIntArray("Date");
        int LiedFail = PlayerPrefs.GetInt("LiedFail");
        int KleinFail = PlayerPrefs.GetInt("KleinFail");

        LiedList = new List<Dialogue>();
        KleinList = new List<Dialogue>();

        for (int i = 0; i < 11; i++)
        {
            data = Lied[i].text.Split(new char[] { '$' });

            row = data[1].Split(new char[] { ',' });

            dial = new Dialogue();
            dial.effect = row[8];

            LiedList.Add(dial);
        }

        for (int i = 0; i < 11; i++)
        {
            data = Klein[i].text.Split(new char[] { '$' });

            row = data[1].Split(new char[] { ',' });

            dial = new Dialogue();
            dial.effect = row[8].Replace("\"", "");

            KleinList.Add(dial);
        }

        LiedBar.size = LiedAffection * 0.01f;
        KleinBar.size = KleinAffection * 0.01f;

        if (date[0] == 10 && date[1] <= 15)
        {
            TextField[0].text = LiedList[0].effect;
        }
        else if (date[0] == 10 && date[1] <= 20 && LiedFail == 0)
        {
            TextField[0].text = LiedList[1].effect;
        }
        else if (date[0] == 10 && date[1] <= 30 && LiedFail == 0)
        {
            TextField[0].text = LiedList[2].effect;
        }
        else if (date[0] == 10 && date[1] <= 31 && LiedFail == 0)
        {
            TextField[0].text = LiedList[3].effect;
        }
        else if (date[0] == 11 && date[1] <= 8 && LiedFail == 0)
        {
            TextField[0].text = LiedList[3].effect;
        }
        else if (date[0] == 11 && date[1] <= 15 && LiedFail == 0)
        {
            TextField[0].text = LiedList[4].effect;
        }
        else if (date[0] == 11 && date[1] <= 17 && LiedFail == 0)
        {
            TextField[0].text = LiedList[5].effect;
        }
        else if (date[0] == 11 && date[1] <= 25 && LiedFail == 0)
        {
            TextField[0].text = LiedList[6].effect;
        }
        else if (date[0] == 11 && date[1] <= 30 && LiedFail == 0)
        {
            TextField[0].text = LiedList[7].effect;
        }
        else if (date[0] == 12 && date[1] <= 3 && LiedFail == 0)
        {
            TextField[0].text = LiedList[8].effect;
        }
        else if (date[0] == 12 && date[1] <= 6 && LiedFail == 0)
        {
            TextField[0].text = LiedList[9].effect;
        }
        else if (date[0] == 12 && date[1] <= 9 && LiedFail == 0)
        {
            TextField[0].text = LiedList[10].effect;
        }
        else
        {
            TextField[0].text = "‚à‚¤U—ª‚Å‚«‚È‚¢";
        }


        if (date[0] == 10 && date[1] <= 16)
        {
            TextField[1].text = KleinList[0].effect;
        }
        else if(date[0] == 10 && date[1] <= 18 && KleinFail == 0)
        {
            TextField[1].text = KleinList[1].effect;
        }
        else if (date[0] == 10 && date[1] <= 25 && KleinFail == 0)
        {
            TextField[1].text = KleinList[2].effect;
        }
        else if (date[0] == 10 && date[1] <= 31 && KleinFail == 0)
        {
            TextField[1].text = KleinList[3].effect;
        }
        else if (date[0] == 11 && date[1] <= 3 && KleinFail == 0)
        {
            TextField[1].text = KleinList[3].effect;
        }
        else if (date[0] == 11 && date[1] <= 10 && KleinFail == 0)
        {
            TextField[1].text = KleinList[4].effect;
        }
        else if (date[0] == 11 && date[1] <= 15 && KleinFail == 0)
        {
            TextField[1].text = KleinList[5].effect;
        }
        else if (date[0] == 11 && date[1] <= 20 && KleinFail == 0)
        {
            TextField[1].text = KleinList[6].effect;
        }
        else if (date[0] == 11 && date[1] <= 27 && KleinFail == 0)
        {
            TextField[1].text = KleinList[7].effect;
        }
        else if (date[0] == 11 && date[1] <= 30 && KleinFail == 0)
        {
            TextField[1].text = KleinList[8].effect;
        }
        else if (date[0] == 12 && date[1] <= 3 && KleinFail == 0)
        {
            TextField[1].text = KleinList[8].effect;
        }
        else if (date[0] == 12 && date[1] <= 7 && KleinFail == 0)
        {
            TextField[1].text = KleinList[9].effect;
        }
        else if (date[0] == 12 && date[1] <= 9 && KleinFail == 0)
        {
            TextField[1].text = KleinList[10].effect;
        }
        else
        {
            TextField[1].text = "‚à‚¤U—ª‚Å‚«‚È‚¢";
        }

    }
}
