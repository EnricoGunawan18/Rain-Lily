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
    Button Extra;

    [SerializeField]
    Sprite[] liedSprite;
    [SerializeField]
    Sprite[] kleinSprite;
    [SerializeField]
    Sprite[] extraSprite;

    [SerializeField]
    Animator Switcher;

    int switching = 0;

    // Start is called before the first frame update
    void Start()
    {
        Lied.onClick.AddListener(SwitchLied);
        Klein.onClick.AddListener(SwitchKlein);
        Extra.onClick.AddListener(SwitchExtra);
    }

    // Update is called once per frame

    void SwitchLied() 
    {
        switching = 0;
        Lied.image.sprite = liedSprite[0];
        Klein.image.sprite = kleinSprite[1];
        Extra.image.sprite = extraSprite[1];
        Switcher.SetBool("IsLied",true);
        Switcher.SetBool("IsKlein", false);
        Switcher.SetBool("IsExtra", false);
    }

    void SwitchKlein() 
    {
        switching = 1;
        Lied.image.sprite = liedSprite[1];
        Klein.image.sprite = kleinSprite[0];
        Extra.image.sprite = extraSprite[1];
        Switcher.SetBool("IsKlein", true);
        Switcher.SetBool("IsLied",false);
        Switcher.SetBool("IsExtra", false);
    }

    void SwitchExtra()
    {
        switching = 2;
        Lied.image.sprite = liedSprite[1];
        Klein.image.sprite = kleinSprite[1];
        Extra.image.sprite = extraSprite[0];
        Switcher.SetBool("IsExtra", true);
        Switcher.SetBool("IsLied",false);
        Switcher.SetBool("IsKlein", false);
    }
}
