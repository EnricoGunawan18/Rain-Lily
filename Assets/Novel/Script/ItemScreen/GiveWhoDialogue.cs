using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveWhoDialogue : MonoBehaviour
{
    [SerializeField]
    LoadDialogue loadDialogue;

    void OnEnable()
    {
        loadDialogue.CharacterItemChoose();
    }
}
