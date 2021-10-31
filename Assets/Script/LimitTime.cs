using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitTime : MonoBehaviour
{
    [SerializeField]
    private Image sec;
    [SerializeField]
    private float limit = 30.0f;
    [SerializeField]
    private ResultScript _result;
    [SerializeField]
    private TimelineStop _stop;

    private float rotateValue = 0;
    private Transform _transform;
    private float turn;

    private void Awake()
    {
        _transform = sec.GetComponent<Transform>();
        turn = (int)(-360 / limit);
    }

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        if (_stop.StopMorment()||_result.SendStop())
        {
            return;
        }

        rotateValue += turn * Time.deltaTime;

        //Debug.Log(rotateValue + "“x‰ñ‚Á‚½");

        _transform.localEulerAngles = new Vector3(0f, 0f, rotateValue);
        _result.GetTime(rotateValue);
    }
}
