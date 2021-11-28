using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class character_select : MonoBehaviour
{
    [SerializeField]
    private Button reit_bm;         //リートの選択ボタン
    [SerializeField]
    private Button cryin_bm;        //クラインの選択ボタン
    [SerializeField]
    private GameObject Panel_r;     //リートのスチル
    [SerializeField]
    private GameObject Panel_c;     //クラインのスチル
    [SerializeField]
    private GameObject cover;

    void Start()
    {
        reit_bm.onClick.AddListener(() => Change_character(Panel_c, Panel_r));
        cryin_bm.onClick.AddListener(() => Change_character(Panel_r, Panel_c));
        //Change_character(Panel_r, Panel_c);
    }

    private void Change_character(GameObject panel_a,GameObject panel_b)
	{
        Debug.Log("出現");
        cover.SetActive(true);
        panel_a.GetComponent<RectTransform>()
            .DOMoveX(940f, 5.0f)
            .SetEase(Ease.OutExpo)
            .OnComplete(() => Debug.Log("引っ込んだ"));      //引っ込める

        panel_b.GetComponent<RectTransform>()
            .DOMoveX(-763f, 5.0f)
            .SetEase(Ease.OutExpo)
            .OnComplete(() => Debug.Log("出た"));             //押し出す
        cover.SetActive(false);
	}
}
