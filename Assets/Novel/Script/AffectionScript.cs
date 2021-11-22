using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffectionScript : MonoBehaviour
{
    [SerializeField]
    Scrollbar LiedBar;
    [SerializeField]
    Scrollbar KleinBar;


    void OnEnable()
    {
        float LiedAffection = PlayerPrefs.GetFloat("LiedHeart");
        float KleinAffection = PlayerPrefs.GetFloat("KleinHeart");

        LiedBar.size = LiedAffection * 0.01f;
        KleinBar.size = KleinAffection * 0.01f;
    }


}
