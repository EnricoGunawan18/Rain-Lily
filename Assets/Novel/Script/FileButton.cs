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
    
    // Start is called before the first frame update
    void Start()
    {
        numNow = 0;

        for(int i = 0; i < 6; i++)
        {
            int num = i;
			buttons[i].onClick.AddListener(delegate{FileButtonClick(num);});
        }
    }

    void FileButtonClick(int num)
    {
        Vector3 position1 = filePanel[numNow].transform.position;
        Vector3 position2 = filePanel[num].transform.position;
        filePanel[numNow].transform.position = Vector3.MoveTowards(filePanel[numNow].transform.position, position2, Time.deltaTime * 100f);
        filePanel[num].transform.position = Vector3.MoveTowards(filePanel[num].transform.position, position1, Time.deltaTime * 100f);
        if(filePanel[numNow].transform.position == position2)
        {
            numNow = num;
        }
    }
}
