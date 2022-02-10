using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectScript4 : MonoBehaviour
{
    MemoryGameScript4 memorygamescript4;

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
    Vector3 position6;
    Vector3 position7;
    Vector3 position8;
    Vector3 position9;
    Vector3 position10;

    private float effectTimer1;
    private float effectTimer2;
    private float effectTimer3;
    private float effectTimer4;
    private float effectTimer5;
    private float effectTimer6;
    private float effectTimer7;
    private float effectTimer8;
    private float effectTimer9;
    private float effectTimer10;

    bool one = true;
    bool two = true;
    bool three = true;
    bool four = true;
    bool five = true;
    bool six = true;
    bool seven = true;
    bool eight = true;
    bool nine = true;
    bool ten = true;

    private static float time1;
    private static float time2;
    private static float time3;
    private static float time4;
    private static float time5;
    private static float time6;
    private static float time7;
    private static float time8;
    private static float time9;
    private static float time10;



    // Start is called before the first frame update
    void Start()
    {
        memorygamescript4 = GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>();

        for (int i = 0; i < 10; i++)
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
        time6 = Time.time;
        time7 = Time.time;
        time8 = Time.time;
        time9 = Time.time;
        time10 = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        position1 = memorygamescript4.NumMat[0].transform.position;
        position2 = memorygamescript4.NumMat[1].transform.position;
        position3 = memorygamescript4.NumMat[2].transform.position;
        position4 = memorygamescript4.NumMat[3].transform.position;
        position5 = memorygamescript4.NumMat[4].transform.position;
        position6 = memorygamescript4.NumMat[5].transform.position;
        position7 = memorygamescript4.NumMat[6].transform.position;
        position8 = memorygamescript4.NumMat[7].transform.position;
        position9 = memorygamescript4.NumMat[8].transform.position;
        position10 = memorygamescript4.NumMat[9].transform.position;

        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[0] == true && one == true)
        {
            time1 = Time.time;
            one = false;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[1] == true && two == true)
        {
            time2 = Time.time;
            two = false;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[2] == true && three == true)
        {
            time3 = Time.time;
            three = false;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[3] == true && four == true)
        {
            time4 = Time.time;
            four = false;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[4] == true && five == true)
        {
            time5 = Time.time;
            five = false;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[5] == true && six == true)
        {
            time6 = Time.time;
            six = false;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[6] == true && seven == true)
        {
            time7 = Time.time;
            seven = false;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[7] == true && eight == true)
        {
            time8 = Time.time;
            eight = false;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[8] == true && nine == true)
        {
            time9 = Time.time;
            nine = false;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[9] == true && ten == true)
        {
            time10 = Time.time;
            ten = false;
        }


        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[0] == true && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[0] == true)
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
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[1] == true && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[1] == true)
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
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[2] == true && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[2] == true)
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
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[3] == true && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[3] == true)
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
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[4] == true && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[4] == true)
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
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[5] == true && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[5] == true)
        {
            float timer6 = Time.time;
            effectTimer6 = timer6 - time6;

            Circle[5].SetActive(true);
            StarEffect[5].SetActive(true);

            Circle[5].transform.position = position6;
            StarEffect[5].transform.position = position6;

            if (effectTimer6 >= 2)
            {
                Circle[5].SetActive(false);

            }


        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[6] == true && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[6] == true)
        {
            float timer7 = Time.time;
            effectTimer7 = timer7 - time7;

            Circle[6].SetActive(true);
            StarEffect[6].SetActive(true);

            Circle[6].transform.position = position7;
            StarEffect[6].transform.position = position7;

            if (effectTimer7 >= 2)
            {
                Circle[6].SetActive(false);

            }

        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[7] == true && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[7] == true)
        {
            float timer8 = Time.time;
            effectTimer8 = timer8 - time8;

            Circle[7].SetActive(true);
            StarEffect[7].SetActive(true);

            Circle[7].transform.position = position8;
            StarEffect[7].transform.position = position8;

            if (effectTimer8 >= 2)
            {
                Circle[7].SetActive(false);

            }

        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[8] == true && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[8] == true)
        {
            float timer9 = Time.time;
            effectTimer9 = timer9 - time9;

            Circle[8].SetActive(true);
            StarEffect[8].SetActive(true);

            Circle[8].transform.position = position9;
            StarEffect[8].transform.position = position9;

            if (effectTimer9 >= 2)
            {
                Circle[8].SetActive(false);

            }

        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[9] == true && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[9] == true)
        {
            float timer10 = Time.time;
            effectTimer10 = timer10 - time10;

            Circle[9].SetActive(true);
            StarEffect[9].SetActive(true);

            Circle[9].transform.position = position10;
            StarEffect[9].transform.position = position10;

            if (effectTimer10 >= 2)
            {
                Circle[9].SetActive(false);

            }

        }



        //false
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[0] == false && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[0] == true)
        {
            float timer1 = Time.time;
            effectTimer1 = timer1 - time1;

            Cross[0].SetActive(true);
            Cross[0].transform.position = position1;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[1] == false && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[1] == true)
        {
            float timer2 = Time.time;
            effectTimer2 = timer2 - time2;

            Cross[1].SetActive(true);
            Cross[1].transform.position = position2;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[2] == false && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[2] == true)
        {
            float timer3 = Time.time;
            effectTimer3 = timer3 - time3;

            Cross[2].SetActive(true);
            Cross[2].transform.position = position3;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[3] == false && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[3] == true)
        {
            float timer4 = Time.time;
            effectTimer4 = timer4 - time4;

            Cross[3].SetActive(true);
            Cross[3].transform.position = position4;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[4] == false && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[4] == true)
        {
            float timer5 = Time.time;
            effectTimer5 = timer5 - time5;

            Cross[4].SetActive(true);
            Cross[4].transform.position = position5;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[5] == false && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[5] == true)
        {
            float timer6 = Time.time;
            effectTimer6 = timer6 - time6;

            Cross[5].SetActive(true);
            Cross[5].transform.position = position6;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[6] == false && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[6] == true)
        {
            float timer7 = Time.time;
            effectTimer7 = timer7 - time7;

            Cross[6].SetActive(true);
            Cross[6].transform.position = position7;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[7] == false && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[7] == true)
        {
            float timer8 = Time.time;
            effectTimer8 = timer8 - time8;

            Cross[7].SetActive(true);
            Cross[7].transform.position = position8;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[8] == false && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[8] == true)
        {
            float timer9 = Time.time;
            effectTimer9 = timer9 - time9;

            Cross[8].SetActive(true);
            Cross[8].transform.position = position9;
        }
        if (GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().correctEffect[9] == false && GameObject.Find("MemoryGameScript4").GetComponent<MemoryGameScript4>().clicked[9] == true)
        {
            float timer10 = Time.time;
            effectTimer10 = timer10 - time10;

            Cross[9].SetActive(true);
            Cross[9].transform.position = position10;
        }
    }
}
