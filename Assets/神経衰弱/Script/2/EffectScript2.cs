using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectScript2 : MonoBehaviour
{
    MemoryGameScript2 memorygamescript2;

    //answer effect
    [SerializeField]
    public GameObject[] Circle;
    public GameObject[] Cross;
    public GameObject[] StarEffect;

    Vector3 position1;
    Vector3 position2;
    Vector3 position3;
    Vector3 position4;
    Vector3 position5;

    private float effectTimer1;
    private float effectTimer2;
    private float effectTimer3;
    private float effectTimer4;
    private float effectTimer5;

    bool one = true;
    bool two = true;
    bool three = true;
    bool four = true;
    bool five = true;

    private static float time1;
    private static float time2;
    private static float time3;
    private static float time4;
    private static float time5;


    // Start is called before the first frame update
    void Start()
    {
        memorygamescript2 = GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>();

        for (int i = 0; i < 5; i++)
        {
            Circle[i].SetActive(false);
            Cross[i].SetActive(false);
            StarEffect[i].SetActive(false);
        }


        time1 = Time.time;
        time2 = Time.time;
        time3 = Time.time;
        time4 = Time.time;
        time5 = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        position1 = memorygamescript2.NumMat[0].transform.position;
        position2 = memorygamescript2.NumMat[1].transform.position;
        position3 = memorygamescript2.NumMat[2].transform.position;
        position4 = memorygamescript2.NumMat[3].transform.position;
        position5 = memorygamescript2.NumMat[4].transform.position;

        if (GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().clicked[0] == true && one == true)
        {
            time1 = Time.time;
            one = false;
        }
        if (GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().clicked[1] == true && two == true)
        {
            time2 = Time.time;
            two = false;
        }
        if (GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().clicked[2] == true && three == true)
        {
            time3 = Time.time;
            three = false;
        }
        if (GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().clicked[3] == true && four == true)
        {
            time4 = Time.time;
            four = false;
        }
        if (GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().clicked[4] == true && five == true)
        {
            time5 = Time.time;
            five = false;
        }

        if (GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().correctEffect[0] == true && GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().clicked[0] == true)
        {
            float timer1 = Time.time;
            effectTimer1 = timer1 - time1;

            Circle[0].SetActive(true);
            StarEffect[0].SetActive(true);
            Circle[0].transform.position = position1;
            StarEffect[0].transform.position = position1;

            if (effectTimer1 >= 2)
            {
                Circle[0].SetActive(false);
            }
        }
        if (GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().correctEffect[1] == true && GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().clicked[1] == true)
        {
            float timer2 = Time.time;
            effectTimer2 = timer2 - time2;

            Circle[1].SetActive(true);
            StarEffect[1].SetActive(true);

            Circle[1].transform.position = position2;
            StarEffect[1].transform.position = position2;

            if (effectTimer2 >= 2)
            {
                Circle[1].SetActive(false);

            }


        }
        if (GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().correctEffect[2] == true && GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().clicked[2] == true)
        {
            float timer3 = Time.time;
            effectTimer3 = timer3 - time3;

            Circle[2].SetActive(true);
            StarEffect[2].SetActive(true);

            Circle[2].transform.position = position3;
            StarEffect[2].transform.position = position3;

            if (effectTimer3 >= 2)
            {
                Circle[2].SetActive(false);

            }


        }
        if (GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().correctEffect[3] == true && GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().clicked[3] == true)
        {
            float timer4 = Time.time;
            effectTimer4 = timer4 - time4;

            Circle[3].SetActive(true);
            StarEffect[3].SetActive(true);

            Circle[3].transform.position = position4;
            StarEffect[3].transform.position = position4;

            if (effectTimer4 >= 2)
            {
                Circle[3].SetActive(false);

            }


        }
        if (GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().correctEffect[4] == true && GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().clicked[4] == true)
        {
            float timer5 = Time.time;
            effectTimer5 = timer5 - time5;

            Circle[4].SetActive(true);
            StarEffect[4].SetActive(true);

            Circle[4].transform.position = position5;
            StarEffect[4].transform.position = position5;

            if (effectTimer5 >= 2)
            {
                Circle[4].SetActive(false);

            }

        }


        //false
        if (GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().correctEffect[0] == false && GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().clicked[0] == true)
        {
            float timer1 = Time.time;
            effectTimer1 = timer1 - time1;

            Cross[0].SetActive(true);
            Cross[0].transform.position = position1;
        }
        if (GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().correctEffect[1] == false && GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().clicked[1] == true)
        {
            float timer2 = Time.time;
            effectTimer2 = timer2 - time2;

            Cross[1].SetActive(true);
            Cross[1].transform.position = position2;
        }
        if (GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().correctEffect[2] == false && GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().clicked[2] == true)
        {
            float timer3 = Time.time;
            effectTimer3 = timer3 - time3;

            Cross[2].SetActive(true);
            Cross[2].transform.position = position3;
        }
        if (GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().correctEffect[3] == false && GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().clicked[3] == true)
        {
            float timer4 = Time.time;
            effectTimer4 = timer4 - time4;

            Cross[3].SetActive(true);
            Cross[3].transform.position = position4;
        }
        if (GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().correctEffect[4] == false && GameObject.Find("MemoryGameScript2").GetComponent<MemoryGameScript2>().clicked[4] == true)
        {
            float timer5 = Time.time;
            effectTimer5 = timer5 - time5;

            Cross[4].SetActive(true);
            Cross[4].transform.position = position5;
        }
    }
}
