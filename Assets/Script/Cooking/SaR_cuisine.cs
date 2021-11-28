using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaR_cuisine : MonoBehaviour
{
    [SerializeField]
    private GameObject[] dishs;
    [SerializeField]
    private Button comp_bn;
    [SerializeField]
    private Image finished_image;
    [SerializeField]
    private Text text;
    [SerializeField]
    private Transform canvasTran;

    private GameObject _object;
    private Vector3 _position = new Vector3();
    private int Rnum;
    private finished_nikujaga nikujaga;
    List<int> remaining =new List<int>();
    private bool frag=true;
    void Start()
    {
        comp_bn.onClick.AddListener(Receiving_result);
        _position = canvasTran.position;
        for (int i = 0; i < dishs.Length; i++)
		{
            remaining.Add(i);
            Debug.Log(remaining[i]);
		}
    }

    void Update()
    {
        send_cuisine();

        //Debug.Log(Rnum);
    }

    private void send_cuisine()
    {
        if (frag)
        {
            Rnum = remaining[Random.Range(0,remaining.Count)];
            Instantiate(dishs[Rnum], _position, Quaternion.identity);
            nikujaga = dishs[Rnum].GetComponent<finished_nikujaga>();
            nikujaga.Send_num(finished_image);
            remaining.RemoveAt(Rnum);
            frag = false;
        }
    }

    private void Receiving_result()
    {
        if (!frag)
        {
            _object = GameObject.FindGameObjectWithTag("dish");

            Destroy(_object);
            frag = true;
        }
        else
        {
            text.text = "èIóπ";
        }
    }
}
