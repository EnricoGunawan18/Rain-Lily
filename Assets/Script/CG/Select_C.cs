using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Select_C : MonoBehaviour
{
    [SerializeField]
    private Button r_bm;         //リートの選択ボタン
    [SerializeField]
    private Button c_bm;        //クラインの選択ボタン
    [SerializeField]
    private Animator reat_anim;
    [SerializeField]
    private Animator crin_anim;

    private bool Check_r = true;
    private bool Check_c = false;
    private bool Check = true;

    void Start()
    {
        reat_anim = reat_anim.GetComponent<Animator>();
        crin_anim = crin_anim.GetComponent<Animator>();
        r_bm.onClick.AddListener(() => Change_r());
        c_bm.onClick.AddListener(() => Change_c());
    }

    private void Update()
    {
        if (Check)
        {
            if (Check_r)
            {
                r_bm.enabled = false;
            }
            else
            {
                r_bm.enabled = true;
            }

            if (Check_c)
            {
                c_bm.enabled = false;
            }
            else
            {
                c_bm.enabled = true;
            }

            Check = false;
        }
    }

    private void Change_c()
    {
        Debug.Log("クライン 出現");
        reat_anim.SetBool("reat_up", false);
        crin_anim.SetBool("crin_down", false);
        reat_anim.SetBool("reat_down", true);
        crin_anim.SetBool("crin_up", true);
        Check_c = true;
        Check_r = false;
        Check = true;
    }

    private void Change_r()
    {
        Debug.Log("リート　出現");
        reat_anim.SetBool("reat_down", false);
        crin_anim.SetBool("crin_up", false);
        reat_anim.SetBool("reat_up", true);
        crin_anim.SetBool("crin_down", true);
        Check_r = true;
        Check_c = false;
        Check = true;
    }
}
