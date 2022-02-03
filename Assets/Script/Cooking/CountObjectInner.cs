using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountObjectInner : MonoBehaviour
{
	private List<GameObject> i_hitObjects = new List<GameObject>();

	void OnTriggerStay2D(Collider2D other)
	{
		if (!other.gameObject.CompareTag("Frame"))
		{
			foreach (var item in i_hitObjects)
			{
				if (item.gameObject == other.gameObject)
				{
					return;
				}
			}

			Debug.Log(other.gameObject);
			i_hitObjects.Add(other.gameObject);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		i_hitObjects.Remove(collision.gameObject);
	}

	public int Calculation()
	{
		int count = i_hitObjects.Count;
		Debug.Log(this);
		Debug.Log(count);

		i_hitObjects.Clear();
		return count;
	}
}
