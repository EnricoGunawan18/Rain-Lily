using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PazzleCookMAnager
{
	public static bool gameStop;
	public static float timeValue = 0;

	public bool GetGameStop()
	{
		return gameStop;
	}

	public void SetGameStop(bool tmp)
	{
		gameStop = tmp;
	}

	public float TimeValue
	{
		get
		{
			return timeValue;
		}
		set
		{
			timeValue = value;
		}
	}
}
