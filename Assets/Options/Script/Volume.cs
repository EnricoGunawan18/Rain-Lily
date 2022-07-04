using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    [SerializeField]
    Slider SESlider;
    [SerializeField]
    Slider BGMSlider;

    [SerializeField]
    AudioMixer Master;

    // Update is called once per frame
    void Update()
    {
        Master.SetFloat("SEVol", SESlider.value);
        Master.SetFloat("BGMVol", BGMSlider.value);
    }
}
