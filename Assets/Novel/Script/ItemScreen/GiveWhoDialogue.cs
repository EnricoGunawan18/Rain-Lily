using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveWhoDialogue : MonoBehaviour
{
    [SerializeField]
    LoadDialogue loadDialogue;
    [SerializeField]
    Button GameShowHide;

    void OnEnable()
    {
        loadDialogue.CharacterItemChoose();
        GameShowHide.interactable = false;
    }
}
