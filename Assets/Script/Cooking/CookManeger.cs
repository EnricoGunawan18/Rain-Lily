using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookManeger : MonoBehaviour
{
    [SerializeField]
    private SaR_cuisine cuisine;
    [SerializeField]
    private ResultCook result;

    void Awake()
    {
        result.ResultAwake();
    }

    void Start()
    {
        cuisine.CuisineStart();
    }

    void Update()
    {
        result.ResultUpdate();
        cuisine.CuisineUpdate();
    }
}
