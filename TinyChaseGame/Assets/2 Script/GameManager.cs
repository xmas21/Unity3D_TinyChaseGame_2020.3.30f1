using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] [Header("遊戲失敗頁面")] GameObject gameOverObj;
    [SerializeField] [Header("遊戲失敗頁面")] Text gameOverInfo_Txt;
    [SerializeField] [Header("重新開始按鈕")] Button restartBtn;
    [SerializeField] [Header("離開按鈕")] Button exitBtn;

    [SerializeField] [Header("下一關頁面")] GameObject nextLevelObj;
    [SerializeField] [Header("下一關文字")] Text nextInfoTxt;
    [SerializeField] [Header("下一關按鈕")] Button nextLevelBtn;

    [SerializeField] [Header("關卡道具數量")] int iCount;
    [SerializeField] [Header("關卡時間")] float fMaxTime;
    float fGameTime;
    float fdeltaTime;

    bool boPlayerDie;
    bool boOverTime;

    Text remainCount;
    Text timerValue;
    Image timerBar;

    void Awake()
    {
        if (remainCount == null)
            remainCount = GameObject.Find("Canvas/HUD/Remaining/Remain Count").GetComponent<Text>();

        if (timerBar == null)
            timerBar = GameObject.Find("Canvas/HUD/Timer/Timer Bar").GetComponent<Image>();

        if (timerValue == null)
            timerValue = GameObject.Find("Canvas/HUD/Timer/Timer Value").GetComponent<Text>();

        if (gameOverObj == null)
            gameOverObj = GameObject.Find("Canvas/Die Page");

        if (restartBtn == null)
            restartBtn = GameObject.Find("Canvas/Die Page/Restart Btn").GetComponent<Button>();

        if (exitBtn == null)
            exitBtn = GameObject.Find("Canvas/Die Page/Exit Btn").GetComponent<Button>();
    }

    void Start()
    {
        fdeltaTime = Time.deltaTime;
        fGameTime = fMaxTime;
        boPlayerDie = false;

        restartBtn.onClick.AddListener(Restart);
        nextLevelBtn.onClick.AddListener(NextLevel);
        exitBtn.onClick.AddListener(ToMenu);

        SetDiePage(false);
        UpdateUI();
    }

    void FixedUpdate()
    {
        if (boPlayerDie || boOverTime)
            return;

        UpdateUI();
        GameTime();
    }

    void UpdateUI()
    {
        remainCount.text = "x " + iCount.ToString();

        timerValue.text = fGameTime.ToString("F0");

        timerBar.fillAmount = (fGameTime / fMaxTime);

        if (timerBar.fillAmount <= 0.05f)
            timerBar.fillAmount = 0f;

        if (timerBar.fillAmount > 0.6f)
            timerBar.color = new Color(0f, 0.65f, 0f, 1f);
        else if (timerBar.fillAmount <= 0.6f && timerBar.fillAmount > 0.3f)
            timerBar.color = new Color(1f, 0.66f, 0f, 1f);
        else if (timerBar.fillAmount <= 0.3f)
            timerBar.color = new Color(1f, 0f, 0f, 1f);
    }

    void GameTime()
    {
        if (fGameTime > 0.1f)
            fGameTime -= fdeltaTime;
        else
            GameOver(true);
    }

    public void SetDiePage(bool r_bEnable)
    {
        boPlayerDie = r_bEnable;
        gameOverObj.SetActive(boPlayerDie);
        gameOverInfo_Txt.text = "你死亡了";
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Decrease()
    {
        iCount--;

        if (iCount <= 0)
            SetNextLevelPage(true);
    }

    public void SetNextLevelPage(bool r_bEnable)
    {
        nextLevelObj.SetActive(r_bEnable);

        nextInfoTxt.text = $"關卡 {SceneManager.GetActiveScene().buildIndex - 1}/3 \r\n 通關成功!!";
    }

    void NextLevel()
    {
        int sceneID = SceneManager.GetActiveScene().buildIndex;

        sceneID++;

        SceneManager.LoadScene(sceneID);
    }

    void GameOver(bool r_bIsOver)
    {
        boOverTime = r_bIsOver;
        gameOverObj.SetActive(boOverTime);
        gameOverInfo_Txt.text = "超過時間";
    }

    void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
