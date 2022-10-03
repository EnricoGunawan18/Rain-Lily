using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_right_BGM : MonoBehaviour
{
    [SerializeField]
    private AudioClip finish;

    private PazzleCookMAnager game = new PazzleCookMAnager();
    AudioSource audioSource;

    void Start()
    {
        //Component‚ðŽæ“¾
        audioSource = GetComponent<AudioSource>();
    }

    public void Finish_effect()
    {
        audioSource.PlayOneShot(finish);
    }

    public void Start_bgm()
    {
        if (game.GetGameStop())
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
    }
}
