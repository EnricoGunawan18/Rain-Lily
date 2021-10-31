using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineStop : MonoBehaviour
{
    private bool sw = false;

    public void DisplayStop()
    {
        if (sw)
        {
            sw = false;
        }
        else
        {
            sw = true;
        }
    }

    public bool StopMorment()
    {
        if (sw)
        {
            return true;
        }

        return false;
    }
}
