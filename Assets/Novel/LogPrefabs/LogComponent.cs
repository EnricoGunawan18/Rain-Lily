using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogComponent : MonoBehaviour
{
    [SerializeField]
    Text nameText;
    [SerializeField]
    Text dialogueText;

    // Update is called once per frame
    public void SetName(string name)
    {
        nameText.text = name;
    }

    public void SetDialogue(string dialogue)
    {
        dialogueText.text = dialogue;
    }
}
