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
    private TimelineStop _stop;

    private float rotateValue = 0;
    private Transform _transform;
    private PazzleCookMAnager game = new PazzleCookMAnager();
    private float turn;

    private void Awake()
    {
        game.TimeValue = 0;
        _transform = sec.GetComponent<Transform>();
        turn = (int)(-360 / limit);
    }

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        if (_stop.StopMorment()||game.GetGameStop())
        {
            return;
        }

        rotateValue += turn * Time.deltaTime;

        _transform.localEulerAngles = new Vector3(0f, 0f, rotateValue);
        game.TimeValue = rotateValue;
    }
}
