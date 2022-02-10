using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MemoryGameScript4 : MonoBehaviour
{
	[SerializeField]
	public Button[] NumMat;

	[SerializeField]
	public Text command_Text;

	[SerializeField]
	public AudioClip[] SEFile;

	[SerializeField]
	public Sprite apple;
	public Sprite beef;
	public Sprite butter;
	public Sprite carrot;
	public Sprite fish;
	public Sprite grape;
	public Sprite salt;
	public Sprite spinach;
	public Sprite sugar;
	public Sprite bread;
	public Sprite draw10;

	public int rand1;
	public int rand2;
	public int rand3;
	public int rand4;
	public int rand5;
	public int rand6;
	public int rand7;
	public int rand8;
	public int rand9;
	public int rand10;

	[SerializeField]
	AudioSource SE;

	public int randText;
	public int randText2;

	private string Text1;
	private string Text2;

	static private int nowStage = 5;

	public float StartTime;

	private Vector2 position1;
	private Vector2 position2;
	private Vector2 position3;
	private Vector2 position4;

	bool[] notShufflePause = { false, false, false };

	public float scoreTimerStart = 0;

	public bool canBePressed = false;

	//score
	public float scoreNow = 0;

	float scoreTimer = 0;

	//clicked button
	public bool[] clicked = { false, false, false, false, false, false, false, false, false, false };
	public bool[] correctEffect = { false, false, false, false, false, false, false, false, false, false };

	public bool shuffleColor = false;


	//answer
	int correctAns = 0;
	int tryAns = 3;

	//outlines
	[SerializeField]
	Outline outline1;
	[SerializeField]
	Outline outline2;
	[SerializeField]
	Outline outline3;
	[SerializeField]
	Outline outline4;
	[SerializeField]
	Outline outline5;
	[SerializeField]
	Outline outline6;
	[SerializeField]
	Outline outline7;
	[SerializeField]
	Outline outline8;
	[SerializeField]
	Outline outline9;
	[SerializeField]
	Outline outline10;

	[SerializeField]
	GameObject[] outline;

	List<int> TextRNG = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
	List<int> RNG = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

	[SerializeField]
	Sprite BoxBack;

	[SerializeField]
	Image[] Heart;

	public Sprite heartEmpty;

	// Start is called before the NumMat[0] frame update

	void Start()
	{
		//Command Text
		randText = Random.Range(1, 10);
		randText2 = Random.Range(1, 10);
		while (randText2 == randText)
		{
			randText2 = Random.Range(1, 10);
		}

		//time
		StartTime = Time.time;

		//shits
		if (randText == 0)
		{
			Text1 = "「リンゴ」";
		}
		else if (randText == 1)
		{
			Text1 = "「ビーフ」";
		}
		else if (randText == 2)
		{
			Text1 = "「バター」";
		}
		else if (randText == 3)
		{
			Text1 = "「人参」";
		}
		else if (randText == 4)
		{
			Text1 = "「魚」";
		}
		else if (randText == 5)
		{
			Text1 = "「グレープ」";
		}
		else if (randText == 6)
		{
			Text1 = "「塩」";
		}
		else if (randText == 7)
		{
			Text1 = "「ほうれん草」";
		}
		else if (randText == 8)
		{
			Text1 = "「砂糖」";
		}
		else if (randText == 9)
		{
			Text1 = "「パン」";
		}

		if (randText2 == 0)
		{
			Text2 = "「リンゴ」";
		}
		else if (randText2 == 1)
		{
			Text2 = "「ビーフ」";
		}
		else if (randText2 == 2)
		{
			Text2 = "「バター」";
		}
		else if (randText2 == 3)
		{
			Text2 = "「人参」";
		}
		else if (randText2 == 4)
		{
			Text2 = "「魚」";
		}
		else if (randText2 == 5)
		{
			Text2 = "「グレープ」";
		}
		else if (randText2 == 6)
		{
			Text2 = "「塩」";
		}
		else if (randText2 == 7)
		{
			Text2 = "「ほうれん草」";
		}
		else if (randText2 == 8)
		{
			Text2 = "「砂糖」";
		}
		else if (randText2 == 9)
		{
			Text2 = "「パン」";
		}

		command_Text.text = "「今日は" + Text1 + Text2 + "を買おう」";

		rand1 = RNG[Random.Range(0, RNG.Count)];
		RNG.Remove(rand1);
		rand2 = RNG[Random.Range(0, RNG.Count)];
		RNG.Remove(rand2);
		rand3 = RNG[Random.Range(0, RNG.Count)];
		RNG.Remove(rand3);
		rand4 = RNG[Random.Range(0, RNG.Count)];
		RNG.Remove(rand4);
		rand5 = RNG[Random.Range(0, RNG.Count)];
		RNG.Remove(rand5);
		rand6 = RNG[Random.Range(0, RNG.Count)];
		RNG.Remove(rand6);
		rand7 = RNG[Random.Range(0, RNG.Count)];
		RNG.Remove(rand7);
		rand8 = RNG[Random.Range(0, RNG.Count)];
		RNG.Remove(rand8);
		rand9 = RNG[Random.Range(0, RNG.Count)];
		RNG.Remove(rand9);
		rand10 = RNG[Random.Range(0, RNG.Count)];
		RNG.Remove(rand10);

		//button click    
		NumMat[0].onClick.AddListener(FirstClick);
		NumMat[1].onClick.AddListener(SecondClick);
		NumMat[2].onClick.AddListener(ThirdClick);
		NumMat[3].onClick.AddListener(FourthClick);
		NumMat[4].onClick.AddListener(FifthClick);
		NumMat[5].onClick.AddListener(SixthClick);
		NumMat[6].onClick.AddListener(SeventhClick);
		NumMat[7].onClick.AddListener(EighthClick);
		NumMat[8].onClick.AddListener(NinthClick);
		NumMat[9].onClick.AddListener(TenthClick);


		getImage();
	}

	[SerializeField]
	ColorBlock[] colorBlock;

	public void getImage()
	{
		//NumMat[0]
		if (rand1 == 0)
		{
			NumMat[0].GetComponent<Image>().sprite = apple;
		}
		else if (rand1 == 1)
		{
			NumMat[0].GetComponent<Image>().sprite = beef;
		}
		else if (rand1 == 2)
		{
			NumMat[0].GetComponent<Image>().sprite = butter;
		}
		else if (rand1 == 3)
		{
			NumMat[0].GetComponent<Image>().sprite = carrot;
		}
		else if (rand1 == 4)
		{
			NumMat[0].GetComponent<Image>().sprite = fish;
		}
		else if (rand1 == 5)
		{
			NumMat[0].GetComponent<Image>().sprite = grape;
		}
		else if (rand1 == 6)
		{
			NumMat[0].GetComponent<Image>().sprite = salt;
		}
		else if (rand1 == 7)
		{
			NumMat[0].GetComponent<Image>().sprite = spinach;
		}
		else if (rand1 == 8)
		{
			NumMat[0].GetComponent<Image>().sprite = sugar;
		}
		else if (rand1 == 9)
		{
			NumMat[0].GetComponent<Image>().sprite = bread;
		}

		if (rand1 == randText || rand1 == randText2)
		{
			outline1.effectColor = Color.red;
		}

		//NumMat[1]
		if (rand2 == 0)
		{
			NumMat[1].GetComponent<Image>().sprite = apple;
		}
		else if (rand2 == 1)
		{
			NumMat[1].GetComponent<Image>().sprite = beef;
		}
		else if (rand2 == 2)
		{
			NumMat[1].GetComponent<Image>().sprite = butter;
		}
		else if (rand2 == 3)
		{
			NumMat[1].GetComponent<Image>().sprite = carrot;
		}
		else if (rand2 == 4)
		{
			NumMat[1].GetComponent<Image>().sprite = fish;
		}
		else if (rand2 == 5)
		{
			NumMat[1].GetComponent<Image>().sprite = grape;
		}
		else if (rand2 == 6)
		{
			NumMat[1].GetComponent<Image>().sprite = salt;
		}
		else if (rand2 == 7)
		{
			NumMat[1].GetComponent<Image>().sprite = spinach;
		}
		else if (rand2 == 8)
		{
			NumMat[1].GetComponent<Image>().sprite = sugar;
		}
		else if (rand2 == 9)
		{
			NumMat[1].GetComponent<Image>().sprite = bread;
		}
		if (rand2 == randText || rand2 == randText2)
		{
			outline2.effectColor = Color.red;
		}


		//NumMat[2]
		if (rand3 == 0)
		{
			NumMat[2].GetComponent<Image>().sprite = apple;
		}
		else if (rand3 == 1)
		{
			NumMat[2].GetComponent<Image>().sprite = beef;
		}
		else if (rand3 == 2)
		{
			NumMat[2].GetComponent<Image>().sprite = butter;
		}
		else if (rand3 == 3)
		{
			NumMat[2].GetComponent<Image>().sprite = carrot;
		}
		else if (rand3 == 4)
		{
			NumMat[2].GetComponent<Image>().sprite = fish;
		}
		else if (rand3 == 5)
		{
			NumMat[2].GetComponent<Image>().sprite = grape;
		}
		else if (rand3 == 6)
		{
			NumMat[2].GetComponent<Image>().sprite = salt;
		}
		else if (rand3 == 7)
		{
			NumMat[2].GetComponent<Image>().sprite = spinach;
		}
		else if (rand3 == 8)
		{
			NumMat[2].GetComponent<Image>().sprite = sugar;
		}
		else if (rand3 == 9)
		{
			NumMat[2].GetComponent<Image>().sprite = bread;
		}
		if (rand3 == randText || rand3 == randText2)
		{
			outline3.effectColor = Color.red;
		}


		//NumMat[3]
		if (rand4 == 0)
		{
			NumMat[3].GetComponent<Image>().sprite = apple;
		}
		else if (rand4 == 1)
		{
			NumMat[3].GetComponent<Image>().sprite = beef;
		}
		else if (rand4 == 2)
		{
			NumMat[3].GetComponent<Image>().sprite = butter;
		}
		else if (rand4 == 3)
		{
			NumMat[3].GetComponent<Image>().sprite = carrot;
		}
		else if (rand4 == 4)
		{
			NumMat[3].GetComponent<Image>().sprite = fish;
		}
		else if (rand4 == 5)
		{
			NumMat[3].GetComponent<Image>().sprite = grape;
		}
		else if (rand4 == 6)
		{
			NumMat[3].GetComponent<Image>().sprite = salt;
		}
		else if (rand4 == 7)
		{
			NumMat[3].GetComponent<Image>().sprite = spinach;
		}
		else if (rand4 == 8)
		{
			NumMat[3].GetComponent<Image>().sprite = sugar;
		}
		else if (rand4 == 9)
		{
			NumMat[3].GetComponent<Image>().sprite = bread;
		}
		if (rand4 == randText || rand4 == randText2)
		{
			outline4.effectColor = Color.red;
		}


		//NumMat[4]
		if (rand5 == 0)
		{
			NumMat[4].GetComponent<Image>().sprite = apple;
		}
		else if (rand5 == 1)
		{
			NumMat[4].GetComponent<Image>().sprite = beef;
		}
		else if (rand5 == 2)
		{
			NumMat[4].GetComponent<Image>().sprite = butter;
		}
		else if (rand5 == 3)
		{
			NumMat[4].GetComponent<Image>().sprite = carrot;
		}
		else if (rand5 == 4)
		{
			NumMat[4].GetComponent<Image>().sprite = fish;
		}
		else if (rand5 == 5)
		{
			NumMat[4].GetComponent<Image>().sprite = grape;
		}
		else if (rand5 == 6)
		{
			NumMat[4].GetComponent<Image>().sprite = salt;
		}
		else if (rand5 == 7)
		{
			NumMat[4].GetComponent<Image>().sprite = spinach;
		}
		else if (rand5 == 8)
		{
			NumMat[4].GetComponent<Image>().sprite = sugar;
		}
		else if (rand5 == 9)
		{
			NumMat[4].GetComponent<Image>().sprite = bread;
		}
		if (rand5 == randText || rand5 == randText2)
		{
			outline5.effectColor = Color.red;
		}


		//NumMat[5]
		if (rand6 == 0)
		{
			NumMat[5].GetComponent<Image>().sprite = apple;
		}
		else if (rand6 == 1)
		{
			NumMat[5].GetComponent<Image>().sprite = beef;
		}
		else if (rand6 == 2)
		{
			NumMat[5].GetComponent<Image>().sprite = butter;
		}
		else if (rand6 == 3)
		{
			NumMat[5].GetComponent<Image>().sprite = carrot;
		}
		else if (rand6 == 4)
		{
			NumMat[5].GetComponent<Image>().sprite = fish;
		}
		else if (rand6 == 5)
		{
			NumMat[5].GetComponent<Image>().sprite = grape;
		}
		else if (rand6 == 6)
		{
			NumMat[5].GetComponent<Image>().sprite = salt;
		}
		else if (rand6 == 7)
		{
			NumMat[5].GetComponent<Image>().sprite = spinach;
		}
		else if (rand6 == 8)
		{
			NumMat[5].GetComponent<Image>().sprite = sugar;
		}
		else if (rand6 == 9)
		{
			NumMat[5].GetComponent<Image>().sprite = bread;
		}

		if (rand6 == randText || rand6 == randText2)
		{
			outline6.effectColor = Color.red;
		}


		//NumMat[6]
		if (rand7 == 0)
		{
			NumMat[6].GetComponent<Image>().sprite = apple;
		}
		else if (rand7 == 1)
		{
			NumMat[6].GetComponent<Image>().sprite = beef;
		}
		else if (rand7 == 2)
		{
			NumMat[6].GetComponent<Image>().sprite = butter;
		}
		else if (rand7 == 3)
		{
			NumMat[6].GetComponent<Image>().sprite = carrot;
		}
		else if (rand7 == 4)
		{
			NumMat[6].GetComponent<Image>().sprite = fish;
		}
		else if (rand7 == 5)
		{
			NumMat[6].GetComponent<Image>().sprite = grape;
		}
		else if (rand7 == 6)
		{
			NumMat[6].GetComponent<Image>().sprite = salt;
		}
		else if (rand7 == 7)
		{
			NumMat[6].GetComponent<Image>().sprite = spinach;
		}
		else if (rand7 == 8)
		{
			NumMat[6].GetComponent<Image>().sprite = sugar;
		}
		else if (rand7 == 9)
		{
			NumMat[6].GetComponent<Image>().sprite = bread;
		}
		if (rand7 == randText || rand7 == randText2)
		{
			outline7.effectColor = Color.red;
		}


		//NumMat[7]
		if (rand8 == 0)
		{
			NumMat[7].GetComponent<Image>().sprite = apple;
		}
		else if (rand8 == 1)
		{
			NumMat[7].GetComponent<Image>().sprite = beef;
		}
		else if (rand8 == 2)
		{
			NumMat[7].GetComponent<Image>().sprite = butter;
		}
		else if (rand8 == 3)
		{
			NumMat[7].GetComponent<Image>().sprite = carrot;
		}
		else if (rand8 == 4)
		{
			NumMat[7].GetComponent<Image>().sprite = fish;
		}
		else if (rand8 == 5)
		{
			NumMat[7].GetComponent<Image>().sprite = grape;
		}
		else if (rand8 == 6)
		{
			NumMat[7].GetComponent<Image>().sprite = salt;
		}
		else if (rand8 == 7)
		{
			NumMat[7].GetComponent<Image>().sprite = spinach;
		}
		else if (rand8 == 8)
		{
			NumMat[7].GetComponent<Image>().sprite = sugar;
		}
		else if (rand8 == 9)
		{
			NumMat[7].GetComponent<Image>().sprite = bread;
		}
		if (rand8 == randText || rand8 == randText2)
		{
			outline8.effectColor = Color.red;
		}


		//NumMat[8]
		if (rand9 == 0)
		{
			NumMat[8].GetComponent<Image>().sprite = apple;
		}
		else if (rand9 == 1)
		{
			NumMat[8].GetComponent<Image>().sprite = beef;
		}
		else if (rand9 == 2)
		{
			NumMat[8].GetComponent<Image>().sprite = butter;
		}
		else if (rand9 == 3)
		{
			NumMat[8].GetComponent<Image>().sprite = carrot;
		}
		else if (rand9 == 4)
		{
			NumMat[8].GetComponent<Image>().sprite = fish;
		}
		else if (rand9 == 5)
		{
			NumMat[8].GetComponent<Image>().sprite = grape;
		}
		else if (rand9 == 6)
		{
			NumMat[8].GetComponent<Image>().sprite = salt;
		}
		else if (rand9 == 7)
		{
			NumMat[8].GetComponent<Image>().sprite = spinach;
		}
		else if (rand9 == 8)
		{
			NumMat[8].GetComponent<Image>().sprite = sugar;
		}
		else if (rand9 == 9)
		{
			NumMat[8].GetComponent<Image>().sprite = bread;
		}
		if (rand9 == randText || rand9 == randText2)
		{
			outline9.effectColor = Color.red;
		}


		//NumMat[9]
		if (rand10 == 0)
		{
			NumMat[9].GetComponent<Image>().sprite = apple;
		}
		else if (rand10 == 1)
		{
			NumMat[9].GetComponent<Image>().sprite = beef;
		}
		else if (rand10 == 2)
		{
			NumMat[9].GetComponent<Image>().sprite = butter;
		}
		else if (rand10 == 3)
		{
			NumMat[9].GetComponent<Image>().sprite = carrot;
		}
		else if (rand10 == 4)
		{
			NumMat[9].GetComponent<Image>().sprite = fish;
		}
		else if (rand10 == 5)
		{
			NumMat[9].GetComponent<Image>().sprite = grape;
		}
		else if (rand10 == 6)
		{
			NumMat[9].GetComponent<Image>().sprite = salt;
		}
		else if (rand10 == 7)
		{
			NumMat[9].GetComponent<Image>().sprite = spinach;
		}
		else if (rand10 == 8)
		{
			NumMat[9].GetComponent<Image>().sprite = sugar;
		}
		else if (rand10 == 9)
		{
			NumMat[9].GetComponent<Image>().sprite = bread;
		}
		if (rand10 == randText || rand10 == randText2)
		{
			outline10.effectColor = Color.red;
		}


	}

	//shuffling
	int count = 0;
	int count2 = 0;
	int rando_;
	int rando_2;
	int rando_3;
	int rando_4;

	float timer = 0;
	bool timerContinue = true;

	void Update()
	{
		//before shuffle timer
		if (timerContinue)
		{
			timer = Time.time - StartTime;
		}

		if (timer >= 1 && timer <= 2)
		{
			SE.clip = SEFile[0];
			SE.Play();
		}
		else if (timer >= 2.5 && timer <= 3)
		{
			SE.Stop();
			SE.clip = SEFile[1];
			SE.loop = true;
			SE.Play();
		}

		if (timer >= 2.5)
		{
			for (int i = 0; i <= 9; i++)
			{
				if (clicked[i] == false/* && shuffleColor == false*/)
				{

					outline1.effectColor = Color.black;
					outline2.effectColor = Color.black;
					outline3.effectColor = Color.black;
					outline4.effectColor = Color.black;
					outline5.effectColor = Color.black;
					outline6.effectColor = Color.black;
					outline7.effectColor = Color.black;
					outline8.effectColor = Color.black;
					outline9.effectColor = Color.black;
					outline10.effectColor = Color.black;

					outline1.effectDistance = new Vector2(4, 4);
					outline2.effectDistance = new Vector2(4, 4);
					outline3.effectDistance = new Vector2(4, 4);
					outline4.effectDistance = new Vector2(4, 4);
					outline5.effectDistance = new Vector2(4, 4);
					outline6.effectDistance = new Vector2(4, 4);
					outline7.effectDistance = new Vector2(4, 4);
					outline8.effectDistance = new Vector2(4, 4);
					outline9.effectDistance = new Vector2(4, 4);
					outline10.effectDistance = new Vector2(4, 4);

					colorBlock[i] = NumMat[i].colors;
					colorBlock[i].normalColor = Color.white;
					NumMat[i].GetComponent<Image>().sprite = BoxBack;
					NumMat[i].colors = colorBlock[i];
				}
			}
			if (timer >= 3 && count2 < 5)
			{
				shuffle();

				if (notShufflePause[0] && count == 1)
				{
					count = 0;
					count2++;
				}

			}

			if (count2 == 5)
			{
				SE.loop = false;
				SE.Stop();
				scoreTimerStart = Time.time;
				count2++;
			}

			if (count2 > 5)
			{
				scoreTimer = Time.time - scoreTimerStart;
				//Debug.Log(scoreTimer);

				//click
				canBePressed = true;

				//text
				command_Text.text = "「買うものが「二つ」あったよね」";
			}

			if (nowStage == 4 || nowStage == 5)
			{
				if (correctAns == 2)
				{
					correctAns = 0;
					scoreNow += 1000;

					for (int i = 0; i < 10; i++)
					{
						NumMat[i].enabled = false;
					}

					if (scoreTimer <= 3)
					{
						scoreNow += 1000;
					}
					else if (scoreTimer > 3)
					{
						for (int i = 0; i < 9; i++)
						{
							if (scoreTimer > 3 + i && scoreTimer < 3 + i + 1)
							{
								scoreNow += 1000 - (100 * i);
							}
						}
					}
					scoreNow -= 100 * (3 - tryAns);
					PlayerPrefs.SetFloat("Score4", scoreNow);
					Debug.Log(scoreNow);
					StartCoroutine(waitForNextStage());
				}
			}
			if (tryAns == 0)
			{
				PlayerPrefs.SetFloat("Score4", 0);
				Debug.Log(scoreNow);

				for (int i = 0; i < 10; i++)
				{
					NumMat[i].enabled = false;
				}

				tryAns = 3;
				StartCoroutine(waitForNextStage());
			}

		}

		IEnumerator waitForNextStage()
		{
			yield return new WaitForSeconds(3f);
			SceneManager.LoadScene("Stage5");
		}


		void shuffle()
		{
			if (count == 0)
			{
				List<int> Randnum = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

				rando_ = Randnum[Random.Range(0, Randnum.Count)];
				Randnum.Remove(rando_);
				rando_2 = Randnum[Random.Range(0, Randnum.Count)];
				Randnum.Remove(rando_2);
				rando_3 = Randnum[Random.Range(0, Randnum.Count)];
				Randnum.Remove(rando_3);
				rando_4 = Randnum[Random.Range(0, Randnum.Count)];
				Randnum.Remove(rando_4);


				position2 = outline[rando_].transform.position;
				position1 = outline[rando_2].transform.position;
				position4 = outline[rando_3].transform.position;
				position3 = outline[rando_4].transform.position;
				count++;
			}

			outline[rando_].transform.position = Vector2.MoveTowards(outline[rando_].transform.position, position1, 200f * Time.deltaTime * 2f);
			outline[rando_2].transform.position = Vector2.MoveTowards(outline[rando_2].transform.position, position2, 200f * Time.deltaTime * 2f);
			outline[rando_3].transform.position = Vector2.MoveTowards(outline[rando_3].transform.position, position3, 200f * Time.deltaTime * 2f);
			outline[rando_4].transform.position = Vector2.MoveTowards(outline[rando_4].transform.position, position4, 200f * Time.deltaTime * 2f);


			if (outline[rando_].transform.position.x == position1.x && outline[rando_].transform.position.y == position1.y && outline[rando_3].transform.position.x == position3.x && outline[rando_3].transform
						.position.y == position3.y)
			{
				notShufflePause[count - 1] = true;
				shuffleColor = false;
			}
			else
			{
				notShufflePause[count - 1] = false;
				shuffleColor = true;
			}

			if (shuffleColor == true)
			{
				colorBlock[rando_] = NumMat[rando_].colors;
				colorBlock[rando_].normalColor = Color.red;
				NumMat[rando_].GetComponent<Image>().sprite = draw10;
				NumMat[rando_].colors = colorBlock[rando_];

				colorBlock[rando_2] = NumMat[rando_2].colors;
				colorBlock[rando_2].normalColor = Color.red;
				NumMat[rando_2].GetComponent<Image>().sprite = draw10;
				NumMat[rando_2].colors = colorBlock[rando_2];

				colorBlock[rando_3] = NumMat[rando_3].colors;
				colorBlock[rando_3].normalColor = Color.blue;
				NumMat[rando_3].GetComponent<Image>().sprite = draw10;
				NumMat[rando_3].colors = colorBlock[rando_3];

				colorBlock[rando_4] = NumMat[rando_4].colors;
				colorBlock[rando_4].normalColor = Color.blue;
				NumMat[rando_4].GetComponent<Image>().sprite = draw10;
				NumMat[rando_4].colors = colorBlock[rando_4];

			}

		}
	}

	public void FirstClick()
	{
		if (canBePressed == true)
		{
			NumMat[0].transform.Rotate(new Vector3(0, 180, 0));
			getImage();
			clicked[0] = true;
			colorBlock[0] = NumMat[0].colors;
			colorBlock[0].normalColor = Color.white;
			NumMat[0].colors = colorBlock[0];
			NumMat[0].enabled = false;

			if (rand1 == randText || rand1 == randText2)
			{
				SE.Stop();
				SE.clip = SEFile[2];
				SE.Play();

				correctEffect[0] = true;
				correctAns++;
			}
			else
			{
				SE.Stop();
				SE.clip = SEFile[3];
				SE.Play();

				tryAns--;
				Heart[tryAns].sprite = heartEmpty;
				NumMat[0].transform.Rotate(new Vector3(0, 180, 0));

			}
		}
	}

	public void SecondClick()
	{
		if (canBePressed == true)
		{

			NumMat[1].transform.Rotate(new Vector3(0, 180, 0));
			getImage();
			clicked[1] = true;
			colorBlock[1] = NumMat[1].colors;
			colorBlock[1].normalColor = Color.white;
			NumMat[1].colors = colorBlock[1];
			NumMat[1].enabled = false;

			if (rand2 == randText || rand2 == randText2)
			{
				SE.Stop();
				SE.clip = SEFile[2];
				SE.Play();

				correctEffect[1] = true;
				correctAns++;
			}
			else
			{
				SE.Stop();
				SE.clip = SEFile[3];
				SE.Play();

				tryAns--;
				Heart[tryAns].sprite = heartEmpty;
				NumMat[1].transform.Rotate(new Vector3(0, 180, 0));

			}
		}
	}

	public void ThirdClick()
	{
		if (canBePressed == true)
		{

			NumMat[2].transform.Rotate(new Vector3(0, 180, 0));
			getImage();
			clicked[2] = true;
			colorBlock[2] = NumMat[2].colors;
			colorBlock[2].normalColor = Color.white;
			NumMat[2].colors = colorBlock[2];
			NumMat[2].enabled = false;

			if (rand3 == randText || rand3 == randText2)
			{
				SE.Stop();
				SE.clip = SEFile[2];
				SE.Play();

				correctEffect[2] = true;
				correctAns++;
			}
			else
			{
				SE.Stop();
				SE.clip = SEFile[3];
				SE.Play();

				tryAns--;
				Heart[tryAns].sprite = heartEmpty;
				NumMat[2].transform.Rotate(new Vector3(0, 180, 0));

			}
		}
	}

	public void FourthClick()
	{
		if (canBePressed == true)
		{

			NumMat[3].transform.Rotate(new Vector3(0, 180, 0));
			getImage();
			clicked[3] = true;
			colorBlock[3] = NumMat[3].colors;
			colorBlock[3].normalColor = Color.white;
			NumMat[3].colors = colorBlock[3];
			NumMat[3].enabled = false;

			if (rand4 == randText || rand4 == randText2)
			{
				SE.Stop();
				SE.clip = SEFile[2];
				SE.Play();

				correctEffect[3] = true;
				correctAns++;
			}
			else
			{
				SE.Stop();
				SE.clip = SEFile[3];
				SE.Play();

				tryAns--;
				Heart[tryAns].sprite = heartEmpty;
				NumMat[3].transform.Rotate(new Vector3(0, 180, 0));

			}
		}
	}

	public void FifthClick()
	{
		if (canBePressed == true)
		{

			NumMat[4].transform.Rotate(new Vector3(0, 180, 0));
			getImage();
			clicked[4] = true;
			colorBlock[4] = NumMat[4].colors;
			colorBlock[4].normalColor = Color.white;
			NumMat[4].colors = colorBlock[4];
			NumMat[4].enabled = false;

			if (rand5 == randText || rand5 == randText2)
			{
				SE.Stop();
				SE.clip = SEFile[2];
				SE.Play();

				correctEffect[4] = true;
				correctAns++;
			}
			else
			{
				SE.Stop();
				SE.clip = SEFile[3];
				SE.Play();

				tryAns--;
				Heart[tryAns].sprite = heartEmpty;
				NumMat[4].transform.Rotate(new Vector3(0, 180, 0));

			}
		}
	}

	public void SixthClick()
	{
		if (canBePressed == true)
		{

			NumMat[5].transform.Rotate(new Vector3(0, 180, 0));
			getImage();
			clicked[5] = true;
			colorBlock[5] = NumMat[5].colors;
			colorBlock[5].normalColor = Color.white;
			NumMat[5].colors = colorBlock[5];
			NumMat[5].enabled = false;

			if (rand6 == randText || rand6 == randText2)
			{
				SE.Stop();
				SE.clip = SEFile[2];
				SE.Play();

				correctEffect[5] = true;
				correctAns++;
			}
			else
			{
				SE.Stop();
				SE.clip = SEFile[3];
				SE.Play();

				tryAns--;
				Heart[tryAns].sprite = heartEmpty;
				NumMat[5].transform.Rotate(new Vector3(0, 180, 0));

			}
		}
	}

	public void SeventhClick()
	{
		if (canBePressed == true)
		{

			NumMat[6].transform.Rotate(new Vector3(0, 180, 0));
			getImage();
			clicked[6] = true;
			colorBlock[6] = NumMat[6].colors;
			colorBlock[6].normalColor = Color.white;
			NumMat[6].colors = colorBlock[6];
			NumMat[6].enabled = false;

			if (rand7 == randText || rand7 == randText2)
			{
				SE.Stop();
				SE.clip = SEFile[2];
				SE.Play();

				correctEffect[6] = true;
				correctAns++;
			}
			else
			{
				SE.Stop();
				SE.clip = SEFile[3];
				SE.Play();

				tryAns--;
				Heart[tryAns].sprite = heartEmpty;
				NumMat[6].transform.Rotate(new Vector3(0, 180, 0));

			}
		}
	}

	public void EighthClick()
	{
		if (canBePressed == true)
		{

			NumMat[7].transform.Rotate(new Vector3(0, 180, 0));
			getImage();
			clicked[7] = true;
			colorBlock[7] = NumMat[7].colors;
			colorBlock[7].normalColor = Color.white;
			NumMat[7].colors = colorBlock[7];
			NumMat[7].enabled = false;

			if (rand8 == randText || rand8 == randText2)
			{
				SE.Stop();
				SE.clip = SEFile[2];
				SE.Play();

				correctEffect[7] = true;
				correctAns++;
			}
			else
			{
				SE.Stop();
				SE.clip = SEFile[3];
				SE.Play();

				tryAns--;
				Heart[tryAns].sprite = heartEmpty;
				NumMat[7].transform.Rotate(new Vector3(0, 180, 0));

			}
		}
	}

	public void NinthClick()
	{
		if (canBePressed == true)
		{

			NumMat[8].transform.Rotate(new Vector3(0, 180, 0));
			getImage();
			clicked[8] = true;
			colorBlock[8] = NumMat[8].colors;
			colorBlock[8].normalColor = Color.white;
			NumMat[8].colors = colorBlock[8];
			NumMat[8].enabled = false;

			if (rand9 == randText || rand9 == randText2)
			{
				SE.Stop();
				SE.clip = SEFile[2];
				SE.Play();

				correctEffect[8] = true;
				correctAns++;
			}
			else
			{
				SE.Stop();
				SE.clip = SEFile[3];
				SE.Play();

				tryAns--;
				Heart[tryAns].sprite = heartEmpty;
				NumMat[8].transform.Rotate(new Vector3(0, 180, 0));

			}
		}
	}

	public void TenthClick()
	{
		if (canBePressed == true)
		{

			NumMat[9].transform.Rotate(new Vector3(0, 180, 0));
			getImage();
			clicked[9] = true;
			colorBlock[9] = NumMat[9].colors;
			colorBlock[9].normalColor = Color.white;
			NumMat[9].colors = colorBlock[9];
			NumMat[9].enabled = false;

			if (rand10 == randText || rand10 == randText2)
			{
				SE.Stop();
				SE.clip = SEFile[2];
				SE.Play();

				correctEffect[9] = true;
				correctAns++;
			}
			else
			{
				SE.Stop();
				SE.clip = SEFile[3];
				SE.Play();

				tryAns--;
				Heart[tryAns].sprite = heartEmpty;
				NumMat[9].transform.Rotate(new Vector3(0, 180, 0));

			}
		}
	}
}