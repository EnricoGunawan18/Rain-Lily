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
    private AddScore _add;
    [SerializeField]
    private click_right_effect _effect;

    [Space(10)]

    [SerializeField]
    private GameObject finish;

    private bool stop_W;
    void Awake()
    {
        Time.timeScale = 1f;
        stop_W=false;
        resultObject.SetActive(false);
        retry.onClick.AddListener(Retry);
        end.onClick.AddListener(Quit);
    }

    async void ResultSW(bool sw)
    {
        if (sw)
        {
            _effect.Finish_effect();
            finish.transform.DOMoveX(0,2.0f)
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
            stop_W=true;
            ResultSW(true);
            text.text = "Score:" + _add.GetScore();
        }
        else
        {
            ResultSW(false);
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

        int miniGame = PlayerPrefs.GetInt("MiniGame");
        if (miniGame == 4)
        {
            PlayerPrefs.SetInt("NovelMenu", 10);
            SceneManager.LoadScene("Novel");
        }
        else
        {
            PlayerPrefs.SetInt("NovelMenu", 0);
            SceneManager.LoadScene("Novel");
        }
    }

    public bool SendStop()
    {
        return stop_W;
    }
}
