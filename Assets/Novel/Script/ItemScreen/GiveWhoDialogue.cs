using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveWhoDialogue : MonoBehaviour
{
    [SerializeField]
    LoadDialogue loadDialogue;

    void OnEnable()
    {
        loadDialogue.CharacterItemChoose();
    }
}
