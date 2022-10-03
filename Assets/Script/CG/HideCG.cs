using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideCG : MonoBehaviour
{
    [SerializeField]
    Button[] CG;

    int[] playerPrefs;

    ColorBlock[] cb;

    // Start is called before the first frame update
    void Awake()
    {
        playerPrefs = new int[13];

        for( int i = 0; i < 13; i++)
        {
            playerPrefs[i] = PlayerPrefs.GetInt("Still-" + (i+1).ToString());
        }

        if(playerPrefs[0] != 1)
        {
            CG[0].image.color = Color.black;
            CG[0].interactable = false;
        }

        if(playerPrefs[2] != 1)
        {
            CG[1].image.color = Color.black;
            CG[1].interactable = false;
        }
        if(playerPrefs[3] != 1)
        {
            CG[2].image.color = Color.black;
            CG[2].interactable = false;
        }
        if(playerPrefs[4] != 1)
        {
            CG[3].image.color = Color.black;
            CG[3].interactable = false;
        }
        if(playerPrefs[5] != 1)
        {
            CG[4].image.color = Color.black;
            CG[4].interactable = false;
        }
        if(playerPrefs[6] != 1)
        {
            CG[5].image.color = Color.black;
            CG[5].interactable = false;
        }

        if(playerPrefs[7] != 1)
        {
            CG[6].image.color = Color.black;
            CG[6].interactable = false;
        }
        if(playerPrefs[8] != 1)
        {
            CG[7].image.color = Color.black;
            CG[7].interactable = false;
        }
    }
}
