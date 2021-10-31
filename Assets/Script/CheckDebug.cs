using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDebug : MonoBehaviour
{
    [SerializeField]
    private Button Pause;

	private void Awake()
	{
		Pause.onClick.AddListener(Practice);
	}

	private void Practice()
	{
		Debug.Log("pause");
	}
}
