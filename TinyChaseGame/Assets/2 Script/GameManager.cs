using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] [Header("�C�����ѭ���")] GameObject gameOverObj;
    [SerializeField] [Header("�C�����ѭ���")] Text gameOverInfo_Txt;
    [SerializeField] [Header("���s�}�l���s")] Button restartBtn;
    [SerializeField] [Header("���}���s")] Button exitBtn;

    [SerializeField] [Header("�U�@������")] GameObject nextLevelObj;
    [SerializeField] [Header("�U�@����r")] Text nextInfoTxt;
    [SerializeField] [Header("�U�@�����s")] Button nextLevelBtn;

    [SerializeField] [Header("���d�D��ƶq")] int iCount;
    [SerializeField] [Header("���d�ɶ�")] float fMaxTime;
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
        gameOverInfo_Txt.text = "�A���`�F";
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

        nextInfoTxt.text = $"���d {SceneManager.GetActiveScene().buildIndex - 1}/3 \r\n �q�����\!!";
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
        gameOverInfo_Txt.text = "�W�L�ɶ�";
    }

    void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
