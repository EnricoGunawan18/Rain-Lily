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
        //Component‚ðŽæ“¾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // ‰E
        if (Input.GetMouseButtonDown(1))
        {
            //‰¹(sound1)‚ð–Â‚ç‚·
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