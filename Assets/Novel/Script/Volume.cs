using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField]
    Scrollbar BGMScrollbar;
    [SerializeField]
    AudioSource BGM;
    [SerializeField]
    Scrollbar SEScrollbar;
    [SerializeField]
    AudioSource SE;

    // Update is called once per frame
    void Update()
    {
        BGM.volume = BGMScrollbar.value;
        SE.volume = SEScrollbar.value;
    }
}
