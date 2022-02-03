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
    private int Bscore = 1000;


    [SerializeField]
    private Text viewScore;

    private ScoreHome home = new ScoreHome();
    private int score = 0;

    private void Update()
    {
        viewScore.text = "score:" + home.GetPazzleScore;
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
        score = (int)(score + add + fixed_mag);
        home.GetPazzleScore = score;
    }

    public void BombAdd( )
    {
        AddSlider(Bscore);
        score += Bscore;
        home.GetPazzleScore = score;
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
