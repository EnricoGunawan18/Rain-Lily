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
    private AudioClip finish;
    [SerializeField]
    private AudioClip bgm;
    [SerializeField]
    private AudioClip count;
    [SerializeField]
    private AudioClip[] chain;

    [Space(10)]

    [SerializeField]
    private ResultScript _stop;

    AudioSource audioSource;
    private IEnumerator coroutine;

    void Start()
    {
        //Component‚ðŽæ“¾
        audioSource = GetComponent<AudioSource>();
        coroutine = DelayMethod();
    }

    void Update()
    {
        // ‰E
        if (Input.GetMouseButtonDown(1))
        {
            //‰¹(sound1)‚ð–Â‚ç‚·
            audioSource.PlayOneShot(erase);
        }
    }

    public void Chain_effect(int num)
    {
        /*
        StartCoroutine(coroutine);
        Debug.Log("se");
        audioSource.PlayOneShot(chain[num]);
        */
    }

    public void Bomb_effect()
    {
        audioSource.PlayOneShot(Bomb);
    }

    public void Finish_effect()
    {
        audioSource.PlayOneShot(finish);
    }

    public void Count_effect(bool swich)
    {
        if (swich)
        {

        }
        else
        {

        }
        audioSource.PlayOneShot(count);
    }

    public void Start_bgm()
    {
        if (_stop.SendStop())
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.PlayOneShot(bgm);
        }
    }

    private IEnumerator DelayMethod()
    {
        while(true)
        {
            yield return new WaitForSeconds(2.0f);
            Debug.Log("StartCoroutine");
            print("WaitAndPrint " + Time.time);
        }
    }
}