using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voice_get : MonoBehaviour
{
    [SerializeField] LoadDialogue _loaddia;
    public List<string> voice_name;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 65;i < 1990;i++ ){
            string digi;
            if (i < 100){
                digi = "00";
            }else if(i < 1000){
                digi = "0";
            }else{
                digi = "";
            }

            if(i >= 65 && i <= 250){
                AudioClip file = Resources.Load<AudioClip>("Voice/プロローグ 1/V-"+digi+i);
                if(file != null){
                    _loaddia.VoiceFile_2.Add(file);
                }
            }else if(i >= 257 && i <= 337){
                AudioClip file = Resources.Load<AudioClip>("Voice/リート1章/V-"+digi+i);
                if(file != null){
                    _loaddia.VoiceFile_2.Add(file);
                }
            }else if(i >= 342 && i <= 419){
                AudioClip file = Resources.Load<AudioClip>("Voice/リート2章/V-"+digi+i);
                if(file != null){
                    _loaddia.VoiceFile_2.Add(file);
                }
            }else if(i >= 424 && i <= 519){
                AudioClip file = Resources.Load<AudioClip>("Voice/リート3章/V-"+digi+i);
                if(file != null){
                    _loaddia.VoiceFile_2.Add(file);
                }
            }else if(i >= 526 && i <= 648){
                AudioClip file = Resources.Load<AudioClip>("Voice/リート4章/V-"+digi+i);
                if(file != null){
                    _loaddia.VoiceFile_2.Add(file);
                }
            }else if(i >= 650 && i <= 813){
                AudioClip file = Resources.Load<AudioClip>("Voice/リート5章/V-"+digi+i);
                if(file != null){
                    _loaddia.VoiceFile_2.Add(file);
                }
            }
            else if(i >= 820 && i <= 963){
                AudioClip file = Resources.Load<AudioClip>("Voice/リート6章/V-"+digi+i);
                if(file != null){
                    _loaddia.VoiceFile_2.Add(file);
                }
            }
            else if(i >= 967 && i <= 1115){
                AudioClip file = Resources.Load<AudioClip>("Voice/リート7章/V-"+digi+i);
                if(file != null){
                    _loaddia.VoiceFile_2.Add(file);
                }
            }else if(i >= 1116 && i <= 1332){
                AudioClip file = Resources.Load<AudioClip>("Voice/リート8章/V-"+digi+i);
                if(file != null){
                    _loaddia.VoiceFile_2.Add(file);
                }
            }else if(i >= 1333 && i <= 1388){
                AudioClip file = Resources.Load<AudioClip>("Voice/リート9章/V-"+digi+i);
                if(file != null){
                    _loaddia.VoiceFile_2.Add(file);
                }
            }
            else if(i >= 1398 && i <= 1449){
                AudioClip file = Resources.Load<AudioClip>("Voice/リート10章/V-"+digi+i);
                if(file != null){
                    _loaddia.VoiceFile_2.Add(file);
                }
            }
            else if(i >= 1467 && i <= 1959){
                AudioClip file = Resources.Load<AudioClip>("Voice/リート11章/V-"+digi+i);
                if(file != null){
                    _loaddia.VoiceFile_2.Add(file);
                }
            }
            else if(i >= 1970 && i <= 1989){
                AudioClip file = Resources.Load<AudioClip>("Voice/リートエピローグ/V-"+digi+i);
                if(file != null){
                    _loaddia.VoiceFile_2.Add(file);
                }
            }
        }
        for(int i= 0 ;i < _loaddia.VoiceFile_2.Count;i++){
            string temp = _loaddia.VoiceFile_2[i].ToString();
            temp = temp.Replace(" (UnityEngine.AudioClip)", "");
            voice_name.Add(temp);

        }
    }

}
