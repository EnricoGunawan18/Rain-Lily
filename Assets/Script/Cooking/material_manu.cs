using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class material_manu : MonoBehaviour
{
	[Header("ãÔçﬁ")]
	[SerializeField]
	private GameObject egg;
	[SerializeField]
	private GameObject potato;
	[SerializeField]
	private GameObject broccoli;
	[SerializeField]
	private GameObject carrot;
	[SerializeField]
	private GameObject tomato;
	[SerializeField]
	private GameObject lettuce;
	[SerializeField]
	private GameObject mushroom;
	[SerializeField]
	private GameObject bacon;
	[SerializeField]
	private GameObject meat;
	[SerializeField]
	private GameObject strawberry;
	[SerializeField]
	private GameObject onion;
	[SerializeField]
	private GameObject salmon;
	[SerializeField]
	private GameObject beef;
	[SerializeField]
	private GameObject raspberry;
	[SerializeField]
	private GameObject waffle;
	[SerializeField]
	private GameObject Sayaendo;
	[SerializeField]
	private GameObject Red_onion;
	[SerializeField]
	private GameObject ice;
	[SerializeField]
	private GameObject blueberry;

	[Space(5)]

	[Header("ãÔçﬁÇÃÉ{É^Éì")]
	[SerializeField]
	private Button egg_bm;
	[SerializeField]
	private Button potato_bm;
	[SerializeField]
	private Button broccoli_bm;
	[SerializeField]
	private Button carrot_bm;
	[SerializeField]
	private Button tomato_bm;
	[SerializeField]
	private Button lettuce_bm;
	[SerializeField]
	private Button mushroom_bm;
	[SerializeField]
	private Button bacon_bm;
	[SerializeField]
	private Button meat_bm;
	[SerializeField]
	private Button strawberry_bm;
	[SerializeField]
	private Button onion_bm;
	[SerializeField]
	private Button salmon_bm;
	[SerializeField]
	private Button beef_bm;
	[SerializeField]
	private Button raspberry_bm;
	[SerializeField]
	private Button waffle_bm;
	[SerializeField]
	private Button Sayaendo_bm;
	[SerializeField]
	private Button Ronion_bm;
	[SerializeField]
	private Button ice_bm;
	[SerializeField]
	private Button blueberry_bm;

	private GameObject knob;
	[SerializeField]
	private Transform canvasTran;

	private void Start()
	{

	}

	private void on_Canvas(GameObject equipment)
	{
		if (knob == null)
		{
			knob = Instantiate(equipment, canvasTran.position, Quaternion.identity);
		}
		else
		{
			Destroy(knob);
		}
	}

}
