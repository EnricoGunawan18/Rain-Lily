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
	private GameObject[] material;
	[Header("ãÔçﬁÇÃÉ{É^Éì")]
	[SerializeField]
	private Button[] material_bn;
	[SerializeField]
	private SoundManager effect;

	[Space(5)]

	[SerializeField]
	private Transform canvasTran;

	private List<GameObject> tmp = new List<GameObject>();
	private Vector3 _position = new Vector3();

	private void Start()
	{
		for (int i = 0; i < material_bn.Length; i++)
		{
			Button tmp = material_bn[i];

			tmp.onClick.AddListener(() => On_Canvas(tmp));
		}
		_position = canvasTran.position;
		_position.z -= 30.0f;
	}

	private void On_Canvas( Button btn)
	{
		effect.PlayEffect();

		for (int i = 0; i < material.Length; i++)
		{
			if (btn.tag==material[i].tag)
			{
				tmp.Add(Instantiate(material[i], _position, Quaternion.identity));
				break;
			}
		}
	}

	private void OnDisable()
	{
		foreach (var item in tmp)
		{
			Destroy(item);
		}

		tmp.Clear();
	}
}
