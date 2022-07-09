using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCharacter : MonoBehaviour
{
    [SerializeField]
    Button onButton;
    [SerializeField]
    Button offButton;

    [SerializeField]
    Sprite[] highlight;

    int startHighlight;
    // Start is called before the first frame update
    void Start()
    {
        startHighlight = PlayerPrefs.GetInt("MeiaShow");
        if(startHighlight == 0)
        {
            onButton.image.sprite = highlight[0];
            offButton.image.sprite = highlight[3];
        }
        else if(startHighlight == 1)
        {
            onButton.image.sprite = highlight[2];
            offButton.image.sprite = highlight[1];
        }

        onButton.onClick.AddListener(On); 
        offButton.onClick.AddListener(Off); 
    }

    void On()
    {
        PlayerPrefs.SetInt("MeiaShow", 0);

        onButton.image.sprite = highlight[0];
        offButton.image.sprite = highlight[3];
    }

    void Off()
    {
        PlayerPrefs.SetInt("MeiaShow", 1);

        onButton.image.sprite = highlight[2];
        offButton.image.sprite = highlight[1];
    }
}
