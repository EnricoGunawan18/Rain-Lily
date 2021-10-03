using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadDialogue : MonoBehaviour
{
	[SerializeField]
	TextAsset prologue;
	[SerializeField]
	TextAsset BGName;
	[SerializeField]
	private Text textLabel;
	[SerializeField]
	public Text nameLabel;
	[SerializeField]
	public Text backGroundLabel;
	[SerializeField]
	public Text logLabel;
	[SerializeField]
	public Scrollbar logScroll;
	[SerializeField]
	private Button nextDialogue;
	[SerializeField]
	public Sprite[] background;
	[SerializeField]
	public Image backgroundNow;
	[SerializeField]
	public Sprite[] charaImage;
	[SerializeField]
	public Image charaImageNow;
	[SerializeField]
	public AudioClip[] BGMFile;
	[SerializeField]
	public AudioClip[] SEFile;
	[SerializeField]
	public GameObject TwoChoices;
	[SerializeField]
	public Text FirstTwo;
	[SerializeField]
	public Text SecondTwo;
	[SerializeField]
	public Button FirstTwoButton;
	[SerializeField]
	public Button SecondTwoButton;
	[SerializeField]
	public Button QuickSaveButton;

	private DialogueManager dialogueManager;
	private AutoScroll autoScroll;
	private Hide hide;
	public BackGroundLogs bgl;
	public Dialogue d;
	Animator FadeAnim;
	private AudioSource BGM;
	private AudioSource SE;

	string[] backData;
	string[] data;
	string[] dataRow;
	string[] row;
	public int whichLineNow = 0;
	public bool waitForFadeAnim = false;
	public bool finishTemp1 = false;
	public bool finishTemp2 = false;
	public bool finishTemp3 = false;
	public int resetPos = 0;
	public List<BackGroundLogs> backgrounds;
	public List<Dialogue> dialogues;

	private void Start()
	{
		backgrounds = new List<BackGroundLogs>();
		dialogues = new List<Dialogue>();
		resetPos = PlayerPrefs.GetInt("ResetPos");

		autoScroll = GameObject.Find("AutoScroll").GetComponent<AutoScroll>();
		hide = GameObject.Find("HideAnimator").GetComponent<Hide>();
		dialogueManager = GetComponent<DialogueManager>();
		FadeAnim = GameObject.Find("Fader").GetComponent<Animator>();
		BGM = GameObject.Find("BGM").GetComponent<AudioSource>();
		SE = GameObject.Find("SE").GetComponent<AudioSource>();
		nextDialogue.onClick.AddListener(TaskOnClick);
		FirstTwoButton.onClick.AddListener(FirstButtonClicked);
		SecondTwoButton.onClick.AddListener(SecondButtonClicked);
		QuickSaveButton.onClick.AddListener(QuickSaveClicked);

		backData = BGName.text.Split(new char[] { '$' });

		for (int i = 1; i < backData.Length - 1; i++)
		{
			dataRow = backData[i].Split(new char[] { ',' });
			bgl = new BackGroundLogs();
			int.TryParse(dataRow[0], out bgl.id);
			bgl.bg = dataRow[1];

			backgrounds.Add(bgl);
		}

		data = prologue.text.Split(new char[] { '$' });

		First();
	}

	private void Update()
	{
		Continue();
	}


	public void First()
	{
		int logNumber = PlayerPrefs.GetInt("LogNow");
		int miniGame1 = PlayerPrefs.GetInt("MiniGame1");
		int miniGame2 = PlayerPrefs.GetInt("MiniGame2");
		int miniGame3 = PlayerPrefs.GetInt("MiniGame3");
		int resetFrom = PlayerPrefs.GetInt("ResetPos");

		Debug.Log(logNumber);

		if (miniGame1 == 1)
		{
			resetPos = 5;
			PlayerPrefs.SetInt("MiniGame1", 0);
			for (int i = 202; i < 211; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[6] != "" || row[7] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.expression = row[3];
					d.background = row[4];
					d.BGM = row[5];
					d.SE = row[6];
					d.effect = row[7];

					dialogues.Add(d);
				}
			}
		}
		else if (miniGame2 == 1)
		{
			resetPos = 6;
			PlayerPrefs.SetInt("MiniGame2", 0);
			for (int i = 212; i < 224; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[6] != "" || row[7] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.expression = row[3];
					d.background = row[4];
					d.BGM = row[5];
					d.SE = row[6];
					d.effect = row[7];

					dialogues.Add(d);
				}
			}
		}
		else if (miniGame3 == 1)
		{
			resetPos = 7;
			PlayerPrefs.SetInt("MiniGame3", 0);
			for (int i = 226; i < 250; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[6] != "" || row[7] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.expression = row[3];
					d.background = row[4];
					d.BGM = row[5];
					d.SE = row[6];
					d.effect = row[7];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 1)
		{
			if (logNumber == 68)
			{
				row = data[68].Split(new char[] { ',' });
				d = new Dialogue();
				int.TryParse(row[0], out d.id);
				d.character = row[1];
				d.dialogue = row[2];
				d.expression = row[3];
				d.background = row[4];
				d.BGM = row[5];
				d.SE = row[6];
				d.effect = row[7];

				dialogues.Add(d);

				for (int i = 73; i < 155; i++)
				{
					row = data[i].Split(new char[] { ',' });

					if (row[2] != "" || row[6] != "" || row[7] != "")
					{
						d = new Dialogue();
						int.TryParse(row[0], out d.id);
						d.character = row[1];
						d.dialogue = row[2];
						d.expression = row[3];
						d.background = row[4];
						d.BGM = row[5];
						d.SE = row[6];
						d.effect = row[7];

						dialogues.Add(d);
					}
				}
			}
			else
			{
				for (int i = logNumber + 4; i < 155; i++)
				{
					row = data[i].Split(new char[] { ',' });

					if (row[2] != "" || row[6] != "" || row[7] != "")
					{
						d = new Dialogue();
						int.TryParse(row[0], out d.id);
						d.character = row[1];
						d.dialogue = row[2];
						d.expression = row[3];
						d.background = row[4];
						d.BGM = row[5];
						d.SE = row[6];
						d.effect = row[7];

						dialogues.Add(d);
					}
				}

			}

		}
		else if (resetFrom == 2)
		{
			for (int i = 73; i < 155; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[6] != "" || row[7] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.expression = row[3];
					d.background = row[4];
					d.BGM = row[5];
					d.SE = row[6];
					d.effect = row[7];

					dialogues.Add(d);
				}
			}
		}

		else if (resetFrom == 3)
		{
			if (logNumber <= 167 && logNumber >= 157)
			{
				for (int i = logNumber; i < 167; i++)
				{
					row = data[i].Split(new char[] { ',' });

					if (row[2] != "" || row[6] != "" || row[7] != "")
					{
						d = new Dialogue();
						int.TryParse(row[0], out d.id);
						d.character = row[1];
						d.dialogue = row[2];
						d.expression = row[3];
						d.background = row[4];
						d.BGM = row[5];
						d.SE = row[6];
						d.effect = row[7];

						dialogues.Add(d);
					}
				}
				for (int i = 177; i < 183; i++)
				{
					row = data[i].Split(new char[] { ',' });

					if (row[2] != "" || row[6] != "" || row[7] != "")
					{
						d = new Dialogue();
						int.TryParse(row[0], out d.id);
						d.character = row[1];
						d.dialogue = row[2];
						d.expression = row[3];
						d.background = row[4];
						d.BGM = row[5];
						d.SE = row[6];
						d.effect = row[7];

						dialogues.Add(d);
					}
				}
				for (int i = 185; i < 195; i++)
				{
					row = data[i].Split(new char[] { ',' });

					if (row[2] != "" || row[6] != "" || row[7] != "")
					{
						d = new Dialogue();
						int.TryParse(row[0], out d.id);
						d.character = row[1];
						d.dialogue = row[2];
						d.expression = row[3];
						d.background = row[4];
						d.BGM = row[5];
						d.SE = row[6];
						d.effect = row[7];

						dialogues.Add(d);
					}
				}
				for (int i = 198; i < 202; i++)
				{
					row = data[i].Split(new char[] { ',' });

					if (row[2] != "" || row[6] != "" || row[7] != "")
					{
						d = new Dialogue();
						int.TryParse(row[0], out d.id);
						d.character = row[1];
						d.dialogue = row[2];
						d.expression = row[3];
						d.background = row[4];
						d.BGM = row[5];
						d.SE = row[6];
						d.effect = row[7];

						dialogues.Add(d);
					}
				}

			}

			else if (logNumber <= 183 && logNumber >= 177)
			{
				for (int i = logNumber; i < 183; i++)
				{
					row = data[i].Split(new char[] { ',' });

					if (row[2] != "" || row[6] != "" || row[7] != "")
					{
						d = new Dialogue();
						int.TryParse(row[0], out d.id);
						d.character = row[1];
						d.dialogue = row[2];
						d.expression = row[3];
						d.background = row[4];
						d.BGM = row[5];
						d.SE = row[6];
						d.effect = row[7];

						dialogues.Add(d);
					}
				}
				for (int i = 185; i < 195; i++)
				{
					row = data[i].Split(new char[] { ',' });

					if (row[2] != "" || row[6] != "" || row[7] != "")
					{
						d = new Dialogue();
						int.TryParse(row[0], out d.id);
						d.character = row[1];
						d.dialogue = row[2];
						d.expression = row[3];
						d.background = row[4];
						d.BGM = row[5];
						d.SE = row[6];
						d.effect = row[7];

						dialogues.Add(d);
					}
				}
				for (int i = 198; i < 202; i++)
				{
					row = data[i].Split(new char[] { ',' });

					if (row[2] != "" || row[6] != "" || row[7] != "")
					{
						d = new Dialogue();
						int.TryParse(row[0], out d.id);
						d.character = row[1];
						d.dialogue = row[2];
						d.expression = row[3];
						d.background = row[4];
						d.BGM = row[5];
						d.SE = row[6];
						d.effect = row[7];

						dialogues.Add(d);
					}
				}


			}
			else if (logNumber <= 195 && logNumber >= 185)
			{
				for (int i = logNumber; i < 195; i++)
				{
					row = data[i].Split(new char[] { ',' });

					if (row[2] != "" || row[6] != "" || row[7] != "")
					{
						d = new Dialogue();
						int.TryParse(row[0], out d.id);
						d.character = row[1];
						d.dialogue = row[2];
						d.expression = row[3];
						d.background = row[4];
						d.BGM = row[5];
						d.SE = row[6];
						d.effect = row[7];

						dialogues.Add(d);
					}
				}
				for (int i = 198; i < 202; i++)
				{
					row = data[i].Split(new char[] { ',' });

					if (row[2] != "" || row[6] != "" || row[7] != "")
					{
						d = new Dialogue();
						int.TryParse(row[0], out d.id);
						d.character = row[1];
						d.dialogue = row[2];
						d.expression = row[3];
						d.background = row[4];
						d.BGM = row[5];
						d.SE = row[6];
						d.effect = row[7];

						dialogues.Add(d);
					}
				}


			}
			else if (logNumber <= 202 && logNumber >= 198)
			{
				for (int i = logNumber; i < 202; i++)
				{
					row = data[i].Split(new char[] { ',' });

					if (row[2] != "" || row[6] != "" || row[7] != "")
					{
						d = new Dialogue();
						int.TryParse(row[0], out d.id);
						d.character = row[1];
						d.dialogue = row[2];
						d.expression = row[3];
						d.background = row[4];
						d.BGM = row[5];
						d.SE = row[6];
						d.effect = row[7];

						dialogues.Add(d);
					}
				}


			}
		}


		else
		{
			for (int i = logNumber; i < 66; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[6] != "" || row[7] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.expression = row[3];
					d.background = row[4];
					d.BGM = row[5];
					d.SE = row[6];
					d.effect = row[7];

					dialogues.Add(d);
				}
			}
		}

		ShowDialogue();
	}


	public void Continue()
	{
		if (finishTemp1 == true)
		{
			Time.timeScale = 0;

			TwoChoices.SetActive(true);

			string[] tempRow = data[67].Split(new char[] { ',' });
			FirstTwo.text = tempRow[2];

			string[] tempRow2 = data[70].Split(new char[] { ',' });
			SecondTwo.text = tempRow2[2];
		}

		if (finishTemp2 == true)
		{
			Time.timeScale = 0;

			TwoChoices.SetActive(true);

			string[] tempRow = data[156].Split(new char[] { ',' });
			FirstTwo.text = tempRow[2];

			string[] tempRow2 = data[168].Split(new char[] { ',' });
			SecondTwo.text = tempRow2[2];

		}
		if (finishTemp3 == true)
		{
			Time.timeScale = 0;

			TwoChoices.SetActive(true);

			string[] tempRow = data[251].Split(new char[] { ',' });
			FirstTwo.text = tempRow[2];

			string[] tempRow2 = data[260].Split(new char[] { ',' });
			SecondTwo.text = tempRow2[2];

		}

	}

	public void ShowDialogue()
	{
		StartCoroutine(StepDialogue());
	}

	private IEnumerator StepDialogue()
	{
		RectTransform rt = logLabel.GetComponent<RectTransform>();

		foreach (Dialogue d in dialogues)
		{
			dialogueManager.next = false;
			nameLabel.text = d.character;
			whichLineNow++;

			logLabel.text = logLabel.text + d.character + "\n" + d.dialogue + "\n\n";

			//background
			if (d.background == "back-001")
			{
				backGroundLabel.text = backgrounds[0].bg;
				backgroundNow.color = new Color(0, 0, 0, 255);
				backgroundNow.sprite = background[2];
			}
			else if (d.background == "back-002")
			{
				backGroundLabel.text = backgrounds[1].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[2];
			}
			else if (d.background == "back-003")
			{
				backGroundLabel.text = backgrounds[2].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[3];
			}
			else if (d.background == "back-004-sun")
			{
				backGroundLabel.text = backgrounds[4].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[4];
			}
			else if (d.background == "back-004-night")
			{
				backGroundLabel.text = backgrounds[3].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[5];
			}
			else if (d.background == "back-005-sun")
			{
				backGroundLabel.text = backgrounds[6].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[6];
			}
			else if (d.background == "back-005-night")
			{
				backGroundLabel.text = backgrounds[5].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[7];
			}
			else if (d.background == "back-006")
			{
				backGroundLabel.text = backgrounds[7].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[8];
			}
			else if (d.background == "back-007")
			{
				backGroundLabel.text = backgrounds[9].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[9];
			}
			else
			{
				backGroundLabel.text = "";
			}

			//character
			if (d.expression == "")
			{
				charaImageNow.color = new Color(0, 0, 0, 0);
			}
			else if (d.expression == "L-01" || d.expression == "L-01a" ||
				d.expression == "L-01b" || d.expression == "L-02" ||
				d.expression == "L-02a" || d.expression == "L-03" ||
				d.expression == "L-04" || d.expression == "L-05" ||
				d.expression == "L-05a" || d.expression == "L-06" ||
				d.expression == "L-06a" || d.expression == "L-07" ||
				d.expression == "L-07a" || d.expression == "L-08" ||
				d.expression == "L-09" || d.expression == "L-10" ||
				d.expression == "L-10a" || d.effect == "リート立ち絵/L-001で表示")
			{
				charaImageNow.color = new Color(255, 255, 255, 255);
				charaImageNow.sprite = charaImage[0];
			}

			else if (d.id == 188)
			{
				charaImageNow.color = new Color(255, 255, 255, 255);
				charaImageNow.sprite = charaImage[1];
			}

			else if (d.expression == "K-01" || d.expression == "K-02" ||
				d.expression == "K-02a" || d.expression == "K-03" ||
				d.expression == "K-04" || d.expression == "K-05" ||
				d.expression == "K-06" || d.expression == "K-07" ||
				d.expression == "K-08" || d.expression == "K-09" ||
				d.expression == "K-09a" || d.expression == "K-10" ||
				d.expression == "K-11")
			{
				charaImageNow.color = new Color(255, 255, 255, 255);
				charaImageNow.sprite = charaImage[1];
			}

			else if (d.expression == "T-01" || d.expression == "T-02" ||
				d.expression == "T-03" || d.expression == "T-03a" ||
				d.expression == "T-04")
			{
				charaImageNow.color = new Color(255, 255, 255, 255);
				charaImageNow.sprite = charaImage[2];
			}
			else if (d.expression == "G-01" || d.expression == "G-02" ||
				d.expression == "G-03" || d.expression == "G-04" ||
				d.expression == "G-05" || d.expression == "G-06" ||
				d.expression == "G-07")
			{
				charaImageNow.color = new Color(255, 255, 255, 255);
				charaImageNow.sprite = charaImage[3];
			}
			else if (d.character == "メイア")
			{
				charaImageNow.color = new Color(0, 0, 0, 0);
				charaImageNow.sprite = charaImage[4];
			}
			else
			{
				charaImageNow.color = new Color(0, 0, 0, 0);
				charaImageNow.sprite = charaImage[5];
			}


			//expression

			//BGM
			if (d.BGM == "BGM-001")
			{
				BGM.clip = BGMFile[0];
				BGM.Play();
			}
			else if (d.BGM == "BGM-002")
			{
				BGM.clip = BGMFile[1];
				BGM.Play();
			}
			else if (d.BGM == "BGM-003")
			{
				BGM.clip = BGMFile[2];
				BGM.Play();
			}
			else if (d.BGM == "BGM-004")
			{
				BGM.clip = BGMFile[3];
				BGM.Play();
			}
			else if (d.BGM == "BGM-005")
			{
				BGM.clip = BGMFile[4];
				BGM.Play();
			}
			else if (d.BGM == "")
			{
			}
			else
			{
				BGM.Stop();
			}

			//SE

			if (autoScroll.automated == false)
			{
				if (d.SE == "SE-001")
				{
					SE.clip = SEFile[0];
					SE.Play();
				}
				else if (d.SE == "SE-002")
				{
					SE.clip = SEFile[1];
					SE.Play();
				}
				else if (d.SE == "SE-003")
				{
					SE.clip = SEFile[2];
					SE.Play();
				}
				else if (d.SE == "SE-004")
				{
					SE.clip = SEFile[3];
					SE.Play();
				}
				else if (d.SE == "SE-005")
				{
					SE.clip = SEFile[4];
					SE.Play();
				}
				else if (d.SE == "SE-006")
				{
					SE.clip = SEFile[5];
					SE.Play();
				}
				else if (d.SE == "SE-007")
				{
					SE.clip = SEFile[6];
					SE.Play();
				}
				else if (d.SE == "SE-008")
				{
					SE.clip = SEFile[7];
					SE.Play();
				}
				else if (d.SE == "SE-009")
				{
					SE.clip = SEFile[8];
					SE.Play();
				}
				else
				{
					SE.Stop();
				}
			}


			//enlarge logs
			if (whichLineNow >= 4)
			{
				rt.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.y + 200);
			}

			//effects & run
			if (d.id == 52 || d.id == 53 || d.id == 128 || d.id == 138
				|| d.id == 145 || d.id == 162 || d.id == 164 || d.id == 179
				|| d.id == 202 || d.id == 209 || d.id == 217)
			{
				whichLineNow += 1;
			}

			if (d.id == 52)
			{
				whichLineNow += 4;
			}

			if (d.id == 170)
			{
				whichLineNow += 2;
			}

			if (d.id == 138)
			{
				whichLineNow += 10;
			}

			if (d.effect == "フェードアウト" || d.effect == "一度画面フェードアウト" || d.effect == "右からアウト" || d.effect == "フェードアウト/３秒暗転")
			{
				nameLabel.text = string.Empty;
				textLabel.text = string.Empty;
				FadeAnim.SetBool("Fading", true);
				waitForFadeAnim = true;
				whichLineNow += 2;
			}
			else if (d.effect == "フェードアウト/3秒待つ")
			{
				nameLabel.text = string.Empty;
				textLabel.text = string.Empty;
				FadeAnim.SetBool("Fading", true);
				waitForFadeAnim = true;
				whichLineNow += 1;

			}
			else
			{
				yield return dialogueManager.Run(d.dialogue, textLabel);
			}


			//effects
			if (waitForFadeAnim == true)
			{
				yield return new WaitForSeconds(1.5f);
				FadeAnim.SetBool("Fading", false);
			}
			else if (autoScroll.automated == false)
			{
				yield return new WaitUntil(() => dialogueManager.next == true);
				if (d.id == 51)
				{
					finishTemp1 = true;
				}
				if (d.id == 128)
				{
					finishTemp2 = true;
				}
				if (d.id == 202)
				{
					finishTemp3 = true;
				}
				if (d.id == 164)
				{
					PlayerPrefs.SetInt("MiniGame1", 1);
				}
				if (d.id == 170)
				{
					PlayerPrefs.SetInt("MiniGame2", 1);
				}
				if (d.id == 179)
				{
					PlayerPrefs.SetInt("MiniGame3", 1);
				}

			}
			else if (autoScroll.automated == true && autoScroll.autoActive == true)
			{
				yield return new WaitForSeconds(2);
				if (d.id == 51)
				{
					finishTemp1 = true;
				}
				if (d.id == 128)
				{
					finishTemp2 = true;
				}
				if (d.id == 202)
				{
					finishTemp3 = true;
				}
				if (d.id == 164)
				{
					PlayerPrefs.SetInt("MiniGame1", 1);
				}
				if (d.id == 170)
				{
					PlayerPrefs.SetInt("MiniGame2", 1);
				}
				if (d.id == 179)
				{
					PlayerPrefs.SetInt("MiniGame3", 1);
				}
			}
			else
			{
				if (d.id == 51)
				{
					finishTemp1 = true;
				}
				if (d.id == 128)
				{
					finishTemp2 = true;
				}
				if (d.id == 202)
				{
					finishTemp3 = true;
				}

				if (d.id == 164)
				{
					PlayerPrefs.SetInt("MiniGame1", 1);
				}
				if (d.id == 170)
				{
					PlayerPrefs.SetInt("MiniGame2", 1);
				}
				if (d.id == 179)
				{
					PlayerPrefs.SetInt("MiniGame3", 1);
				}
			}
		}
	}

	void TaskOnClick()
	{
		dialogueManager.next = true;
	}

	void FirstButtonClicked()
	{
		TwoChoices.SetActive(false);
		dialogues.Clear();

		Time.timeScale = 1;

		if (finishTemp1 == true)
		{
			resetPos = 1;
			finishTemp1 = false;
			whichLineNow = 62;

			row = data[68].Split(new char[] { ',' });
			d = new Dialogue();
			int.TryParse(row[0], out d.id);
			d.character = row[1];
			d.dialogue = row[2];
			d.expression = row[3];
			d.background = row[4];
			d.BGM = row[5];
			d.SE = row[6];
			d.effect = row[7];

			dialogues.Add(d);

			for (int i = 73; i < 155; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[6] != "" || row[7] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.expression = row[3];
					d.background = row[4];
					d.BGM = row[5];
					d.SE = row[6];
					d.effect = row[7];

					dialogues.Add(d);
				}
			}
		}

		if (finishTemp2 == true)
		{
			resetPos = 3;
			finishTemp2 = false;
			whichLineNow = 156;

			for (int i = 157; i < 167; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[6] != "" || row[7] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.expression = row[3];
					d.background = row[4];
					d.BGM = row[5];
					d.SE = row[6];
					d.effect = row[7];

					dialogues.Add(d);
				}
			}
			for (int i = 177; i < 183; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[6] != "" || row[7] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.expression = row[3];
					d.background = row[4];
					d.BGM = row[5];
					d.SE = row[6];
					d.effect = row[7];

					dialogues.Add(d);
				}
			}

			for (int i = 185; i < 195; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[6] != "" || row[7] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.expression = row[3];
					d.background = row[4];
					d.BGM = row[5];
					d.SE = row[6];
					d.effect = row[7];

					dialogues.Add(d);
				}
			}
			for (int i = 198; i < 202; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[6] != "" || row[7] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.expression = row[3];
					d.background = row[4];
					d.BGM = row[5];
					d.SE = row[6];
					d.effect = row[7];

					dialogues.Add(d);
				}
			}
		}
		if (finishTemp3 == true)
		{
			resetPos = 8;
			finishTemp3 = false;

			for (int i = 252; i < 259; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[6] != "" || row[7] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.expression = row[3];
					d.background = row[4];
					d.BGM = row[5];
					d.SE = row[6];
					d.effect = row[7];

					dialogues.Add(d);
				}
			}
			for (int i = 270; i < 307; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[6] != "" || row[7] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.expression = row[3];
					d.background = row[4];
					d.BGM = row[5];
					d.SE = row[6];
					d.effect = row[7];

					dialogues.Add(d);
				}
			}

		}

		ShowDialogue();
	}

	void SecondButtonClicked()
	{
		TwoChoices.SetActive(false);
		dialogues.Clear();

		Time.timeScale = 1;
		if (finishTemp1 == true)
		{
			resetPos = 2;
			finishTemp1 = false;
			whichLineNow = 62;

			row = data[71].Split(new char[] { ',' });
			d = new Dialogue();
			int.TryParse(row[0], out d.id);
			d.character = row[1];
			d.dialogue = row[2];
			d.expression = row[3];
			d.background = row[4];
			d.BGM = row[5];
			d.SE = row[6];
			d.effect = row[7];

			dialogues.Add(d);

			for (int i = 73; i < 155; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[6] != "" || row[7] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.expression = row[3];
					d.background = row[4];
					d.BGM = row[5];
					d.SE = row[6];
					d.effect = row[7];

					dialogues.Add(d);
				}
			}
		}

		if (finishTemp2 == true)
		{
			resetPos = 4;
			finishTemp2 = false;

			for (int i = 169; i < 195; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[6] != "" || row[7] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.expression = row[3];
					d.background = row[4];
					d.BGM = row[5];
					d.SE = row[6];
					d.effect = row[7];

					dialogues.Add(d);
				}
			}
			for (int i = 198; i < 202; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[6] != "" || row[7] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.expression = row[3];
					d.background = row[4];
					d.BGM = row[5];
					d.SE = row[6];
					d.effect = row[7];

					dialogues.Add(d);
				}
			}
		}

		if (finishTemp3 == true)
		{
			resetPos = 9;
			finishTemp3 = false;

			for (int i = 261; i < 307; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[6] != "" || row[7] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.expression = row[3];
					d.background = row[4];
					d.BGM = row[5];
					d.SE = row[6];
					d.effect = row[7];

					dialogues.Add(d);
				}
			}
		}

		ShowDialogue();
	}

	void QuickSaveClicked()
	{
		int startFrom = PlayerPrefs.GetInt("LogNow");

		PlayerPrefs.SetInt("LogNow", startFrom + whichLineNow - 1);
		PlayerPrefs.SetInt("ResetPos", resetPos);
		whichLineNow = 0;
	}
}
