using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchChapter : MonoBehaviour
{
    [SerializeField]
    Button Lied;
    [SerializeField]
    Button Klein;

    [SerializeField]
    Sprite[] liedSprite;
    [SerializeField]
    Sprite[] kleinSprite;

    [SerializeField]
    Animator Switcher;


    // Start is called before the first frame update
    void Start()
    {
        Lied.onClick.AddListener(SwitchLied);
        Klein.onClick.AddListener(SwitchKlein);
    }

    // Update is called once per frame

    void SwitchLied() 
    {
        Lied.image.sprite = liedSprite[0];
        Klein.image.sprite = kleinSprite[1];
        Switcher.SetBool("IsLied", true);
    }

    void SwitchKlein() 
    {
        Lied.image.sprite = liedSprite[1];
        Klein.image.sprite = kleinSprite[0];
        Switcher.SetBool("IsLied", false);
    }
}
