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
	TextAsset itemDialogue;
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
	[SerializeField]
	GameObject GameMenu;
	[SerializeField]
	GameObject ItemScreen;
	[SerializeField]
	GameObject ItemChooseScreen;
	[SerializeField]
	GameObject MiniGameChoose;

	[SerializeField]
	GameObject EraseButton1;
	[SerializeField]
	GameObject EraseButton2;
	[SerializeField]
	GameObject EraseButton3;
	[SerializeField]
	GameObject EraseUI1;
	[SerializeField]
	GameObject EraseUI2;



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
	string[] itemData;
	string[] dataRow;
	string[] row;
	string[] itemRow;
	public int whichLineNow = 0;
	public bool waitForFadeAnim = false;
	public bool finishTemp1 = false;
	public bool finishTemp2 = false;
	public bool finishTemp3 = false;
	public bool finishTemp4 = false;

	public bool ItemEffect = false;
	public bool itemChoose = false;
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


		itemData = itemDialogue.text.Split(new char[] { '$' });

		data = prologue.text.Split(new char[] { '$' });

		int menu = PlayerPrefs.GetInt("NovelMenu");

		if (menu == 0 || menu == 5)
		{
			GameMenu.SetActive(false);
		}
		else
		{
			GameMenu.SetActive(true);
		}

		First();
	}

	private void Update()
	{
		Continue();
	}


	public void First()
	{
		int logNumber = PlayerPrefs.GetInt("LogNow");
		int miniGame = PlayerPrefs.GetInt("MiniGame");
		int resetFrom = PlayerPrefs.GetInt("ResetPos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu");

		Debug.Log(logNumber);

		if (miniGame == 1 && novelMenu == 0)
		{
			resetPos = 5;
			PlayerPrefs.SetInt("MiniGame", 0);
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
		else if (miniGame == 2)
		{
			resetPos = 6;
			PlayerPrefs.SetInt("NovelMenu", 0);
			PlayerPrefs.SetInt("MiniGame", 0);
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
		else if ((miniGame == 3 && novelMenu == 0) || resetFrom == 10)
		{
			PlayerPrefs.SetInt("MiniGame", 0);
			AfterShopPrologue();
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
			if (logNumber == 64)
			{
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
			else
			{
				for (int i = logNumber + 8; i < 155; i++)
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
				for (int i = 177; i < 184; i++)
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
			else
			{
				for (int i = logNumber; i < 202; i++)
				{
					row = data[i].Split(new char[] { ',' });

					if (row[2] != "" || row[6] != "" || row[7] != "" || row[0] != "153")
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

		else if (resetFrom == 4)
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

		else if (resetFrom == 5)
		{
			for (int i = logNumber; i < 211; i++)
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

		else if (resetFrom == 6)
		{
			for (int i = logNumber; i < 224; i++)
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

		else if (resetFrom == 7)
		{
			for (int i = logNumber; i < 250; i++)
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

		else if (resetFrom == 8)
		{
			if (logNumber <= 258)
			{
				for (int i = logNumber; i < 259; i++)
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
			else
			{
				for (int i = logNumber; i < 307; i++)
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

		else if (resetFrom == 9)
		{
			for (int i = logNumber; i < 307; i++)
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

		if (finishTemp4 == true)
		{
			TwoChoices.SetActive(true);

			string[] tempRow = itemData[4].Split(new char[] { ',' });
			FirstTwo.text = tempRow[2];

			string[] tempRow2 = itemData[5].Split(new char[] { ',' });
			SecondTwo.text = tempRow2[2];

		}

	}

	public void ShowDialogue()
	{
		StartCoroutine(PrologueDialogue());
	}

	private IEnumerator PrologueDialogue()
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
			if (d.expression == "L-01" || d.expression == "L-01a" ||
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
				//charaImageNow.color = new Color(0, 0, 0, 0);
				//charaImageNow.sprite = charaImage[4];
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

			////////////////////////////////////////////////////////////////////////////P R O L O G U E////////////////////////////////////////////////////////////////
			//effects & run
			if (d.id == 154 && resetPos == 3)
			{
				whichLineNow++;
			}

			if (d.id == 52 || d.id == 53 || d.id == 128
				|| d.id == 145 || d.id == 162 || d.id == 164 || d.id == 179
				|| d.id == 203)
			{
				whichLineNow += 1;
			}

			if (d.id == 54 && resetPos == 1)
			{
				whichLineNow += 4;
			}

			if (d.id == 170)
			{
				whichLineNow += 2;
			}

			if (d.id == 146 && resetPos == 3)
			{
				whichLineNow += 10;
			}

			if (d.id == 165)
			{
				whichLineNow = 202;
			}

			if (d.id == 171)
			{
				whichLineNow = 212;
			}

			if (d.id == 180)
			{
				whichLineNow = 227;
			}

			if (d.id == 218 && resetPos == 8)
			{
				whichLineNow += 11;
			}

			if (d.id == 210)
			{
				whichLineNow = 261;
			}

			if (d.id == 218 && resetPos == 9)
			{
				whichLineNow++;
			}

			if(d.id == 251)
            {
				PlayerPrefs.SetInt("NovelMenu", 10);
			}

			bool minusLine = false;
			if (d.id == 231)
			{
				minusLine = true;
			}

			if (d.effect == "フェードアウト" && minusLine == true)
			{
				minusLine = false;
				nameLabel.text = string.Empty;
				textLabel.text = string.Empty;
				FadeAnim.SetBool("Fading", true);
				waitForFadeAnim = true;
				whichLineNow += 1;
			}
			else if (d.effect == "フェードアウト" || d.effect == "一度画面フェードアウト" || d.effect == "右からアウト" || d.effect == "フェードアウト/３秒暗転")
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
			else if (ItemEffect == true)
			{
				ItemEffect = false;
				nameLabel.text = string.Empty;
				textLabel.text = string.Empty;
				FadeAnim.SetBool("Fading", true);
				waitForFadeAnim = true;
			}
			else
			{
				yield return dialogueManager.Run(d.dialogue, textLabel);
			}


			//effects
			int menu = PlayerPrefs.GetInt("NovelMenu");
			if (waitForFadeAnim == true)
			{
				yield return new WaitForSeconds(1.5f);
				FadeAnim.SetBool("Fading", false);
			}


			else if (menu == 1 || menu == 2 || menu == 3)
			{
				MiniGameChoose.SetActive(true);
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
				if (d.id == 162)
				{
					PlayerPrefs.SetInt("MiniGame", 1);
					PlayerPrefs.SetInt("NovelMenu", 1);
				}
				if (d.id == 164)
				{
					PlayerPrefs.SetInt("NovelMenu", 4);
				}
				if (d.id == 170)
				{
					PlayerPrefs.SetInt("MiniGame", 2);
					PlayerPrefs.SetInt("NovelMenu", 2);
				}
				if (d.id == 176)
				{
					PlayerPrefs.SetInt("MiniGame", 3);
					PlayerPrefs.SetInt("NovelMenu", 3);
				}
				if (d.id == 179)
				{
					PlayerPrefs.SetInt("NovelMenu", 5);
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
				if (d.id == 162)
				{
					PlayerPrefs.SetInt("MiniGame", 1);
					PlayerPrefs.SetInt("NovelMenu", 1);
				}
				if (d.id == 164)
				{
					PlayerPrefs.SetInt("NovelMenu", 4);
				}
				if (d.id == 170)
				{
					PlayerPrefs.SetInt("MiniGame", 2);
					PlayerPrefs.SetInt("NovelMenu", 2);
				}
				if (d.id == 176)
				{
					PlayerPrefs.SetInt("MiniGame", 3);
					PlayerPrefs.SetInt("NovelMenu", 3);
				}
				if (d.id == 179)
				{
					PlayerPrefs.SetInt("NovelMenu", 5);
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
				if (d.id == 162)
				{
					PlayerPrefs.SetInt("MiniGame", 1);
					PlayerPrefs.SetInt("NovelMenu", 1);
				}
				if (d.id == 164)
				{
					PlayerPrefs.SetInt("NovelMenu", 4);
				}
				if (d.id == 170)
				{
					PlayerPrefs.SetInt("MiniGame", 2);
					PlayerPrefs.SetInt("NovelMenu", 2);
				}
				if (d.id == 176)
				{
					PlayerPrefs.SetInt("MiniGame", 3);
					PlayerPrefs.SetInt("NovelMenu", 3);
				}
				if (d.id == 179)
				{
					PlayerPrefs.SetInt("NovelMenu", 5);
				}
			}

			if (itemChoose == true)
			{
				ItemChooseScreen.SetActive(true);
			}
		}
	}

	void TaskOnClick()
	{
		dialogueManager.next = true;
		if (d.dialogue == "「そうだ、折角なら何か買い物して行こうかな」")
		{
			finishTemp4 = true;
		}
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
			for (int i = 177; i < 184; i++)
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
		if (finishTemp4 == true)
		{
			finishTemp4 = false;
			ItemScreen.SetActive(true);

			EraseButton1.SetActive(false);
			EraseButton2.SetActive(false);
			EraseButton3.SetActive(false);
			EraseUI1.SetActive(false);
			EraseUI2.SetActive(false);

			itemRow = itemData[8].Split(new char[] { ',' });

			d = new Dialogue();
			int.TryParse(itemRow[0], out d.id);
			d.character = itemRow[1];
			d.dialogue = itemRow[2];
			d.expression = itemRow[3];
			d.background = itemRow[4];
			d.BGM = itemRow[5];
			d.SE = itemRow[6];
			d.effect = itemRow[7];

			dialogues.Add(d);
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
			whichLineNow = 168;

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

		if (finishTemp4 == true)
		{
			finishTemp4 = false;
			d = new Dialogue();
			int.TryParse("999", out d.id);
			d.character = "";
			d.dialogue = "";
			d.expression = "";
			d.background = "";
			d.BGM = "";
			d.SE = "";
			d.effect = "afteritem";

			dialogues.Add(d);

			ItemEffect = true;

			AfterShopPrologue();
		}

		ShowDialogue();
	}

	void QuickSaveClicked()
	{
		int startFrom = PlayerPrefs.GetInt("LogNow");

		int whichFile = PlayerPrefs.GetInt("WhichFile");
		if (whichFile == 1)
		{
			if (whichLineNow != 0)
			{
				PlayerPrefs.SetInt("FirstLog", startFrom + whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("FirstLog", startFrom + whichLineNow);
			}
			PlayerPrefs.SetInt("FirstPos", resetPos);

			int file = PlayerPrefs.GetInt("FirstLog");
			PlayerPrefs.SetInt("LogNow", file);
			string date = PlayerPrefs.GetString("Date");
			PlayerPrefs.SetString("Date1", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber1", ItemNumber);
		}
		else if (whichFile == 2)
		{
			if (whichLineNow != 0)
			{
				PlayerPrefs.SetInt("SecondLog", startFrom + whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("SecondLog", startFrom + whichLineNow);
			}

			PlayerPrefs.SetInt("SecondPos", resetPos);

			int file = PlayerPrefs.GetInt("SecondLog");
			PlayerPrefs.SetInt("LogNow", file);
			string date = PlayerPrefs.GetString("Date");
			PlayerPrefs.SetString("Date2", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber2", ItemNumber);
		}
		else if (whichFile == 3)
		{
			if (whichLineNow != 0)
			{
				PlayerPrefs.SetInt("ThirdLog", startFrom + whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("ThirdLog", startFrom + whichLineNow);
			}
			PlayerPrefs.SetInt("ThirdPos", resetPos);

			int file = PlayerPrefs.GetInt("ThirdLog");
			PlayerPrefs.SetInt("LogNow", file);
			string date = PlayerPrefs.GetString("Date");
			PlayerPrefs.SetString("Date3", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber3", ItemNumber);
		}
		else if (whichFile == 4)
		{
			if (whichLineNow != 0)
			{
				PlayerPrefs.SetInt("FourthLog", startFrom + whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("FourthLog", startFrom + whichLineNow);
			}
			PlayerPrefs.SetInt("FourthPos", resetPos);

			int file = PlayerPrefs.GetInt("FourthLog");
			PlayerPrefs.SetInt("LogNow", file);
			string date = PlayerPrefs.GetString("Date");
			PlayerPrefs.SetString("Date4", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber4", ItemNumber);
		}
		else if (whichFile == 5)
		{
			if (whichLineNow != 0)
			{
				PlayerPrefs.SetInt("FifthLog", startFrom + whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("FifthLog", startFrom + whichLineNow);
			}
			PlayerPrefs.SetInt("FifthPos", resetPos);

			int file = PlayerPrefs.GetInt("FifthLog");
			PlayerPrefs.SetInt("LogNow", file);
			string date = PlayerPrefs.GetString("Date");
			PlayerPrefs.SetString("Date5", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber5", ItemNumber);
		}
		else if (whichFile == 6)
		{
			if (whichLineNow != 0)
			{
				PlayerPrefs.SetInt("SixthLog", startFrom + whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("SixthLog", startFrom + whichLineNow);
			}
			PlayerPrefs.SetInt("SixthPos", resetPos);

			int file = PlayerPrefs.GetInt("SixthLog");
			PlayerPrefs.SetInt("LogNow", file);
			string date = PlayerPrefs.GetString("Date");
			PlayerPrefs.SetString("Date6", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber6", ItemNumber);
		}
		else if (whichFile == 7)
		{
			if (whichLineNow != 0)
			{
				PlayerPrefs.SetInt("SeventhLog", startFrom + whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("SeventhLog", startFrom + whichLineNow);
			}
			PlayerPrefs.SetInt("SeventhPos", resetPos);

			int file = PlayerPrefs.GetInt("SeventhLog");
			PlayerPrefs.SetInt("LogNow", file);
			string date = PlayerPrefs.GetString("Date");
			PlayerPrefs.SetString("Date7", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber7", ItemNumber);
		}
		else if (whichFile == 8)
		{
			if (whichLineNow != 0)
			{
				PlayerPrefs.SetInt("EighthLog", startFrom + whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("EighthLog", startFrom + whichLineNow);
			}
			PlayerPrefs.SetInt("EighthPos", resetPos);

			int file = PlayerPrefs.GetInt("EighthLog");
			PlayerPrefs.SetInt("LogNow", file);
			string date = PlayerPrefs.GetString("Date");
			PlayerPrefs.SetString("Date8", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber8", ItemNumber);
		}
		else if (whichFile == 9)
		{
			if (whichLineNow != 0)
			{
				PlayerPrefs.SetInt("NinthLog", startFrom + whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("NinthLog", startFrom + whichLineNow);
			}
			PlayerPrefs.SetInt("NinthPos", resetPos);

			int file = PlayerPrefs.GetInt("NinthLog");
			PlayerPrefs.SetInt("LogNow", file);
			string date = PlayerPrefs.GetString("Date");
			PlayerPrefs.SetString("Date9", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber9", ItemNumber);
		}
		else if (whichFile == 10)
		{
			if (whichLineNow != 0)
			{
				PlayerPrefs.SetInt("TenthLog", startFrom + whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("TenthLog", startFrom + whichLineNow);
			}
			PlayerPrefs.SetInt("TenthPos", resetPos);

			int file = PlayerPrefs.GetInt("TenthLog");
			PlayerPrefs.SetInt("LogNow", file);
			string date = PlayerPrefs.GetString("Date");
			PlayerPrefs.SetString("Date10", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber10", ItemNumber);
		}

		whichLineNow = 0;
	}






	public void CharacterItemChoose()
	{
		dialogues.Clear();
		itemRow = itemData[10].Split(new char[] { ',' });

		d = new Dialogue();
		int.TryParse(itemRow[0], out d.id);
		d.character = itemRow[1];
		d.dialogue = itemRow[2];
		d.expression = itemRow[3];
		d.background = itemRow[4];
		d.BGM = itemRow[5];
		d.SE = itemRow[6];
		d.effect = itemRow[7];

		dialogues.Add(d);

		ShowDialogue();

		Debug.Log(resetPos);
	}


	public void RiitItem()
	{
		dialogues.Clear();
		itemRow = itemData[17].Split(new char[] { ',' });

		d = new Dialogue();
		int.TryParse(itemRow[0], out d.id);
		d.character = itemRow[1];
		d.dialogue = itemRow[2];
		d.expression = itemRow[3];
		d.background = itemRow[4];
		d.BGM = itemRow[5];
		d.SE = itemRow[6];
		d.effect = itemRow[7];

		dialogues.Add(d);

		d = new Dialogue();
		int.TryParse("999", out d.id);
		d.character = "";
		d.dialogue = "";
		d.expression = "";
		d.background = "";
		d.BGM = "";
		d.SE = "";
		d.effect = "giveitem";

		dialogues.Add(d);

		itemChoose = true;

		ShowDialogue();
	}

	public void KleinItem()
	{
		dialogues.Clear();
		itemRow = itemData[29].Split(new char[] { ',' });

		d = new Dialogue();
		int.TryParse(itemRow[0], out d.id);
		d.character = itemRow[1];
		d.dialogue = itemRow[2];
		d.expression = itemRow[3];
		d.background = itemRow[4];
		d.BGM = itemRow[5];
		d.SE = itemRow[6];
		d.effect = itemRow[7];

		dialogues.Add(d);

		d = new Dialogue();
		int.TryParse("999", out d.id);
		d.character = "";
		d.dialogue = "";
		d.expression = "";
		d.background = "";
		d.BGM = "";
		d.SE = "";
		d.effect = "giveitem";

		dialogues.Add(d);

		itemChoose = true;

		ShowDialogue();
	}






	public void RiitEffect(int feel)
	{
		dialogues.Clear();
		itemChoose = false;
		if (feel == 0)
		{
			itemRow = itemData[22].Split(new char[] { ',' });

			d = new Dialogue();
			int.TryParse(itemRow[0], out d.id);
			d.character = itemRow[1];
			d.dialogue = itemRow[2];
			d.expression = itemRow[3];
			d.background = itemRow[4];
			d.BGM = itemRow[5];
			d.SE = itemRow[6];
			d.effect = itemRow[7];

			dialogues.Add(d);
		}

		else if (feel == 1)
		{
			itemRow = itemData[21].Split(new char[] { ',' });

			d = new Dialogue();
			int.TryParse(itemRow[0], out d.id);
			d.character = itemRow[1];
			d.dialogue = itemRow[2];
			d.expression = itemRow[3];
			d.background = itemRow[4];
			d.BGM = itemRow[5];
			d.SE = itemRow[6];
			d.effect = itemRow[7];

			dialogues.Add(d);
		}

		else if (feel == 2)
		{
			itemRow = itemData[20].Split(new char[] { ',' });

			d = new Dialogue();
			int.TryParse(itemRow[0], out d.id);
			d.character = itemRow[1];
			d.dialogue = itemRow[2];
			d.expression = itemRow[3];
			d.background = itemRow[4];
			d.BGM = itemRow[5];
			d.SE = itemRow[6];
			d.effect = itemRow[7];

			dialogues.Add(d);
		}

		d = new Dialogue();
		int.TryParse("999", out d.id);
		d.character = "";
		d.dialogue = "";
		d.expression = "";
		d.background = "";
		d.BGM = "";
		d.SE = "";
		d.effect = "giveitem";

		dialogues.Add(d);

		AfterShopPrologue();
		ShowDialogue();


		ItemEffect = true;
	}

	public void KleinEffect(int feel)
	{
		dialogues.Clear();
		itemChoose = false;
		if (feel == 0)
		{
			itemRow = itemData[34].Split(new char[] { ',' });

			d = new Dialogue();
			int.TryParse(itemRow[0], out d.id);
			d.character = itemRow[1];
			d.dialogue = itemRow[2];
			d.expression = itemRow[3];
			d.background = itemRow[4];
			d.BGM = itemRow[5];
			d.SE = itemRow[6];
			d.effect = itemRow[7];

			dialogues.Add(d);
		}

		else if (feel == 1)
		{
			itemRow = itemData[33].Split(new char[] { ',' });

			d = new Dialogue();
			int.TryParse(itemRow[0], out d.id);
			d.character = itemRow[1];
			d.dialogue = itemRow[2];
			d.expression = itemRow[3];
			d.background = itemRow[4];
			d.BGM = itemRow[5];
			d.SE = itemRow[6];
			d.effect = itemRow[7];

			dialogues.Add(d);
		}

		else if (feel == 2)
		{
			itemRow = itemData[32].Split(new char[] { ',' });

			d = new Dialogue();
			int.TryParse(itemRow[0], out d.id);
			d.character = itemRow[1];
			d.dialogue = itemRow[2];
			d.expression = itemRow[3];
			d.background = itemRow[4];
			d.BGM = itemRow[5];
			d.SE = itemRow[6];
			d.effect = itemRow[7];

			dialogues.Add(d);
		}

		d = new Dialogue();
		int.TryParse("999", out d.id);
		d.character = "";
		d.dialogue = "";
		d.expression = "";
		d.background = "";
		d.BGM = "";
		d.SE = "";
		d.effect = "giveitem";

		dialogues.Add(d);

		AfterShopPrologue();
		ShowDialogue();


		ItemEffect = true;
	}

	public void AfterShopPrologue()
	{
		whichLineNow = 226;
		resetPos = 7;
		EraseButton1.SetActive(true);
		EraseButton2.SetActive(true);
		EraseButton3.SetActive(true);
		EraseUI1.SetActive(true);
		EraseUI2.SetActive(true);

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
}
