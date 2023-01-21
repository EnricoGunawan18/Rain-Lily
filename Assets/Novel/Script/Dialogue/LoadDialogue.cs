using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadDialogue : MonoBehaviour
{
	[SerializeField]
	TextAsset prologue;
	[SerializeField]
	TextAsset itemDialogue;
	[SerializeField]
	TextAsset BGName;
	[SerializeField]
	Button[] MinGameButton;
	[SerializeField]
	private Text textLabel;
	[SerializeField]
	public Text nameLabel;
	[SerializeField]
	public Text backGroundLabel;
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
	LogPrefabSpawn logPrefabSpawn;

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
	GameObject MeiaImage;

	[SerializeField]
	Image MeiaMain;
	[SerializeField]
	Image MeiaEye;
	[SerializeField]
	Image MeiaMouth;

	[SerializeField]
	Sprite[] MeiaSprite;

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

	[SerializeField]
	AudioSource SE;

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
	public bool finishTemp14 = false;
	public bool finishTemp15 = false;
	public bool finishTemp16 = false;
	public bool finishTemp17 = false;
	public bool finishTemp18 = false;
	public bool finishTemp19 = false;
	public bool finishTemp20 = false;
	public bool finishTemp21 = false;
	public bool finishTemp22 = false;
	public bool finishTemp23 = false;
	public bool finishTemp24 = false;
	public bool finishTemp25 = false;
	public bool finishTemp26 = false;
	public bool finishTemp27 = false;
	public bool finishTemp28 = false;
	public bool finishTemp29 = false;
	public bool finishTemp30 = false;
	public bool finishTemp31 = false;

	public bool ItemEffect = false;
	public bool itemChoose = false;
	public int resetPos = 0;

    public int id;//0
    public string character;//1
    public string dialogue;//2
    public string mainchara;//3
    public string expression;//4
    public string showtwoone;//5
    public string showtwotwo;//6
    public string back;//7

    public string firstchoose;//8
    public string secondchoose;//9
    public string choicetextshow;//10

    public string objecteffect;//11
    public string itemimage;//12
    public string effect;//13
    public string music;//14
    public string sound;//15
    public string voice;//16
    public string note;//17

	bool shopDecide = true;

	float speed;

	bool manager;
	bool voiceManager;

	string backGroundName;

	[SerializeField]
	GameMenu GameMenuScript;

	public List<BackGroundLogs> backgrounds;
	public List<Dialogue> dialogues;

	[SerializeField]
	TextAsset[] LiedDialogue;
	[SerializeField]
	TextAsset[] KleinDialogue;

    static AssetBundle assetBundle;

	bool audioFade = false;
	string whichBGClip = "";

	bool mouthStop;

	float clipLength;

	int meiaShow;

	private void Start()
	{
		Time.timeScale = 1;
		int gameMoneyGet = PlayerPrefs.GetInt("Money");

		if(assetBundle == null)
		{
        	assetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "voice"));
		}

		whichLineNow = PlayerPrefs.GetInt("LogNow");

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

		if (menu != 13)
		{
			//Lied

			if (date[0] == 10 && (date[1] == 7 || date[1] == 8 || date[1] == 9))
			{
				data = prologue.text.Split(new char[] { '$' });
					PlayerPrefs.SetString("ChapterTitle", "Prologue");
			}
			else if (date[0] == 10 && date[1] == 15)
			{
				data = LiedDialogue[0].text.Split(new char[] { '$' });
				if (liedAff >= 10f)
				{
					menu = 14;
					PlayerPrefs.SetString("ChapterTitle", "Episode1");
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					PlayerPrefs.SetInt("LiedFail", 1);
				}

			}
			else if (date[0] == 10 && date[1] == 20)
			{
				data = LiedDialogue[1].text.Split(new char[] { '$' });
				if (liedAff >= 15f)
				{
					menu = 15;
					PlayerPrefs.SetString("ChapterTitle", "Episode2");
					PlayerPrefs.SetInt("NovelMenu", menu);
					PlayerPrefs.SetInt("CleanNumber", 0);
				}
				else
				{
					PlayerPrefs.SetInt("LiedFail", 1);
				}

			}
			else if (date[0] == 10 && date[1] == 30)
			{
				data = LiedDialogue[2].text.Split(new char[] { '$' });
				if (liedAff >= 20f)
				{
					menu = 16;
					PlayerPrefs.SetString("ChapterTitle", "Episode3");
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					PlayerPrefs.SetInt("LiedFail", 1);
				}

			}
			else if (date[0] == 11 && date[1] == 8)
			{
				data = LiedDialogue[3].text.Split(new char[] { '$' });
				if (liedAff >= 25f)
				{
					PlayerPrefs.SetString("ChapterTitle", "Episode4");
					menu = 17;
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					PlayerPrefs.SetInt("LiedFail", 1);
				}

			}
			else if (date[0] == 11 && date[1] == 15)
			{
				if (liedAff >= 30f)
				{
					data = LiedDialogue[4].text.Split(new char[] { '$' });
					menu = 18;
					PlayerPrefs.SetString("ChapterTitle", "Episode5");
					PlayerPrefs.SetInt("KleinFail", 1);
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else if (kleinAff >= 35f)
				{
					data = KleinDialogue[5].text.Split(new char[] { '$' });
					menu = 31;
					PlayerPrefs.SetString("ChapterTitle", "Episode6");
					PlayerPrefs.SetInt("LiedFail", 1);
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					data = LiedDialogue[4].text.Split(new char[] { '$' });
					PlayerPrefs.SetInt("LiedFail", 1);
					PlayerPrefs.SetInt("KleinFail", 1);
				}

			}
			else if (date[0] == 11 && date[1] == 17)
			{
				data = LiedDialogue[5].text.Split(new char[] { '$' });
				if (liedAff >= 35f)
				{
					PlayerPrefs.SetString("ChapterTitle", "Episode6");
					menu = 19;
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					PlayerPrefs.SetInt("LiedFail", 1);
				}

			}
			else if (date[0] == 11 && date[1] == 25)
			{
				data = LiedDialogue[6].text.Split(new char[] { '$' });
				if (liedAff >= 40f)
				{
					PlayerPrefs.SetString("ChapterTitle", "Episode7");
					menu = 20;
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					PlayerPrefs.SetInt("LiedFail", 1);
				}

			}
			else if (date[0] == 11 && date[1] == 30)
			{
				data = LiedDialogue[7].text.Split(new char[] { '$' });
				if (liedAff >= 45f)
				{
					PlayerPrefs.SetString("ChapterTitle", "Episode8");
					menu = 21;
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					PlayerPrefs.SetInt("LiedFail", 1);
				}

			}
			else if (date[0] == 12 && date[1] == 3)
			{
				if (liedAff >= 50f)
				{
					data = LiedDialogue[8].text.Split(new char[] { '$' });
					menu = 22;
					PlayerPrefs.SetString("ChapterTitle", "Episode9");
					PlayerPrefs.SetInt("KleinFail", 1);
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else if (kleinAff >= 50f)
				{
					data = KleinDialogue[8].text.Split(new char[] { '$' });
					menu = 34;
					PlayerPrefs.SetString("ChapterTitle", "Episode9");
					PlayerPrefs.SetInt("LiedFail", 1);
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					data = LiedDialogue[8].text.Split(new char[] { '$' });
					PlayerPrefs.SetInt("LiedFail", 1);
					PlayerPrefs.SetInt("KleinFail", 1);
				}

			}
			else if (date[0] == 12 && date[1] == 6)
			{
				data = LiedDialogue[9].text.Split(new char[] { '$' });
				if (liedAff >= 55f)
				{
					menu = 23;
					PlayerPrefs.SetString("ChapterTitle", "Episode10");
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					PlayerPrefs.SetInt("LiedFail", 1);
				}

			}
			else if (date[0] == 12 && date[1] == 9)
			{
				if (liedAff >= 60f)
				{
					data = LiedDialogue[10].text.Split(new char[] { '$' });
					menu = 24;
					PlayerPrefs.SetString("ChapterTitle", "Episode11");
					PlayerPrefs.SetInt("KleinFail", 1);
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else if (kleinAff >= 60f)
				{
					data = KleinDialogue[10].text.Split(new char[] { '$' });
					menu = 36;
					PlayerPrefs.SetString("ChapterTitle", "Episode11");
					PlayerPrefs.SetInt("LiedFail", 1);
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					data = LiedDialogue[10].text.Split(new char[] { '$' });
					PlayerPrefs.SetInt("LiedFail", 1);
					PlayerPrefs.SetInt("KleinFail", 1);
				}

			}
			else if (date[0] == 12 && date[1] == 10)
			{
				if (liedAff >= 60f)
				{
					data = LiedDialogue[11].text.Split(new char[] { '$' });
					menu = 25;
					PlayerPrefs.SetString("ChapterTitle", "Epilogue");
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					data = KleinDialogue[11].text.Split(new char[] { '$' });
					menu = 37;
					PlayerPrefs.SetString("ChapterTitle", "Epilogue");
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
			}

			//Klein

			else if (date[0] == 10 && date[1] == 16)
			{
				data = KleinDialogue[0].text.Split(new char[] { '$' });
				if (kleinAff >= 10)
				{
					menu = 26;
					PlayerPrefs.SetString("ChapterTitle", "Episode1");
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					PlayerPrefs.SetInt("KleinFail", 1);
				}
			}
			else if (date[0] == 10 && date[1] == 18)
			{
				data = KleinDialogue[1].text.Split(new char[] { '$' });
				if (kleinAff >= 15)
				{
					menu = 27;
					PlayerPrefs.SetString("ChapterTitle", "Episode2");
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					PlayerPrefs.SetInt("KleinFail", 1);
				}
			}
			else if (date[0] == 10 && date[1] == 25)
			{
				data = KleinDialogue[2].text.Split(new char[] { '$' });
				if (kleinAff >= 20)
				{
					PlayerPrefs.SetString("ChapterTitle", "Episode3");
					menu = 28;
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					PlayerPrefs.SetInt("KleinFail", 1);
				}

			}
			else if (date[0] == 11 && date[1] == 3)
			{
				data = KleinDialogue[3].text.Split(new char[] { '$' });
				if (kleinAff >= 25)
				{
					PlayerPrefs.SetString("ChapterTitle", "Episode4");
					menu = 29;
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					PlayerPrefs.SetInt("KleinFail", 1);
				}
			}
			else if (date[0] == 11 && date[1] == 10)
			{
				data = KleinDialogue[4].text.Split(new char[] { '$' });
				if (kleinAff >= 30)
				{
					PlayerPrefs.SetString("ChapterTitle", "Episode5");
					menu = 30;
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					PlayerPrefs.SetInt("KleinFail", 1);
				}
			}
			else if (date[0] == 11 && date[1] == 20)
			{
				data = KleinDialogue[6].text.Split(new char[] { '$' });
				if (kleinAff >= 40)
				{
					PlayerPrefs.SetString("ChapterTitle", "Episode7");
					menu = 32;
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					PlayerPrefs.SetInt("KleinFail", 1);
				}
			}
			else if (date[0] == 11 && date[1] == 27)
			{
				data = KleinDialogue[7].text.Split(new char[] { '$' });
				if (kleinAff >= 45)
				{
					PlayerPrefs.SetString("ChapterTitle", "Episode8");
					menu = 33;
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					PlayerPrefs.SetInt("KleinFail", 1);
				}
			}
			else if (date[0] == 12 && date[1] == 7)
			{
				data = KleinDialogue[9].text.Split(new char[] { '$' });
				if (kleinAff >= 55)
				{
					PlayerPrefs.SetString("ChapterTitle", "Episode10");
					menu = 35;
					PlayerPrefs.SetInt("NovelMenu", menu);
				}
				else
				{
					PlayerPrefs.SetInt("KleinFail", 1);
				}
			}


			//Lied failed
			int liedFail = PlayerPrefs.GetInt("LiedFail");
			if (liedFail == 1 && ((date[0] == 10 && date[1] == 15) || (date[0] == 10 && date[1] == 20) ||
				(date[0] == 10 && date[1] == 30) || (date[0] == 11 && date[1] == 8) ||
				(date[0] == 11 && date[1] == 17) || (date[0] == 11 && date[1] == 25) ||
				(date[0] == 11 && date[1] == 30) || (date[0] == 12 && date[1] == 6)))
			{
				menu = 12;
			}

			//Klein failed
			int kleinFail = PlayerPrefs.GetInt("KleinFail");
			if (kleinFail == 1 && ((date[0] == 10 && date[1] == 16) || (date[0] == 10 && date[1] == 18) ||
				(date[0] == 10 && date[1] == 25) || (date[0] == 11 && date[1] == 3) ||
				(date[0] == 11 && date[1] == 10) || (date[0] == 11 && date[1] == 20) ||
				(date[0] == 11 && date[1] == 27) || (date[0] == 12 && date[1] == 7)))
			{
				menu = 12;
			}

			//Both dates failed
			if (kleinFail == 1 && liedFail == 1 && ((date[0] == 11 && date[1] == 15) || (date[0] == 12 && date[1] == 3) ||
				(date[0] == 12 && date[1] == 9) || (date[0] == 12 && date[1] == 10)))
			{
				menu = 12;
			}
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
		if(manager == true)
		{
			Manage();
		}
		if(voiceManager == true)
		{
			VoiceManage();
		}
	}


	public void First()
	{
		int logNumber = PlayerPrefs.GetInt("LogNow");
		int miniGame = PlayerPrefs.GetInt("MiniGame");
		int resetFrom = PlayerPrefs.GetInt("ResetPos");
		int novelMenu = PlayerPrefs.GetInt("NovelMenu");

		if (novelMenu == 11)
		{
			row = itemData[1].Split(new char[] { ',' });

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


		//Start Lied

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
			for (int i = 1; i < 45; i++)
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
		else if (novelMenu == 24 && resetFrom == 48)
		{
			resetPos = 49;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 45; i++)
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
		else if (novelMenu == 25 && resetFrom == 56)
		{
			resetPos = 57;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 31; i++)
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


		//Start Klein

		else if (novelMenu == 26 && resetFrom == 58)
		{
			resetPos = 59;
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
		else if (novelMenu == 27 && resetFrom == 62)
		{
			resetPos = 63;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 36; i++)
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
		else if (novelMenu == 28 && resetFrom == 66)
		{
			resetPos = 67;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 33; i++)
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
		else if (novelMenu == 29 && resetFrom == 72)
		{
			resetPos = 73;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 73; i++)
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
		else if (novelMenu == 30 && resetFrom == 76)
		{
			resetPos = 77;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 32; i++)
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
		else if (novelMenu == 31 && resetFrom == 28)
		{
			resetPos = 82;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 36; i++)
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
		else if (novelMenu == 32 && resetFrom == 85)
		{
			resetPos = 86;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 89; i++)
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
		else if (novelMenu == 33 && resetFrom == 91)
		{
			resetPos = 92;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 90; i++)
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
		else if (novelMenu == 34 && resetFrom == 42)
		{
			resetPos = 95;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 56; i++)
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
		else if (novelMenu == 35 && resetFrom == 98)
		{
			resetPos = 99;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 117; i++)
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
		else if (novelMenu == 36 && resetFrom == 48)
		{
			resetPos = 100;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 109; i++)
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
		else if (novelMenu == 37 && resetFrom == 56)
		{
			resetPos = 107;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 1; i < 37; i++)
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

		///////////////////////////////////////////////CG//////////////////////////////

		else if (novelMenu == 24 && resetFrom == 108)
		{
			resetPos = 109;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 502; i < 513; i++)
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
		else if (novelMenu == 36 && resetFrom == 110)
		{
			resetPos = 111;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 533; i < 541; i++)
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
		else if (novelMenu == 25 && resetFrom == 112)
		{
			resetPos = 113;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 25; i < 31; i++)
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
		else if (novelMenu == 37 && resetFrom == 114)
		{
			resetPos = 115;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 26; i < 37; i++)
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
		else if (novelMenu == 24 && resetFrom == 116)
		{
			resetPos = 117;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 208; i < 226; i++)
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
		else if (novelMenu == 17 && resetFrom == 118)
		{
			resetPos = 119;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 44; i < 67; i++)
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
		else if (novelMenu == 21 && resetFrom == 120)
		{
			resetPos = 121;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 129; i < 145; i++)
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
		else if (novelMenu == 28 && resetFrom == 122)
		{
			resetPos = 123;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 94; i < 105; i++)
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
		else if (novelMenu == 29 && resetFrom == 124)
		{
			resetPos = 125;
			PlayerPrefs.SetInt("LogNow", 1);
			for (int i = 50; i < 63; i++)
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
			whichLineNow = 173;
			PlayerPrefsX.SetIntArray("Date", dateNow);

			resetPos = 5;
			PlayerPrefs.SetInt("MiniGame", 0);
			for (int i = 173; i < 180; i++)
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
			whichLineNow = 180;
			PlayerPrefsX.SetIntArray("Date", dateNow);

			resetPos = 6;
			PlayerPrefs.SetInt("MiniGame", 0);
			for (int i = 180; i < 191; i++)
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
			whichLineNow = 191;
			resetPos = 7;

			for (int i = 191; i < 214; i++)
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
			for (int i = logNumber; i < 132; i++)
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

			for (int i = logNumber; i < 132; i++)
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
			for (int i = logNumber; i < 173; i++)
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
			for (int i = logNumber; i < 173; i++)
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
			for (int i = logNumber; i < 180; i++)
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
			for (int i = logNumber; i < 180; i++)
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
			for (int i = logNumber; i < 214; i++)
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
			for (int i = logNumber; i < 265; i++)
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
			for (int i = logNumber; i < 265; i++)
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
			for (int i = logNumber; i < 93; i++)
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
			for (int i = logNumber; i < 93; i++)
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
			for (int i = logNumber; i < 100; i++)
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
			for (int i = logNumber; i < 100; i++)
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
			for (int i = logNumber; i < 169; i++)
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
			for (int i = logNumber; i < 169; i++)
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
			for (int i = logNumber; i < 160; i++)
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
			for (int i = logNumber; i < 160; i++)
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
			for (int i = logNumber; i < 222; i++)
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
			for (int i = logNumber; i < 222; i++)
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
		else if (resetFrom == 49)
		{
			for (int i = logNumber; i < 45; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		else if (resetFrom == 50)
		{
			for (int i = logNumber; i < 79; i++)
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
		else if (resetFrom == 51)
		{
			for (int i = logNumber; i < 112; i++)
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
		else if (resetFrom == 52)
		{
			for (int i = logNumber; i < 130; i++)
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
		else if (resetFrom == 53)
		{
			for (int i = logNumber; i < 357; i++)
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
		else if (resetFrom == 54)
		{
			for (int i = logNumber; i < 385; i++)
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
		else if (resetFrom == 55)
		{
			for (int i = logNumber; i < 514; i++)
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
		else if (resetFrom == 57)
		{
			for (int i = logNumber; i < 31; i++)
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

		////////////////////////////////////////////Klein /////////////////////////////////////////////////////

		else if (resetFrom == 59)
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
		else if (resetFrom == 60)
		{
			for (int i = logNumber; i < 75; i++)
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
		else if (resetFrom == 61)
		{
			for (int i = logNumber; i < 75; i++)
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
		else if (resetFrom == 63)
		{
			for (int i = logNumber; i < 36; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		else if (resetFrom == 64)
		{
			for (int i = logNumber; i < 107; i++)
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
		else if (resetFrom == 65)
		{
			for (int i = logNumber; i < 107; i++)
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
		else if (resetFrom == 67)
		{
			for (int i = logNumber; i < 33; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		else if (resetFrom == 68)
		{
			for (int i = logNumber; i < 123; i++)
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
		else if (resetFrom == 69)
		{
			for (int i = logNumber; i < 123; i++)
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
		else if (resetFrom == 70)
		{
			for (int i = logNumber; i < 137; i++)
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
		else if (resetFrom == 71)
		{
			for (int i = logNumber; i < 137; i++)
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
		else if (resetFrom == 73)
		{
			for (int i = logNumber; i < 73; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		else if (resetFrom == 74)
		{
			for (int i = logNumber; i < 123; i++)
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
		else if (resetFrom == 75)
		{
			for (int i = logNumber; i < 123; i++)
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
		else if (resetFrom == 77)
		{
			for (int i = logNumber; i < 32; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		else if (resetFrom == 78)
		{
			for (int i = logNumber; i < 69; i++)
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
		else if (resetFrom == 79)
		{
			for (int i = logNumber; i < 69; i++)
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
		else if (resetFrom == 80)
		{
			for (int i = logNumber; i < 148; i++)
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
		else if (resetFrom == 81)
		{
			for (int i = logNumber; i < 148; i++)
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
		else if (resetFrom == 82)
		{
			for (int i = logNumber; i < 36; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		else if (resetFrom == 83)
		{
			for (int i = logNumber; i < 124; i++)
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
		else if (resetFrom == 84)
		{
			for (int i = logNumber; i < 124; i++)
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
		else if (resetFrom == 86)
		{
			for (int i = logNumber; i < 89; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		else if (resetFrom == 87)
		{
			for (int i = logNumber; i < 196; i++)
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
		else if (resetFrom == 88)
		{
			for (int i = logNumber; i < 196; i++)
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
		else if (resetFrom == 89)
		{
			for (int i = logNumber; i < 230; i++)
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
		else if (resetFrom == 90)
		{
			for (int i = logNumber; i < 230; i++)
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
		else if (resetFrom == 92)
		{
			for (int i = logNumber; i < 90; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		else if (resetFrom == 93)
		{
			for (int i = logNumber; i < 149; i++)
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
		else if (resetFrom == 94)
		{
			for (int i = logNumber; i < 149; i++)
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
		else if (resetFrom == 95)
		{
			for (int i = logNumber; i < 56; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		else if (resetFrom == 96)
		{
			for (int i = logNumber; i < 105; i++)
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
		else if (resetFrom == 97)
		{
			for (int i = logNumber; i < 105; i++)
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
		else if (resetFrom == 99)
		{
			for (int i = logNumber; i < 117; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		else if (resetFrom == 100)
		{
			for (int i = logNumber; i < 109; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		else if (resetFrom == 101)
		{
			for (int i = logNumber; i < 235; i++)
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
		else if (resetFrom == 102)
		{
			for (int i = logNumber; i < 135; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		else if (resetFrom == 103)
		{
			for (int i = logNumber; i < 248; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		else if (resetFrom == 104)
		{
			for (int i = logNumber; i < 389; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		else if (resetFrom == 105)
		{
			for (int i = logNumber; i < 607; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		else if (resetFrom == 106)
		{
			for (int i = logNumber; i < 627; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		else if (resetFrom == 107)
		{
			for (int i = logNumber; i < 37; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		int menu = PlayerPrefs.GetInt("NovelMenu");

		if(menu != 11)
		{
			AudioManager(logNumber);		
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

			string[] tempRow = data[214].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/KleinLove_high", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[214].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/KleinLove_low", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;

		}
		if (finishTemp4 == true)
		{
			TwoChoices.SetActive(true);

			string[] tempRow = itemData[2].Split(new char[] { ',' });
			string Filtered1 = tempRow[8].Replace("『", "");
			string Filtered2 = Filtered1.Replace("』", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = itemData[2].Split(new char[] { ',' });
			string Filtered4 = tempRow2[9].Replace("『", "");
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
			FirstTwo.fontSize = 28;
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
			string Filtered6 = tempRow2[9].Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp14 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[44].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/end", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[44].Split(new char[] { ',' });
			string Filtered6 = tempRow2[9].Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp15 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[112].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/end", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[112].Split(new char[] { ',' });
			string Filtered6 = tempRow2[9].Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp16 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[357].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/end", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[357].Split(new char[] { ',' });
			string Filtered6 = tempRow2[9].Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp17 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[40].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/KleinLove_low", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[40].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/KleinLove_high", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp18 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[36].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/KleinLove_high", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[36].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/KleinLove_low", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp19 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[33].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/KleinLove_high", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[33].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/Klein_gameover", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp20 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[123].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/KleinLove_low", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[123].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/KleinLove_high", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp21 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[73].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/KleinLove_low", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[73].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/KleinLove_high", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp22 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[32].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/KleinLove_low", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[32].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/KleinLove_high", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp23 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[69].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/KleinLove_low", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[69].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/KleinLove_low", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp24 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[36].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/KleinLove_low", "");
			string Filtered3 = tempRow[8].Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[36].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/KleinLove_low", "");
			string Filtered6 = tempRow2[9].Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp25 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[89].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/KleinLove_low", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[89].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/KleinLove_high", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp26 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[196].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/KleinLove_high", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[196].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/KleinLove_low", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp27 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[90].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/KleinLove_lowdown", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[90].Split(new char[] { ',' });
			string Filtered6 = tempRow2[9].Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp28 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[56].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/KleinLove_low", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[56].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/KleinLove_high", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp29 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[109].Split(new char[] { ',' });
			string Filtered3 = tempRow[8].Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[109].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/end", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp30 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[235].Split(new char[] { ',' });
			string Filtered2 = tempRow[8].Replace("/end", "");
			string Filtered3 = Filtered2.Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[235].Split(new char[] { ',' });
			string Filtered6 = tempRow2[9].Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
		if (finishTemp31 == true)
		{
			TwoChoices.SetActive(true);
			string[] tempRow = data[389].Split(new char[] { ',' });
			string Filtered3 = tempRow[8].Replace("\"", "");
			FirstTwo.text = Filtered3;

			string[] tempRow2 = data[389].Split(new char[] { ',' });
			string Filtered5 = tempRow2[9].Replace("/end", "");
			string Filtered6 = Filtered5.Replace("\"", "");
			SecondTwo.text = Filtered6;
		}
	}

	void AudioManager(int num)
	{
		string[] firstLine = data[num].Split(new char[] { ',' });
		string music = firstLine[7];

		whichBGClip = PlayerPrefs.GetString("BackgroundClip");
		string digi;

		for (int i = 0; i < 23; i++)
		{
			if ((i + 1) < 10)
			{
				digi = "00";
			}
			else
			{
				digi = "0";
			}


			if (whichBGClip.Contains("BGM-" + digi + (i + 1).ToString()) && music == "")
			{
				BGM.clip = BGMFile[i];
				BGM.Play();
			}
			else if(whichBGClip == "")
			{
				BGM.Stop();
			}
		}

		if (whichBGClip.Contains("working_morning") && music == "")
		{
			BGM.clip = BGMFile[23];
			BGM.Play();
		}

	}

	public void ShowDialogue()
	{
		StartCoroutine(DialogueGo());
	}

	void VoiceManage()
	{
		if (autoScroll.dialogueIsSkipped == false)
    	{
			if (voice != "" && id <= 3883 && dialogueManager.next == false)
			{
        		AudioClip file = assetBundle.LoadAsset<AudioClip>(voice.ToString());
				Voice.clip = file;
				Voice.Play();
				
				mouthStop = false;
    			//MouthAnim
 				if (expression.Contains("L-01"))
				{
					StartCoroutine(MouthAnim(0, 1, 2, Voice.clip.length));
				}
				else if (expression.Contains("L-02"))
            	{
            	    StartCoroutine(MouthAnim(3, 4, 5, Voice.clip.length));
            	}
            	else if (expression.Contains("L-03"))
            	{
            	    StartCoroutine(MouthAnim(6, 7, 8, Voice.clip.length));
            	}
            	else if (expression.Contains("L-04"))
            	{
            	    StartCoroutine(MouthAnim(9, 10, 11, Voice.clip.length));
            	}
            	else if (expression.Contains("L-05"))
            	{
            	    StartCoroutine(MouthAnim(12, 13, 14, Voice.clip.length));
            	}
            	else if (expression.Contains("L-06"))
            	{
            	    StartCoroutine(MouthAnim(15, 16, 17, Voice.clip.length));
            	}
            	else if (expression.Contains("L-07"))
            	{
            	    StartCoroutine(MouthAnim(18, 19, 20, Voice.clip.length));
            	}
            	else if (expression.Contains("L-08"))
            	{
            	    StartCoroutine(MouthAnim(21, 22, 23, Voice.clip.length));
            	}
            	else if (expression.Contains("L-09"))
            	{
            	    StartCoroutine(MouthAnim(24, 25, 26, Voice.clip.length));
            	}
            	else if (expression.Contains("L-10"))
            	{
            	    StartCoroutine(MouthAnim(27, 28, 29, Voice.clip.length));
            	}
            	else if (expression.Contains("L-11"))
            	{
            	    StartCoroutine(MouthAnim(97, 98, 99, Voice.clip.length));
            	}
            	else if (expression.Contains("L-12"))
            	{
            	    StartCoroutine(MouthAnim(100, 101, 102, Voice.clip.length));
            	}
            	else if (expression.Contains("K-01"))
            	{
            	    StartCoroutine(MouthAnim(31, 32, 33, Voice.clip.length));
            	}
            	else if (expression.Contains("K-02"))
            	{
            	    StartCoroutine(MouthAnim(34, 35, 36, Voice.clip.length));
            	}
            	else if (expression.Contains("K-03"))
            	{
            	    StartCoroutine(MouthAnim(37, 38, 39, Voice.clip.length));
            	}
            	else if (expression.Contains("K-04"))
            	{
            	    StartCoroutine(MouthAnim(40, 41, 42, Voice.clip.length));
            	}
            	else if (expression.Contains("K-05"))
            	{
            	    StartCoroutine(MouthAnim(43, 44, 45, Voice.clip.length));
            	}
            	else if (expression.Contains("K-06"))
            	{
            	    StartCoroutine(MouthAnim(46, 47, 48, Voice.clip.length));
            	}
            	else if (expression.Contains("K-07"))
            	{
            	    StartCoroutine(MouthAnim(49, 50, 51, Voice.clip.length));
            	}
            	else if (expression.Contains("K-08"))
            	{
            	    StartCoroutine(MouthAnim(52, 53, 54, Voice.clip.length));
            	}
            	else if (expression.Contains("K-09"))
            	{
            	    StartCoroutine(MouthAnim(55, 56, 57, Voice.clip.length));
            	}
            	else if (expression.Contains("K-10"))
            	{
            	    StartCoroutine(MouthAnim(58, 59, 60, Voice.clip.length));
            	}
            	else if (expression.Contains("K-11"))
            	{
            	    StartCoroutine(MouthAnim(60, 62, 63, Voice.clip.length));
            	}
            	else if (expression.Contains("G-01"))
            	{
            	    StartCoroutine(MouthAnim(64, 65, 66, Voice.clip.length));
            	}
            	else if (expression.Contains("G-02"))
            	{
            	    StartCoroutine(MouthAnim(67, 68, 69, Voice.clip.length));
            	}
            	else if (expression.Contains("G-03"))
            	{
            	    StartCoroutine(MouthAnim(70, 71, 72, Voice.clip.length));
            	}
            	else if (expression.Contains("G-04"))
            	{
            	    StartCoroutine(MouthAnim(73, 74, 75, Voice.clip.length));
            	}
            	else if (expression.Contains("G-05"))
            	{
            	    StartCoroutine(MouthAnim(76, 77, 78, Voice.clip.length));
            	}
            	else if (expression.Contains("G-06"))
            	{
            	    StartCoroutine(MouthAnim(79, 80, 81, Voice.clip.length));
            	}
            	else if (expression.Contains("G-07"))
            	{
            	    StartCoroutine(MouthAnim(82, 83, 84, Voice.clip.length));
            	}
            	else if (expression.Contains("T-01"))
            	{
            	    StartCoroutine(MouthAnim(85, 86, 87, Voice.clip.length));
            	}
            	else if (expression.Contains("T-02"))
            	{
            	    StartCoroutine(MouthAnim(88, 89, 90, Voice.clip.length));
            	}
            	else if (expression.Contains("T-03"))
            	{
            	    StartCoroutine(MouthAnim(91, 92, 93, Voice.clip.length));
            	}
            	else if (expression.Contains("T-04"))
            	{
            	    StartCoroutine(MouthAnim(94, 95, 96, Voice.clip.length));
            	}

            	if (showtwoone.Contains("L-01"))
            	{
            	    StartCoroutine(MouthAnim1(0, 1, 2, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("L-02"))
            	{
            	    StartCoroutine(MouthAnim1(3, 4, 5, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("L-03"))
            	{
            	    StartCoroutine(MouthAnim1(6, 7, 8, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("L-04"))
            	{
            	    StartCoroutine(MouthAnim1(9, 10, 11, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("L-05"))
            	{
            	    StartCoroutine(MouthAnim1(12, 13, 14, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("L-06"))
            	{
            	    StartCoroutine(MouthAnim1(15, 16, 17, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("L-07"))
            	{
            	    StartCoroutine(MouthAnim1(18, 19, 20, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("L-08"))
            	{
            	    StartCoroutine(MouthAnim1(21, 22, 23, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("L-09"))
            	{
            	    StartCoroutine(MouthAnim1(24, 25, 26, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("L-10"))
            	{
            	    StartCoroutine(MouthAnim1(27, 28, 29, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("K-01"))
            	{
            	    StartCoroutine(MouthAnim1(31, 32, 33, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("K-02"))
            	{
            	    StartCoroutine(MouthAnim1(34, 35, 36, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("K-03"))
            	{
            	    StartCoroutine(MouthAnim1(37, 38, 39, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("K-04"))
            	{
            	    StartCoroutine(MouthAnim1(40, 41, 42, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("K-05"))
            	{
            	    StartCoroutine(MouthAnim1(43, 44, 45, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("K-06"))
            	{
            	    StartCoroutine(MouthAnim1(46, 47, 48, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("K-07"))
            	{
            	    StartCoroutine(MouthAnim1(49, 50, 51, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("K-08"))
            	{
            	    StartCoroutine(MouthAnim1(52, 53, 54, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("K-09"))
            	{
            	    StartCoroutine(MouthAnim1(55, 56, 57, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("K-10"))
            	{
            	    StartCoroutine(MouthAnim1(58, 59, 60, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("K-11"))
            	{
            	    StartCoroutine(MouthAnim1(60, 62, 63, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("G-01"))
            	{
            	    StartCoroutine(MouthAnim1(64, 65, 66, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("G-02"))
            	{
            	    StartCoroutine(MouthAnim1(67, 68, 69, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("G-03"))
            	{
            	    StartCoroutine(MouthAnim1(70, 71, 72, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("G-04"))
            	{
            	    StartCoroutine(MouthAnim1(73, 74, 75, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("G-05"))
            	{
            	    StartCoroutine(MouthAnim1(76, 77, 78, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("G-06"))
            	{
            	    StartCoroutine(MouthAnim1(79, 80, 81, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("G-07"))
            	{
            	    StartCoroutine(MouthAnim1(82, 83, 84, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("T-01"))
            	{
            	    StartCoroutine(MouthAnim1(85, 86, 87, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("T-02"))
            	{
            	    StartCoroutine(MouthAnim1(88, 89, 90, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("T-03"))
            	{
            	    StartCoroutine(MouthAnim1(91, 92, 93, Voice.clip.length));
            	}
            	else if (showtwoone.Contains("T-04"))
            	{
            	    StartCoroutine(MouthAnim1(94, 95, 96, Voice.clip.length));
            	}

            	if (showtwotwo.Contains("L-01"))
            	{
            	    StartCoroutine(MouthAnim2(0, 1, 2, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("L-02"))
            	{
            	    StartCoroutine(MouthAnim2(3, 4, 5, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("L-03"))
            	{
            	    StartCoroutine(MouthAnim2(6, 7, 8, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("L-04"))
            	{
            	    StartCoroutine(MouthAnim2(9, 10, 11, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("L-05"))
            	{
            	    StartCoroutine(MouthAnim2(12, 13, 14, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("L-06"))
            	{
            	    StartCoroutine(MouthAnim2(15, 16, 17, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("L-07"))
            	{
            	    StartCoroutine(MouthAnim2(18, 19, 20, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("L-08"))
            	{
            	    StartCoroutine(MouthAnim2(21, 22, 23, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("L-09"))
            	{
            	    StartCoroutine(MouthAnim2(24, 25, 26, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("L-10"))
            	{
            	    StartCoroutine(MouthAnim2(27, 28, 29, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("K-01"))
            	{
            	    StartCoroutine(MouthAnim2(31, 32, 33, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("K-02"))
            	{
            	    StartCoroutine(MouthAnim2(34, 35, 36, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("K-03"))
            	{
            	    StartCoroutine(MouthAnim2(37, 38, 39, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("K-04"))
            	{
            	    StartCoroutine(MouthAnim2(40, 41, 42, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("K-05"))
            	{
            	    StartCoroutine(MouthAnim2(43, 44, 45, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("K-06"))
            	{
            	    StartCoroutine(MouthAnim2(46, 47, 48, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("K-07"))
            	{
            	    StartCoroutine(MouthAnim2(49, 50, 51, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("K-08"))
            	{
            	    StartCoroutine(MouthAnim2(52, 53, 54, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("K-09"))
            	{
            	    StartCoroutine(MouthAnim2(55, 56, 57, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("K-10"))
            	{
            	    StartCoroutine(MouthAnim2(58, 59, 60, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("K-11"))
            	{
            	    StartCoroutine(MouthAnim2(60, 62, 63, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("G-01"))
            	{
            	    StartCoroutine(MouthAnim2(64, 65, 66, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("G-02"))
            	{
            	    StartCoroutine(MouthAnim2(67, 68, 69, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("G-03"))
            	{
            	    StartCoroutine(MouthAnim2(70, 71, 72, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("G-04"))
            	{
            	    StartCoroutine(MouthAnim2(73, 74, 75, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("G-05"))
            	{
            	    StartCoroutine(MouthAnim2(76, 77, 78, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("G-06"))
            	{
            	    StartCoroutine(MouthAnim2(79, 80, 81, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("G-07"))
            	{
            	    StartCoroutine(MouthAnim2(82, 83, 84, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("T-01"))
            	{
            	    StartCoroutine(MouthAnim2(85, 86, 87, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("T-02"))
            	{
            	    StartCoroutine(MouthAnim2(88, 89, 90, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("T-03"))
            	{
            	    StartCoroutine(MouthAnim2(91, 92, 93, Voice.clip.length));
            	}
            	else if (showtwotwo.Contains("T-04"))
            	{
            	    StartCoroutine(MouthAnim2(94, 95, 96, Voice.clip.length));
            	}
			}
        	else
        	{
    	    	Voice.Stop();
    		}
			if (autoScroll.dialogueIsSkipped == false)
            {
                if (sound.Contains("SE-001"))
                {
                    SE.clip = SEFile[0];
                    SE.Play();
                }
                else if (sound.Contains("SE-002"))
                {
                    SE.clip = SEFile[1];
                    SE.Play();
                }
                else if (sound.Contains("SE-003"))
                {
                    SE.clip = SEFile[2];
                    SE.Play();
                }
                else if (sound.Contains("SE-004"))
                {
                    SE.clip = SEFile[3];
                    SE.Play();
                }
                else if (sound.Contains("SE-005"))
                {
                    SE.clip = SEFile[4];
                    SE.Play();
                }
                else if (sound.Contains("SE-006"))
                {
                    SE.clip = SEFile[5];
                    SE.Play();
                }
                else if (sound.Contains("SE-007"))
                {
                    SE.clip = SEFile[6];
                    SE.Play();
                }
                else if (sound.Contains("SE-008"))
                {
                    SE.clip = SEFile[7];
                    SE.Play();
                }
                else if (sound.Contains("SE-009"))
                {
                    SE.clip = SEFile[8];
                    SE.Play();
                }
                else if (sound.Contains("SE-010"))
                {
                    SE.clip = SEFile[9];
                    SE.Play();
                }
                else if (sound.Contains("SE-011"))
                {
                    SE.clip = SEFile[10];
                    SE.Play();
                }
                else if (sound.Contains("SE-012"))
                {
                    SE.clip = SEFile[11];
                    SE.Play();
                }
                else if (sound.Contains("SE-013"))
                {
                    SE.clip = SEFile[12];
                    SE.Play();
                }
                else if (sound.Contains("SE-014"))
                {
                    SE.clip = SEFile[13];
                    SE.Play();
                }
                else if (sound.Contains("SE-015"))
                {
                    SE.clip = SEFile[14];
                    SE.Play();
                }
                else if (sound.Contains("SE-016"))
                {
                    SE.clip = SEFile[15];
                    SE.Play();
                }
                else if (sound.Contains("SE-017"))
                {
                    SE.clip = SEFile[16];
                    SE.Play();
                }
                else if (sound.Contains("SE-018"))
                {
                    SE.clip = SEFile[17];
                    SE.Play();
                }
                else if (sound.Contains("SE-019"))
                {
                    SE.clip = SEFile[18];
                    SE.Play();
                }
                else if (sound.Contains("SE-020"))
                {
                    SE.clip = SEFile[19];
                    SE.Play();
                }
                else if (sound.Contains("SE-021"))
                {
                    SE.clip = SEFile[20];
                    SE.Play();
                }
                else if (sound.Contains("SE-022"))
                {
                    SE.clip = SEFile[21];
                    SE.Play();
                }
                else if (sound.Contains("SE-023"))
                {
                    SE.clip = SEFile[22];
                    SE.Play();
                }
                else if (sound.Contains("SE-024"))
                {
                    SE.clip = SEFile[23];
                    SE.Play();
                }
                else if (sound.Contains("SE-025"))
                {
                    SE.clip = SEFile[24];
                    SE.Play();
                }
                else if (sound.Contains("SE-026"))
                {
                    SE.clip = SEFile[25];
                    SE.Play();
                }
                else if (sound.Contains("SE-027"))
                {
                    SE.clip = SEFile[26];
                    SE.Play();
                }
                else if (sound.Contains("SE-028"))
                {
                    SE.clip = SEFile[27];
                    SE.Play();
                }
                else if (sound.Contains("SE-029"))
                {
                    SE.clip = SEFile[28];
                    SE.Play();
                }
                else if (sound.Contains("SE-030"))
                {
                    SE.clip = SEFile[29];
                    SE.Play();
                }
                else if (sound.Contains("SE-031"))
                {
                    SE.clip = SEFile[30];
                    SE.Play();
                }
                else if (sound.Contains("SE-032"))
                {
                    SE.clip = SEFile[31];
                    SE.Play();
                }
                else if (sound.Contains("SE-033"))
                {
                    SE.clip = SEFile[32];
                    SE.Play();
                }
                else if (sound.Contains("SE-034"))
                {
                    SE.clip = SEFile[33];
                    SE.Play();
                }
                else if (sound.Contains("SE-035"))
                {
                    SE.clip = SEFile[34];
                    SE.Play();
                }
                else if (sound.Contains("SE-036"))
                {
                    SE.clip = SEFile[35];
                    SE.Play();
                }
                else if (sound.Contains("SE-037"))
                {
                    SE.clip = SEFile[36];
                    SE.Play();
                }
                else if (sound.Contains("SE-038"))
                {
                    SE.clip = SEFile[37];
                    SE.Play();
                }
                else if (sound.Contains("SE-039"))
                {
                    SE.clip = SEFile[38];
                    SE.Play();
                }
                else if (sound.Contains("SE-040"))
                {
                    SE.clip = SEFile[39];
                    SE.Play();
                }
                else if (sound.Contains("SE-041"))
                {
                    SE.clip = SEFile[40];
                    SE.Play();
                }
                else if (sound.Contains("SE-042"))
                {
                    SE.clip = SEFile[41];
                    SE.Play();
                }
                else if (sound.Contains("SE-043"))
                {
                    SE.clip = SEFile[42];
                    SE.Play();
                }
                else if (sound.Contains("SE-044"))
                {
                    SE.clip = SEFile[43];
                    SE.Play();
                }
                else if (sound.Contains("SE-045"))
                {
                    SE.clip = SEFile[44];
                    SE.Play();
                }
                else if (sound.Contains("SE-046"))
                {
                    SE.clip = SEFile[45];
                    SE.Play();
                }
                else if (sound.Contains("SE-047"))
                {
                    SE.clip = SEFile[46];
                    SE.Play();
                }
                else if (sound.Contains("SE-048"))
                {
                    SE.clip = SEFile[47];
                    SE.Play();
                }
                else if (sound.Contains("SE-049"))
                {
                    SE.clip = SEFile[48];
                    SE.Play();
                }
                else if (sound.Contains("SE-050"))
                {
                    SE.clip = SEFile[49];
                    SE.Play();
                }
                else
                {
                    SE.Stop();
                }
        	}
		}
		voiceManager = false;
	}

	void Manage()
	{
		if (back.Contains("still-006-a"))
		{
			textLabel.color = Color.white;
			StillImage.sprite = StillSprite[0];
			StillImage.color = new Color(255, 255, 255, 255);
			DialogueBG.sprite = null;
			DialogueBG.color = new Color(0, 0, 0, 0);
			StillDialogueBG.SetActive(true);
		    nameLabel.color = new Color(255, 255, 255, 255);
			Hide.SetBool("Still", true);
		}
		else if (back.Contains("still-006-b"))
		{
			textLabel.color = Color.white;
		    StillImage.sprite = StillSprite[1];
		    StillImage.color = new Color(255, 255, 255, 255);
		    DialogueBG.sprite = null;
		    DialogueBG.color = new Color(0, 0, 0, 0);
		    StillDialogueBG.SetActive(true);
		    nameLabel.color = new Color(255, 255, 255, 255);
		    Hide.SetBool("Still", true);
		}
		else if (back.Contains("still-006-c"))
		{
			textLabel.color = Color.white;
		    StillImage.sprite = StillSprite[2];
		    StillImage.color = new Color(255, 255, 255, 255);
		    DialogueBG.sprite = null;
		    DialogueBG.color = new Color(0, 0, 0, 0);
		    StillDialogueBG.SetActive(true);
		    nameLabel.color = new Color(255, 255, 255, 255);
		    Hide.SetBool("Still", true);
		}
		else if (back.Contains("still-001"))
		{
			textLabel.color = Color.white;
		    StillImage.sprite = StillSprite[3];
		    StillImage.color = new Color(255, 255, 255, 255);
		    DialogueBG.sprite = null;
		    DialogueBG.color = new Color(0, 0, 0, 0);
		    StillDialogueBG.SetActive(true);
		    nameLabel.color = new Color(255, 255, 255, 255);
		    Hide.SetBool("Still", true);
		}
		else if (back.Contains("still-003"))
		{
			textLabel.color = Color.white;
		    StillImage.sprite = StillSprite[4];
		    StillImage.color = new Color(255, 255, 255, 255);
		    DialogueBG.sprite = null;
		    DialogueBG.color = new Color(0, 0, 0, 0);
		    StillDialogueBG.SetActive(true);
		    nameLabel.color = new Color(255, 255, 255, 255);
		    Hide.SetBool("Still", true);
		}
		else if (back.Contains("still-004"))
		{
			textLabel.color = Color.white;
		    StillImage.sprite = StillSprite[8];
		    StillImage.color = new Color(255, 255, 255, 255);
		    DialogueBG.sprite = null;
		    DialogueBG.color = new Color(0, 0, 0, 0);
		    StillDialogueBG.SetActive(true);
		    nameLabel.color = new Color(255, 255, 255, 255);
		    Hide.SetBool("Still", true);
		}
		else if (back.Contains("still-005-a"))
		{
			textLabel.color = Color.white;
		    StillImage.sprite = StillSprite[5];
		    StillImage.color = new Color(255, 255, 255, 255);
		    DialogueBG.sprite = null;
		    DialogueBG.color = new Color(0, 0, 0, 0);
		    StillDialogueBG.SetActive(true);
		    nameLabel.color = new Color(255, 255, 255, 255);
		    Hide.SetBool("Still", true);
		}
		else if (back.Contains("still-005"))
		{
			textLabel.color = Color.white;
		    StillImage.sprite = StillSprite[6];
		    StillImage.color = new Color(255, 255, 255, 255);
		    DialogueBG.sprite = null;
		    DialogueBG.color = new Color(0, 0, 0, 0);
		    StillDialogueBG.SetActive(true);
		    nameLabel.color = new Color(255, 255, 255, 255);
		    Hide.SetBool("Still", true);
		}
		else if (back.Contains("still-007"))
		{
			textLabel.color = Color.white;
		    StillImage.sprite = StillSprite[7];
		    StillImage.color = new Color(255, 255, 255, 255);
		    DialogueBG.sprite = null;
		    DialogueBG.color = new Color(0, 0, 0, 0);
		    StillDialogueBG.SetActive(true);
		    nameLabel.color = new Color(255, 255, 255, 255);
		    Hide.SetBool("Still", true);
		}
		else if (back.Contains("still-008"))
		{
			textLabel.color = Color.white;
		    StillImage.sprite = StillSprite[9];
		    StillImage.color = new Color(255, 255, 255, 255);
		    DialogueBG.sprite = null;
		    DialogueBG.color = new Color(0, 0, 0, 0);
		    StillDialogueBG.SetActive(true);
		    nameLabel.color = new Color(255, 255, 255, 255);
		    Hide.SetBool("Still", true);
		}
		else if (back.Contains("still-009"))
		{
			textLabel.color = Color.white;
		    StillImage.sprite = StillSprite[10];
		    StillImage.color = new Color(255, 255, 255, 255);
		    DialogueBG.sprite = null;
		    DialogueBG.color = new Color(0, 0, 0, 0);
		    StillDialogueBG.SetActive(true);
		    nameLabel.color = new Color(255, 255, 255, 255);
		    Hide.SetBool("Still", true);
		}
		else
		{
			textLabel.color = Color.black;
		    StillImage.color = new Color(0, 0, 0, 0);
		    DialogueBG.sprite = DialogueBGImage;
		    DialogueBG.color = new Color(255f / 255, 255f / 255, 255f / 255, 200f / 255);
		    StillDialogueBG.SetActive(false);
		    nameLabel.color = new Color(255, 255, 255, 255);
		    Hide.SetBool("Still", false);
		}

		meiaShow = PlayerPrefs.GetInt("MeiaShow");

		if(meiaShow == 1 || back.Contains("still"))
		{
			MeiaImage.SetActive(false);
		}


		if (back.Contains("back-001"))
		{
		    backGroundLabel.text = backgrounds[0].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[1];
		}
		else if (back.Contains("back-002"))
		{
		    backGroundLabel.text = backgrounds[1].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[2];
		}
		else if (back.Contains("back-003-blue"))
		{
		    backGroundLabel.text = backgrounds[4].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[4];
		}
		else if (back.Contains("back-003-pink"))
		{
		    backGroundLabel.text = backgrounds[3].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[5];
		}
		else if (back.Contains("back-003"))
		{
		    backGroundLabel.text = backgrounds[2].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[3];
		}
		else if (back.Contains("back-004-sun"))
		{
		    backGroundLabel.text = backgrounds[5].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[6];
		}
		else if (back.Contains("back-004-night"))
		{
		    backGroundLabel.text = backgrounds[6].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[7];
		}
		else if (back.Contains("back-005-sun"))
		{
		    backGroundLabel.text = backgrounds[7].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[8];
		}
		else if (back.Contains("back-005-night"))
		{
		    backGroundLabel.text = backgrounds[8].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[9];
		}
		else if (back.Contains("back-006-a"))
		{
		    backGroundLabel.text = backgrounds[11].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[11];
		}
		else if (back.Contains("back-006"))
		{
		    backGroundLabel.text = backgrounds[9].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[10];
		}
		else if (back.Contains("back-007"))
		{
		    backGroundLabel.text = backgrounds[12].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[12];
		}
		else if (back.Contains("back-008"))
		{
		    backGroundLabel.text = backgrounds[13].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[13];
		}
		else if (back.Contains("back-009"))
		{
		    backGroundLabel.text = backgrounds[14].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[14];
		}
		else if (back.Contains("back-010"))
		{
		    backGroundLabel.text = backgrounds[15].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[15];
		}
		else if (back.Contains("back-011"))
		{
		    backGroundLabel.text = backgrounds[16].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[16];
		}
		else if (back.Contains("back-012"))
		{
		    backGroundLabel.text = backgrounds[17].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[17];
		}
		else if (back.Contains("back-013-night"))
		{
		    backGroundLabel.text = backgrounds[19].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[20];
		}
		else if (back.Contains("back-013-pink"))
		{
		    backGroundLabel.text = backgrounds[20].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[21];
		}
		else if (back.Contains("back-013-blue"))
		{
		    backGroundLabel.text = backgrounds[21].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[19];
		}
		else if (back.Contains("back-013"))
		{
		    backGroundLabel.text = backgrounds[18].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[18];
		}
		else if (back.Contains("back-014"))
		{
		    backGroundLabel.text = backgrounds[22].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[22];
		}
		else if (back.Contains("back-015-sun"))
		{
		    backGroundLabel.text = backgrounds[23].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[23];
		}
		else if (back.Contains("back-015-night"))
		{
		    backGroundLabel.text = backgrounds[24].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[24];
		}
		else if (back.Contains("back-016"))
		{
		    backGroundLabel.text = backgrounds[25].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[25];
		}
		else if (back.Contains("back-017"))
		{
		    backGroundLabel.text = backgrounds[26].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[26];
		}
		else if (back.Contains("back-019"))
		{
		    backGroundLabel.text = backgrounds[29].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[27];
		}
		else if (back.Contains("back-020"))
		{
		    backGroundLabel.text = backgrounds[30].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[28];
		}
		else if (back.Contains("back-021"))
		{
		    backGroundLabel.text = backgrounds[31].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[29];
		}
		else if (back.Contains("back-022"))
		{
		    backGroundLabel.text = backgrounds[32].bg;
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[30];
		}
		else if (back.Contains("back-023"))
		{
		    backGroundLabel.text = "";
		    backgroundNow.color = new Color(255, 255, 255, 255);
		    backgroundNow.sprite = background[31];
		}
		else if (back == "暗転")
		{
			backGroundLabel.text = "暗転";
			backgroundNow.color = new Color(0, 0, 0, 255);
		}
		else
		{
			backGroundLabel.text = "";
		}

        //meia expression
		if(mainchara == "")
		{
		    MeiaMain.color = new Color(0,0,0,0);
		    MeiaEye.color = new Color(0,0,0,0);
		    MeiaMouth.color = new Color(0,0,0,0);
		}
		else 
		{
		    MeiaMain.color = new Color(255,255,255,255);
		    MeiaEye.color = new Color(255,255,255,255);
		    MeiaMouth.color = new Color(255,255,255,255);
		}

		if(mainchara.Contains("M-01a"))
		{
		    MeiaEye.sprite = MeiaSprite[22];
		    MeiaMouth.sprite = MeiaSprite[23];
		}
		else
		{
		    for( int i = 0; i < 11; i++)
		    {
		        if(mainchara.Contains("M-0"+ (i+1).ToString()))
		        {
		            MeiaEye.sprite = MeiaSprite[i * 2];
		            MeiaMouth.sprite = MeiaSprite[1 + (i * 2)];
		        }
		    }
		}	

		if (showtwoone != "" || showtwotwo != "")
		{
			charaImageNow.color = new Color(0, 0, 0, 0);
			EyeNow.color = new Color(0, 0, 0, 0);
			MouthNow.color = new Color(0, 0, 0, 0);
		}
		//character expression
		if (expression.Contains("L-01a"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    EyeNow.sprite = CharaEyes[2];
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[2];
		}
		else if (expression.Contains("L-01b"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 3, 4, 5 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[2];
		}
		else if (expression.Contains("L-01-ragan"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 3, 4, 5 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[2];
		}
		else if (expression.Contains("L-01"))
		{
		    StopCoroutine("EyeAnim");
		    int[] eyeList = { 0, 1, 2 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.sprite = CharaMouth[2];
		}
		else if (expression.Contains("L-02a"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 9, 10, 11 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[5];
		}
		else if (expression.Contains("L-02"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 6, 7, 8 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[5];
		}
		else if (expression.Contains("L-03"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 12, 13, 14 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[8];
		}
		else if (expression.Contains("L-04"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    EyeNow.sprite = CharaEyes[18];
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[10];
		}
		else if (expression.Contains("L-05a"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 22, 23, 24 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[14];
		}
		else if (expression.Contains("L-05"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 19, 20, 21 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[14];
		}
		else if (expression.Contains("L-06a"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 107, 108, 109 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[17];
		}
		else if (expression.Contains("L-06"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 25, 26, 27 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[17];
		}
		else if (expression.Contains("L-07a"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 118, 119, 120 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[20];
		}
		else if (expression.Contains("L-07"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 31, 32, 33 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[20];
		}
		else if (expression.Contains("L-08"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 34, 35, 36 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[23];
		}
		else if (expression.Contains("L-09"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 37, 38, 39 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[26];
		}
		else if (expression.Contains("L-10a"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 110, 111, 110 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[29];
		}
		else if (expression.Contains("L-10"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 40, 41, 40 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[29];
		}
		else if (expression.Contains("L-11"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 121, 122, 123 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[29];
		}
		else if (expression.Contains("L-12"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 124, 125, 126 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[29];
		}
		else if (expression.Contains("K-01"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 43, 44, 45 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[33];
		}
		else if (expression.Contains("K-02a"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 46, 47, 48 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[36];
		}
		else if (expression.Contains("K-02"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 43, 44, 45 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[36];
		}
		else if (expression.Contains("K-03"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    EyeNow.sprite = CharaEyes[49];
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[39];
		}
		else if (expression.Contains("K-04"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 50, 51, 52 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[42];
		}
		else if (expression.Contains("K-05"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 53, 54, 55 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[45];
		}
		else if (expression.Contains("K-06"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 56, 57, 58 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[48];
		}
		else if (expression.Contains("K-07"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 59, 60, 61 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[51];
		}
		else if (expression.Contains("K-08"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 62, 63, 64 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[54];
		}
		else if (expression.Contains("K-09a"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 73, 74, 67 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[57];
		}
		else if (expression.Contains("K-09"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 65, 66, 67 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[57];
		}
		else if (expression.Contains("K-10"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 68, 69, 70 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[60];
		}
		else if (expression.Contains("K-11"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 71, 72, 71 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[63];
		}
		else if (expression.Contains("G-01"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 75, 76, 77 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[64];
		}
		else if (expression.Contains("G-02"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    EyeNow.sprite = CharaEyes[78];
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[67];
		}
		else if (expression.Contains("G-03"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 79, 80, 81 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[72];
		}
		else if (expression.Contains("G-04"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 82, 83, 84 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[75];
		}
		else if (expression.Contains("G-05"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 85, 86, 87 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[76];
		}
		else if (expression.Contains("G-06"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 88, 89, 90 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[81];
		}
		else if (expression.Contains("G-07"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 91, 92, 93 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[84];
		}
		else if (expression.Contains("T-01"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 94, 95, 96 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[87];
		}
		else if (expression.Contains("T-02"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    EyeNow.sprite = CharaEyes[97];
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[90];
		}
		else if (expression.Contains("T-03a"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 101, 102, 103 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[93];
		}
		else if (expression.Contains("T-03"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 98, 99, 100 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[93];
		}
		else if (expression.Contains("T-04"))
		{
		    StopCoroutine("EyeAnim");
		    EyeNow.color = new Color(255, 255, 255, 255);
		    int[] eyeList = { 104, 105, 106 };
		    StartCoroutine("EyeAnim", eyeList);
		    MouthNow.color = new Color(255, 255, 255, 255);
		    MouthNow.sprite = CharaMouth[96];
		}	
		    //left chara
		    if (showtwoone.Contains("L-01a"))
		    {
		        StopCoroutine("EyeAnim1");
		        EyeNow1.color = new Color(255, 255, 255, 255);
		        EyeNow1.sprite = CharaEyes[2];

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[2];
            }
            else if (showtwoone.Contains("L-01b"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 3, 4, 5 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[2];
            }
            else if (showtwoone.Contains("L-01-ragan"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 3, 4, 5 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[2];
            }
            else if (showtwoone.Contains("L-01"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 0, 1, 2 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[2];
            }
            else if (showtwoone.Contains("L-02a"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 9, 10, 11 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[5];
            }
            else if (showtwoone.Contains("L-02"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 6, 7, 8 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[5];
            }
            else if (showtwoone.Contains("L-03"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 12, 13, 14 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[8];
            }
            else if (showtwoone.Contains("L-04"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                EyeNow1.sprite = CharaEyes[18];

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[10];
            }
            else if (showtwoone.Contains("L-05a"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 22, 23, 24 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[14];
            }
            else if (showtwoone.Contains("L-05"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 19, 20, 21 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[14];
            }
            else if (showtwoone.Contains("L-06a"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 107, 108, 109 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[17];
            }
            else if (showtwoone.Contains("L-06"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 25, 26, 27 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[17];
            }
            else if (showtwoone.Contains("L-07"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 31, 32, 33 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[20];
            }
            else if (showtwoone.Contains("L-08"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 34, 35, 36 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[23];
            }
            else if (showtwoone.Contains("L-09"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 37, 38, 39 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[26];
            }
            else if (showtwoone.Contains("L-10a"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 110, 111, 110 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[29];
            }
            else if (showtwoone.Contains("L-10"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 40, 41, 40 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[29];
            }
            else if (showtwoone.Contains("L-11"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 121, 122, 123 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[29];
            }
            else if (showtwoone.Contains("L-12"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 124, 125, 126 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[29];
            }

            else if (showtwoone.Contains("K-01"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 43, 44, 45 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[33];
            }
            else if (showtwoone.Contains("K-02a"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 46, 47, 48 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[36];
            }
            else if (showtwoone.Contains("K-02"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 43, 44, 45 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[36];
            }
            else if (showtwoone.Contains("K-03"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                EyeNow1.sprite = CharaEyes[49];

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[39];
            }
            else if (showtwoone.Contains("K-04"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 50, 51, 52 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[42];
            }
            else if (showtwoone.Contains("K-05"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 53, 54, 55 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[45];
            }
            else if (showtwoone.Contains("K-06"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 56, 57, 58 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[48];
            }
            else if (showtwoone.Contains("K-07"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 59, 60, 61 };
                StartCoroutine("EyeAnim1", eyeList);
                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[51];
            }
            else if (showtwoone.Contains("K-08"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 62, 63, 64 };
                StartCoroutine("EyeAnim1", eyeList);
                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[54];
            }
            else if (showtwoone.Contains("K-09a"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 73, 74, 67 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[57];
            }
            else if (showtwoone.Contains("K-09"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 65, 66, 67 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[57];
            }
            else if (showtwoone.Contains("K-10"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 68, 69, 70 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[60];
            }
            else if (showtwoone.Contains("K-11"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 71, 72, 71 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[63];
            }

            else if (showtwoone.Contains("G-01"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 75, 76, 77 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[64];
            }
            else if (showtwoone.Contains("G-02"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                EyeNow1.sprite = CharaEyes[78];

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[67];
            }
            else if (showtwoone.Contains("G-03"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 79, 80, 81 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[72];
            }
            else if (showtwoone.Contains("G-04"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 82, 83, 84 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[75];
            }
            else if (showtwoone.Contains("G-05"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 85, 86, 87 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[76];
            }
            else if (showtwoone.Contains("G-06"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 88, 89, 90 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[81];
            }
            else if (showtwoone.Contains("G-07"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 91, 92, 93 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[84];
            }

            else if (showtwoone.Contains("T-01"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 94, 95, 96 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[87];
            }
            else if (showtwoone.Contains("T-02"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                EyeNow1.sprite = CharaEyes[97];

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[90];
            }
            else if (showtwoone.Contains("T-03a"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 101, 102, 103 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[93];
            }
            else if (showtwoone.Contains("T-03"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 98, 99, 100 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[93];
            }
            else if (showtwoone.Contains("T-04"))
            {
                StopCoroutine("EyeAnim1");
                EyeNow1.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 104, 105, 106 };
                StartCoroutine("EyeAnim1", eyeList);

                MouthNow1.color = new Color(255, 255, 255, 255);
                MouthNow1.sprite = CharaMouth[96];
            }

            //right chara
            if (showtwotwo.Contains("L-01a"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                EyeNow2.sprite = CharaEyes[2];

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[2];
            }
            else if (showtwotwo.Contains("L-01b"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 3, 4, 5 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[2];
            }
            else if (showtwotwo.Contains("L-01-ragan"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 3, 4, 5 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[2];
            }
            else if (showtwotwo.Contains("L-01"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 0, 1, 2 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[2];
            }
            else if (showtwotwo.Contains("L-02a"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 9, 10, 11 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[5];
            }
            else if (showtwotwo.Contains("L-02"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 6, 7, 8 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[5];
            }
            else if (showtwotwo.Contains("L-03"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 12, 13, 14 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[8];
            }
            else if (showtwotwo.Contains("L-04"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                EyeNow2.sprite = CharaEyes[18];

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[10];
            }
            else if (showtwotwo.Contains("L-05a"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 22, 23, 24 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[14];
            }
            else if (showtwotwo.Contains("L-05"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 19, 20, 21 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[14];
            }
            else if (showtwotwo.Contains("L-06a"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 107, 108, 109 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[17];
            }
            else if (showtwotwo.Contains("L-06"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 25, 26, 27 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[17];
            }
            else if (showtwotwo.Contains("L-07"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 31, 32, 33 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[20];
            }
            else if (showtwotwo.Contains("L-08"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 34, 35, 36 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[23];
            }
            else if (showtwotwo.Contains("L-09"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 37, 38, 39 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[26];
            }
            else if (showtwoone.Contains("L-10a"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 110, 111, 110 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[29];
            }
            else if (showtwotwo.Contains("L-10"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 40, 41, 40 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[29];
            }
            else if (showtwotwo.Contains("L-11"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 121, 122, 123 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[29];
            }
            else if (showtwotwo.Contains("L-12"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 124, 125, 126 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[29];
            }
            else if (showtwotwo.Contains("K-01"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 43, 44, 45 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[33];
            }
            else if (showtwotwo.Contains("K-02a"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 46, 47, 48 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[36];
            }
            else if (showtwotwo.Contains("K-02"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 43, 44, 45 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[36];
            }
            else if (showtwotwo.Contains("K-03"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                EyeNow2.sprite = CharaEyes[49];

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[39];
            }
            else if (showtwotwo.Contains("K-04"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 50, 51, 52 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[42];
            }
            else if (showtwotwo.Contains("K-05"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 53, 54, 55 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[45];
            }
            else if (showtwotwo.Contains("K-06"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 56, 57, 58 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[48];
            }
            else if (showtwotwo.Contains("K-07"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 59, 60, 61 };
                StartCoroutine("EyeAnim2", eyeList);
                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[51];
            }
            else if (showtwotwo.Contains("K-08"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 62, 63, 64 };
                StartCoroutine("EyeAnim2", eyeList);
                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[54];
            }
            else if (showtwotwo.Contains("K-09a"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 73, 74, 67 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[57];
            }
            else if (showtwotwo.Contains("K-09"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 65, 66, 67 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[57];
            }
            else if (showtwotwo.Contains("K-10"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 68, 69, 70 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[60];
            }
            else if (showtwotwo.Contains("K-11"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 71, 72, 71 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[63];
            }

            else if (showtwotwo.Contains("G-01"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 75, 76, 77 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[64];
            }
            else if (showtwotwo.Contains("G-02"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                EyeNow2.sprite = CharaEyes[78];

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[67];
            }
            else if (showtwotwo.Contains("G-03"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 79, 80, 81 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[72];
            }
            else if (showtwotwo.Contains("G-04"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 82, 83, 84 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[75];
            }
            else if (showtwotwo.Contains("G-05"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 85, 86, 87 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[76];
            }
            else if (showtwotwo.Contains("G-06"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 88, 89, 90 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[81];
            }
            else if (showtwotwo.Contains("G-07"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 91, 92, 93 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[84];
            }

            else if (showtwotwo.Contains("T-01"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 94, 95, 96 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[87];
            }
            else if (showtwotwo.Contains("T-02"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                EyeNow2.sprite = CharaEyes[97];

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[90];
            }
            else if (showtwotwo.Contains("T-03a"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 101, 102, 103 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[93];
            }
            else if (showtwotwo.Contains("T-03"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 98, 99, 100 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[93];
            }
            else if (showtwotwo.Contains("T-04"))
            {
                StopCoroutine("EyeAnim2");
                EyeNow2.color = new Color(255, 255, 255, 255);
                int[] eyeList = { 104, 105, 106 };
                StartCoroutine("EyeAnim2", eyeList);

                MouthNow2.color = new Color(255, 255, 255, 255);
                MouthNow2.sprite = CharaMouth[96];
            }

            //left chara
            if (showtwoone == "")
            {
                charaImageNow1.color = new Color(0, 0, 0, 0);
                EyeNow1.color = new Color(0, 0, 0, 0);
                MouthNow1.color = new Color(0, 0, 0, 0);
            }
            if (showtwoone.Contains("L-01") || showtwoone.Contains("L-01a") ||
                showtwoone.Contains("L-01b") || showtwoone.Contains("L-02") ||
                showtwoone.Contains("L-02a") || showtwoone.Contains("L-03") ||
                showtwoone.Contains("L-04") || showtwoone.Contains("L-05") ||
                showtwoone.Contains("L-05a") || showtwoone.Contains("L-06") ||
                showtwoone.Contains("L-06a") || showtwoone.Contains("L-07") ||
                showtwoone.Contains("L-07a") || showtwoone.Contains("L-08") ||
                showtwoone.Contains("L-10") || showtwoone.Contains("L-01-ragan") ||
                showtwoone.Contains("L-10a")||showtwoone.Contains("L-11") ||
                showtwoone.Contains("L-12"))
            {
                charaImageNow1.color = new Color(255, 255, 255, 255);
                charaImageNow1.sprite = charaImage[0];
            }

            else if (showtwoone.Contains("L-09"))
            {
                charaImageNow1.color = new Color(255, 255, 255, 255);
                charaImageNow1.sprite = charaImage[4];
            }

            else if (showtwoone.Contains("K-01") || showtwoone.Contains("K-02") ||
                showtwoone.Contains("K-02a") || showtwoone.Contains("K-03") ||
                showtwoone.Contains("K-04") || showtwoone.Contains("K-05") ||
                showtwoone.Contains("K-06") || showtwoone.Contains("K-07") ||
                showtwoone.Contains("K-08") || showtwoone.Contains("K-09") ||
                showtwoone.Contains("K-09a") || showtwoone.Contains("K-10") ||
                showtwoone.Contains("K-11"))
            {
                charaImageNow1.color = new Color(255, 255, 255, 255);
                charaImageNow1.sprite = charaImage[1];
            }

            else if (showtwoone.Contains("T-01") || showtwoone.Contains("T-02") ||
                showtwoone.Contains("T-03") || showtwoone.Contains("T-03a") ||
                showtwoone.Contains("T-04"))
            {
                charaImageNow1.color = new Color(255, 255, 255, 255);
                charaImageNow1.sprite = charaImage[2];
            }
            else if (showtwoone.Contains("G-01") || showtwoone.Contains("G-02") ||
                showtwoone.Contains("G-03") || showtwoone.Contains("G-04") ||
                showtwoone.Contains("G-05") || showtwoone.Contains("G-06") ||
                showtwoone.Contains("G-07"))
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
            if (showtwotwo == "")
            {
                charaImageNow2.color = new Color(0, 0, 0, 0);
                EyeNow2.color = new Color(0, 0, 0, 0);
                MouthNow2.color = new Color(0, 0, 0, 0);
            }
            if (showtwotwo.Contains("L-01") || showtwotwo.Contains("L-01a") ||
                showtwotwo.Contains("L-01b") || showtwotwo.Contains("L-02") ||
                showtwotwo.Contains("L-02a") || showtwotwo.Contains("L-03") ||
                showtwotwo.Contains("L-04") || showtwotwo.Contains("L-05") ||
                showtwotwo.Contains("L-05a") || showtwotwo.Contains("L-06") ||
                showtwotwo.Contains("L-06a") || showtwotwo.Contains("L-07") ||
                showtwotwo.Contains("L-07a") || showtwotwo.Contains("L-08") ||
                showtwotwo.Contains("L-10") || showtwotwo.Contains("L-01-ragan") ||
                showtwotwo.Contains("L-10a") || showtwotwo.Contains("L-11") ||
                showtwotwo.Contains("L-12"))
            {
                charaImageNow2.color = new Color(255, 255, 255, 255);
                charaImageNow2.sprite = charaImage[0];
            }

            else if (showtwotwo.Contains("L-09"))
            {
                charaImageNow2.color = new Color(255, 255, 255, 255);
                charaImageNow2.sprite = charaImage[4];
            }

            else if (showtwotwo.Contains("K-01") || showtwotwo.Contains("K-02") ||
                showtwotwo.Contains("K-02a") || showtwotwo.Contains("K-03") ||
                showtwotwo.Contains("K-04") || showtwotwo.Contains("K-05") ||
                showtwotwo.Contains("K-06") || showtwotwo.Contains("K-07") ||
                showtwotwo.Contains("K-08") || showtwotwo.Contains("K-09") ||
                showtwotwo.Contains("K-09a") || showtwotwo.Contains("K-10") ||
                showtwotwo.Contains("K-11"))
            {
                charaImageNow2.color = new Color(255, 255, 255, 255);
                charaImageNow2.sprite = charaImage[1];
            }

            else if (showtwotwo.Contains("T-01") || showtwotwo.Contains("T-02") ||
                showtwotwo.Contains("T-03") || showtwotwo.Contains("T-03a") ||
                showtwotwo.Contains("T-04"))
            {
                charaImageNow2.color = new Color(255, 255, 255, 255);
                charaImageNow2.sprite = charaImage[2];
            }
            else if (showtwotwo.Contains("G-01") || showtwotwo.Contains("G-02") ||
                showtwotwo.Contains("G-03") || showtwotwo.Contains("G-04") ||
                showtwotwo.Contains("G-05") || showtwotwo.Contains("G-06") ||
                showtwotwo.Contains("G-07"))
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
		//Background Text Show
		string[] textTemp = { backGroundName, backGroundLabel.text, whichLineNow.ToString() };
		StartCoroutine("BGTextAnim", textTemp);

//BGM
            if (music.Contains("BGM-001"))
            {
                BGM.clip = BGMFile[0];
            }
            else if (music.Contains("BGM-002"))
            {
                BGM.clip = BGMFile[1];
            }
            else if (music.Contains("BGM-003"))
            {
                BGM.clip = BGMFile[2];
            }
            else if (music.Contains("BGM-004"))
            {
                BGM.clip = BGMFile[3];
            }
            else if (music.Contains("BGM-005"))
            {
                BGM.clip = BGMFile[4];
            }
            else if (music.Contains("BGM-006"))
            {
                BGM.clip = BGMFile[5];
            }
            else if (music.Contains("BGM-007"))
            {
                BGM.clip = BGMFile[6];
            }
            else if (music.Contains("BGM-008"))
            {
                BGM.clip = BGMFile[7];
            }
            else if (music.Contains("BGM-009"))
            {
                BGM.clip = BGMFile[8];
            }
            else if (music.Contains("BGM-010"))
            {
                BGM.clip = BGMFile[9];
            }
            else if (music.Contains("BGM-011"))
            {
                BGM.clip = BGMFile[10];
            }
            else if (music.Contains("BGM-012"))
            {
                BGM.clip = BGMFile[11];
            }
            else if (music.Contains("BGM-013"))
            {
                BGM.clip = BGMFile[12];
            }
            else if (music.Contains("BGM-014"))
            {
                BGM.clip = BGMFile[13];
            }
            else if (music.Contains("BGM-015"))
            {
                BGM.clip = BGMFile[14];
            }
            else if (music.Contains("BGM-016"))
            {
                BGM.clip = BGMFile[15];
            }
            else if (music.Contains("BGM-017"))
            {
                BGM.clip = BGMFile[16];
            }
            else if (music.Contains("BGM-018"))
            {
                BGM.clip = BGMFile[17];
            }
            else if (music.Contains("BGM-019"))
            {
                BGM.clip = BGMFile[18];
            }
            else if (music.Contains("BGM-020"))
            {
                BGM.clip = BGMFile[19];
            }
            else if (music.Contains("BGM-021"))
            {
                BGM.clip = BGMFile[20];
            }
            else if (music.Contains("BGM-022"))
            {
                BGM.clip = BGMFile[21];
            }
            else if (music.Contains("BGM-023"))
            {
                BGM.clip = BGMFile[22];
            }
            else if (music.Contains("working_morning"))
            {
                BGM.clip = BGMFile[23];
            }
            else if (music == "")
            {
            }
            else
            {
                BGM.Stop();
            }

            float current = 0;

            if (music.Contains("CO"))
            {
                audioFade = false;
                StopCoroutine("FadeAudio");
                BGM.Stop();
            }
            if (music.Contains("CI"))
            {
                audioFade = false;
                StopCoroutine("FadeAudio");
                BGM.volume = 1;
                BGM.Play();
            }
            if (music.Contains("FI"))
            {
                audioFade = true;
                BGM.Play();
                StartCoroutine(FadeAudio(current, 0, 1, 2));
            }
            if (music.Contains("FO"))
            {
                audioFade = true;
                StartCoroutine(FadeAudio(current, 1, 0, 2));
            }

            if (music != "")
            {
                string Filter1 = music.Replace("/", "");
                string Filter2 = Filter1.Replace("CI", "");
                string Filter3 = Filter2.Replace("CO", "");
                string Filter4 = Filter3.Replace("FI", "");
                whichBGClip = Filter4.Replace("FO", "");
                PlayerPrefs.SetString("BackgroundClip", whichBGClip);
            }

		manager = false;
	}	


	private IEnumerator DialogueGo()
	{
		foreach (Dialogue d in dialogues.ToArray())
		{
			dialogueManager.next = false;
			whichLineNow++;

			string MainCharaName = d.character;
			string DialogueChange = d.dialogue;
			string NameChange = PlayerPrefs.GetString("PlayerName");

			if (MainCharaName == "メイア" && NameChange != "")
			{
				MainCharaName = NameChange;
				DialogueChange = d.dialogue.Replace("メイア", NameChange);
			}

			logPrefabSpawn.SpawnLog(MainCharaName,DialogueChange);

			//MouthAnimStop
			StopCoroutine("MouthAnim");
			StopCoroutine("MouthAnim1");
			StopCoroutine("MouthAnim2");

			//background

    		id = d.id;//0
    		character = d.character;//1
    		dialogue = d.dialogue;//2
    		mainchara = d.mainchara;//3
    		expression = d. expression;//4
    		showtwoone = d.showtwoone;//5
    		showtwotwo = d.showtwotwo;//6
    		back = d.background;//7
    		firstchoose = d.firstchoose;//8
    		secondchoose = d.secondchoose;//9
    		choicetextshow = d.choicetextshow;//10
    		objecteffect = d.objecteffect;//11
    		itemimage = d.itemimage;//12
    		effect = d.effect;//13
    		music = d.BGM;//14
    		sound = d.SE;//15
    		voice = d.voice;//16
    		note = d.note;//17

			//character body
			bool blankAnim = BustUpAnim.GetBool("isBlank");

			manager = true;

			//main chara
			if (d.expression == "")
			{
				charaImageNow.color = new Color(0, 0, 0, 0);

				EyeNow.color = new Color(0, 0, 0, 0);

				MouthNow.color = new Color(0, 0, 0, 0);

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
				d.expression.Contains("L-10a") || d.expression.Contains("L-11") ||
				d.expression.Contains("L-12"))
			{
				if (blankAnim == true)
				{
					BustUpAnim.SetBool("isLied",true);
					charaImageNow.color = new Color(255, 255, 255, 255);
					EyeNow.color = new Color(255, 255, 255, 255);
					MouthNow.color = new Color(255, 255, 255, 255);
					charaImageNow.sprite = charaImage[0];
					BustUpAnim.SetBool("isBlank", false);
					yield return new WaitForSeconds(1.5f);
				}
				charaImageNow.sprite = charaImage[0];
			}

			else if (d.expression.Contains("L-09"))
			{
				if (blankAnim == true)
				{
					BustUpAnim.SetBool("isLied",true);
					charaImageNow.color = new Color(255, 255, 255, 255);
					EyeNow.color = new Color(255, 255, 255, 255);
					MouthNow.color = new Color(255, 255, 255, 255);
					charaImageNow.sprite = charaImage[4];
					BustUpAnim.SetBool("isBlank", false);
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
					BustUpAnim.SetBool("isLied",false);
					charaImageNow.color = new Color(255, 255, 255, 255);
					EyeNow.color = new Color(255, 255, 255, 255);
					MouthNow.color = new Color(255, 255, 255, 255);
					charaImageNow.sprite = charaImage[1];
					BustUpAnim.SetBool("isBlank", false);
					yield return new WaitForSeconds(1.5f);
				}
				else
				{
					BustUpAnim.SetBool("isLied",false);
					charaImageNow.color = new Color(255, 255, 255, 255);
					EyeNow.color = new Color(255, 255, 255, 255);
					MouthNow.color = new Color(255, 255, 255, 255);
					charaImageNow.sprite = charaImage[1];
					BustUpAnim.SetBool("isBlank", false);
				}
				charaImageNow.sprite = charaImage[1];
			}

			else if (d.expression.Contains("T-01") || d.expression.Contains("T-02") ||
				d.expression.Contains("T-03") || d.expression.Contains("T-03a") ||
				d.expression.Contains("T-04"))
			{
				if (blankAnim == true)
				{
					BustUpAnim.SetBool("isLied",false);
					charaImageNow.color = new Color(255, 255, 255, 255);
					EyeNow.color = new Color(255, 255, 255, 255);
					MouthNow.color = new Color(255, 255, 255, 255);
					charaImageNow.sprite = charaImage[2];
					BustUpAnim.SetBool("isBlank", false);
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
					BustUpAnim.SetBool("isLied",false);
					charaImageNow.color = new Color(255, 255, 255, 255);
					EyeNow.color = new Color(255, 255, 255, 255);
					MouthNow.color = new Color(255, 255, 255, 255);
					charaImageNow.sprite = charaImage[3];
					BustUpAnim.SetBool("isBlank", false);
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


			//Bust Up(?)
			if (d.expression.Contains("BU"))
			{
				bool bustUpNow = BustUpAnim.GetBool("isBig");
				BustUpAnim.SetBool("isBig", true);
				if (bustUpNow == false)
				{
					yield return new WaitForSeconds(1.5f);
				}
			}
			else
			{
				bool bustUpNow = BustUpAnim.GetBool("isBig");
				BustUpAnim.SetBool("isBig", false);
				if (bustUpNow == true)
				{
					yield return new WaitForSeconds(1.5f);
				}
			}

			voiceManager = true;

			//Voice
			mouthStop = true;

			int[] date = PlayerPrefsX.GetIntArray("Date");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");

			nameLabel.text = MainCharaName;

			int chapterScreen = PlayerPrefs.GetInt("ChapterScreen");

			////////////////////////////////////////////////////////////////////////////P R O L O G U E////////////////////////////////////////////////////////////////
			if (date[0] == 10 && (date[1] == 7 || date[1] == 8 || date[1] == 9))
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 164)
				{
					PlayerPrefs.SetInt("MiniGame", 1);
					PlayerPrefs.SetInt("NovelMenu", 1);
					dialogueManager.dialogueSpeed = 0;
					MiniGameChoose.SetActive(true);
					MinGameButton[0].interactable = true;
					MinGameButton[1].interactable = false;
					MinGameButton[2].interactable = false;

				}
				if (d.id == 170)
				{
					PlayerPrefs.SetInt("MiniGame", 2);
					PlayerPrefs.SetInt("NovelMenu", 2);
					dialogueManager.dialogueSpeed = 0;
					MiniGameChoose.SetActive(true);
					MinGameButton[0].interactable = false;
					MinGameButton[1].interactable = true;
					MinGameButton[2].interactable = false;
				}
				if (d.id == 178)
				{
					PlayerPrefs.SetInt("MiniGame", 3);
					PlayerPrefs.SetInt("NovelMenu", 3);
					dialogueManager.dialogueSpeed = 0;
					MiniGameChoose.SetActive(true);
					MinGameButton[0].interactable = false;
					MinGameButton[1].interactable = false;
					MinGameButton[2].interactable = true;
				}

				if (d.id == 251)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}

				}
			}

			///////////////////////////////////////////////////////////////////////////////L I E D 1/////////////////////////////////////////////////////////////////
			else if (date[0] == 10 && date[1] == 15)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 339)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}

			}

			///////////////////////////////////////////////////////////////////////////////L I E D 2/////////////////////////////////////////////////////////////////

			else if (date[0] == 10 && date[1] == 20 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 423)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}

			}


			///////////////////////////////////////////////////////////////////////////////L I E D 3/////////////////////////////////////////////////////////////////

			else if (date[0] == 10 && date[1] == 30 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}


				if (d.id == 516 || d.id == 521)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}

			}

			///////////////////////////////////////////////////////////////////////////////L I E D 4/////////////////////////////////////////////////////////////////

			else if (date[0] == 11 && date[1] == 8 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}

				if (d.id == 567)
				{
					PlayerPrefs.SetInt("Still-6", 1);
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 589 && resetPos == 119)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					SceneManager.LoadScene("Scene_CG");
				}


				if (d.id == 648)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}

			}


			///////////////////////////////////////////////////////////////////////////////L I E D 5/////////////////////////////////////////////////////////////////

			else if (date[0] == 11 && date[1] == 15 && LiedFail == 0)
			{
				if (d.background.Contains("FI") || d.id == 662)
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 813)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}


			///////////////////////////////////////////////////////////////////////////////L I E D 6/////////////////////////////////////////////////////////////////

			else if (date[0] == 11 && date[1] == 17 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}

				if (d.id == 834)
				{
					PlayerPrefs.SetInt("Still-13", 1);
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 963)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////L I E D 7/////////////////////////////////////////////////////////////////

			else if (date[0] == 11 && date[1] == 25 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 1115)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////L I E D 8/////////////////////////////////////////////////////////////////

			else if (date[0] == 11 && date[1] == 30 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}

				if (d.id == 1241)
				{
					PlayerPrefs.SetInt("Still-7", 1);
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 1255 && resetPos == 121)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					SceneManager.LoadScene("Scene_CG");
				}


				if (d.id == 1332)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////L I E D 9/////////////////////////////////////////////////////////////////

			else if (date[0] == 12 && date[1] == 3 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 1397)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////L I E D 10/////////////////////////////////////////////////////////////////

			else if (date[0] == 12 && date[1] == 6 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 1449)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////L I E D 11/////////////////////////////////////////////////////////////////

			else if (date[0] == 12 && date[1] == 9 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}

				if (d.id == 1948)
				{
					PlayerPrefs.SetInt("Still-1", 1);
				}
				if (d.id == 1655)
				{
					PlayerPrefs.SetInt("Still-5", 1);
				}

				if (d.id == 1492)
				{
					finishTemp14 = true;
				}
				if (d.id == 1558)
				{
					finishTemp15 = true;
				}
				if (d.id == 1803)
				{
					finishTemp16 = true;
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 1526 || d.id == 1575 || d.id == 1830)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					SceneManager.LoadScene("TitleScreen");
				}

				if (d.id == 1958 && resetPos == 109)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					SceneManager.LoadScene("Scene_CG");
				}

				if (d.id == 1672 && resetPos == 117)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					SceneManager.LoadScene("Scene_CG");
				}


				if (d.id == 1959)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);
					if(chapterScreen == 0)
					{
					GameMenuScript.NextDay();
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}

				}
			}

			///////////////////////////////////////////////////////////////////////////////L I E D EP/////////////////////////////////////////////////////////////////

			else if (date[0] == 12 && date[1] == 10 && LiedFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}

				if (d.id == 1984)
				{
					PlayerPrefs.SetInt("Still-3", 1);
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 1989)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if (resetPos == 113)
					{
						SceneManager.LoadScene("Scene_CG");
					}
					else
					{
						SceneManager.LoadScene("TitleScreen");
					}
				}
			}



			///////////////////////////////////////////////////////////////////////////////K L E I N 1 /////////////////////////////////////////////////////////////////

			else if (date[0] == 10 && date[1] == 16 && KleinFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				if (d.id == 2028)
				{
					finishTemp17 = true;
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 2062)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////K L E I N 2 /////////////////////////////////////////////////////////////////

			else if (date[0] == 10 && date[1] == 18 && KleinFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				if (d.id == 2097)
				{
					finishTemp18 = true;
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 2166)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////K L E I N 3 /////////////////////////////////////////////////////////////////

			else if (date[0] == 10 && date[1] == 25 && KleinFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}

				if (d.id == 2254)
				{
					PlayerPrefs.SetInt("Still-8", 1);
				}
				if (d.id == 2193)
				{
					finishTemp19 = true;
				}
				if (d.id == 2282)
				{
					finishTemp20 = true;
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 2264 && resetPos == 123)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					SceneManager.LoadScene("Scene_CG");
				}


				if (d.id == 2295)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////K L E I N 4 /////////////////////////////////////////////////////////////////

			else if (date[0] == 11 && date[1] == 3 && KleinFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}

				if (d.id == 2345)
				{
					PlayerPrefs.SetInt("Still-9", 1);
				}
				if (d.id == 2367)
				{
					finishTemp21 = true;
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 2357 && resetPos == 125)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					SceneManager.LoadScene("Scene_CG");
				}

				if (d.id == 2416)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////K L E I N 5 /////////////////////////////////////////////////////////////////

			else if (date[0] == 11 && date[1] == 10 && KleinFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}

				if (d.id == 2447)
				{
					finishTemp22 = true;
				}
				if (d.id == 2483)
				{
					finishTemp23 = true;
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 2561)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////K L E I N 6 /////////////////////////////////////////////////////////////////

			else if (date[0] == 11 && date[1] == 15 && KleinFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				if (d.id == 2596)
				{
					finishTemp24 = true;
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 2683)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////K L E I N 7 /////////////////////////////////////////////////////////////////

			else if (date[0] == 11 && date[1] == 20 && KleinFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				if (d.id == 2771)
				{
					finishTemp25 = true;
				}
				if (d.id == 2876)
				{
					finishTemp26 = true;
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 2909 || d.id == 2902)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////K L E I N 8 /////////////////////////////////////////////////////////////////

			else if (date[0] == 11 && date[1] == 27 && KleinFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				if (d.id == 2962)
				{
					finishTemp27 = true;
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 3014)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////K L E I N 9 /////////////////////////////////////////////////////////////////

			else if (date[0] == 12 && date[1] == 3 && KleinFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				if (d.id == 3069)
				{
					finishTemp28 = true;
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 3116)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////K L E I N 10 /////////////////////////////////////////////////////////////////

			else if (date[0] == 12 && date[1] == 7 && KleinFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 3232)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						PlayerPrefs.SetInt("NovelMenu", 10);
						GameMenu.SetActive(true);
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////K L E I N 11 /////////////////////////////////////////////////////////////////

			else if (date[0] == 12 && date[1] == 9 && KleinFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}

				if (d.id == 3754)
				{
					PlayerPrefs.SetInt("Still-2", 1);
				}

				if (d.id == 3331)
				{
					finishTemp29 = true;
				}
				if (d.id == 3456)
				{
					finishTemp30 = true;
				}
				if (d.id == 3609)
				{
					finishTemp31 = true;
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}

				if (d.id == 3356 || d.id == 3468 || d.id == 3847)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					SceneManager.LoadScene("TitleScreen");
				}

				if (d.id == 3761 && resetPos == 111)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					SceneManager.LoadScene("Scene_CG");
				}


				if (d.id == 3827)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					if(chapterScreen == 0)
					{
						GameMenuScript.NextDay();
					}
					else
					{
            			SceneManager.LoadScene("TitleScreen");
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////K L E I N EP /////////////////////////////////////////////////////////////////

			else if (date[0] == 12 && date[1] == 10 && KleinFail == 0)
			{
				if (d.background.Contains("FI"))
				{
					FadeAnim.SetBool("Fading", false);
					yield return new WaitForSeconds(1.5f);
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}
				else if (d.background.Contains("SI"))
				{
					yield return new WaitForSeconds(1.5f);
					SlideAnim.Play("NormalFade", -1, 0);
					yield return dialogueManager.Run(DialogueChange, textLabel);

				}
				else
				{
					yield return dialogueManager.Run(DialogueChange, textLabel);
				}

				if (d.id == 3873)
				{
					PlayerPrefs.SetInt("Still-4", 1);
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
					SlideAnim.Play("Sliding", -1, 0);
					yield return new WaitForSeconds(1.5f);
				}


				if (d.id == 3883 && resetPos == 115)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					SceneManager.LoadScene("Scene_CG");
				}


				else if (d.id == 3883)
				{
					nameLabel.text = string.Empty;
					textLabel.text = string.Empty;
					FadeAnim.SetBool("Fading", true);
					yield return new WaitForSeconds(1.5f);

					SceneManager.LoadScene("TitleScreen");
				}
			}


			/////////////////////////////////////////////////////////S H O P/////////////////////////////
			else
			{
				yield return dialogueManager.Run(DialogueChange, textLabel);
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
		Voice.Stop();
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

			for (int i = 133; i < 172; i++)
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
			whichLineNow = 215;

			for (int i = 215; i < 265; i++)
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

			row = itemData[3].Split(new char[] { ',' });

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

			for (int i = 43; i < 93; i++)
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

			for (int i = 45; i < 100; i++)
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

			for (int i = 103; i < 169; i++)
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

			for (int i = 22; i < 160; i++)
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

			for (int i = 66; i < 222; i++)
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
		if (finishTemp14 == true)
		{
			resetPos = 50;
			finishTemp14 = false;
			whichLineNow = 45;

			for (int i = 45; i < 79; i++)
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
		if (finishTemp15 == true)
		{
			resetPos = 52;
			finishTemp15 = false;
			whichLineNow = 113;

			for (int i = 113; i < 130; i++)
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
		if (finishTemp16 == true)
		{
			resetPos = 54;
			finishTemp16 = false;
			whichLineNow = 358;

			for (int i = 358; i < 385; i++)
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
		if (finishTemp17 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 2;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 60;
			finishTemp17 = false;
			whichLineNow = 41;

			for (int i = 41; i < 75; i++)
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
		if (finishTemp18 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 5;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 64;
			finishTemp18 = false;
			whichLineNow = 37;

			for (int i = 37; i < 107; i++)
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
		if (finishTemp19 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 5;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 68;
			finishTemp19 = false;
			whichLineNow = 34;

			for (int i = 34; i < 123; i++)
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
		if (finishTemp20 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 2;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 70;
			finishTemp20 = false;
			whichLineNow = 124;

			for (int i = 124; i < 137; i++)
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
		if (finishTemp21 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 2;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 74;
			finishTemp21 = false;
			whichLineNow = 74;

			for (int i = 74; i < 123; i++)
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
		if (finishTemp22 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 2;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 78;
			finishTemp22 = false;
			whichLineNow = 74;

			for (int i = 33; i < 69; i++)
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
		if (finishTemp23 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 2;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 80;
			finishTemp23 = false;
			whichLineNow = 70;

			for (int i = 70; i < 148; i++)
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
		if (finishTemp24 == true)
		{
			resetPos = 83;
			finishTemp24 = false;
			whichLineNow = 37;

			for (int i = 37; i < 124; i++)
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
		if (finishTemp25 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 2;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 87;
			finishTemp25 = false;
			whichLineNow = 90;

			for (int i = 90; i < 196; i++)
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
		if (finishTemp26 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 5;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 89;
			finishTemp26 = false;
			whichLineNow = 197;

			for (int i = 197; i < 230; i++)
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
		if (finishTemp27 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection -= 2;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 93;
			finishTemp27 = false;
			whichLineNow = 91;

			for (int i = 91; i < 149; i++)
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
		if (finishTemp28 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 2;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 96;
			finishTemp28 = false;
			whichLineNow = 57;

			for (int i = 57; i < 105; i++)
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
		if (finishTemp29 == true)
		{
			resetPos = 101;
			finishTemp29 = false;
			whichLineNow = 110;

			for (int i = 110; i < 235; i++)
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
		if (finishTemp30 == true)
		{
			resetPos = 103;
			finishTemp30 = false;
			whichLineNow = 236;

			for (int i = 236; i < 248; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		if (finishTemp31 == true)
		{
			resetPos = 105;
			finishTemp31 = false;
			whichLineNow = 390;

			for (int i = 390; i < 607; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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

			for (int i = 133; i < 172; i++)
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
			whichLineNow = 215;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 9;
			finishTemp3 = false;

			for (int i = 215; i < 265; i++)
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

			for (int i = 43; i < 93; i++)
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

			for (int i = 45; i < 100; i++)
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

			for (int i = 103; i < 169; i++)
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

			for (int i = 22; i < 160; i++)
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

			for (int i = 66; i < 222; i++)
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
		if (finishTemp14 == true)
		{
			resetPos = 51;
			finishTemp14 = false;
			whichLineNow = 79;

			for (int i = 79; i < 112; i++)
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
		if (finishTemp15 == true)
		{
			resetPos = 53;
			finishTemp15 = false;
			whichLineNow = 130;

			for (int i = 130; i < 357; i++)
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
		if (finishTemp16 == true)
		{
			resetPos = 55;
			finishTemp16 = false;
			whichLineNow = 385;

			for (int i = 385; i < 514; i++)
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
		if (finishTemp17 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 5;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 61;
			finishTemp17 = false;
			whichLineNow = 41;

			for (int i = 41; i < 75; i++)
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
		if (finishTemp18 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 2;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 65;
			finishTemp18 = false;
			whichLineNow = 37;

			for (int i = 37; i < 107; i++)
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
		if (finishTemp19 == true)
		{
			resetPos = 69;
			finishTemp19 = false;
			whichLineNow = 34;

			for (int i = 34; i < 123; i++)
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
		if (finishTemp20 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 5;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 71;
			finishTemp20 = false;
			whichLineNow = 124;

			for (int i = 124; i < 137; i++)
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
		if (finishTemp21 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 5;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 75;
			finishTemp21 = false;
			whichLineNow = 74;

			for (int i = 74; i < 123; i++)
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
		if (finishTemp22 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 5;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 79;
			finishTemp22 = false;
			whichLineNow = 74;

			for (int i = 33; i < 69; i++)
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
		if (finishTemp23 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 2;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 81;
			finishTemp23 = false;
			whichLineNow = 70;

			for (int i = 70; i < 148; i++)
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
		if (finishTemp24 == true)
		{
			resetPos = 83;
			finishTemp24 = false;
			whichLineNow = 37;

			for (int i = 37; i < 124; i++)
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
		if (finishTemp25 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 5;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 88;
			finishTemp25 = false;
			whichLineNow = 90;

			for (int i = 90; i < 196; i++)
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
		if (finishTemp26 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 2;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 90;
			finishTemp26 = false;
			whichLineNow = 197;

			for (int i = 197; i < 230; i++)
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
		if (finishTemp27 == true)
		{
			resetPos = 94;
			finishTemp27 = false;
			whichLineNow = 91;

			for (int i = 91; i < 149; i++)
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
		if (finishTemp28 == true)
		{
			float affection = PlayerPrefs.GetFloat("KleinHeart");
			affection += 5;
			PlayerPrefs.SetFloat("KleinHeart", affection);

			resetPos = 97;
			finishTemp28 = false;
			whichLineNow = 57;

			for (int i = 57; i < 105; i++)
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
		if (finishTemp29 == true)
		{
			resetPos = 102;
			finishTemp29 = false;
			whichLineNow = 121;

			for (int i = 121; i < 135; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		if (finishTemp30 == true)
		{
			resetPos = 104;
			finishTemp30 = false;
			whichLineNow = 248;

			for (int i = 248; i < 389; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		if (finishTemp31 == true)
		{
			resetPos = 106;
			finishTemp31 = false;
			whichLineNow = 607;

			for (int i = 607; i < 627; i++)
			{
				row = data[i].Split(new char[] { ',' });

				if ((row[2] != "" || row[15] != "" || row[17] != ""))
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
		for(int i = 0; i < 36; i++)
		{
			if (whichLineNow != 0)
			{
				PlayerPrefs.SetInt($"{i}Log", whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt($"{i}Log", whichLineNow);
			}
			int novelMenu = PlayerPrefs.GetInt("NovelMenu");
			int[] date = PlayerPrefsX.GetIntArray("Date");
			float liedAff = PlayerPrefs.GetFloat("LiedHeart");
			float kleinAff = PlayerPrefs.GetFloat("KleinHeart");
			int money = PlayerPrefs.GetInt("Money");
			int cleanNumber = PlayerPrefs.GetInt("CleanNumber");
			int cookNumber = PlayerPrefs.GetInt("CookNumber");
			int shopNumber = PlayerPrefs.GetInt("ShopNumber");
			int LiedFail = PlayerPrefs.GetInt("LiedFail");
			int KleinFail = PlayerPrefs.GetInt("KleinFail");
			string backgroundClip = PlayerPrefs.GetString("BackgroundClip");
			string nameSave = PlayerPrefs.GetString("PlayerName");
			int[] ItemNumber = PlayerPrefsX.GetIntArray("ItemNumber");

			PlayerPrefs.SetString($"PlayerName{i + 1}", nameSave);
			PlayerPrefs.SetInt($"LiedFail{i + 1}", LiedFail);
			PlayerPrefs.SetInt($"KleinFail{i + 1}", KleinFail);
			PlayerPrefs.SetInt($"CleanNumber{i + 1}", cleanNumber);
			PlayerPrefs.SetInt($"CookNumber{i + 1}", cookNumber);
			PlayerPrefs.SetInt($"ShopNumber{i + 1}", shopNumber);
			PlayerPrefs.SetInt($"Money{i + 1}", money);
			PlayerPrefs.SetFloat($"LiedHeart{i + 1}", liedAff);
			PlayerPrefs.SetFloat($"KleinHeart{i + 1}", kleinAff);
			PlayerPrefsX.SetIntArray($"Date{i + 1}", date);
			PlayerPrefs.SetInt($"NovelMenu{i + 1}", novelMenu);
			PlayerPrefs.SetInt($"{i + 1}Pos", resetPos);
			PlayerPrefsX.SetIntArray($"ItemNumber{i + 1}", ItemNumber);
			PlayerPrefs.SetString($"BackgroundClip{i + 1}", backgroundClip);
		}
		int whichFile = PlayerPrefs.GetInt("WhichFile");

		if (whichFile == 0)
		{
			if (whichLineNow != 0)
			{
				PlayerPrefs.SetInt("ZeroLog", whichLineNow - 1);
			}
			else
			{
				PlayerPrefs.SetInt("ZeroLog", whichLineNow);
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
			string backgroundclip = PlayerPrefs.GetString("BackgroundClip");
			string nameSave = PlayerPrefs.GetString("PlayerName");

			PlayerPrefs.SetString("PlayerName0", nameSave);
			PlayerPrefs.SetInt("LiedFail0", LiedFail);
			PlayerPrefs.SetInt("KleinFail0", KleinFail);
			PlayerPrefs.SetInt("Money0", money);
			PlayerPrefs.SetFloat("LiedHeart0", liedAff);
			PlayerPrefs.SetFloat("KleinHeart0", kleinAff);
			PlayerPrefs.SetString("BackgroundClip0", backgroundclip);

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
		row = itemData[4].Split(new char[] { ',' });

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

		ShowDialogue();
	}


	public void RiitItem()
	{
		dialogues.Clear();
		row = itemData[5].Split(new char[] { ',' });

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

		itemChoose = true;

		ShowDialogue();
	}

	public void KleinItem()
	{
		dialogues.Clear();
		row = itemData[9].Split(new char[] { ',' });

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

			row = itemData[8].Split(new char[] { ',' });

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

		else if (feel == 1)
		{
			affection += 3;

			row = itemData[7].Split(new char[] { ',' });

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

		else if (feel == 2)
		{
			affection += 2;

			row = itemData[6].Split(new char[] { ',' });

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

		PlayerPrefs.SetFloat("LiedHeart", affection);

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

			row = itemData[12].Split(new char[] { ',' });

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

		else if (feel == 1)
		{
			affection += 3;

			row = itemData[11].Split(new char[] { ',' });

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

		else if (feel == 2)
		{
			affection += 2;

			row = itemData[10].Split(new char[] { ',' });

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

		PlayerPrefs.SetFloat("KleinHeart", affection);

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

	float[] spectrum;
	float frqLow = 200;
	float frqHigh = 800;
	float fMax = 24000;

	float SpectrumVol(float fLow, float fHigh)
	{
		fLow = Mathf.Clamp(fLow, 20, fMax);
		fHigh = Mathf.Clamp(fHigh, fLow, fMax);
		Voice.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
		int n1 = (int)Mathf.Floor(fLow * 256 / fMax);
		int n2 = (int)Mathf.Floor(fHigh * 256 / fMax);
		float sum = 0;
		for (int i = n1; i <= n2; i++)
		{
			sum += spectrum[i];
		}
		return sum / (n2 - n1 + 1);
	}


	public IEnumerator MouthAnim(int mouth1, int mouth2, int mouth3, float voiceTime)
	{
		float timeToClose = 0;
		int i = 0;
		spectrum = new float[256];

		while (timeToClose <= voiceTime && mouthStop == false)
		{
			timeToClose += Time.deltaTime;

			if (timeToClose > 0.6 * i && SpectrumVol(frqLow, frqHigh) > 0.02f)
			{
				StopCoroutine("Mouth1");
				StartCoroutine(Mouth1(mouth1, mouth2, mouth3));
				i++;
			}

			yield return null;
		}
		yield break;
	}

	public IEnumerator MouthAnim1(int mouth1, int mouth2, int mouth3, float voiceTime)
	{
		float timeToClose = 0;
		int i = 0;
		spectrum = new float[256];

		while (timeToClose <= voiceTime && mouthStop == false)
		{
			timeToClose += Time.deltaTime;

			if (timeToClose > 0.6 * i && SpectrumVol(frqLow, frqHigh) > 0.02f)
			{
				StopCoroutine("Mouth2");
				StartCoroutine(Mouth2(mouth1, mouth2, mouth3));
				i++;
			}

			yield return null;
		}
		yield break;
	}

	public IEnumerator MouthAnim2(int mouth1, int mouth2, int mouth3, float voiceTime)
	{
		float timeToClose = 0;
		int i = 0;
		spectrum = new float[256];

		while (timeToClose <= voiceTime && mouthStop == false)
		{
			timeToClose += Time.deltaTime;

			if (timeToClose > 0.6 * i && SpectrumVol(frqLow, frqHigh) > 0.02f)
			{
				{
					StopCoroutine("Mouth3");
					StartCoroutine(Mouth3(mouth1, mouth2, mouth3));
					i++;
				}

				yield return null;
			}
			yield break;
		}
	}

	public IEnumerator Mouth1(int mouth1, int mouth2, int mouth3)
	{
		MouthNow.sprite = CharaMouth[mouth2];
		yield return new WaitForSeconds(0.1f);
		MouthNow.sprite = CharaMouth[mouth1];
		yield return new WaitForSeconds(0.1f);
		MouthNow.sprite = CharaMouth[mouth2];
		yield return new WaitForSeconds(0.1f);
		MouthNow.sprite = CharaMouth[mouth3];
		yield return new WaitForSeconds(0.05f);
	}

	public IEnumerator Mouth2(int mouth1, int mouth2, int mouth3)
	{
		MouthNow1.sprite = CharaMouth[mouth2];
		yield return new WaitForSeconds(0.1f);
		MouthNow1.sprite = CharaMouth[mouth1];
		yield return new WaitForSeconds(0.1f);
		MouthNow1.sprite = CharaMouth[mouth2];
		yield return new WaitForSeconds(0.1f);
		MouthNow1.sprite = CharaMouth[mouth3];
		yield return new WaitForSeconds(0.05f);
	}

	public IEnumerator Mouth3(int mouth1, int mouth2, int mouth3)
	{
		MouthNow2.sprite = CharaMouth[mouth2];
		yield return new WaitForSeconds(0.1f);
		MouthNow2.sprite = CharaMouth[mouth1];
		yield return new WaitForSeconds(0.1f);
		MouthNow2.sprite = CharaMouth[mouth2];
		yield return new WaitForSeconds(0.1f);
		MouthNow2.sprite = CharaMouth[mouth3];
		yield return new WaitForSeconds(0.05f);
	}



	public IEnumerator FadeAudio(float current, float start, float end, float duration)
	{
		while (current >= 0 && audioFade == true)
		{
			current += Time.deltaTime;
			BGM.volume = Mathf.Lerp(start, end, current / duration);
			yield return null;
		}
		yield break;
	}
}
