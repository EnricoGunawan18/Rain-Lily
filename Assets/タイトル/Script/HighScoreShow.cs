using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreShow : MonoBehaviour
{
    [SerializeField]
    Text CleanHS;
	[SerializeField]
	Text CookHS;
    [SerializeField]
    Text MemoryHS;

    public float highScore;
	public int highScoreCook;
	public int highScoreClean;

    // Start is called before the first frame update
    void OnEnable()
    {
		highScore = PlayerPrefs.GetFloat("ShopHighScore");
		highScoreClean = PlayerPrefs.GetInt("CleanHighScore");
		highScoreCook = PlayerPrefs.GetInt("CookHighScore");


		float scoreGet = PlayerPrefs.GetFloat("ScoreAll");

		if (highScore <= scoreGet)
		{
			highScore = scoreGet;
			PlayerPrefs.SetFloat("ScoreAll", highScore);
		}

		MemoryHS.text = "High Score : " + highScore.ToString();




		int scoreCookGet = PlayerPrefs.GetInt("ScoreCook");

		if (highScoreCook <= scoreCookGet)
		{
			highScoreCook = scoreCookGet;
			PlayerPrefs.SetInt("ScoreCook", highScoreCook);
		}

		CookHS.text = "High Score : " + highScoreCook.ToString();




		int scoreCleanGet = PlayerPrefs.GetInt("ScoreClean");

		Debug.Log(scoreCleanGet);

		if (highScoreClean <= scoreCleanGet)
		{
			highScoreClean = scoreCleanGet;
			PlayerPrefs.SetInt("ScoreClean", highScoreClean);
		}

		CleanHS.text = "High Score : " + highScoreClean.ToString();

	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
