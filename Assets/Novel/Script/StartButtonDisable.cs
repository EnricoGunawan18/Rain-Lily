using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonDisable : MonoBehaviour
{
    [SerializeField]
    Button QuickSave;
    [SerializeField]
    Button QuickLoad;

    [SerializeField]
    Button[] SavedButton;
    // Start is called before the first frame update
    void Start()
    {
        int whichFile = PlayerPrefs.GetInt("WhichFile");
        if(whichFile == 0)
        {
            QuickSave.interactable = false;
            QuickLoad.interactable = false;
        }
        else
        {
            QuickSave.interactable = true;
            QuickLoad.interactable = true;
        }

        for(int i = 0; i< 10; i++)
        {
            SavedButton[i].onClick.AddListener(Saved);
        }
    }

    // Update is called once per frame
    void Saved()
    {
        QuickSave.interactable = true;
        QuickLoad.interactable = true;
    }
}
