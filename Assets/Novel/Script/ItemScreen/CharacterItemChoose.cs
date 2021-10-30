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

    public string Character;

    // Start is called before the first frame update
    void Start()
    {
        Character = "None";
        Riit.onClick.AddListener(RiitPress);
        Klein.onClick.AddListener(KleinPress);
        NoGive.onClick.AddListener(NoGivePress);
    }

    void RiitPress()
    {
        Character = "Riit";
        GiveWhoScreen.SetActive(false);
        loadDialogue.RiitItem();
    }

    void KleinPress()
    {
        Character = "Klein";
        GiveWhoScreen.SetActive(false);
        loadDialogue.KleinItem();
    }

    void NoGivePress()
    {
    }
}
