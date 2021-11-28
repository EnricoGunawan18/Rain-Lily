using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class material_manu : MonoBehaviour
{
	[Header("‹ïÞ")]
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

	[Header("‹ïÞ‚Ìƒ{ƒ^ƒ“")]
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
	private Vector3 _position = new Vector3();

	private void Start()
	{
		lettuce_bm.onClick.AddListener(() => on_Canvas(lettuce));
		Ronion_bm.onClick.AddListener(() => on_Canvas(Red_onion));
		salmon_bm.onClick.AddListener(() => on_Canvas(salmon));
		bacon_bm.onClick.AddListener(() => on_Canvas(bacon));
		tomato_bm.onClick.AddListener(() => on_Canvas(tomato));
		egg_bm.onClick.AddListener(() => on_Canvas(egg));
		carrot_bm.onClick.AddListener(() => on_Canvas(carrot));
		onion_bm.onClick.AddListener(() => on_Canvas(onion));
		potato_bm.onClick.AddListener(() => on_Canvas(potato));
		beef_bm.onClick.AddListener(() => on_Canvas(beef));
		Sayaendo_bm.onClick.AddListener(() => on_Canvas(Sayaendo));
		meat_bm.onClick.AddListener(() => on_Canvas(meat));
		mushroom_bm.onClick.AddListener(() => on_Canvas(mushroom));
		broccoli_bm.onClick.AddListener(() => on_Canvas(broccoli));
		waffle_bm.onClick.AddListener(() => on_Canvas(waffle));
		strawberry_bm.onClick.AddListener(() => on_Canvas(strawberry));
		raspberry_bm.onClick.AddListener(() => on_Canvas(raspberry));
		blueberry_bm.onClick.AddListener(() => on_Canvas(blueberry));
		ice_bm.onClick.AddListener(() => on_Canvas(ice));
		_position = canvasTran.position;
		_position.z -= 30.0f;
	}

	private void on_Canvas(GameObject equipment)
	{
		if (knob == null)
		{
			knob = Instantiate(equipment, _position, Quaternion.identity);
		}
		else
		{
			Destroy(knob);
		}
	}

}
