using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    [SerializeField]
    private Slider scoreSlider;
    [SerializeField]
    private Slider Slider2;
    [SerializeField]
    private float add = 300f;
    [SerializeField]
    private float mag = 50f;
    [SerializeField]
    private float Bscore = 100;


    [SerializeField]
    private Text viewScore;

    private float score = 0;
    private float maxScore;

    private void Update()
    {
        //Debug.Log(score);
        viewScore.text = "score:" + score;
    }

    public void ScoreAdd(int count)
    {
        int _fixed =  count - 3;
        var fixed_mag = 0f;

        for (int i = 0; i < _fixed; i++)
        {
            fixed_mag += mag;
        }

        AddSlider(add + fixed_mag);
        score =(int)(score + add + fixed_mag);
        maxScore = score;
    }

    public void BombAdd(int count)
    {
        AddSlider(Bscore * count);
        score += Bscore * count;
        maxScore = score;
    }

    public int GetScore()
    {
        return (int)maxScore;
    }

    private void AddSlider(float _Score)
    {
        if (scoreSlider.value <= 10000)
        {
            scoreSlider.value += _Score;
        }
        else
        {
            Slider2.value += _Score;
        }
    }
        
}
