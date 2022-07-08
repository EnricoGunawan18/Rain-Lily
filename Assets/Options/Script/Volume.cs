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

    float bgm;
    float se;

    private void Awake() 
    {
        SESlider.value = PlayerPrefs.GetFloat("BGM");
        BGMSlider.value = PlayerPrefs.GetFloat("SE");
    }

    void Update()
    {
        Master.SetFloat("SEVol", SESlider.value);
        Master.SetFloat("BGMVol", BGMSlider.value);
    }
}
