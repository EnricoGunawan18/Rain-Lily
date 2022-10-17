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
    bool[] isNum;

    Vector3 position1;
    Vector3 position2;
    
    // Start is called before the first frame update
    void Start()
    {
        numNow = 0;

        position1 = filePanel[0].transform.position;
        position2 = filePanel[1].transform.position;

        isNum = new bool[6];
        for( int i = 0; i < 6; i++)
        {
            isNum[i] = false;
        }

        for(int i = 0; i < 6; i++)
        {
            int num = i;
			buttons[num].onClick.AddListener(delegate{FileButtonClick(num);});
            leftButton.onClick.AddListener(LeftButtonClick);
            rightButton.onClick.AddListener(RightButtonClick);
        }
    }

    void Update()
    {
        for( int i = 0; i < 6; i++)
        {
            if(isNum[i] == true)
            {
                float time = 0;
                time += Time.unscaledDeltaTime;

                buttons[numNow].image.sprite = unpressed[numNow];
                buttons[i].image.sprite = pressed[i];

                filePanel[numNow].transform.position = Vector3.MoveTowards(filePanel[numNow].transform.position, position2, Time.unscaledDeltaTime * 1920f);
                filePanel[i].transform.position = Vector3.MoveTowards(filePanel[i].transform.position, position1, Time.unscaledDeltaTime * 1920f);
                if(filePanel[numNow].transform.position == position2)
                {
                    numNow = i;
                    isNum[i] = false;
                }
            }
        }
    }

    void FileButtonClick(int num)
    {
        isNum[num] = true;
    }

    void LeftButtonClick()
    {
        if(numNow > 0)
        {
            isNum[numNow - 1] = true;
        }
    }
    
    void RightButtonClick()
    {
        if(numNow < buttons.Length - 1)
        {
            isNum[numNow + 1] = true;
        }
    }
}
