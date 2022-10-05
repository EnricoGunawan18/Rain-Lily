using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManeger : MonoBehaviour
{
    [SerializeField]
    private Tochmaneger touch;
    [SerializeField]
    private ResultScript result;
    [SerializeField]
    private MakeBook book;
    [SerializeField]
    private click_right_effect effect;
    [SerializeField]
    private AddScore score;
    private void Awake()
    {
        result.ResultAwake();
    }

    void Start()
    {
        touch.TouchStart();
        book.MakeStart();
        effect.EffectStart();
    }

    void Update()
    {
        book.MakeUpdate();
        score.ScoreUpdate();
        result.ResultUpdate();
        effect.EffectUpdate();
    }
}
