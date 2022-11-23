using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] [Header("���⦺�`����")] GameObject playerDieObj;
    [SerializeField] [Header("���s�}�l���s")] Button restartBtn;
    [SerializeField] [Header("���}���s")] Button exitBtn;

    [SerializeField] [Header("�U�@������")] GameObject nextLevelObj;
    [SerializeField] [Header("�U�@�����s")] Button nextLevelBtn;

    [SerializeField] [Header("���d�D��ƶq")] int iCount;
    [SerializeField] [Header("���d�ɶ�")] float fMaxTime;
    float fGameTime;
    float fdeltaTime;

    bool boPlayerDie;

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

        if (playerDieObj == null)
            playerDieObj = GameObject.Find("Canvas/Die Page");

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

        SetDiePage(false);
        UpdateUI();
    }

    void FixedUpdate()
    {
        if (boPlayerDie)
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
    }

    void Restart()
    {
        // SceneManager.LoadScene("2 Game");
    }

    void NextLevel()
    {
        int sceneID = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(sceneID++);
    }

    public void Decrease()
    {
        iCount--;
    }

    public void SetDiePage(bool r_bEnable)
    {
        boPlayerDie = r_bEnable;
        playerDieObj.SetActive(boPlayerDie);
    }
}
