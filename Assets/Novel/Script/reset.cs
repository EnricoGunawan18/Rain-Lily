using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
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
        PlayerPrefs.SetInt("MiniGame1", 0);
        PlayerPrefs.SetInt("MiniGame2", 0);
        PlayerPrefs.SetInt("MiniGame3", 0);
        PlayerPrefs.SetInt("ResetPos", 0);
    }
}
