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

    public void EffectStart()
    {
        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    public void EffectUpdate()
    {
        // �E
        if (Input.GetMouseButtonDown(1))
        {
            //��(sound1)��炷
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