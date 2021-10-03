using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
	[SerializeField]
	public Button NewGame;
	public Button LoadGame;
	public Button Game;
	public Button MemoryGame;
	public Text MemoryHS;

	public GameObject TitleScreen;
	public GameObject GameScreen;

	public static float highScore = 0;

	// Start is called before the first frame update
	void Start()
	{
		//reset//////////////////////////////////////////////////////////////////
		//PlayerPrefs.SetFloat("ScoreAll", 0);
		//PlayerPrefs.SetFloat("Score1", 0);
		//PlayerPrefs.SetFloat("Score2", 0);
		//PlayerPrefs.SetFloat("Score3", 0);
		//PlayerPrefs.SetFloat("Score4", 0);
		//PlayerPrefs.SetFloat("Score5", 0);
		//PlayerPrefs.SetInt("LogNow", 1);

		float scoreGet = PlayerPrefs.GetFloat("ScoreAll");

		if (highScore <= scoreGet)
		{
			highScore = scoreGet;
		}

		MemoryHS.text = "High Score : " + highScore;

		NewGame.onClick.AddListener(NewGameStart);
		LoadGame.onClick.AddListener(LoadGameStart);
		Game.onClick.AddListener(GameClicked);
		MemoryGame.onClick.AddListener(MemoryGameClicked);
		TitleScreen.SetActive(true);
		GameScreen.SetActive(false);
	}

	public void NewGameStart()
	{
		PlayerPrefs.SetInt("LogNow", 1);
		PlayerPrefs.SetFloat("DialogueSpeed", 25f);
		PlayerPrefs.SetInt("MiniGame1", 0);
		PlayerPrefs.SetInt("MiniGame2", 0);
		PlayerPrefs.SetInt("MiniGame3", 0);
		PlayerPrefs.SetInt("ResetPos", 0);
		SceneManager.LoadScene("Novel");
	}

	public void LoadGameStart()
	{
		SceneManager.LoadScene("Novel");
	}

	public void GameClicked()
	{
		TitleScreen.SetActive(false);
		GameScreen.SetActive(true);
	}

	public void MemoryGameClicked()
	{
		SceneManager.LoadScene("Stage1");
	}
}

