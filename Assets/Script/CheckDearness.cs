using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDearness : MonoBehaviour
{
    public enum Characters
    {
        klein,
        lied
    }

    [SerializeField,Range(0,100)]
    private int intimacy;
    [SerializeField]
    private Sprite[] numbers;
    [SerializeField]
    private Image digit1;       //一桁目
    [SerializeField]
    private Image digit2;       //二桁目
    [SerializeField]
    private Image digit3;       //三桁目

    public Characters character = Characters.klein; //参照するキャラクターを選択

    private void Start() {
        int overIntimacy = 0;

        if (character == 0)
        {
            //クラインの親密度をintimacyに代入する 
            Debug.Log("クライン");
        }
        else
        {
            //リートの親密度をintimacyに代入する
            Debug.Log("リート");
        }

        if (intimacy<10)            //0～9が入ったらここ
        {
            digit1.sprite = numbers[intimacy];
            digit2.gameObject.SetActive(false);
            digit3.gameObject.SetActive(false);
        }
        else if(intimacy<100)       //10～99が入ったらここ
        {
            var digit2Num = intimacy / 10;
            var digit1Num = intimacy - (digit2Num * 10);

            digit1.sprite = numbers[digit1Num];
            digit2.sprite = numbers[digit2Num];
            digit3.gameObject.SetActive(false);
        }
        else if(intimacy == 100)    //100が入ったらここ
        {
            var digit3Num = intimacy / 100;
            var digit2Num = (intimacy - digit3Num * 100) / 10;
            var digit1Num = (intimacy - digit3Num * 100) - (digit2Num * 10);

            digit1.sprite = numbers[digit1Num];
            digit2.sprite = numbers[digit2Num];
            digit3.sprite = numbers[digit3Num];
        }
        else                        //0～100以外の数字が入ったらここに行く
        {
            digit1.sprite = numbers[overIntimacy];
            digit2.sprite = numbers[overIntimacy];
            digit3.sprite = numbers[overIntimacy];
        }
    }
}
