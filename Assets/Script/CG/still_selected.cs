using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class still_selected : MonoBehaviour
{
    [SerializeField]
    private Button still_bn;
    [SerializeField]
    private GameObject still;

    [SerializeField]
    private Transform CanvasTran;


    void Start()
    {
        still_bn.onClick.AddListener(() => Pop_still());
    }


    private void Pop_still()
	{
        Instantiate(still, CanvasTran);
	}
}
