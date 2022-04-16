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
    Animator Switcher;


    // Start is called before the first frame update
    void Start()
    {
        Lied.onClick.AddListener(SwitchLied);
        Klein.onClick.AddListener(SwitchKlein);
    }

    // Update is called once per frame

    void SwitchLied() {
        Switcher.SetBool("IsLied", true);
    }

    void SwitchKlein() {
        Switcher.SetBool("IsLied", false);
    }
}
