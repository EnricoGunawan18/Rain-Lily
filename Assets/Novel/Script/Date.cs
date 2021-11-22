using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Date : MonoBehaviour
{
    [SerializeField]
    Text MonthText;
    [SerializeField]
    Text DayText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        int menu = PlayerPrefs.GetInt("NovelMenu");
        int[] date = PlayerPrefsX.GetIntArray("Date");

        if (menu == 1)
        {
            MonthText.text = "10";
            DayText.text = "7";
        }
        else if (menu == 2)
        {
            MonthText.text = "10";
            DayText.text = "8";
        }
        else if (menu == 3)
        {
            MonthText.text = "10";
            DayText.text = "9";
        }
        else
        {
            MonthText.text = date[0].ToString();
            DayText.text = date[1].ToString();
        }
    }

}
