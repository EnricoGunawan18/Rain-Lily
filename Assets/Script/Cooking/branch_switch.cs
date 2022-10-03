using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class branch_switch : MonoBehaviour
{
    [SerializeField]
    private Button swittch;


    [SerializeField]
    private GameObject M_manu;
    [SerializeField]
    private GameObject S_manu;

	private Text text = null;
    private bool branch = true;

	void Start()
    {
		text = swittch.GetComponentInChildren<Text>();
		swittch.onClick.AddListener(Branch_manu);
		text.text = "Material";
		S_manu.SetActive(false);
	}

	private void Branch_manu()
	{
		if (branch == true)
		{
			M_manu.SetActive(false);
			S_manu.SetActive(true);
			text.text = "Seasoning";
			branch = false;
		}
		else
		{
			S_manu.SetActive(false);
			M_manu.SetActive(true);
			text.text = "Material";
			branch = true;
		}
	}
}
