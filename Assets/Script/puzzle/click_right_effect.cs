using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click_right_effect : MonoBehaviour
{
    [SerializeField]
    private AudioClip erase;
    [SerializeField]
    private AudioClip Bomb;
    [SerializeField]
    private AudioClip refresh;

    AudioSource audioSource;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 右
        if (Input.GetMouseButtonDown(1))
        {
            //音(sound1)を鳴らす
            audioSource.PlayOneShot(refresh);
        }
    }

    public void Bomb_effect()
    {
        audioSource.PlayOneShot(Bomb);
    }

    public void Erase_effect()
    {
        audioSource.PlayOneShot(erase);
    }
}