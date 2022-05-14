using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameChoose : MonoBehaviour
{
    [SerializeField]
    public AudioClip BGMFile;

    [SerializeField]
    AudioSource BGM;

    void OnEnable()
    {
        BGM.clip = BGMFile;
        BGM.Play();
    }
}
