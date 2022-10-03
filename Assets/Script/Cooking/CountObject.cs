using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountObject: MonoBehaviour
{
	private List<GameObject> m_hitObjects = new List<GameObject>();

	void OnTriggerStay2D(Collider2D other)
	{
		if (!other.gameObject.CompareTag("Frame"))
		{
			foreach (var item in m_hitObjects)
			{
				if (item.gameObject == other.gameObject)
				{
					return;
				}
			}

			m_hitObjects.Add(other.gameObject);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		m_hitObjects.Remove(collision.gameObject);
	}

	public int Calculation()
	{
		int count = m_hitObjects.Count;

		m_hitObjects.Clear();
		return count;
	}
}
