using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Threading.Tasks;

public class ResultScript : MonoBehaviour
{
	[SerializeField]
	private Button retry;
	[SerializeField]
	private Button end;
	[SerializeField]
	private GameObject resultObject;
	[SerializeField]
	private Text text;
	[SerializeField]
	private Text gold;
	[SerializeField]
	private AddScore _add;
	[SerializeField]
	private Image star;
	[SerializeField]
	private click_right_effect _effect;

	[Space(10)]

	[SerializeField]
	private GameObject finish;

	private bool stop_W;
	private Image[] stock = new Image[5];
	private Transform _patent;
	private Vector3 _position;
	int gameMoneyGet;

	void Awake()
	{
		gameMoneyGet = PlayerPrefs.GetInt("Money");
		Time.timeScale = 1f;
		_position = new Vector3(0f, -3.2f, 0f);
		_patent = resultObject.transform;
		stop_W = false;
		resultObject.SetActive(false);
		retry.onClick.AddListener(Retry);
		end.onClick.AddListener(Quit);
	}

	async void ResultSW(bool sw)
	{
		if (sw)
		{
			_effect.Finish_effect();
			finish.transform.DOMoveX(0, 2.0f)
				.SetEase(Ease.OutQuad);
			await Task.Delay(3000);
			_effect.Start_bgm();
			Time.timeScale = 0f;
		}
		resultObject.SetActive(sw);
	}

	public void GetTime(float value)
	{
		if (value <= -360f)
		{
			stop_W = true;
			ResultSW(true);
			if (_add.GetScore() < 1000)
			{
				Star_create(0, 1);
				gold.text = "金貨を100枚獲得しました";
				gameMoneyGet += 100;
				Debug.Log("1");
			}
			else if (_add.GetScore() < 1500)
			{
				Star_create(75, 2);
				gold.text = "金貨を300枚獲得しました";
				gameMoneyGet += 300;
				Debug.Log("2");
			}
			else if (_add.GetScore() < 2000)
			{
				Star_create(125, 3);
				gold.text = "金貨を500枚獲得しました";
				gameMoneyGet += 500;
				Debug.Log("3");
			}
			else if (_add.GetScore() < 2500)
			{
				Star_create(75, 4);
				gold.text = "金貨を700枚獲得しました";
				gameMoneyGet += 700;
				Debug.Log("4");
			}
			else
			{
				Star_create(125, 5);
				gold.text = "金貨を1000枚獲得しました";
				gameMoneyGet += 1000;
				Debug.Log("5");
			}
			text.text = "Score:" + _add.GetScore();
		}
		else
		{
			ResultSW(false);
		}
	}
	private void Star_create(float numX, int num)
	{
		switch (num)
		{
			case 1:
				stock[0] = Instantiate(star, _position, Quaternion.identity);
				Debug.Log("star1");
				break;
			case 2:
				_position.x += numX;
				stock[0] = Instantiate(star, _position, Quaternion.identity);
				_position.x -= numX * 2;
				stock[1] = Instantiate(star, _position, Quaternion.identity);
				Debug.Log("star2");
				break;
			case 3:
				stock[0] = Instantiate(star, _position, Quaternion.identity);
				_position.x += numX;
				stock[1] = Instantiate(star, _position, Quaternion.identity);
				_position.x -= numX * 2;
				stock[2] = Instantiate(star, _position, Quaternion.identity);
				Debug.Log("star3");
				break;
			case 4:
				_position.x += numX;
				stock[0] = Instantiate(star, _position, Quaternion.identity);
				_position.x += numX;
				stock[1] = Instantiate(star, _position, Quaternion.identity);
				_position.x -= numX * 2;
				stock[2] = Instantiate(star, _position, Quaternion.identity);
				_position.x -= numX;
				stock[3] = Instantiate(star, _position, Quaternion.identity);
				Debug.Log("star4");
				break;
			case 5:
				stock[0] = Instantiate(star, _position, Quaternion.identity);
				_position.x += numX;
				stock[1] = Instantiate(star, _position, Quaternion.identity);
				_position.x += numX;
				stock[2] = Instantiate(star, _position, Quaternion.identity);
				_position.x -= numX * 3;
				stock[3] = Instantiate(star, _position, Quaternion.identity);
				_position.x -= numX;
				stock[4] = Instantiate(star, _position, Quaternion.identity);
				Debug.Log("star5");
				break;
			default:
				break;
		}
		for (int i = 0; i < num; i++)
		{
			stock[i].transform.SetParent(_patent, false);
		}
	}

	private void Retry()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Scene_pazle");
	}

	private void Quit()
	{
		Time.timeScale = 1;
		int score = _add.GetScore();
		int miniGame = PlayerPrefs.GetInt("MiniGame");

		if (miniGame == 4)
		{
			int cleanTimes = PlayerPrefs.GetInt("CleanNumber");
			cleanTimes += 1;
			PlayerPrefs.SetInt("CleanNumber", cleanTimes);

			PlayerPrefs.SetInt("Money", gameMoneyGet);
			PlayerPrefs.SetInt("NovelMenu", 13);
			SceneManager.LoadScene("Novel");
		}
		else if (miniGame == 1)
		{
			PlayerPrefs.SetInt("NovelMenu", 0);
			SceneManager.LoadScene("Novel");
		}
		else
		{
			SceneManager.LoadScene("TitleScreen");
		}
	}

	public bool SendStop()
	{
		return stop_W;
	}
}
