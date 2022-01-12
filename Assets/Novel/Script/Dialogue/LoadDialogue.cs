﻿using System.Collections;
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
	public Image charaImageNow1;
	[SerializeField]
	public Image charaImageNow2;
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
	GameObject[] CharacterImage;

	[SerializeField]
	public Sprite[] CharaEyes;
	[SerializeField]
	public Sprite[] CharaMouth;

	[SerializeField]
	Sprite[] StillSprite;
	[SerializeField]
	Image StillImage;
	[SerializeField]
	Sprite DialogueBGImage;
	[SerializeField]
	GameObject StillDialogueBG;
	[SerializeField]
	Image DialogueBG;

	[SerializeField]
	Image EyeNow;
	[SerializeField]
	Image MouthNow;

	[SerializeField]
	Image EyeNow1;
	[SerializeField]
	Image MouthNow1;

	[SerializeField]
	Image EyeNow2;
	[SerializeField]
	Image MouthNow2;

	[SerializeField]
	public AudioClip[] VoiceFile;

	[SerializeField]
	AudioSource ButtonAudioSource;

	[SerializeField]
	GameObject EraseButton1;
	[SerializeField]
	GameObject EraseButton2;
	[SerializeField]
	GameObject EraseButton3;


	[SerializeField]
	DialogueManager dialogueManager;
	private AutoScroll autoScroll;
	public BackGroundLogs bgl;
	public Dialogue d;

	[SerializeField]
	Animator FadeAnim;
	[SerializeField]
	Animator SlideAnim;
	[SerializeField]
	Animator BustUpAnim;

	private AudioSource BGM;
	private AudioSource SE;

	[SerializeField]
	Animator TextBGHide;

	[SerializeField]
	Animator Hide;

	[SerializeField]
	AudioSource Voice;

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
	public bool finishTemp5 = false;
	public bool finishTemp6 = false;
	public bool finishTemp7 = false;
	public bool finishTemp8 = false;
	public bool finishTemp9 = false;
	public bool finishTemp10 = false;
	public bool finishTemp11 = false;
	public bool finishTemp12 = false;
	public bool finishTemp13 = false;


	public bool ItemEffect = false;
	public bool itemChoose = false;
	public int resetPos = 0;

	bool shopDecide = true;

	float speed;

	string backGroundName;

	public float voiceTime;

	[SerializeField]
	GameObject GameShowOnly;


	public List<BackGroundLogs> backgrounds;
	public List<Dialogue> dialogues;

	[SerializeField]
	TextAsset[] LiedDialogue;
	[SerializeField]
	TextAsset[] KleinDialogue;

	private void Start()
	{
		int gameMoneyGet = PlayerPrefs.GetInt("Money");
		//Debug.Log(gameMoneyGet);

		charaImageNow.color = new Color(0, 0, 0, 0);
		EyeNow.color = new Color(0, 0, 0, 0);
		MouthNow.color = new Color(0, 0, 0, 0);

		backgrounds = new List<BackGroundLogs>();
		dialogues = new List<Dialogue>();
		resetPos = PlayerPrefs.GetInt("ResetPos");

		ButtonAudioSource.Stop();

		backGroundName = "";

		autoScroll = GameObject.Find("AutoScroll").GetComponent<AutoScroll>();
		BGM = GameObject.Find("BGM").GetComponent<AudioSource>();
		SE = GameObject.Find("SE").GetComponent<AudioSource>();
		nextDialogue.onClick.AddListener(TaskOnClick);
		FirstTwoButton.onClick.AddListener(FirstButtonClicked);
		SecondTwoButton.onClick.AddListener(SecondButtonClicked);
		QuickSaveButton.onClick.AddListener(QuickSaveClicked);

		int[] date = PlayerPrefsX.GetIntArray("Date");
		float liedAff = PlayerPrefs.GetFloat("LiedHeart");
		float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
		int countClean = PlayerPrefs.GetInt("CleanNumber");
		int countCook = PlayerPrefs.GetInt("CookNumber");
		int countShop = PlayerPrefs.GetInt("ShopNumber");
		int menu = PlayerPrefs.GetInt("NovelMenu");


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

		if (date[0] == 10 && (date[1] == 7 || date[1] == 8 || date[1] == 9))
		{
			data = prologue.text.Split(new char[] { '$' });
		}
		else if (date[0] == 10 && date[1] == 13)
		{
			data = LiedDialogue[0].text.Split(new char[] { '$' });
			if (liedAff >= 10f)
			{
				menu = 14;
				PlayerPrefs.SetInt("NovelMenu", menu);
			}
			else
			{
				PlayerPrefs.SetInt("LiedFail", 1);
			}

		}
		else if (date[0] == 10 && date[1] == 16)
		{
			data = LiedDialogue[1].text.Split(new char[] { '$' });
			if (liedAff >= 15f)
			{
				menu = 15;
				PlayerPrefs.SetInt("NovelMenu", menu);
				PlayerPrefs.SetInt("CleanNumber", 0);
			}
			else
			{
				PlayerPrefs.SetInt("LiedFail", 1);
			}

		}
		else if (date[0] == 10 && date[1] == 19)
		{
			data = LiedDialogue[2].text.Split(new char[] { '$' });
			if (liedAff >= 20f)
			{
				menu = 16;
				PlayerPrefs.SetInt("NovelMenu", menu);
			}
			else
			{
				PlayerPrefs.SetInt("LiedFail", 1);
			}

		}
		else if (date[0] == 10 && date[1] == 22)
		{
			data = LiedDialogue[3].text.Split(new char[] { '$' });
			if (liedAff >= 25f)
			{
				menu = 17;
				PlayerPrefs.SetInt("NovelMenu", menu);
			}
			else
			{
				PlayerPrefs.SetInt("LiedFail", 1);
			}

		}
		else if (date[0] == 10 && date[1] == 25)
		{
			data = LiedDialogue[4].text.Split(new char[] { '$' });
			if (liedAff >= 30f)
			{
				menu = 18;
				PlayerPrefs.SetInt("NovelMenu", menu);
			}
			else
			{
				PlayerPrefs.SetInt("LiedFail", 1);
			}

		}
		else if (date[0] == 10 && date[1] == 28)
		{
			data = LiedDialogue[5].text.Split(new char[] { '$' });
			if (liedAff >= 35f)
			{
				menu = 19;
				PlayerPrefs.SetInt("NovelMenu", menu);
			}
			else
			{
				PlayerPrefs.SetInt("LiedFail", 1);
			}

		}
		else if (date[0] == 10 && date[1] == 31)
		{
			data = LiedDialogue[6].text.Split(new char[] { '$' });
			if (liedAff >= 40f)
			{
				menu = 20;
				PlayerPrefs.SetInt("NovelMenu", menu);
			}
			else
			{
				PlayerPrefs.SetInt("LiedFail", 1);
			}

		}
		else if (date[0] == 11 && date[1] == 3)
		{
			data = LiedDialogue[7].text.Split(new char[] { '$' });
			if (liedAff >= 45f)
			{
				menu = 21;
				PlayerPrefs.SetInt("NovelMenu", menu);
			}
			else
			{
				PlayerPrefs.SetInt("LiedFail", 1);
			}

		}
		else if (date[0] == 11 && date[1] == 6)
		{
			data = LiedDialogue[8].text.Split(new char[] { '$' });
			if (liedAff >= 50f)
			{
				menu = 22;
				PlayerPrefs.SetInt("NovelMenu", menu);
			}
			else
			{
				PlayerPrefs.SetInt("LiedFail", 1);
			}

		}
		else if (date[0] == 11 && date[1] == 9)
		{
			data = LiedDialogue[9].text.Split(new char[] { '$' });
			if (liedAff >= 55f)
			{
				menu = 23;
				PlayerPrefs.SetInt("NovelMenu", menu);
			}
			else
			{
				PlayerPrefs.SetInt("LiedFail", 1);
			}

		}


		//Lied failed
		int liedFail = PlayerPrefs.GetInt("LiedFail");
		if (liedFail == 1)
		{
			menu = 12;
		}


		if (menu == 0 || menu == 6 || menu == 7 || menu == 8 || menu == 11 || menu >= 14)
		{
			MiniGameChoose.SetActive(false);
			GameMenu.SetActive(false);
		}
		else if (menu == 13 || menu == 10)
		{
			MiniGameChoose.SetActive(false);
			GameMenu.SetActive(true);
		}
		else if (menu == 11)
		{
			//buy item
		}
		else if (menu == 12)
		{
			MiniGameChoose.SetActive(true);
			GameMenu.SetActive(false);
		}
		else
		{
			GameMenu.SetActive(true);
		}

		if (menu != 13 && menu != 12 && menu != 10)
		{
			First();
		}
		else if (menu >= 14)
		{
			First();
		}
	}

	void Update()
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

		if (novelMenu == 11)
		{
			string[] tempRow = itemData[3].Split(new char[] { ',' });

			if (tempRow[2] != "" || tempRow[12] != "" || tempRow[14] != "")
			{
				d = new Dialogue();
				int.TryParse(tempRow[0], out d.id);
				d.character = tempRow[1];
				d.dialogue = tempRow[2];
				d.expression = tempRow[4];
				d.background = tempRow[7];
				d.BGM = tempRow[11];
				d.SE = tempRow[12];
				d.voice = tempRow[13];
				d.note = tempRow[14];

				dialogues.Add(d);
			}

		}


		else if (novelMenu == 14 && resetFrom == 10)
		{
			resetPos = 13;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 17; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (novelMenu == 15 && resetFrom == 16)
		{
			resetPos = 17;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 41; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}

		}
		else if (novelMenu == 16 && resetFrom == 20)
		{
			resetPos = 24;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 46; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}

		}
		else if (novelMenu == 17 && resetFrom == 23)
		{
			resetPos = 25;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 92; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}

		}
		else if (novelMenu == 18 && resetFrom == 28)
		{
			resetPos = 29;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 103; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}

		}
		else if (novelMenu == 19 && resetFrom == 32)
		{
			resetPos = 33;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 151; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}

		}
		else if (novelMenu == 20 && resetFrom == 34)
		{
			resetPos = 35;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 21; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}

		}
		else if (novelMenu == 21 && resetFrom == 38)
		{
			resetPos = 39;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 65; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}

		}
		else if (novelMenu == 22 && resetFrom == 42)
		{
			resetPos = 43;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 66; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}

		}
		else if (novelMenu == 23 && resetFrom == 44)
		{
			resetPos = 45;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 15; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}

		}



		///////////////////////////////////////////////PROLOGUE////////////////////////

		else if (miniGame == 1 && novelMenu == 0)
		{
			int[] dateNow = { 10, 8 };
			PlayerPrefsX.SetIntArray("Date", dateNow);

			resetPos = 5;
			PlayerPrefs.SetInt("MiniGame", 0);
			for (int i = 171; i < 177; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (miniGame == 2 && novelMenu == 0)
		{
			int[] dateNow = { 10, 9 };
			PlayerPrefsX.SetIntArray("Date", dateNow);

			resetPos = 6;
			PlayerPrefs.SetInt("MiniGame", 0);
			for (int i = 178; i < 189; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (miniGame == 3 && novelMenu == 0)
		{
			PlayerPrefs.SetInt("MiniGame", 0);
			whichLineNow = 189;
			resetPos = 7;

			for (int i = 189; i < 213; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}


		else if (resetFrom == 1)
		{
			for (int i = logNumber; i < 133; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}

		}
		else if (resetFrom == 2)
		{

			for (int i = logNumber; i < 133; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		else if (resetFrom == 3)
		{
			for (int i = logNumber; i < 171; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		else if (resetFrom == 4)
		{
			for (int i = logNumber; i < 171; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		else if (resetFrom == 5)
		{
			for (int i = logNumber; i < 178; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		else if (resetFrom == 6)
		{
			for (int i = logNumber; i < 189; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}

		}

		else if (resetFrom == 7)
		{
			for (int i = logNumber; i < 213; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}

		}

		else if (resetFrom == 8)
		{
			for (int i = logNumber; i < 263; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		else if (resetFrom == 9)
		{
			for (int i = logNumber; i < 263; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}

		}



		////////////////////////////////////////////Lied /////////////////////////////////////////////////////

		else if (resetFrom == 11)
		{
			for (int i = logNumber; i < 43; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		else if (resetFrom == 12)
		{
			for (int i = logNumber; i < 43; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		else if (resetFrom == 13)
		{
			for (int i = logNumber; i < 17; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 14)
		{
			for (int i = logNumber; i < 92; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 15)
		{
			for (int i = logNumber; i < 92; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		else if (resetFrom == 17)
		{
			for (int i = logNumber; i < 41; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 18)
		{
			for (int i = logNumber; i < 87; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 19)
		{
			for (int i = logNumber; i < 87; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		else if (resetFrom == 21)
		{
			for (int i = logNumber; i < 102; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 22)
		{
			for (int i = logNumber; i < 102; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 24)
		{
			for (int i = logNumber; i < 45; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		else if (resetFrom == 25)
		{
			for (int i = logNumber; i < 92; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 26)
		{
			for (int i = logNumber; i < 128; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 27)
		{
			for (int i = logNumber; i < 128; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		else if (resetFrom == 29)
		{
			for (int i = logNumber; i < 103; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 30)
		{
			for (int i = logNumber; i < 168; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 31)
		{
			for (int i = logNumber; i < 168; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 33)
		{
			for (int i = logNumber; i < 151; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 35)
		{
			for (int i = logNumber; i < 21; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 36)
		{
			for (int i = logNumber; i < 154; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 37)
		{
			for (int i = logNumber; i < 154; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		else if (resetFrom == 39)
		{
			for (int i = logNumber; i < 65; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 40)
		{
			for (int i = logNumber; i < 220; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 41)
		{
			for (int i = logNumber; i < 220; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 43)
		{
			for (int i = logNumber; i < 66; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 45)
		{
			for (int i = logNumber; i < 15; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 46)
		{
			for (int i = logNumber; i < 54; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		else if (resetFrom == 47)
		{
			for (int i = logNumber; i < 54; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}



		else if (novelMenu == 0 && resetFrom == 0)
		{
			for (int i = logNumber; i < 54; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if (row[2] != "" || row[15] != "" || row[17] != "")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

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
			TwoChoices.SetActive(true);

			string[] tempRow = data[53].Split(new char[] { ',' });
			string Filtered1 = tempRow[8].Replace("『", "");
			string Filtered2 = Filtered1.Replace("』", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[53].Split(new char[] { ',' });
			string Filtered4 = tempRow2[9].Replace("『", "");
			string Filtered5 = Filtered4.Replace("』", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}

		if (finishTemp2 == true)
		{
			TwoChoices.SetActive(true);

			string[] tempRow = data[132].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/LiedLove_high", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[132].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/LiedLove_low", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;

		}
		if (finishTemp3 == true)
		{
			TwoChoices.SetActive(true);

			string[] tempRow = data[212].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/KleinLove_high", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[212].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/KleinLove_low", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;

		}

		if (finishTemp4 == true)
		{
			TwoChoices.SetActive(true);

			string[] tempRow = itemData[4].Split(new char[] { ',' });
			string Filtered1 = tempRow[2].Replace("『", "");
			string Filtered2 = Filtered1.Replace("』", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = itemData[5].Split(new char[] { ',' });
			string Filtered4 = tempRow2[2].Replace("『", "");
			string Filtered5 = Filtered4.Replace("』", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;

		}
		if (finishTemp5 == true)
		{
			TwoChoices.SetActive(true);

			string[] tempRow = data[16].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/LiedLove_high", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[16].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/LiedLove_low", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp6 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[42].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/LiedLove_low", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[42].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/LiedLove_lowdown", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp7 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[40].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/LiedLove_low", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[40].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/LiedLove_high", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp8 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[44].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/KleinLove_low", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[44].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/Lied_gameover", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp9 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[91].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/LiedLove_high", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[91].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/LiedLove_lowdown", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp10 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[102].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/LiedLove_high", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[102].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/Lied_gameover", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp11 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[21].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/LiedLove_low", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[21].Split(new char[] { ',' });
			string Filtered6 = tempRow2[9].Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp12 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[65].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/LiedLove_high", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[65].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/LiedLove_low", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp13 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[15].Split(new char[] { ',' });
			string Filtered3 = tempRow[8].Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[15].Split(new char[] { ',' });
			string Filtered6 = tempRow[9].Replace("\"", "");
			SecondTwo.text = Filtered6;
		}


	}

	public void ShowDialogue()
	{
		StartCoroutine(DialogueGo());
	}

	private IEnumerator DialogueGo()
	{
		RectTransform rt = logLabel.GetComponent<RectTransform>();

		foreach (Dialogue d in dialogues)
		{
			dialogueManager.next = false;
			whichLineNow++;

			logLabel.text = logLabel.text + d.character + "\n" + d.dialogue + "\n\n";

			//background

			if (d.background == "still-006-a")
			{
				StillImage.sprite = StillSprite[0];
				StillImage.color = new Color(255, 255, 255, 255);
				DialogueBG.sprite = null;
				DialogueBG.color = new Color(0, 0, 0, 0);
				StillDialogueBG.SetActive(true);
				nameLabel.color = new Color(0, 0, 0, 255);
				Hide.SetBool("Still", true);
			}
			else if (d.background == "still-006-b")
			{
				StillImage.sprite = StillSprite[1];
				StillImage.color = new Color(255, 255, 255, 255);
				DialogueBG.sprite = null;
				DialogueBG.color = new Color(0, 0, 0, 0);
				StillDialogueBG.SetActive(true);
				nameLabel.color = new Color(0, 0, 0, 255);
				Hide.SetBool("Still", true);
			}
			else if (d.background == "still-006-c")
			{
				StillImage.sprite = StillSprite[2];
				StillImage.color = new Color(255, 255, 255, 255);
				DialogueBG.sprite = null;
				DialogueBG.color = new Color(0, 0, 0, 0);
				StillDialogueBG.SetActive(true);
				nameLabel.color = new Color(0, 0, 0, 255);
				Hide.SetBool("Still", true);
			}

			else
			{
				StillImage.color = new Color(0, 0, 0, 0);
				DialogueBG.sprite = DialogueBGImage;
				DialogueBG.color = new Color(255, 255, 255, 255);
				StillDialogueBG.SetActive(false);
				nameLabel.color = new Color(255, 255, 255, 255);
				Hide.SetBool("Still", false);
			}


			if (d.background.Contains("back-001"))
			{
				backGroundLabel.text = backgrounds[0].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[1];
			}
			else if (d.background.Contains("back-002"))
			{
				backGroundLabel.text = backgrounds[1].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[2];
			}
			else if (d.background.Contains("back-003"))
			{
				backGroundLabel.text = backgrounds[2].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[3];
			}
			else if (d.background.Contains("back-004-sun"))
			{
				backGroundLabel.text = backgrounds[5].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[4];
			}
			else if (d.background.Contains("back-004-night"))
			{
				backGroundLabel.text = backgrounds[6].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[5];
			}
			else if (d.background.Contains("back-005-sun"))
			{
				backGroundLabel.text = backgrounds[7].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[6];
			}
			else if (d.background.Contains("back-005-night"))
			{
				backGroundLabel.text = backgrounds[8].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[7];
			}
			else if (d.background.Contains("back-006"))
			{
				backGroundLabel.text = backgrounds[9].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[8];
			}
			else if (d.background.Contains("back-007"))
			{
				backGroundLabel.text = backgrounds[12].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[21];
			}
			else if (d.background.Contains("back-008"))
			{
				backGroundLabel.text = backgrounds[13].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[25];
			}
			else if (d.background.Contains("back-009"))
			{
				backGroundLabel.text = backgrounds[14].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[12];
			}

			else if (d.background.Contains("back-014"))
			{
				backGroundLabel.text = backgrounds[22].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[26];
			}
			else if (d.background.Contains("back-015-sun"))
			{
				backGroundLabel.text = backgrounds[23].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[17];
			}
			else if (d.background.Contains("back-015-night"))
			{
				backGroundLabel.text = backgrounds[24].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[16];
			}
			else if (d.background.Contains("back-013") || d.background.Contains("back-013-night"))
			{
				backGroundLabel.text = backgrounds[18].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[3];
			}
			else if (d.background.Contains("back-016"))
			{
				backGroundLabel.text = backgrounds[25].bg;
				backgroundNow.color = new Color(255, 255, 255, 255);
				backgroundNow.sprite = background[18];
			}
			else if (d.background == "暗転")
			{
				backGroundLabel.text = "暗転";
				backgroundNow.color = new Color(0, 0, 0, 255);
			}
			else
			{
				backGroundLabel.text = "";
			}

			string[] textTemp = { backGroundName, backGroundLabel.text, whichLineNow.ToString() };
			StartCoroutine("BGTextAnim", textTemp);




			//Voice
			if (autoScroll.automated == false)
			{
				if (d.voice == "V-0065")
				{
					Voice.clip = VoiceFile[0];
					Voice.Play();
				}
				else if (d.voice == "V-0067")
				{
					Voice.clip = VoiceFile[1];
					Voice.Play();
				}
				else if (d.voice == "V-0069")
				{
					Voice.clip = VoiceFile[2];
					Voice.Play();
				}
				else if (d.voice == "V-0071")
				{
					Voice.clip = VoiceFile[3];
					Voice.Play();
				}
				else if (d.voice == "V-0072")
				{
					Voice.clip = VoiceFile[4];
					Voice.Play();
				}
				else if (d.voice == "V-0074")
				{
					Voice.clip = VoiceFile[5];
					Voice.Play();
				}
				else if (d.voice == "V-0076")
				{
					Voice.clip = VoiceFile[6];
					Voice.Play();
				}
				else if (d.voice == "V-0077")
				{
					Voice.clip = VoiceFile[7];
					Voice.Play();
				}
				else if (d.voice == "V-0080")
				{
					Voice.clip = VoiceFile[8];
					Voice.Play();
				}
				else if (d.voice == "V-0083")
				{
					Voice.clip = VoiceFile[9];
					Voice.Play();
				}
				else if (d.voice == "V-0086")
				{
					Voice.clip = VoiceFile[10];
					Voice.Play();
				}
				else if (d.voice == "V-0089")
				{
					Voice.clip = VoiceFile[11];
					Voice.Play();
				}
				else if (d.voice == "V-0091")
				{
					Voice.clip = VoiceFile[12];
					Voice.Play();
				}
				else if (d.voice == "V-0092")
				{
					Voice.clip = VoiceFile[13];
					Voice.Play();
				}
				else if (d.voice == "V-0093")
				{
					Voice.clip = VoiceFile[14];
					Voice.Play();
				}
				else if (d.voice == "V-0095")
				{
					Voice.clip = VoiceFile[15];
					Voice.Play();
				}
				else if (d.voice == "V-0097")
				{
					Voice.clip = VoiceFile[16];
					Voice.Play();
				}
				else if (d.voice == "V-0099")
				{
					Voice.clip = VoiceFile[17];
					Voice.Play();
				}
				else if (d.voice == "V-0100")
				{
					Voice.clip = VoiceFile[18];
					Voice.Play();
				}
				else if (d.voice == "V-0101")
				{
					Voice.clip = VoiceFile[19];
					Voice.Play();
				}
				else if (d.voice == "V-0103")
				{
					Voice.clip = VoiceFile[20];
					Voice.Play();
				}
				else if (d.voice == "V-0105")
				{
					Voice.clip = VoiceFile[21];
					Voice.Play();
				}
				else if (d.voice == "V-0107")
				{
					Voice.clip = VoiceFile[22];
					Voice.Play();
				}
				else if (d.voice == "V-0109")
				{
					Voice.clip = VoiceFile[23];
					Voice.Play();
				}
				else if (d.voice == "V-0111")
				{
					Voice.clip = VoiceFile[24];
					Voice.Play();
				}
				else if (d.voice == "V-0115")
				{
					Voice.clip = VoiceFile[25];
					Voice.Play();
				}
				else if (d.voice == "V-0118")
				{
					Voice.clip = VoiceFile[26];
					Voice.Play();
				}
				else if (d.voice == "V-0124")
				{
					Voice.clip = VoiceFile[27];
					Voice.Play();
				}
				else if (d.voice == "V-0126")
				{
					Voice.clip = VoiceFile[28];
					Voice.Play();
				}
				else if (d.voice == "V-0133")
				{
					Voice.clip = VoiceFile[29];
					Voice.Play();
				}
				else if (d.voice == "V-0136")
				{
					Voice.clip = VoiceFile[30];
					Voice.Play();
				}
				else if (d.voice == "V-0142")
				{
					Voice.clip = VoiceFile[31];
					Voice.Play();
				}
				else if (d.voice == "V-0144")
				{
					Voice.clip = VoiceFile[32];
					Voice.Play();
				}
				else if (d.voice == "V-0148")
				{
					Voice.clip = VoiceFile[33];
					Voice.Play();
				}
				else if (d.voice == "V-0150")
				{
					Voice.clip = VoiceFile[34];
					Voice.Play();
				}
				else if (d.voice == "V-0152")
				{
					Voice.clip = VoiceFile[35];
					Voice.Play();
				}
				else if (d.voice == "V-0153")
				{
					Voice.clip = VoiceFile[36];
					Voice.Play();
				}
				else if (d.voice == "V-0155")
				{
					Voice.clip = VoiceFile[37];
					Voice.Play();
				}
				else if (d.voice == "V-0158")
				{
					Voice.clip = VoiceFile[38];
					Voice.Play();
				}
				else if (d.voice == "V-0161")
				{
					Voice.clip = VoiceFile[39];
					Voice.Play();
				}
				else if (d.voice == "V-0172")
				{
					Voice.clip = VoiceFile[40];
					Voice.Play();
				}
				else if (d.voice == "V-0186")
				{
					Voice.clip = VoiceFile[41];
					Voice.Play();
				}
				else if (d.voice == "V-0189")
				{
					Voice.clip = VoiceFile[42];
					Voice.Play();
				}
				else if (d.voice == "V-0191")
				{
					Voice.clip = VoiceFile[43];
					Voice.Play();
				}
				else if (d.voice == "V-0192")
				{
					Voice.clip = VoiceFile[44];
					Voice.Play();
				}
				else if (d.voice == "V-0194")
				{
					Voice.clip = VoiceFile[45];
					Voice.Play();
				}
				else if (d.voice == "V-0196")
				{
					Voice.clip = VoiceFile[46];
					Voice.Play();
				}
				else if (d.voice == "V-0197")
				{
					Voice.clip = VoiceFile[47];
					Voice.Play();
				}
				else if (d.voice == "V-0199")
				{
					Voice.clip = VoiceFile[48];
					Voice.Play();
				}
				else if (d.voice == "V-0204")
				{
					Voice.clip = VoiceFile[49];
					Voice.Play();
				}
				else if (d.voice == "V-0206")
				{
					Voice.clip = VoiceFile[50];
					Voice.Play();
				}
				else if (d.voice == "V-0207")
				{
					Voice.clip = VoiceFile[51];
					Voice.Play();
				}
				else if (d.voice == "V-0209")
				{
					Voice.clip = VoiceFile[52];
					Voice.Play();
				}
				else if (d.voice == "V-0211")
				{
					Voice.clip = VoiceFile[53];
					Voice.Play();
				}
				else if (d.voice == "V-0213")
				{
					Voice.clip = VoiceFile[54];
					Voice.Play();
				}
				else if (d.voice == "V-0214")
				{
					Voice.clip = VoiceFile[55];
					Voice.Play();
				}
				else if (d.voice == "V-0216")
				{
					Voice.clip = VoiceFile[56];
					Voice.Play();
				}
				else if (d.voice == "V-0217")
				{
					Voice.clip = VoiceFile[57];
					Voice.Play();
				}
				else if (d.voice == "V-0218")
				{
					Voice.clip = VoiceFile[58];
					Voice.Play();
				}
				else if (d.voice == "V-0220")
				{
					Voice.clip = VoiceFile[59];
					Voice.Play();
				}
				else if (d.voice == "V-0221")
				{
					Voice.clip = VoiceFile[60];
					Voice.Play();
				}
				else if (d.voice == "V-0225")
				{
					Voice.clip = VoiceFile[61];
					Voice.Play();
				}
				else if (d.voice == "V-0227")
				{
					Voice.clip = VoiceFile[62];
					Voice.Play();
				}
				else if (d.voice == "V-0228")
				{
					Voice.clip = VoiceFile[63];
					Voice.Play();
				}
				else if (d.voice == "V-0229")
				{
					Voice.clip = VoiceFile[64];
					Voice.Play();
				}
				else if (d.voice == "V-0231")
				{
					Voice.clip = VoiceFile[65];
					Voice.Play();
				}
				else if (d.voice == "V-0232")
				{
					Voice.clip = VoiceFile[66];
					Voice.Play();
				}
				else if (d.voice == "V-0237")
				{
					Voice.clip = VoiceFile[67];
					Voice.Play();
				}
				else if (d.voice == "V-0240")
				{
					Voice.clip = VoiceFile[68];
					Voice.Play();
				}
				else if (d.voice == "V-0242")
				{
					Voice.clip = VoiceFile[69];
					Voice.Play();
				}
				else if (d.voice == "V-0244")
				{
					Voice.clip = VoiceFile[70];
					Voice.Play();
				}
				else if (d.voice == "V-0245")
				{
					Voice.clip = VoiceFile[71];
					Voice.Play();
				}
				else if (d.voice == "V-0248")
				{
					Voice.clip = VoiceFile[72];
					Voice.Play();
				}
				else if (d.voice == "V-0250")
				{
					Voice.clip = VoiceFile[73];
					Voice.Play();
				}
				else if (d.voice == "V-0257")
				{
					Voice.clip = VoiceFile[74];
					Voice.Play();
				}
				else if (d.voice == "V-0259")
				{
					Voice.clip = VoiceFile[75];
					Voice.Play();
				}
				else if (d.voice == "V-0263")
				{
					Voice.clip = VoiceFile[76];
					Voice.Play();
				}
				else if (d.voice == "V-0265")
				{
					Voice.clip = VoiceFile[77];
					Voice.Play();
				}
				else if (d.voice == "V-0269")
				{
					Voice.clip = VoiceFile[78];
					Voice.Play();
				}
				else if (d.voice == "V-0271")
				{
					Voice.clip = VoiceFile[79];
					Voice.Play();
				}
				else if (d.voice == "V-0274")
				{
					Voice.clip = VoiceFile[80];
					Voice.Play();
				}
				else if (d.voice == "V-0278")
				{
					Voice.clip = VoiceFile[81];
					Voice.Play();
				}
				else if (d.voice == "V-0280")
				{
					Voice.clip = VoiceFile[82];
					Voice.Play();
				}
				else if (d.voice == "V-0281")
				{
					Voice.clip = VoiceFile[83];
					Voice.Play();
				}
				else if (d.voice == "V-0283")
				{
					Voice.clip = VoiceFile[84];
					Voice.Play();
				}
				else if (d.voice == "V-0286")
				{
					Voice.clip = VoiceFile[85];
					Voice.Play();
				}
				else if (d.voice == "V-0290")
				{
					Voice.clip = VoiceFile[86];
					Voice.Play();
				}
				else if (d.voice == "V-0294")
				{
					Voice.clip = VoiceFile[87];
					Voice.Play();
				}
				else if (d.voice == "V-0296")
				{
					Voice.clip = VoiceFile[88];
					Voice.Play();
				}
				else if (d.voice == "V-0298")
				{
					Voice.clip = VoiceFile[89];
					Voice.Play();
				}
				else if (d.voice == "V-0300")
				{
					Voice.clip = VoiceFile[90];
					Voice.Play();
				}
				else if (d.voice == "V-0302")
				{
					Voice.clip = VoiceFile[91];
					Voice.Play();
				}
				else if (d.voice == "V-0303")
				{
					Voice.clip = VoiceFile[92];
					Voice.Play();
				}
				else if (d.voice == "V-0304")
				{
					Voice.clip = VoiceFile[93];
					Voice.Play();
				}
				else if (d.voice == "V-0308")
				{
					Voice.clip = VoiceFile[94];
					Voice.Play();
				}
				else if (d.voice == "V-0314")
				{
					Voice.clip = VoiceFile[95];
					Voice.Play();
				}
				else if (d.voice == "V-0316")
				{
					Voice.clip = VoiceFile[96];
					Voice.Play();
				}
				else if (d.voice == "V-0318")
				{
					Voice.clip = VoiceFile[97];
					Voice.Play();
				}
				else if (d.voice == "V-0320")
				{
					Voice.clip = VoiceFile[98];
					Voice.Play();
				}
				else if (d.voice == "V-0322")
				{
					Voice.clip = VoiceFile[99];
					Voice.Play();
				}
				else if (d.voice == "V-0324")
				{
					Voice.clip = VoiceFile[100];
					Voice.Play();
				}
				else if (d.voice == "V-0326")
				{
					Voice.clip = VoiceFile[101];
					Voice.Play();
				}
				else if (d.voice == "V-0328")
				{
					Voice.clip = VoiceFile[102];
					Voice.Play();
				}
				else if (d.voice == "V-0330")
				{
					Voice.clip = VoiceFile[103];
					Voice.Play();
				}
				else if (d.voice == "V-0332")
				{
					Voice.clip = VoiceFile[104];
					Voice.Play();
				}
				else if (d.voice == "V-0333")
				{
					Voice.clip = VoiceFile[105];
					Voice.Play();
				}
				else if (d.voice == "V-0335")
				{
					Voice.clip = VoiceFile[106];
					Voice.Play();
				}
				else if (d.voice == "V-0337")
				{
					Voice.clip = VoiceFile[107];
					Voice.Play();
				}
				else if (d.voice == "V-0342")
				{
					Voice.clip = VoiceFile[108];
					Voice.Play();
				}
				else if (d.voice == "V-0344")
				{
					Voice.clip = VoiceFile[109];
					Voice.Play();
				}
				else if (d.voice == "V-0345")
				{
					Voice.clip = VoiceFile[110];
					Voice.Play();
				}
				else if (d.voice == "V-0347")
				{
					Voice.clip = VoiceFile[111];
					Voice.Play();
				}
				else if (d.voice == "V-0350")
				{
					Voice.clip = VoiceFile[112];
					Voice.Play();
				}
				else if (d.voice == "V-0352")
				{
					Voice.clip = VoiceFile[113];
					Voice.Play();
				}
				else if (d.voice == "V-0354")
				{
					Voice.clip = VoiceFile[114];
					Voice.Play();
				}
				else if (d.voice == "V-0357")
				{
					Voice.clip = VoiceFile[115];
					Voice.Play();
				}
				else if (d.voice == "V-0358")
				{
					Voice.clip = VoiceFile[116];
					Voice.Play();
				}
				else if (d.voice == "V-0360")
				{
					Voice.clip = VoiceFile[117];
					Voice.Play();
				}
				else if (d.voice == "V-0362")
				{
					Voice.clip = VoiceFile[118];
					Voice.Play();
				}
				else if (d.voice == "V-0364")
				{
					Voice.clip = VoiceFile[119];
					Voice.Play();
				}
				else if (d.voice == "V-0366")
				{
					Voice.clip = VoiceFile[120];
					Voice.Play();
				}
				else if (d.voice == "V-0370")
				{
					Voice.clip = VoiceFile[121];
					Voice.Play();
				}
				else if (d.voice == "V-0372")
				{
					Voice.clip = VoiceFile[122];
					Voice.Play();
				}
				else if (d.voice == "V-0374")
				{
					Voice.clip = VoiceFile[123];
					Voice.Play();
				}
				else if (d.voice == "V-0376")
				{
					Voice.clip = VoiceFile[124];
					Voice.Play();
				}
				else if (d.voice == "V-0380")
				{
					Voice.clip = VoiceFile[125];
					Voice.Play();
				}
				else if (d.voice == "V-0382")
				{
					Voice.clip = VoiceFile[126];
					Voice.Play();
				}
				else if (d.voice == "V-0384")
				{
					Voice.clip = VoiceFile[127];
					Voice.Play();
				}
				else if (d.voice == "V-0386")
				{
					Voice.clip = VoiceFile[128];
					Voice.Play();
				}
				else if (d.voice == "V-0388")
				{
					Voice.clip = VoiceFile[129];
					Voice.Play();
				}
				else if (d.voice == "V-0390")
				{
					Voice.clip = VoiceFile[130];
					Voice.Play();
				}
				else if (d.voice == "V-0393")
				{
					Voice.clip = VoiceFile[131];
					Voice.Play();
				}
				else if (d.voice == "V-0395")
				{
					Voice.clip = VoiceFile[132];
					Voice.Play();
				}
				else if (d.voice == "V-0397")
				{
					Voice.clip = VoiceFile[133];
					Voice.Play();
				}
				else if (d.voice == "V-0398")
				{
					Voice.clip = VoiceFile[134];
					Voice.Play();
				}
				else if (d.voice == "V-0399")
				{
					Voice.clip = VoiceFile[135];
					Voice.Play();
				}
				else if (d.voice == "V-0405")
				{
					Voice.clip = VoiceFile[136];
					Voice.Play();
				}
				else if (d.voice == "V-0407")
				{
					Voice.clip = VoiceFile[137];
					Voice.Play();
				}
				else if (d.voice == "V-0409")
				{
					Voice.clip = VoiceFile[138];
					Voice.Play();
				}
				else if (d.voice == "V-0411")
				{
					Voice.clip = VoiceFile[139];
					Voice.Play();
				}
				else if (d.voice == "V-0413")
				{
					Voice.clip = VoiceFile[140];
					Voice.Play();
				}
				else if (d.voice == "V-0415")
				{
					Voice.clip = VoiceFile[141];
					Voice.Play();
				}
				else if (d.voice == "V-0417")
				{
					Voice.clip = VoiceFile[142];
					Voice.Play();
				}
				else if (d.voice == "V-0419")
				{
					Voice.clip = VoiceFile[143];
					Voice.Play();
				}
				else if (d.voice == "V-0424")
				{
					Voice.clip = VoiceFile[144];
					Voice.Play();
				}
				else if (d.voice == "V-0426")
				{
					Voice.clip = VoiceFile[145];
					Voice.Play();
				}
				else if (d.voice == "V-0428")
				{
					Voice.clip = VoiceFile[146];
					Voice.Play();
				}
				else if (d.voice == "V-0430")
				{
					Voice.clip = VoiceFile[147];
					Voice.Play();
				}
				else if (d.voice == "V-0432")
				{
					Voice.clip = VoiceFile[148];
					Voice.Play();
				}
				else if (d.voice == "V-0434")
				{
					Voice.clip = VoiceFile[149];
					Voice.Play();
				}
				else if (d.voice == "V-0437")
				{
					Voice.clip = VoiceFile[150];
					Voice.Play();
				}
				else if (d.voice == "V-0439")
				{
					Voice.clip = VoiceFile[151];
					Voice.Play();
				}
				else if (d.voice == "V-0442")
				{
					Voice.clip = VoiceFile[152];
					Voice.Play();
				}
				else if (d.voice == "V-0444")
				{
					Voice.clip = VoiceFile[153];
					Voice.Play();
				}
				else if (d.voice == "V-0445")
				{
					Voice.clip = VoiceFile[154];
					Voice.Play();
				}
				else if (d.voice == "V-0447")
				{
					Voice.clip = VoiceFile[155];
					Voice.Play();
				}
				else if (d.voice == "V-0451")
				{
					Voice.clip = VoiceFile[156];
					Voice.Play();
				}
				else if (d.voice == "V-0453")
				{
					Voice.clip = VoiceFile[157];
					Voice.Play();
				}
				else if (d.voice == "V-0455")
				{
					Voice.clip = VoiceFile[158];
					Voice.Play();
				}
				else if (d.voice == "V-0457")
				{
					Voice.clip = VoiceFile[159];
					Voice.Play();
				}
				else if (d.voice == "V-0458")
				{
					Voice.clip = VoiceFile[160];
					Voice.Play();
				}
				else if (d.voice == "V-0460")
				{
					Voice.clip = VoiceFile[161];
					Voice.Play();
				}
				else if (d.voice == "V-0462")
				{
					Voice.clip = VoiceFile[162];
					Voice.Play();
				}
				else if (d.voice == "V-0464")
				{
					Voice.clip = VoiceFile[163];
					Voice.Play();
				}
				else if (d.voice == "V-0465")
				{
					Voice.clip = VoiceFile[164];
					Voice.Play();
				}
				else if (d.voice == "V-0468")
				{
					Voice.clip = VoiceFile[165];
					Voice.Play();
				}
				else if (d.voice == "V-0470")
				{
					Voice.clip = VoiceFile[166];
					Voice.Play();
				}
				else if (d.voice == "V-0472")
				{
					Voice.clip = VoiceFile[167];
					Voice.Play();
				}
				else if (d.voice == "V-0474")
				{
					Voice.clip = VoiceFile[168];
					Voice.Play();
				}
				else if (d.voice == "V-0476")
				{
					Voice.clip = VoiceFile[169];
					Voice.Play();
				}
				else if (d.voice == "V-0477")
				{
					Voice.clip = VoiceFile[170];
					Voice.Play();
				}
				else if (d.voice == "V-0479")
				{
					Voice.clip = VoiceFile[171];
					Voice.Play();
				}
				else if (d.voice == "V-0480")
				{
					Voice.clip = VoiceFile[172];
					Voice.Play();
				}
				else if (d.voice == "V-0482")
				{
					Voice.clip = VoiceFile[173];
					Voice.Play();
				}
				else if (d.voice == "V-0484")
				{
					Voice.clip = VoiceFile[174];
					Voice.Play();
				}
				else if (d.voice == "V-0486")
				{
					Voice.clip = VoiceFile[175];
					Voice.Play();
				}
				else if (d.voice == "V-0488")
				{
					Voice.clip = VoiceFile[176];
					Voice.Play();
				}
				else if (d.voice == "V-0490")
				{
					Voice.clip = VoiceFile[177];
					Voice.Play();
				}
				else if (d.voice == "V-0491")
				{
					Voice.clip = VoiceFile[178];
					Voice.Play();
				}
				else if (d.voice == "V-0493")
				{
					Voice.clip = VoiceFile[179];
					Voice.Play();
				}
				else if (d.voice == "V-0494")
				{
					Voice.clip = VoiceFile[180];
					Voice.Play();
				}
				else if (d.voice == "V-0496")
				{
					Voice.clip = VoiceFile[181];
					Voice.Play();
				}
				else if (d.voice == "V-0498")
				{
					Voice.clip = VoiceFile[182];
					Voice.Play();
				}
				else if (d.voice == "V-0500")
				{
					Voice.clip = VoiceFile[183];
					Voice.Play();
				}
				else if (d.voice == "V-0501")
				{
					Voice.clip = VoiceFile[184];
					Voice.Play();
				}
				else if (d.voice == "V-0503")
				{
					Voice.clip = VoiceFile[185];
					Voice.Play();
				}
				else if (d.voice == "V-0505")
				{
					Voice.clip = VoiceFile[186];
					Voice.Play();
				}
				else if (d.voice == "V-0507")
				{
					Voice.clip = VoiceFile[187];
					Voice.Play();
				}
				else if (d.voice == "V-0509")
				{
					Voice.clip = VoiceFile[188];
					Voice.Play();
				}
				else if (d.voice == "V-0510")
				{
					Voice.clip = VoiceFile[189];
					Voice.Play();
				}
				else if (d.voice == "V-0512")
				{
					Voice.clip = VoiceFile[190];
					Voice.Play();
				}
				else if (d.voice == "V-0519")
				{
					Voice.clip = VoiceFile[191];
					Voice.Play();
				}
				else if (d.voice == "V-0526")
				{
					Voice.clip = VoiceFile[192];
					Voice.Play();
				}
				else if (d.voice == "V-0529")
				{
					Voice.clip = VoiceFile[193];
					Voice.Play();
				}
				else if (d.voice == "V-0531")
				{
					Voice.clip = VoiceFile[194];
					Voice.Play();
				}
				else if (d.voice == "V-0534")
				{
					Voice.clip = VoiceFile[195];
					Voice.Play();
				}
				else if (d.voice == "V-0536")
				{
					Voice.clip = VoiceFile[196];
					Voice.Play();
				}
				else if (d.voice == "V-0538")
				{
					Voice.clip = VoiceFile[197];
					Voice.Play();
				}
				else if (d.voice == "V-0539")
				{
					Voice.clip = VoiceFile[198];
					Voice.Play();
				}
				else if (d.voice == "V-0541")
				{
					Voice.clip = VoiceFile[199];
					Voice.Play();
				}
				else if (d.voice == "V-0542")
				{
					Voice.clip = VoiceFile[200];
					Voice.Play();
				}
				else if (d.voice == "V-0544")
				{
					Voice.clip = VoiceFile[201];
					Voice.Play();
				}
				else if (d.voice == "V-0546")
				{
					Voice.clip = VoiceFile[202];
					Voice.Play();
				}
				else if (d.voice == "V-0549")
				{
					Voice.clip = VoiceFile[203];
					Voice.Play();
				}
				else if (d.voice == "V-0551")
				{
					Voice.clip = VoiceFile[204];
					Voice.Play();
				}
				else if (d.voice == "V-0553")
				{
					Voice.clip = VoiceFile[205];
					Voice.Play();
				}
				else if (d.voice == "V-0555")
				{
					Voice.clip = VoiceFile[206];
					Voice.Play();
				}
				else if (d.voice == "V-0558")
				{
					Voice.clip = VoiceFile[207];
					Voice.Play();
				}
				else if (d.voice == "V-0560")
				{
					Voice.clip = VoiceFile[208];
					Voice.Play();
				}
				else if (d.voice == "V-0562")
				{
					Voice.clip = VoiceFile[209];
					Voice.Play();
				}
				else if (d.voice == "V-0564")
				{
					Voice.clip = VoiceFile[210];
					Voice.Play();
				}
				else if (d.voice == "V-0568")
				{
					Voice.clip = VoiceFile[211];
					Voice.Play();
				}
				else if (d.voice == "V-0570")
				{
					Voice.clip = VoiceFile[212];
					Voice.Play();
				}
				else if (d.voice == "V-0572")
				{
					Voice.clip = VoiceFile[213];
					Voice.Play();
				}
				else if (d.voice == "V-0574")
				{
					Voice.clip = VoiceFile[214];
					Voice.Play();
				}
				else if (d.voice == "V-0576")
				{
					Voice.clip = VoiceFile[215];
					Voice.Play();
				}
				else if (d.voice == "V-0580")
				{
					Voice.clip = VoiceFile[216];
					Voice.Play();
				}
				else if (d.voice == "V-0581")
				{
					Voice.clip = VoiceFile[217];
					Voice.Play();
				}
				else if (d.voice == "V-0584")
				{
					Voice.clip = VoiceFile[218];
					Voice.Play();
				}
				else if (d.voice == "V-0586")
				{
					Voice.clip = VoiceFile[219];
					Voice.Play();
				}
				else if (d.voice == "V-0588")
				{
					Voice.clip = VoiceFile[220];
					Voice.Play();
				}
				else if (d.voice == "V-0591")
				{
					Voice.clip = VoiceFile[221];
					Voice.Play();
				}
				else if (d.voice == "V-0593")
				{
					Voice.clip = VoiceFile[222];
					Voice.Play();
				}
				else if (d.voice == "V-0595")
				{
					Voice.clip = VoiceFile[223];
					Voice.Play();
				}
				else if (d.voice == "V-0597")
				{
					Voice.clip = VoiceFile[224];
					Voice.Play();
				}
				else if (d.voice == "V-0599")
				{
					Voice.clip = VoiceFile[225];
					Voice.Play();
				}
				else if (d.voice == "V-0601")
				{
					Voice.clip = VoiceFile[226];
					Voice.Play();
				}
				else if (d.voice == "V-0606")
				{
					Voice.clip = VoiceFile[227];
					Voice.Play();
				}
				else if (d.voice == "V-0608")
				{
					Voice.clip = VoiceFile[228];
					Voice.Play();
				}
				else if (d.voice == "V-0613")
				{
					Voice.clip = VoiceFile[229];
					Voice.Play();
				}
				else if (d.voice == "V-0615")
				{
					Voice.clip = VoiceFile[230];
					Voice.Play();
				}
				else if (d.voice == "V-0617")
				{
					Voice.clip = VoiceFile[231];
					Voice.Play();
				}
				else if (d.voice == "V-0619")
				{
					Voice.clip = VoiceFile[232];
					Voice.Play();
				}
				else if (d.voice == "V-0621")
				{
					Voice.clip = VoiceFile[233];
					Voice.Play();
				}
				else if (d.voice == "V-0623")
				{
					Voice.clip = VoiceFile[234];
					Voice.Play();
				}
				else if (d.voice == "V-0626")
				{
					Voice.clip = VoiceFile[235];
					Voice.Play();
				}
				else if (d.voice == "V-0628")
				{
					Voice.clip = VoiceFile[236];
					Voice.Play();
				}
				else if (d.voice == "V-0630")
				{
					Voice.clip = VoiceFile[237];
					Voice.Play();
				}
				else if (d.voice == "V-0632")
				{
					Voice.clip = VoiceFile[238];
					Voice.Play();
				}
				else if (d.voice == "V-0634")
				{
					Voice.clip = VoiceFile[239];
					Voice.Play();
				}
				else if (d.voice == "V-0637")
				{
					Voice.clip = VoiceFile[240];
					Voice.Play();
				}
				else if (d.voice == "V-0639")
				{
					Voice.clip = VoiceFile[241];
					Voice.Play();
				}
				else if (d.voice == "V-0642")
				{
					Voice.clip = VoiceFile[242];
					Voice.Play();
				}
				else if (d.voice == "V-0644")
				{
					Voice.clip = VoiceFile[243];
					Voice.Play();
				}
				else if (d.voice == "V-0646")
				{
					Voice.clip = VoiceFile[244];
					Voice.Play();
				}
				else if (d.voice == "V-0648")
				{
					Voice.clip = VoiceFile[245];
					Voice.Play();
				}
				else if (d.voice == "V-0650")
				{
					Voice.clip = VoiceFile[246];
					Voice.Play();
				}
				else if (d.voice == "V-0652")
				{
					Voice.clip = VoiceFile[247];
					Voice.Play();
				}
				else if (d.voice == "V-0654")
				{
					Voice.clip = VoiceFile[248];
					Voice.Play();
				}
				else if (d.voice == "V-0656")
				{
					Voice.clip = VoiceFile[249];
					Voice.Play();
				}
				else if (d.voice == "V-0657")
				{
					Voice.clip = VoiceFile[250];
					Voice.Play();
				}
				else if (d.voice == "V-0659")
				{
					Voice.clip = VoiceFile[251];
					Voice.Play();
				}
				else if (d.voice == "V-0661")
				{
					Voice.clip = VoiceFile[252];
					Voice.Play();
				}
				else if (d.voice == "V-0687")
				{
					Voice.clip = VoiceFile[253];
					Voice.Play();
				}
				else if (d.voice == "V-0690")
				{
					Voice.clip = VoiceFile[254];
					Voice.Play();
				}
				else if (d.voice == "V-0692")
				{
					Voice.clip = VoiceFile[255];
					Voice.Play();
				}
				else if (d.voice == "V-0694")
				{
					Voice.clip = VoiceFile[256];
					Voice.Play();
				}
				else if (d.voice == "V-0697")
				{
					Voice.clip = VoiceFile[257];
					Voice.Play();
				}
				else if (d.voice == "V-0699")
				{
					Voice.clip = VoiceFile[258];
					Voice.Play();
				}
				else if (d.voice == "V-0703")
				{
					Voice.clip = VoiceFile[259];
					Voice.Play();
				}
				else if (d.voice == "V-0705")
				{
					Voice.clip = VoiceFile[260];
					Voice.Play();
				}
				else if (d.voice == "V-0709")
				{
					Voice.clip = VoiceFile[261];
					Voice.Play();
				}
				else if (d.voice == "V-0711")
				{
					Voice.clip = VoiceFile[262];
					Voice.Play();
				}
				else if (d.voice == "V-0714")
				{
					Voice.clip = VoiceFile[263];
					Voice.Play();
				}
				else if (d.voice == "V-0716")
				{
					Voice.clip = VoiceFile[264];
					Voice.Play();
				}
				else if (d.voice == "V-0719")
				{
					Voice.clip = VoiceFile[265];
					Voice.Play();
				}
				else if (d.voice == "V-0721")
				{
					Voice.clip = VoiceFile[266];
					Voice.Play();
				}
				else if (d.voice == "V-0723")
				{
					Voice.clip = VoiceFile[267];
					Voice.Play();
				}
				else if (d.voice == "V-0725")
				{
					Voice.clip = VoiceFile[268];
					Voice.Play();
				}
				else if (d.voice == "V-0727")
				{
					Voice.clip = VoiceFile[269];
					Voice.Play();
				}
				else if (d.voice == "V-0730")
				{
					Voice.clip = VoiceFile[270];
					Voice.Play();
				}
				else if (d.voice == "V-0732")
				{
					Voice.clip = VoiceFile[271];
					Voice.Play();
				}
				else if (d.voice == "V-0734")
				{
					Voice.clip = VoiceFile[272];
					Voice.Play();
				}
				else if (d.voice == "V-0735")
				{
					Voice.clip = VoiceFile[273];
					Voice.Play();
				}
				else if (d.voice == "V-0736")
				{
					Voice.clip = VoiceFile[274];
					Voice.Play();
				}
				else if (d.voice == "V-0737")
				{
					Voice.clip = VoiceFile[275];
					Voice.Play();
				}
				else if (d.voice == "V-0739")
				{
					Voice.clip = VoiceFile[276];
					Voice.Play();
				}
				else if (d.voice == "V-0741")
				{
					Voice.clip = VoiceFile[277];
					Voice.Play();
				}
				else if (d.voice == "V-0743")
				{
					Voice.clip = VoiceFile[278];
					Voice.Play();
				}
				else if (d.voice == "V-0745")
				{
					Voice.clip = VoiceFile[279];
					Voice.Play();
				}
				else if (d.voice == "V-0746")
				{
					Voice.clip = VoiceFile[280];
					Voice.Play();
				}
				else if (d.voice == "V-0750")
				{
					Voice.clip = VoiceFile[281];
					Voice.Play();
				}
				else if (d.voice == "V-0752")
				{
					Voice.clip = VoiceFile[282];
					Voice.Play();
				}
				else if (d.voice == "V-0754")
				{
					Voice.clip = VoiceFile[283];
					Voice.Play();
				}
				else if (d.voice == "V-0757")
				{
					Voice.clip = VoiceFile[284];
					Voice.Play();
				}
				else if (d.voice == "V-0759")
				{
					Voice.clip = VoiceFile[285];
					Voice.Play();
				}
				else if (d.voice == "V-0761")
				{
					Voice.clip = VoiceFile[286];
					Voice.Play();
				}
				else if (d.voice == "V-0762")
				{
					Voice.clip = VoiceFile[287];
					Voice.Play();
				}
				else if (d.voice == "V-0767")
				{
					Voice.clip = VoiceFile[288];
					Voice.Play();
				}
				else if (d.voice == "V-0771")
				{
					Voice.clip = VoiceFile[289];
					Voice.Play();
				}
				else if (d.voice == "V-0774")
				{
					Voice.clip = VoiceFile[290];
					Voice.Play();
				}
				else if (d.voice == "V-0775")
				{
					Voice.clip = VoiceFile[291];
					Voice.Play();
				}
				else if (d.voice == "V-0777")
				{
					Voice.clip = VoiceFile[292];
					Voice.Play();
				}
				else if (d.voice == "V-0780")
				{
					Voice.clip = VoiceFile[293];
					Voice.Play();
				}
				else if (d.voice == "V-0782")
				{
					Voice.clip = VoiceFile[294];
					Voice.Play();
				}
				else if (d.voice == "V-0785")
				{
					Voice.clip = VoiceFile[295];
					Voice.Play();
				}
				else if (d.voice == "V-0787")
				{
					Voice.clip = VoiceFile[296];
					Voice.Play();
				}
				else if (d.voice == "V-0791")
				{
					Voice.clip = VoiceFile[297];
					Voice.Play();
				}
				else if (d.voice == "V-0792")
				{
					Voice.clip = VoiceFile[298];
					Voice.Play();
				}
				else if (d.voice == "V-0799")
				{
					Voice.clip = VoiceFile[299];
					Voice.Play();
				}
				else if (d.voice == "V-0800")
				{
					Voice.clip = VoiceFile[300];
					Voice.Play();
				}
				else if (d.voice == "V-0801")
				{
					Voice.clip = VoiceFile[301];
					Voice.Play();
				}
				else if (d.voice == "V-0802")
				{
					Voice.clip = VoiceFile[302];
					Voice.Play();
				}
				else if (d.voice == "V-0803")
				{
					Voice.clip = VoiceFile[303];
					Voice.Play();
				}
				else if (d.voice == "V-0804")
				{
					Voice.clip = VoiceFile[304];
					Voice.Play();
				}
				else if (d.voice == "V-0805")
				{
					Voice.clip = VoiceFile[305];
					Voice.Play();
				}
				else if (d.voice == "V-0806")
				{
					Voice.clip = VoiceFile[306];
					Voice.Play();
				}
				else if (d.voice == "V-0807")
				{
					Voice.clip = VoiceFile[307];
					Voice.Play();
				}
				else if (d.voice == "V-0808")
				{
					Voice.clip = VoiceFile[308];
					Voice.Play();
				}
				else if (d.voice == "V-0809")
				{
					Voice.clip = VoiceFile[309];
					Voice.Play();
				}
				else if (d.voice == "V-0810")
				{
					Voice.clip = VoiceFile[310];
					Voice.Play();
				}
				else if (d.voice == "V-0811")
				{
					Voice.clip = VoiceFile[311];
					Voice.Play();
				}
				else if (d.voice == "V-0812")
				{
					Voice.clip = VoiceFile[312];
					Voice.Play();
				}
				else if (d.voice == "V-0813")
				{
					Voice.clip = VoiceFile[313];
					Voice.Play();
				}
				else if (d.voice == "V-0604")
				{
					Voice.clip = VoiceFile[314];
					Voice.Play();
				}



				else
				{
					Voice.Stop();
				}
			}
			else
			{
				Voice.Stop();
			}

			bool blankAnim = BustUpAnim.GetBool("isBlank");
			//character body
			if (d.expression == "")
			{
				BustUpAnim.SetBool("isBlank", true);
			}
			if (d.expression.Contains("L-01") || d.expression.Contains("L-01a") ||
				d.expression.Contains("L-01b") || d.expression.Contains("L-02") ||
				d.expression.Contains("L-02a") || d.expression.Contains("L-03") ||
				d.expression.Contains("L-04") || d.expression.Contains("L-05") ||
				d.expression.Contains("L-05a") || d.expression.Contains("L-06") ||
				d.expression.Contains("L-06a") || d.expression.Contains("L-07") ||
				d.expression.Contains("L-07a") || d.expression.Contains("L-08") ||
				d.expression.Contains("L-10") || d.expression.Contains("L-01-ragan") ||
				d.expression.Contains("L-10a"))
			{
				if (blankAnim == true)
				{
					BustUpAnim.SetBool("isBlank", false);
					charaImageNow.color = new Color(255, 255, 255, 255);
					EyeNow.color = new Color(255, 255, 255, 255);
					MouthNow.color = new Color(255, 255, 255, 255);
					yield return new WaitForSeconds(1.5f);
				}
				charaImageNow.sprite = charaImage[0];
			}

			else if (d.expression.Contains("L-09"))
			{
				if (blankAnim == true)
				{
					BustUpAnim.SetBool("isBlank", false);
					charaImageNow.color = new Color(255, 255, 255, 255);
					EyeNow.color = new Color(255, 255, 255, 255);
					MouthNow.color = new Color(255, 255, 255, 255);
					yield return new WaitForSeconds(1.5f);
				}
				charaImageNow.sprite = charaImage[4];
			}

			else if (d.expression.Contains("K-01") || d.expression.Contains("K-02") ||
				d.expression.Contains("K-02a") || d.expression.Contains("K-03") ||
				d.expression.Contains("K-04") || d.expression.Contains("K-05") ||
				d.expression.Contains("K-06") || d.expression.Contains("K-07") ||
				d.expression.Contains("K-08") || d.expression.Contains("K-09") ||
				d.expression.Contains("K-09a") || d.expression.Contains("K-10") ||
				d.expression.Contains("K-11"))
			{
				if (blankAnim == true)
				{
					BustUpAnim.SetBool("isBlank", false);
					charaImageNow.color = new Color(255, 255, 255, 255);
					EyeNow.color = new Color(255, 255, 255, 255);
					MouthNow.color = new Color(255, 255, 255, 255);
					yield return new WaitForSeconds(1.5f);
				}
				charaImageNow.sprite = charaImage[1];
			}

			else if (d.expression.Contains("T-01") || d.expression.Contains("T-02") ||
				d.expression.Contains("T-03") || d.expression.Contains("T-03a") ||
				d.expression.Contains("T-04"))
			{
				if (blankAnim == true)
				{
					BustUpAnim.SetBool("isBlank", false);
					charaImageNow.color = new Color(255, 255, 255, 255);
					EyeNow.color = new Color(255, 255, 255, 255);
					MouthNow.color = new Color(255, 255, 255, 255);
					yield return new WaitForSeconds(1.5f);
				}
				charaImageNow.sprite = charaImage[2];
			}
			else if (d.expression.Contains("G-01") || d.expression.Contains("G-02") ||
				d.expression.Contains("G-03") || d.expression.Contains("G-04") ||
				d.expression.Contains("G-05") || d.expression.Contains("G-06") ||
				d.expression.Contains("G-07"))
			{
				if (blankAnim == true)
				{
					BustUpAnim.SetBool("isBlank", false);
					charaImageNow.color = new Color(255, 255, 255, 255);
					EyeNow.color = new Color(255, 255, 255, 255);
					MouthNow.color = new Color(255, 255, 255, 255);
					yield return new WaitForSeconds(1.5f);
				}
				charaImageNow.sprite = charaImage[3];
			}
			else
			{
				BustUpAnim.SetBool("isBlank", true);

				charaImageNow.color = new Color(0, 0, 0, 0);

				EyeNow.color = new Color(0, 0, 0, 0);

				MouthNow.color = new Color(0, 0, 0, 0);
			}

			//left chara
			if (d.showtwoone == "")
			{
				charaImageNow1.color = new Color(0, 0, 0, 0);
				EyeNow1.color = new Color(0, 0, 0, 0);
				MouthNow1.color = new Color(0, 0, 0, 0);
			}
			if (d.showtwoone.Contains("L-01") || d.showtwoone.Contains("L-01a") ||
				d.showtwoone.Contains("L-01b") || d.showtwoone.Contains("L-02") ||
				d.showtwoone.Contains("L-02a") || d.showtwoone.Contains("L-03") ||
				d.showtwoone.Contains("L-04") || d.showtwoone.Contains("L-05") ||
				d.showtwoone.Contains("L-05a") || d.showtwoone.Contains("L-06") ||
				d.showtwoone.Contains("L-06a") || d.showtwoone.Contains("L-07") ||
				d.showtwoone.Contains("L-07a") || d.showtwoone.Contains("L-08") ||
				d.showtwoone.Contains("L-10") || d.showtwoone.Contains("L-01-ragan") ||
				d.showtwoone.Contains("L-10a"))
			{
				charaImageNow1.color = new Color(255, 255, 255, 255);
				charaImageNow1.sprite = charaImage[0];
			}

			else if (d.showtwoone.Contains("L-09"))
			{
				charaImageNow1.color = new Color(255, 255, 255, 255);
				charaImageNow1.sprite = charaImage[4];
			}

			else if (d.showtwoone.Contains("K-01") || d.showtwoone.Contains("K-02") ||
				d.showtwoone.Contains("K-02a") || d.showtwoone.Contains("K-03") ||
				d.showtwoone.Contains("K-04") || d.showtwoone.Contains("K-05") ||
				d.showtwoone.Contains("K-06") || d.showtwoone.Contains("K-07") ||
				d.showtwoone.Contains("K-08") || d.showtwoone.Contains("K-09") ||
				d.showtwoone.Contains("K-09a") || d.showtwoone.Contains("K-10") ||
				d.showtwoone.Contains("K-11"))
			{
				charaImageNow1.color = new Color(255, 255, 255, 255);
				charaImageNow1.sprite = charaImage[1];
			}

			else if (d.showtwoone.Contains("T-01") || d.showtwoone.Contains("T-02") ||
				d.showtwoone.Contains("T-03") || d.showtwoone.Contains("T-03a") ||
				d.showtwoone.Contains("T-04"))
			{
				charaImageNow1.color = new Color(255, 255, 255, 255);
				charaImageNow1.sprite = charaImage[2];
			}
			else if (d.showtwoone.Contains("G-01") || d.showtwoone.Contains("G-02") ||
				d.showtwoone.Contains("G-03") || d.showtwoone.Contains("G-04") ||
				d.showtwoone.Contains("G-05") || d.showtwoone.Contains("G-06") ||
				d.showtwoone.Contains("G-07"))
			{
				charaImageNow1.color = new Color(255, 255, 255, 255);
				charaImageNow1.sprite = charaImage[3];
			}
			else
			{
				charaImageNow1.color = new Color(0, 0, 0, 0);

				EyeNow1.color = new Color(0, 0, 0, 0);

				MouthNow1.color = new Color(0, 0, 0, 0);
			}

			//right chara
			if (d.showtwotwo == "")
			{
				charaImageNow2.color = new Color(0, 0, 0, 0);
				EyeNow2.color = new Color(0, 0, 0, 0);
				MouthNow2.color = new Color(0, 0, 0, 0);
			}
			if (d.showtwotwo.Contains("L-01") || d.showtwotwo.Contains("L-01a") ||
				d.showtwotwo.Contains("L-01b") || d.showtwotwo.Contains("L-02") ||
				d.showtwotwo.Contains("L-02a") || d.showtwotwo.Contains("L-03") ||
				d.showtwotwo.Contains("L-04") || d.showtwotwo.Contains("L-05") ||
				d.showtwotwo.Contains("L-05a") || d.showtwotwo.Contains("L-06") ||
				d.showtwotwo.Contains("L-06a") || d.showtwotwo.Contains("L-07") ||
				d.showtwotwo.Contains("L-07a") || d.showtwotwo.Contains("L-08") ||
				d.showtwotwo.Contains("L-10") || d.showtwotwo.Contains("L-01-ragan") ||
				d.showtwotwo.Contains("L-10a"))
			{
				charaImageNow2.color = new Color(255, 255, 255, 255);
				charaImageNow2.sprite = charaImage[0];
			}

			else if (d.showtwotwo.Contains("L-09"))
			{
				charaImageNow2.color = new Color(255, 255, 255, 255);
				charaImageNow2.sprite = charaImage[4];
			}

			else if (d.showtwotwo.Contains("K-01") || d.showtwotwo.Contains("K-02") ||
				d.showtwotwo.Contains("K-02a") || d.showtwotwo.Contains("K-03") ||
				d.showtwotwo.Contains("K-04") || d.showtwotwo.Contains("K-05") ||
				d.showtwotwo.Contains("K-06") || d.showtwotwo.Contains("K-07") ||
				d.showtwotwo.Contains("K-08") || d.showtwotwo.Contains("K-09") ||
				d.showtwotwo.Contains("K-09a") || d.showtwotwo.Contains("K-10") ||
				d.showtwotwo.Contains("K-11"))
			{
				charaImageNow2.color = new Color(255, 255, 255, 255);
				charaImageNow2.sprite = charaImage[1];
			}

			else if (d.showtwotwo.Contains("T-01") || d.showtwotwo.Contains("T-02") ||
				d.showtwotwo.Contains("T-03") || d.showtwotwo.Contains("T-03a") ||
				d.showtwotwo.Contains("T-04"))
			{
				charaImageNow2.color = new Color(255, 255, 255, 255);
				charaImageNow2.sprite = charaImage[2];
			}
			else if (d.showtwotwo.Contains("G-01") || d.showtwotwo.Contains("G-02") ||
				d.showtwotwo.Contains("G-03") || d.showtwotwo.Contains("G-04") ||
				d.showtwotwo.Contains("G-05") || d.showtwotwo.Contains("G-06") ||
				d.showtwotwo.Contains("G-07"))
			{
				charaImageNow2.color = new Color(255, 255, 255, 255);
				charaImageNow2.sprite = charaImage[3];
			}
			else if (d.character == "メイア")
			{
			}
			else
			{
				charaImageNow2.color = new Color(0, 0, 0, 0);

				EyeNow2.color = new Color(0, 0, 0, 0);

				MouthNow2.color = new Color(0, 0, 0, 0);
			}




			if (d.showtwoone != "" || d.showtwotwo != "")
			{
				charaImageNow.color = new Color(0, 0, 0, 0);

				EyeNow.color = new Color(0, 0, 0, 0);

				MouthNow.color = new Color(0, 0, 0, 0);
			}
			else
			{

			}

			//character expression
			StopCoroutine("MouthAnim");

			if (d.expression.Contains("L-01"))
			{
				StopCoroutine("EyeAnim");
				StopCoroutine("MouthAnim");
				int[] eyeList = { 0, 1, 2 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.sprite = CharaMouth[2];
			}
			else if (d.expression.Contains("L-01a"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				EyeNow.sprite = CharaEyes[2];

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[2];
			}
			else if (d.expression.Contains("L-01b"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 3, 4, 5 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[2];
			}
			else if (d.expression.Contains("L-01-ragan"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 3, 4, 5 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[2];
			}
			else if (d.expression.Contains("L-02"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 6, 7, 8 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[5];
			}
			else if (d.expression.Contains("L-02a"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 9, 10, 11 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[5];
			}
			else if (d.expression.Contains("L-03"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 12, 13, 14 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[8];
			}
			else if (d.expression.Contains("L-04"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				EyeNow.sprite = CharaEyes[18];

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[10];
			}
			else if (d.expression.Contains("L-05"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 19, 20, 21 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[14];
			}
			else if (d.expression.Contains("L-05a"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 22, 23, 24 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[14];
			}
			else if (d.expression.Contains("L-06"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 25, 26, 27 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[17];
			}
			else if (d.expression.Contains("L-06a"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 28, 29, 30 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[17];
			}
			else if (d.expression.Contains("L-07"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 31, 32, 33 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[20];
			}
			else if (d.expression.Contains("L-08"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 34, 35, 36 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[23];
			}
			else if (d.expression.Contains("L-09"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 37, 38, 39 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[26];
			}
			else if (d.expression.Contains("L-10"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 40, 41, 40 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[29];
			}

			else if (d.expression.Contains("K-01"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 43, 44, 45 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[33];
			}
			else if (d.expression.Contains("K-02"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 43, 44, 45 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[36];
			}
			else if (d.expression.Contains("K-02a"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 46, 47, 48 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[36];
			}
			else if (d.expression.Contains("K-03"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				EyeNow.sprite = CharaEyes[49];

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[39];
			}
			else if (d.expression.Contains("K-04"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 50, 51, 52 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[42];
			}
			else if (d.expression.Contains("K-05"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 53, 54, 55 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[45];
			}
			else if (d.expression.Contains("K-06"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 56, 57, 58 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[48];
			}
			else if (d.expression.Contains("K-07"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 59, 60, 61 };
				StartCoroutine("EyeAnim", eyeList);
				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[51];
			}
			else if (d.expression.Contains("K-08"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 62, 63, 64 };
				StartCoroutine("EyeAnim", eyeList);
				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[54];
			}
			else if (d.expression.Contains("K-09"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 65, 66, 67 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[57];
			}
			else if (d.expression.Contains("K-09a"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 73, 74, 67 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[57];
			}
			else if (d.expression.Contains("K-10"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 68, 69, 70 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[60];
			}
			else if (d.expression.Contains("K-11"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 71, 72, 71 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[63];
			}

			else if (d.expression.Contains("G-01"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 75, 76, 77 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[66];
			}
			else if (d.expression.Contains("G-02"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				EyeNow.sprite = CharaEyes[78];

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[69];
			}
			else if (d.expression.Contains("G-03"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 79, 80, 81 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[72];
			}
			else if (d.expression.Contains("G-04"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 82, 83, 84 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[75];
			}
			else if (d.expression.Contains("G-05"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 85, 86, 87 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[78];
			}
			else if (d.expression.Contains("G-06"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 88, 89, 90 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[81];
			}
			else if (d.expression.Contains("G-07"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 91, 92, 93 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[84];
			}

			else if (d.expression.Contains("T-01"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 94, 95, 96 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[87];
			}
			else if (d.expression.Contains("T-02"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				EyeNow.sprite = CharaEyes[97];

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[90];
			}
			else if (d.expression.Contains("T-03"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 98, 99, 100 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[93];
			}
			else if (d.expression.Contains("T-03a"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 101, 102, 103 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[93];
			}
			else if (d.expression.Contains("T-04"))
			{
				StopCoroutine("EyeAnim");
				EyeNow.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 104, 105, 106 };
				StartCoroutine("EyeAnim", eyeList);

				MouthNow.color = new Color(255, 255, 255, 255);
				MouthNow.sprite = CharaMouth[96];
			}


			//left chara
			if (d.showtwoone.Contains("L-01"))
			{
				StopCoroutine("EyeAnim1");
				StopCoroutine("MouthAnim");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 0, 1, 2 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[2];
			}
			else if (d.showtwoone.Contains("L-01a"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				EyeNow1.sprite = CharaEyes[2];

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[2];
			}
			else if (d.showtwoone.Contains("L-01b"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 3, 4, 5 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[2];
			}
			else if (d.showtwoone.Contains("L-01-ragan"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 3, 4, 5 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[2];
			}
			else if (d.showtwoone.Contains("L-02"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 6, 7, 8 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[5];
			}
			else if (d.showtwoone.Contains("L-02a"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 9, 10, 11 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[5];
			}
			else if (d.showtwoone.Contains("L-03"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 12, 13, 14 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[8];
			}
			else if (d.showtwoone.Contains("L-04"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				EyeNow1.sprite = CharaEyes[18];

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[10];
			}
			else if (d.showtwoone.Contains("L-05"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 19, 20, 21 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[14];
			}
			else if (d.showtwoone.Contains("L-05a"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 22, 23, 24 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[14];
			}
			else if (d.showtwoone.Contains("L-06"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 25, 26, 27 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[17];
			}
			else if (d.showtwoone.Contains("L-06a"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 28, 29, 30 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[17];
			}
			else if (d.showtwoone.Contains("L-07"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 31, 32, 33 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[20];
			}
			else if (d.showtwoone.Contains("L-08"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 34, 35, 36 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[23];
			}
			else if (d.showtwoone.Contains("L-09"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 37, 38, 39 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[26];
			}
			else if (d.showtwoone.Contains("L-10"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 40, 41, 40 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[29];
			}

			else if (d.showtwoone.Contains("K-01"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 43, 44, 45 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[33];
			}
			else if (d.showtwoone.Contains("K-02"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 43, 44, 45 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[36];
			}
			else if (d.showtwoone.Contains("K-02a"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 46, 47, 48 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[36];
			}
			else if (d.showtwoone.Contains("K-03"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				EyeNow1.sprite = CharaEyes[49];

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[39];
			}
			else if (d.showtwoone.Contains("K-04"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 50, 51, 52 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[42];
			}
			else if (d.showtwoone.Contains("K-05"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 53, 54, 55 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[45];
			}
			else if (d.showtwoone.Contains("K-06"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 56, 57, 58 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[48];
			}
			else if (d.showtwoone.Contains("K-07"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 59, 60, 61 };
				StartCoroutine("EyeAnim1", eyeList);
				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[51];
			}
			else if (d.showtwoone.Contains("K-08"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 62, 63, 64 };
				StartCoroutine("EyeAnim1", eyeList);
				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[54];
			}
			else if (d.showtwoone.Contains("K-09"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 65, 66, 67 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[57];
			}
			else if (d.showtwoone.Contains("K-09a"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 73, 74, 67 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[57];
			}
			else if (d.showtwoone.Contains("K-10"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 68, 69, 70 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[60];
			}
			else if (d.showtwoone.Contains("K-11"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 71, 72, 71 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[63];
			}

			else if (d.showtwoone.Contains("G-01"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 75, 76, 77 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[66];
			}
			else if (d.showtwoone.Contains("G-02"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				EyeNow1.sprite = CharaEyes[78];

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[69];
			}
			else if (d.showtwoone.Contains("G-03"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 79, 80, 81 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[72];
			}
			else if (d.showtwoone.Contains("G-04"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 82, 83, 84 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[75];
			}
			else if (d.showtwoone.Contains("G-05"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 85, 86, 87 };
				StartCoroutine("EyeAnim11", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[78];
			}
			else if (d.showtwoone.Contains("G-06"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 88, 89, 90 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[81];
			}
			else if (d.showtwoone.Contains("G-07"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 91, 92, 93 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[84];
			}

			else if (d.showtwoone.Contains("T-01"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 94, 95, 96 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[87];
			}
			else if (d.showtwoone.Contains("T-02"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				EyeNow1.sprite = CharaEyes[97];

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[90];
			}
			else if (d.showtwoone.Contains("T-03"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 98, 99, 100 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[93];
			}
			else if (d.showtwoone.Contains("T-03a"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 101, 102, 103 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[93];
			}
			else if (d.showtwoone.Contains("T-04"))
			{
				StopCoroutine("EyeAnim1");
				EyeNow1.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 104, 105, 106 };
				StartCoroutine("EyeAnim1", eyeList);

				MouthNow1.color = new Color(255, 255, 255, 255);
				MouthNow1.sprite = CharaMouth[96];
			}

			//right chara
			if (d.showtwotwo.Contains("L-01"))
			{
				StopCoroutine("EyeAnim2");
				StopCoroutine("MouthAnim");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 0, 1, 2 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[2];
			}
			else if (d.showtwotwo.Contains("L-01a"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				EyeNow2.sprite = CharaEyes[2];

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[2];
			}
			else if (d.showtwotwo.Contains("L-01b"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 3, 4, 5 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[2];
			}
			else if (d.showtwotwo.Contains("L-01-ragan"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 3, 4, 5 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[2];
			}
			else if (d.showtwotwo.Contains("L-02"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 6, 7, 8 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[5];
			}
			else if (d.showtwotwo.Contains("L-02a"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 9, 10, 11 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[5];
			}
			else if (d.showtwotwo.Contains("L-03"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 12, 13, 14 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[8];
			}
			else if (d.showtwotwo.Contains("L-04"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				EyeNow2.sprite = CharaEyes[18];

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[10];
			}
			else if (d.showtwotwo.Contains("L-05"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 19, 20, 21 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[14];
			}
			else if (d.showtwotwo.Contains("L-05a"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 22, 23, 24 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[14];
			}
			else if (d.showtwotwo.Contains("L-06"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 25, 26, 27 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[17];
			}
			else if (d.showtwotwo.Contains("L-06a"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 28, 29, 30 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[17];
			}
			else if (d.showtwotwo.Contains("L-07"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 31, 32, 33 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[20];
			}
			else if (d.showtwotwo.Contains("L-08"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 34, 35, 36 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[23];
			}
			else if (d.showtwotwo.Contains("L-09"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 37, 38, 39 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[26];
			}
			else if (d.showtwotwo.Contains("L-10"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 40, 41, 40 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[29];
			}

			else if (d.showtwotwo.Contains("K-01"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 43, 44, 45 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[33];
			}
			else if (d.showtwotwo.Contains("K-02"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 43, 44, 45 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[36];
			}
			else if (d.showtwotwo.Contains("K-02a"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 46, 47, 48 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[36];
			}
			else if (d.showtwotwo.Contains("K-03"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				EyeNow2.sprite = CharaEyes[49];

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[39];
			}
			else if (d.showtwotwo.Contains("K-04"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 50, 51, 52 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[42];
			}
			else if (d.showtwotwo.Contains("K-05"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 53, 54, 55 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[45];
			}
			else if (d.showtwotwo.Contains("K-06"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 56, 57, 58 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[48];
			}
			else if (d.showtwotwo.Contains("K-07"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 59, 60, 61 };
				StartCoroutine("EyeAnim2", eyeList);
				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[51];
			}
			else if (d.showtwotwo.Contains("K-08"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 62, 63, 64 };
				StartCoroutine("EyeAnim2", eyeList);
				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[54];
			}
			else if (d.showtwotwo.Contains("K-09"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 65, 66, 67 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[57];
			}
			else if (d.showtwotwo.Contains("K-09a"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 73, 74, 67 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[57];
			}
			else if (d.showtwotwo.Contains("K-10"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 68, 69, 70 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[60];
			}
			else if (d.showtwotwo.Contains("K-11"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 71, 72, 71 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[63];
			}

			else if (d.showtwotwo.Contains("G-01"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 75, 76, 77 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[66];
			}
			else if (d.showtwotwo.Contains("G-02"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				EyeNow2.sprite = CharaEyes[78];

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[69];
			}
			else if (d.showtwotwo.Contains("G-03"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 79, 80, 81 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[72];
			}
			else if (d.showtwotwo.Contains("G-04"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 82, 83, 84 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[75];
			}
			else if (d.showtwotwo.Contains("G-05"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 85, 86, 87 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[78];
			}
			else if (d.showtwotwo.Contains("G-06"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 88, 89, 90 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[81];
			}
			else if (d.showtwotwo.Contains("G-07"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 91, 92, 93 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[84];
			}

			else if (d.showtwotwo.Contains("T-01"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 94, 95, 96 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[87];
			}
			else if (d.showtwotwo.Contains("T-02"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				EyeNow2.sprite = CharaEyes[97];

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[90];
			}
			else if (d.showtwotwo.Contains("T-03"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 98, 99, 100 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[93];
			}
			else if (d.showtwotwo.Contains("T-03a"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 101, 102, 103 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[93];
			}
			else if (d.showtwotwo.Contains("T-04"))
			{
				StopCoroutine("EyeAnim2");
				EyeNow2.color = new Color(255, 255, 255, 255);
				int[] eyeList = { 104, 105, 106 };
				StartCoroutine("EyeAnim2", eyeList);

				MouthNow2.color = new Color(255, 255, 255, 255);
				MouthNow2.sprite = CharaMouth[96];
			}


			//Bust Up(?)
			if (d.expression.Contains("BU"))
			{
				BustUpAnim.SetBool("isBig", true);
			}
			else
			{
				BustUpAnim.SetBool("isBig", false);
			}


			//BGM
			if (d.BGM.Contains("BGM-001"))
			{
				BGM.clip = BGMFile[0];
				BGM.Play();
			}
			else if (d.BGM.Contains("BGM-002"))
			{
				BGM.clip = BGMFile[1];
				BGM.Play();
			}
			else if (d.BGM.Contains("BGM-003"))
			{
				BGM.clip = BGMFile[2];
				BGM.Play();
			}
			else if (d.BGM.Contains("BGM-004"))
			{
				BGM.clip = BGMFile[3];
				BGM.Play();
			}
			else if (d.BGM.Contains("BGM-005"))
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


			//loads

			if (d.id == 54)
			{
				whichLineNow = 56;
			}
			if (d.id == 139)
			{
				whichLineNow = 143;
			}
			if (d.id == 146)
			{
				whichLineNow = 151;
			}
			if (d.id == 154)
			{
				whichLineNow = 159;
			}
			if (d.id == 165)
			{
				whichLineNow = 171;
			}
			if (d.id == 171)
			{
				whichLineNow = 178;
			}
			if (d.id == 180)
			{
				whichLineNow = 188;
			}
			if (d.id == 210)
			{
				whichLineNow = 220;
			}
			if (d.id == 218)
			{
				whichLineNow = 229;
			}
			if (d.id == 276)
			{
				whichLineNow = 26;
			}
			if (d.id == 280)
			{
				whichLineNow = 31;
			}
			if (d.id == 295)
			{
				whichLineNow = 47;
			}
			if (d.id == 299)
			{
				whichLineNow = 51;
			}
			if (d.id == 392)
			{
				whichLineNow = 54;
			}
			if (d.id == 417)
			{
				whichLineNow = 80;
			}
			if (d.id == 517)
			{
				whichLineNow = 97;
			}
			if (d.id == 631)
			{
				whichLineNow = 109;
			}
			if (d.id == 642)
			{
				whichLineNow = 121;
			}
			if (d.id == 784)
			{
				whichLineNow = 138;
			}
			if (d.id == 790)
			{
				whichLineNow = 144;
			}
			if (d.id == 792)
			{
				whichLineNow = 146;
			}
			if (d.id == 793)
			{
				whichLineNow = 147;
			}
			if (d.id == 794)
			{
				whichLineNow = 148;
			}
			if (d.id == 795)
			{
				whichLineNow = 149;
			}
			if (d.id == 991)
			{
				whichLineNow = 29;
			}
			if (d.id == 995)
			{
				whichLineNow = 33;
			}
			if (d.id == 1200)
			{
				whichLineNow = 86;
			}
			if (d.id == 1210)
			{
				whichLineNow = 96;
			}
			if (d.id == 1415)
			{
				whichLineNow = 19;
			}
			if (d.id == 1419)
			{
				whichLineNow = 23;
			}


			int[] date = PlayerPrefsX.GetIntArray("Date");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			nameLabel.text = d.character;


			////////////////////////////////////////////////////////////////////////////P R O L O G U E////////////////////////////////////////////////////////////////
			if (date[0] == 10 && (date[1] == 7 || date[1] == 8 || date[1] == 9))
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					SlideAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}


				//effects
				int menu = PlayerPrefs.GetInt("NovelMenu");

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


				if (d.id == 169)
				{
					PlayerPrefs.SetInt("MiniGame", 2);
					PlayerPrefs.SetInt("NovelMenu", 2);
				}



				if (autoScroll.automated == false)
				{
					yield return new WaitUntil(() => dialogueManager.next == true);
				}
				else if (autoScroll.automated == true && autoScroll.autoActive == true)
				{
					yield return new WaitForSeconds(2);
				}
				else
				{
				}

				if (d.background.Contains("FO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}
				if (d.background.Contains("SO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					SlideAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 164)
				{
					PlayerPrefs.SetInt("MiniGame", 1);
					PlayerPrefs.SetInt("NovelMenu", 1);
				}
				if (d.id == 170)
				{
					PlayerPrefs.SetInt("MiniGame", 2);
					PlayerPrefs.SetInt("NovelMenu", 2);
				}
				if (d.id == 178)
				{
					PlayerPrefs.SetInt("MiniGame", 3);
					PlayerPrefs.SetInt("NovelMenu", 3);
				}

				if (d.id == 251)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					PlayerPrefs.SetInt("NovelMenu", 10);
					GameShowOnly.SetActive(true);
				}
			}

			///////////////////////////////////////////////////////////////////////////////L I E D 1/////////////////////////////////////////////////////////////////
			else if (date[0] == 10 && date[1] == 13)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					SlideAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}

				if (d.id == 266)
				{
					finishTemp5 = true;
				}

				if (d.id == 290)
				{
					finishTemp6 = true;
				}

				if (autoScroll.automated == false)
				{
					yield return new WaitUntil(() => dialogueManager.next == true);
				}
				else if (autoScroll.automated == true && autoScroll.autoActive == true)
				{
					yield return new WaitForSeconds(2);
				}
				else
				{
				}

				if (d.background.Contains("FO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}
				if (d.background.Contains("SO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					SlideAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 339)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					PlayerPrefs.SetInt("NovelMenu", 10);
					GameShowOnly.SetActive(true);
				}

			}

			///////////////////////////////////////////////////////////////////////////////L I E D 2/////////////////////////////////////////////////////////////////

			else if (date[0] == 10 && date[1] == 16 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					SlideAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}

				if (d.id == 378)
				{
					finishTemp7 = true;
				}

				if (autoScroll.automated == false)
				{
					yield return new WaitUntil(() => dialogueManager.next == true);
				}
				else if (autoScroll.automated == true && autoScroll.autoActive == true)
				{
					yield return new WaitForSeconds(2);
				}
				else
				{
				}

				if (d.background.Contains("FO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}
				if (d.background.Contains("SO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					SlideAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 423)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					PlayerPrefs.SetInt("NovelMenu", 10);
					GameShowOnly.SetActive(true);
				}

			}


			///////////////////////////////////////////////////////////////////////////////L I E D 3/////////////////////////////////////////////////////////////////

			else if (date[0] == 10 && date[1] == 19 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					SlideAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}

				if (d.id == 466)
				{
					finishTemp8 = true;
				}

				if (autoScroll.automated == false)
				{
					yield return new WaitUntil(() => dialogueManager.next == true);
				}
				else if (autoScroll.automated == true && autoScroll.autoActive == true)
				{
					yield return new WaitForSeconds(2);
				}
				else
				{
				}

				if (d.background.Contains("FO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}
				if (d.background.Contains("SO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					SlideAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}


				if (d.id == 516 || d.id == 521)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					PlayerPrefs.SetInt("NovelMenu", 10);
					GameShowOnly.SetActive(true);
				}

			}

			///////////////////////////////////////////////////////////////////////////////L I E D 4/////////////////////////////////////////////////////////////////

			else if (date[0] == 10 && date[1] == 22 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					SlideAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}

				if (d.id == 613)
				{
					finishTemp9 = true;
				}

				if (autoScroll.automated == false)
				{
					yield return new WaitUntil(() => dialogueManager.next == true);
				}
				else if (autoScroll.automated == true && autoScroll.autoActive == true)
				{
					yield return new WaitForSeconds(2);
				}
				else
				{
				}

				if (d.background.Contains("FO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}
				if (d.background.Contains("SO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					SlideAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 648)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					PlayerPrefs.SetInt("NovelMenu", 10);
					GameShowOnly.SetActive(true);
				}

			}


			///////////////////////////////////////////////////////////////////////////////L I E D 5/////////////////////////////////////////////////////////////////

			else if (date[0] == 10 && date[1] == 25 && LiedFail == 0)
			{
				if (d.background.Contains("FI") || d.id == 662)
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					SlideAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}


				if (d.id == 748)
				{
					finishTemp10 = true;
				}

				if (autoScroll.automated == false)
				{
					yield return new WaitUntil(() => dialogueManager.next == true);
				}
				else if (autoScroll.automated == true && autoScroll.autoActive == true)
				{
					yield return new WaitForSeconds(2);
				}
				else
				{
				}

				if (d.background.Contains("FO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}
				if (d.background.Contains("SO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					SlideAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 813)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					PlayerPrefs.SetInt("NovelMenu", 10);
					GameShowOnly.SetActive(true);
				}
			}


			///////////////////////////////////////////////////////////////////////////////L I E D 6/////////////////////////////////////////////////////////////////

			else if (date[0] == 10 && date[1] == 28 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					SlideAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}

				if (autoScroll.automated == false)
				{
					yield return new WaitUntil(() => dialogueManager.next == true);
				}
				else if (autoScroll.automated == true && autoScroll.autoActive == true)
				{
					yield return new WaitForSeconds(2);
				}
				else
				{
				}

				if (d.background.Contains("FO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}
				if (d.background.Contains("SO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					SlideAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 963)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					PlayerPrefs.SetInt("NovelMenu", 10);
					GameShowOnly.SetActive(true);
				}
			}

			///////////////////////////////////////////////////////////////////////////////L I E D 7/////////////////////////////////////////////////////////////////

			else if (date[0] == 10 && date[1] == 31 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					SlideAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}

				if (d.id == 983)
				{
					finishTemp11 = true;
				}


				if (autoScroll.automated == false)
				{
					yield return new WaitUntil(() => dialogueManager.next == true);
				}
				else if (autoScroll.automated == true && autoScroll.autoActive == true)
				{
					yield return new WaitForSeconds(2);
				}
				else
				{
				}

				if (d.background.Contains("FO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}
				if (d.background.Contains("SO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					SlideAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 1115)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					PlayerPrefs.SetInt("NovelMenu", 10);
					GameShowOnly.SetActive(true);
				}
			}

			///////////////////////////////////////////////////////////////////////////////L I E D 8/////////////////////////////////////////////////////////////////

			else if (date[0] == 11 && date[1] == 3 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					SlideAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}

				if (d.id == 1179)
				{
					finishTemp12 = true;
				}


				if (autoScroll.automated == false)
				{
					yield return new WaitUntil(() => dialogueManager.next == true);
				}
				else if (autoScroll.automated == true && autoScroll.autoActive == true)
				{
					yield return new WaitForSeconds(2);
				}
				else
				{
				}

				if (d.background.Contains("FO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}
				if (d.background.Contains("SO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					SlideAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 1332)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					PlayerPrefs.SetInt("NovelMenu", 10);
					GameShowOnly.SetActive(true);
				}
			}

			///////////////////////////////////////////////////////////////////////////////L I E D 9/////////////////////////////////////////////////////////////////

			else if (date[0] == 11 && date[1] == 6 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					SlideAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}

				if (autoScroll.automated == false)
				{
					yield return new WaitUntil(() => dialogueManager.next == true);
				}
				else if (autoScroll.automated == true && autoScroll.autoActive == true)
				{
					yield return new WaitForSeconds(2);
				}
				else
				{
				}

				if (d.background.Contains("FO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}
				if (d.background.Contains("SO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					SlideAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 1397)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					PlayerPrefs.SetInt("NovelMenu", 10);
					GameShowOnly.SetActive(true);
				}
			}

			///////////////////////////////////////////////////////////////////////////////L I E D 10/////////////////////////////////////////////////////////////////

			else if (date[0] == 11 && date[1] == 9 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					SlideAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(d.dialogue, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(d.dialogue, textLabel);
				}

				if (d.id == 1411)
				{
					finishTemp13 = true;
				}


				if (autoScroll.automated == false)
				{
					yield return new WaitUntil(() => dialogueManager.next == true);
				}
				else if (autoScroll.automated == true && autoScroll.autoActive == true)
				{
					yield return new WaitForSeconds(2);
				}
				else
				{
				}

				if (d.background.Contains("FO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}
				if (d.background.Contains("SO"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					SlideAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 1449)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					PlayerPrefs.SetInt("NovelMenu", 10);
					GameShowOnly.SetActive(true);
				}
			}



			/////////////////////////////////////////////////////////S H O P/////////////////////////////
			else
			{
				yield return dialogueManager.Run(d.dialogue, textLabel);
				if (autoScroll.automated == false)
				{
					yield return new WaitUntil(() => dialogueManager.next == true);
				}
				else if (autoScroll.automated == true && autoScroll.autoActive == true)
				{
					yield return new WaitForSeconds(2);
				}
				else
				{
				}
			}

			if (ItemEffect == true)
			{
				nameLabel.text = string.Empty;
				textLabel.text = string.Empty;
				FadeAnim.SetBool("Fading", true);
				waitForFadeAnim = true;

				PlayerPrefs.SetInt("NovelMenu", 10);
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
		int menu = PlayerPrefs.GetInt("NovelMenu");

		if (menu == 11 && shopDecide == true)
		{
			shopDecide = false;
			finishTemp4 = true;
		}
	}

	void FirstButtonClicked()
	{
		TwoChoices.SetActive(false);
		dialogues.Clear();

		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		Time.timeScale = 1;

		if (finishTemp1 == true)
		{
			resetPos = 1;
			finishTemp1 = false;
			whichLineNow = 54;


			for (int i = 54; i < 133; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}


		if (finishTemp2 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection += 5;
			PlayerPrefs.SetFloat("LiedHeart", affection);
			resetPos = 3;
			finishTemp2 = false;
			whichLineNow = 133;

			for (int i = 133; i < 171; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		if (finishTemp3 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 5;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 8;
			finishTemp3 = false;
			whichLineNow = 133;

			for (int i = 213; i < 263; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

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

			itemRow = itemData[8].Split(new char[] { ',' });

			d = new Dialogue();
			int.TryParse(itemRow[0], out d.id);
			d.character = itemRow[1];
			d.dialogue = itemRow[2];
			d.expression = itemRow[4];
			d.background = itemRow[7];
			d.BGM = itemRow[11];
			d.SE = itemRow[12];
			d.voice = "";
			d.note = itemRow[13];

			dialogues.Add(d);
		}

		if (finishTemp5 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection += 5;
			PlayerPrefs.SetFloat("LiedHeart", affection);
			resetPos = 11;
			finishTemp5 = false;
			whichLineNow = 17;

			for (int i = 17; i < 43; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		if (finishTemp6 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection += 2;
			PlayerPrefs.SetFloat("LiedHeart", affection);
			resetPos = 14;
			finishTemp6 = false;
			whichLineNow = 43;

			for (int i = 43; i < 92; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		if (finishTemp7 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection += 2;
			PlayerPrefs.SetFloat("LiedHeart", affection);
			resetPos = 18;
			finishTemp7 = false;
			whichLineNow = 41;

			for (int i = 41; i < 87; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		if (finishTemp8 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection += 2;
			PlayerPrefs.SetFloat("LiedHeart", affection);
			resetPos = 21;
			finishTemp8 = false;
			whichLineNow = 45;

			for (int i = 45; i < 102; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		if (finishTemp9 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection += 5;
			PlayerPrefs.SetFloat("LiedHeart", affection);
			resetPos = 26;
			finishTemp9 = false;
			whichLineNow = 92;

			for (int i = 92; i < 128; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		if (finishTemp10 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection += 5;
			PlayerPrefs.SetFloat("LiedHeart", affection);
			resetPos = 30;
			finishTemp10 = false;
			whichLineNow = 103;

			for (int i = 103; i < 168; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		if (finishTemp11 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection += 2;
			PlayerPrefs.SetFloat("LiedHeart", affection);
			resetPos = 36;
			finishTemp11 = false;
			whichLineNow = 22;

			for (int i = 22; i < 154; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		if (finishTemp12 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection += 5;
			PlayerPrefs.SetFloat("LiedHeart", affection);
			resetPos = 40;
			finishTemp12 = false;
			whichLineNow = 66;

			for (int i = 66; i < 220; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		if (finishTemp13 == true)
		{
			resetPos = 46;
			finishTemp13 = false;
			whichLineNow = 16;

			for (int i = 16; i < 54; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Bonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

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

		ButtonAudioSource.Stop();
		ButtonAudioSource.Play();

		Time.timeScale = 1;
		if (finishTemp1 == true)
		{
			resetPos = 2;
			finishTemp1 = false;

			for (int i = 54; i < 133; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		if (finishTemp2 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection += 2;
			PlayerPrefs.SetFloat("LiedHeart", affection);

			resetPos = 4;
			finishTemp2 = false;

			for (int i = 133; i < 171; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		if (finishTemp3 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 2;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 9;
			finishTemp3 = false;

			for (int i = 213; i < 263; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		if (finishTemp4 == true)
		{
			finishTemp4 = false;
			PlayerPrefs.SetInt("NovelMenu", 13);
			SceneManager.LoadScene("Novel");
		}
		if (finishTemp5 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection += 5;
			PlayerPrefs.SetFloat("LiedHeart", affection);
			resetPos = 12;
			finishTemp5 = false;

			for (int i = 17; i < 43; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		if (finishTemp6 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection -= 2;
			PlayerPrefs.SetFloat("LiedHeart", affection);
			resetPos = 15;
			finishTemp6 = false;
			whichLineNow = 43;

			for (int i = 43; i < 92; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}

		if (finishTemp7 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection += 5;
			PlayerPrefs.SetFloat("LiedHeart", affection);
			resetPos = 19;
			finishTemp7 = false;

			for (int i = 41; i < 87; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		if (finishTemp8 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection += 0;
			PlayerPrefs.SetFloat("LiedHeart", affection);
			resetPos = 22;
			finishTemp8 = false;

			for (int i = 45; i < 102; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		if (finishTemp9 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection -= 2;
			PlayerPrefs.SetFloat("LiedHeart", affection);
			resetPos = 27;
			finishTemp9 = false;

			for (int i = 92; i < 128; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		if (finishTemp10 == true)
		{
			resetPos = 31;
			finishTemp9 = false;

			for (int i = 103; i < 168; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		if (finishTemp11 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection += 0;
			PlayerPrefs.SetFloat("LiedHeart", affection);
			resetPos = 37;
			finishTemp11 = false;

			for (int i = 22; i < 154; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		if (finishTemp12 == true)
		{
			float affection = PlayerPrefs.GetFloat("LiedHeart");
			affection += 2;
			PlayerPrefs.SetFloat("LiedHeart", affection);
			resetPos = 41;
			finishTemp12 = false;

			for (int i = 66; i < 220; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
		}
		if (finishTemp13 == true)
		{
			resetPos = 47;
			finishTemp13 = false;
			whichLineNow = 16;

			for (int i = 16; i < 54; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != "") && row[10] != "Aonly")
				{
					d = new Dialogue();
					int.TryParse(row[0], out d.id);
					d.character = row[1];
					d.dialogue = row[2];
					d.mainchara = row[3];
					d.expression = row[4];
					d.showtwoone = row[5];
					d.showtwotwo = row[6];
					d.background = row[7];
					d.firstchoose = row[8];
					d.secondchoose = row[9];
					d.choicetextshow = row[10];
					d.objecteffect = row[11];
					d.itemimage = row[12];
					d.effect = row[13];
					d.BGM = row[14];
					d.SE = row[15];
					d.voice = row[16];
					d.note = row[17];

					dialogues.Add(d);
				}
			}
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
			int[] date = PlayerPrefsX.GetIntArray("Date");
			PlayerPrefsX.SetIntArray("Date1", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber1", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("LiedFail1", LiedFail);
			PlayerPrefs.SetInt("KleinFail1", KleinFail);
			PlayerPrefs.SetInt("Money1", money);
			PlayerPrefs.SetFloat("LiedHeart1", liedAff);
			PlayerPrefs.SetFloat("KleinHeart1", kleinAff);
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber1", cleanNumber);
			PlayerPrefs.SetInt("CookNumber1", cookNumber);
			PlayerPrefs.SetInt("ShopNumber1", shopNumber);

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
			int[] date = PlayerPrefsX.GetIntArray("Date");
			PlayerPrefsX.SetIntArray("Date2", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber2", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("LiedFail2", LiedFail);
			PlayerPrefs.SetInt("KleinFail2", KleinFail);
			PlayerPrefs.SetInt("Money2", money);
			PlayerPrefs.SetFloat("LiedHeart2", liedAff);
			PlayerPrefs.SetFloat("KleinHeart2", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber2", cleanNumber);
			PlayerPrefs.SetInt("CookNumber2", cookNumber);
			PlayerPrefs.SetInt("ShopNumber2", shopNumber);
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
			int[] date = PlayerPrefsX.GetIntArray("Date");
			PlayerPrefsX.SetIntArray("Date3", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber3", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("LiedFail3", LiedFail);
			PlayerPrefs.SetInt("KleinFail3", KleinFail);
			PlayerPrefs.SetInt("Money3", money);
			PlayerPrefs.SetFloat("LiedHeart3", liedAff);
			PlayerPrefs.SetFloat("KleinHeart3", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber3", cleanNumber);
			PlayerPrefs.SetInt("CookNumber3", cookNumber);
			PlayerPrefs.SetInt("ShopNumber3", shopNumber);
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
			int[] date = PlayerPrefsX.GetIntArray("Date");
			PlayerPrefsX.SetIntArray("Date4", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber4", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("LiedFail4", LiedFail);
			PlayerPrefs.SetInt("KleinFail4", KleinFail);
			PlayerPrefs.SetInt("Money4", money);
			PlayerPrefs.SetFloat("LiedHeart4", liedAff);
			PlayerPrefs.SetFloat("KleinHeart4", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber4", cleanNumber);
			PlayerPrefs.SetInt("CookNumber4", cookNumber);
			PlayerPrefs.SetInt("ShopNumber4", shopNumber);
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
			int[] date = PlayerPrefsX.GetIntArray("Date");
			PlayerPrefsX.SetIntArray("Date5", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber5", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("LiedFail5", LiedFail);
			PlayerPrefs.SetInt("KleinFail5", KleinFail);
			PlayerPrefs.SetInt("Money5", money);
			PlayerPrefs.SetFloat("LiedHeart5", liedAff);
			PlayerPrefs.SetFloat("KleinHeart5", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber5", cleanNumber);
			PlayerPrefs.SetInt("CookNumber5", cookNumber);
			PlayerPrefs.SetInt("ShopNumber5", shopNumber);
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
			int[] date = PlayerPrefsX.GetIntArray("Date");
			PlayerPrefsX.SetIntArray("Date6", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber6", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("LiedFail6", LiedFail);
			PlayerPrefs.SetInt("KleinFail6", KleinFail);
			PlayerPrefs.SetInt("Money6", money);
			PlayerPrefs.SetFloat("LiedHeart6", liedAff);
			PlayerPrefs.SetFloat("KleinHeart6", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber6", cleanNumber);
			PlayerPrefs.SetInt("CookNumber6", cookNumber);
			PlayerPrefs.SetInt("ShopNumber6", shopNumber);
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
			int[] date = PlayerPrefsX.GetIntArray("Date");
			PlayerPrefsX.SetIntArray("Date7", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber7", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("LiedFail7", LiedFail);
			PlayerPrefs.SetInt("KleinFail7", KleinFail);
			PlayerPrefs.SetInt("Money7", money);
			PlayerPrefs.SetFloat("LiedHeart7", liedAff);
			PlayerPrefs.SetFloat("KleinHeart7", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber7", cleanNumber);
			PlayerPrefs.SetInt("CookNumber7", cookNumber);
			PlayerPrefs.SetInt("ShopNumber7", shopNumber);
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
			int[] date = PlayerPrefsX.GetIntArray("Date");
			PlayerPrefsX.SetIntArray("Date8", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber8", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("LiedFail8", LiedFail);
			PlayerPrefs.SetInt("KleinFail8", KleinFail);
			PlayerPrefs.SetInt("Money8", money);
			PlayerPrefs.SetFloat("LiedHeart8", liedAff);
			PlayerPrefs.SetFloat("KleinHeart8", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber8", cleanNumber);
			PlayerPrefs.SetInt("CookNumber8", cookNumber);
			PlayerPrefs.SetInt("ShopNumber8", shopNumber);
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
			int[] date = PlayerPrefsX.GetIntArray("Date");
			PlayerPrefsX.SetIntArray("Date9", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber9", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("LiedFail9", LiedFail);
			PlayerPrefs.SetInt("KleinFail9", KleinFail);
			PlayerPrefs.SetInt("Money9", money);
			PlayerPrefs.SetFloat("LiedHeart9", liedAff);
			PlayerPrefs.SetFloat("KleinHeart9", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber9", cleanNumber);
			PlayerPrefs.SetInt("CookNumber9", cookNumber);
			PlayerPrefs.SetInt("ShopNumber9", shopNumber);
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
			int[] date = PlayerPrefsX.GetIntArray("Date");
			PlayerPrefsX.SetIntArray("Date10", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber10", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("LiedFail10", LiedFail);
			PlayerPrefs.SetInt("KleinFail10", KleinFail);
			PlayerPrefs.SetInt("Money10", money);
			PlayerPrefs.SetFloat("LiedHeart10", liedAff);
			PlayerPrefs.SetFloat("KleinHeart10", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber10", cleanNumber);
			PlayerPrefs.SetInt("CookNumber10", cookNumber);
			PlayerPrefs.SetInt("ShopNumber10", shopNumber);
		}
		else if (whichFile == 0)
		{
			if (whichLineNow != 0)
			{
				PlayerPrefs.SetInt("ZeroLog", startFrom + whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("ZeroLog", startFrom + whichLineNow);
			}
			PlayerPrefs.SetInt("ZeroPos", resetPos);

			int file = PlayerPrefs.GetInt("ZeroLog");
			PlayerPrefs.SetInt("LogNow", file);
			int[] date = PlayerPrefsX.GetIntArray("Date");
			PlayerPrefsX.SetIntArray("Date0", date);
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");
			PlayerPrefsX.SetIntArray("ItemNumber0", ItemNumber);
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			PlayerPrefs.SetInt("LiedFail0", LiedFail);
			PlayerPrefs.SetInt("KleinFail0", KleinFail);
			PlayerPrefs.SetInt("Money0", money);
			PlayerPrefs.SetFloat("LiedHeart0", liedAff);
			PlayerPrefs.SetFloat("KleinHeart0", kleinAff);

			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");

			PlayerPrefs.SetInt("CleanNumber0", cleanNumber);
			PlayerPrefs.SetInt("CookNumber0", cookNumber);
			PlayerPrefs.SetInt("ShopNumber0", shopNumber);
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
		d.expression = itemRow[4];
		d.background = itemRow[7];
		d.BGM = itemRow[11];
		d.SE = itemRow[12];
		d.voice = "";
		d.note = itemRow[13];

		dialogues.Add(d);

		ShowDialogue();
	}


	public void RiitItem()
	{
		dialogues.Clear();
		itemRow = itemData[17].Split(new char[] { ',' });

		d = new Dialogue();
		int.TryParse(itemRow[0], out d.id);
		d.character = itemRow[1];
		d.dialogue = itemRow[2];
		d.expression = itemRow[4];
		d.background = itemRow[7];
		d.BGM = itemRow[11];
		d.SE = itemRow[12];
		d.voice = "";
		d.note = itemRow[13];

		dialogues.Add(d);

		d = new Dialogue();
		int.TryParse("999", out d.id);
		d.character = "";
		d.dialogue = "";
		d.expression = "";
		d.background = "";
		d.BGM = "";
		d.SE = "";
		d.note = "giveitem";

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
		d.expression = itemRow[4];
		d.background = itemRow[7];
		d.BGM = itemRow[11];
		d.SE = itemRow[12];
		d.voice = "";
		d.note = itemRow[13];

		dialogues.Add(d);

		d = new Dialogue();
		int.TryParse("999", out d.id);
		d.character = "";
		d.dialogue = "";
		d.expression = "";
		d.background = "";
		d.BGM = "";
		d.SE = "";
		d.note = "giveitem";

		dialogues.Add(d);

		itemChoose = true;

		ShowDialogue();
	}






	public void RiitEffect(int feel)
	{
		dialogues.Clear();
		itemChoose = false;

		float affection = PlayerPrefs.GetFloat("LiedHeart");

		if (feel == 0)
		{
			affection += 5;

			itemRow = itemData[22].Split(new char[] { ',' });

			d = new Dialogue();
			int.TryParse(itemRow[0], out d.id);
			d.character = itemRow[1];
			d.dialogue = itemRow[2];
			d.expression = itemRow[4];
			d.background = itemRow[7];
			d.BGM = itemRow[11];
			d.SE = itemRow[12];
			d.voice = "";
			d.note = itemRow[13];

			dialogues.Add(d);
		}

		else if (feel == 1)
		{
			affection += 3;

			itemRow = itemData[21].Split(new char[] { ',' });

			d = new Dialogue();
			int.TryParse(itemRow[0], out d.id);
			d.character = itemRow[1];
			d.dialogue = itemRow[2];
			d.expression = itemRow[4];
			d.background = itemRow[7];
			d.BGM = itemRow[11];
			d.SE = itemRow[12];
			d.voice = "";
			d.note = itemRow[13];

			dialogues.Add(d);
		}

		else if (feel == 2)
		{
			affection += 2;

			itemRow = itemData[20].Split(new char[] { ',' });

			d = new Dialogue();
			int.TryParse(itemRow[0], out d.id);
			d.character = itemRow[1];
			d.dialogue = itemRow[2];
			d.expression = itemRow[4];
			d.background = itemRow[7];
			d.BGM = itemRow[11];
			d.SE = itemRow[12];
			d.voice = "";
			d.note = itemRow[13];

			dialogues.Add(d);
		}

		PlayerPrefs.SetFloat("LiedHeart", affection);

		d = new Dialogue();
		int.TryParse("999", out d.id);
		d.character = "";
		d.dialogue = "";
		d.expression = "";
		d.background = "";
		d.BGM = "";
		d.SE = "";
		d.note = "giveitem";

		dialogues.Add(d);

		ShowDialogue();

		ItemEffect = true;
	}

	public void KleinEffect(int feel)
	{
		dialogues.Clear();
		itemChoose = false;

		float affection = PlayerPrefs.GetFloat("KleinHeart");

		if (feel == 0)
		{
			affection += 5;

			itemRow = itemData[34].Split(new char[] { ',' });

			d = new Dialogue();
			int.TryParse(itemRow[0], out d.id);
			d.character = itemRow[1];
			d.dialogue = itemRow[2];
			d.expression = itemRow[4];
			d.background = itemRow[7];
			d.BGM = itemRow[11];
			d.SE = itemRow[12];
			d.voice = "";
			d.note = itemRow[13];

			dialogues.Add(d);
		}

		else if (feel == 1)
		{
			affection += 3;

			itemRow = itemData[33].Split(new char[] { ',' });

			d = new Dialogue();
			int.TryParse(itemRow[0], out d.id);
			d.character = itemRow[1];
			d.dialogue = itemRow[2];
			d.expression = itemRow[4];
			d.background = itemRow[7];
			d.BGM = itemRow[11];
			d.SE = itemRow[12];
			d.voice = "";
			d.note = itemRow[13];

			dialogues.Add(d);
		}

		else if (feel == 2)
		{
			affection += 2;

			itemRow = itemData[32].Split(new char[] { ',' });

			d = new Dialogue();
			int.TryParse(itemRow[0], out d.id);
			d.character = itemRow[1];
			d.dialogue = itemRow[2];
			d.expression = itemRow[4];
			d.background = itemRow[7];
			d.BGM = itemRow[11];
			d.SE = itemRow[12];
			d.voice = "";
			d.note = itemRow[13];

			dialogues.Add(d);
		}

		PlayerPrefs.SetFloat("KleinHeart", affection);

		d = new Dialogue();
		int.TryParse("999", out d.id);
		d.character = "";
		d.dialogue = "";
		d.expression = "";
		d.background = "";
		d.BGM = "";
		d.SE = "";
		d.note = "giveitem";

		dialogues.Add(d);

		ShowDialogue();


		ItemEffect = true;
	}


	public IEnumerator EyeAnim(int[] eye)
	{
		while (true)
		{
			EyeNow.sprite = CharaEyes[eye[0]];
			yield return new WaitForSeconds(3);
			EyeNow.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow.sprite = CharaEyes[eye[2]];
			yield return new WaitForSeconds(0.1f);
			EyeNow.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow.sprite = CharaEyes[eye[0]];
			yield return new WaitForSeconds(5);
			EyeNow.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow.sprite = CharaEyes[eye[2]];
			yield return new WaitForSeconds(0.1f);
			EyeNow.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow.sprite = CharaEyes[eye[0]];
			yield return new WaitForSeconds(0.5f);
			EyeNow.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow.sprite = CharaEyes[eye[2]];
			yield return new WaitForSeconds(0.1f);
			EyeNow.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow.sprite = CharaEyes[eye[0]];
			yield return new WaitForSeconds(0);
		}
	}
	public IEnumerator EyeAnim1(int[] eye)
	{
		while (true)
		{
			EyeNow1.sprite = CharaEyes[eye[0]];
			yield return new WaitForSeconds(3);
			EyeNow1.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow1.sprite = CharaEyes[eye[2]];
			yield return new WaitForSeconds(0.1f);
			EyeNow1.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow1.sprite = CharaEyes[eye[0]];
			yield return new WaitForSeconds(5);
			EyeNow1.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow1.sprite = CharaEyes[eye[2]];
			yield return new WaitForSeconds(0.1f);
			EyeNow1.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow1.sprite = CharaEyes[eye[0]];
			yield return new WaitForSeconds(0.5f);
			EyeNow1.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow1.sprite = CharaEyes[eye[2]];
			yield return new WaitForSeconds(0.1f);
			EyeNow1.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow1.sprite = CharaEyes[eye[0]];
			yield return new WaitForSeconds(0);
		}
	}
	public IEnumerator EyeAnim2(int[] eye)
	{
		while (true)
		{
			EyeNow2.sprite = CharaEyes[eye[0]];
			yield return new WaitForSeconds(3);
			EyeNow2.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow2.sprite = CharaEyes[eye[2]];
			yield return new WaitForSeconds(0.1f);
			EyeNow2.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow2.sprite = CharaEyes[eye[0]];
			yield return new WaitForSeconds(5);
			EyeNow2.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow2.sprite = CharaEyes[eye[2]];
			yield return new WaitForSeconds(0.1f);
			EyeNow2.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow2.sprite = CharaEyes[eye[0]];
			yield return new WaitForSeconds(0.5f);
			EyeNow2.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow2.sprite = CharaEyes[eye[2]];
			yield return new WaitForSeconds(0.1f);
			EyeNow2.sprite = CharaEyes[eye[1]];
			yield return new WaitForSeconds(0.1f);
			EyeNow2.sprite = CharaEyes[eye[0]];
			yield return new WaitForSeconds(0);
		}
	}


	//public IEnumerator MouthAnim(int[] mouth)
	//{
	//    float timeToClose = 0;

	//    if (timeToClose == voiceTime)
	//    {
	//        MouthNow.sprite = CharaMouth[mouth[2]];
	//        yield break;
	//    }
	//    else
	//    {
	//        while (true)
	//        {
	//            MouthNow.sprite = CharaMouth[mouth[0]];
	//            yield return new WaitForSeconds(0.1f);
	//            MouthNow.sprite = CharaMouth[mouth[1]];
	//            yield return new WaitForSeconds(0.1f);
	//        }
	//    }
	//    //yield return new WaitForSeconds(voiceTime);
	//}

	public IEnumerator BGTextAnim(string[] x)
	{
		if (x[1] == "暗転" || x[1] == "")
		{
			backGroundName = x[1];
			TextBGHide.SetBool("TextIsHidden", true);
		}
		else if (x[0] != x[1])
		{
			backGroundName = x[1];
			TextBGHide.SetBool("TextIsHidden", false);
			yield return new WaitForSeconds(2f);
			TextBGHide.SetBool("TextIsHidden", true);
		}
		else if (x[0] == x[1])
		{
			backGroundName = x[1];
			TextBGHide.SetBool("TextIsHidden", true);
		}
	}


}
