using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterItemChoose : MonoBehaviour
{
    [SerializeField]
    Button Riit;
    [SerializeField]
    Button Klein;
    [SerializeField]
    Button NoGive;

    [SerializeField]
    GameObject GiveWhoScreen;
    [SerializeField]
    GameObject ItemScreen;

    [SerializeField]
    LoadDialogue loadDialogue;

    // Start is called before the first frame update
    void Start()
    {
        Riit.onClick.AddListener(RiitPress);
        Klein.onClick.AddListener(KleinPress);
        NoGive.onClick.AddListener(NoGivePress);
    }

    void RiitPress()
    {
        GiveWhoScreen.SetActive(false);
        loadDialogue.RiitItem();
    }

    void KleinPress()
    {
        GiveWhoScreen.SetActive(false);
        loadDialogue.KleinItem();
    }

    void NoGivePress()
    {
    }
}
