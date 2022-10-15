using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileButton : MonoBehaviour
{
    [SerializeField]
    Button[] buttons;
    [SerializeField]
    Button leftButton;
    [SerializeField] 
    Button rightButton;

    [SerializeField]
    Sprite[] unpressed;
    [SerializeField]
    Sprite[] pressed;

    [SerializeField]
    GameObject[] filePanel;

    int numNow;
    int numSwitch;
    // Start is called before the first frame update
    void Start()
    {
        numNow = 0;
        numSwitch = 0;

        for(int i = 0; i < 6; i++)
        {
            int num = i;
			buttons[i].onClick.AddListener(delegate{FileButtonClick(num);});
        }
    }

    void FileButtonClick(int num)
    {
        
    }
}
