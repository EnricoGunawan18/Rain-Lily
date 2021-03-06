using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class seasoning_manu : MonoBehaviour
{
	[Header("調味料")]
	[SerializeField]
	private GameObject parsley;
	[SerializeField]
	private GameObject crouton;
	[SerializeField]
	private GameObject cheese;
	[SerializeField]
	private GameObject dressing;
	[SerializeField]
	private GameObject sauce;
	[SerializeField]
	private GameObject oil;
	[SerializeField]
	private GameObject pepper;
	[SerializeField]
	private GameObject suger;
	[SerializeField]
	private GameObject very_sauce;
	[SerializeField]
	private GameObject rosemary;
	[SerializeField]
	private GameObject mint;
	[SerializeField]
	private GameObject lemon;

	[Space(5)]

	[Header("調味料のボタン")]
	[SerializeField]
	private Button parsley_bm;
	[SerializeField]
	private Button crouton_bm;
	[SerializeField]
	private Button cheese_bm;
	[SerializeField]
	private Button dressing_bm;
	[SerializeField]
	private Button sauce_bm;
	[SerializeField]
	private Button oil_bm;
	[SerializeField]
	private Button pepper_bm;
	[SerializeField]
	private Button suger_bm;
	[SerializeField]
	private Button veryS_bm;
	[SerializeField]
	private Button rosemary_bm;
	[SerializeField]
	private Button mint_bm;
	[SerializeField]
	private Button lemon_bm;

	private GameObject knob;
	[SerializeField]
	private Transform canvasTran;
	private Vector3 _position = new Vector3();

	private void Start()
	{
		oil_bm.onClick.AddListener(() => on_Canvas(oil));
		sauce_bm.onClick.AddListener(() => on_Canvas(sauce));
		pepper_bm.onClick.AddListener(() => on_Canvas(pepper));
		lemon_bm.onClick.AddListener(() => on_Canvas(lemon));
		rosemary_bm.onClick.AddListener(() => on_Canvas(rosemary));
		crouton_bm.onClick.AddListener(() => on_Canvas(crouton));
		dressing_bm.onClick.AddListener(() => on_Canvas(dressing));
		cheese_bm.onClick.AddListener(() => on_Canvas(cheese));
		parsley_bm.onClick.AddListener(() => on_Canvas(parsley));
		suger_bm.onClick.AddListener(() => on_Canvas(suger));
		veryS_bm.onClick.AddListener(() => on_Canvas(very_sauce));
		mint_bm.onClick.AddListener(() => on_Canvas(mint));
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
