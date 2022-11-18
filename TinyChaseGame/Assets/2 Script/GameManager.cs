using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] [Header("關卡道具數量")] int iCount;
    [SerializeField] [Header("關卡時間")] float fMaxTime;
    float fGameTime;
    float fdeltaTime;

    Text remainCount;
    Image timerBar;

    void Awake()
    {
        if (remainCount == null)
            remainCount = GameObject.Find("Canvas/HUD/Remaining/Remain Count").GetComponent<Text>();

        if (timerBar == null)
            timerBar = GameObject.Find("Canvas/HUD/Timer/Timer Bar").GetComponent<Image>();
    }

    void Start()
    {
        fdeltaTime = Time.deltaTime;
        fGameTime = fMaxTime;

        UpdateUI();
    }

    void FixedUpdate()
    {
        UpdateUI();
        GameTime();
    }

    public void Decrease()
    {
        iCount--;
    }

    void UpdateUI()
    {
        remainCount.text = iCount.ToString();

        timerBar.fillAmount = (fGameTime / fMaxTime);

        if (timerBar.fillAmount > 0.6f)
            timerBar.color = new Color(0f, 1f, 0f, 1f);
        else if (timerBar.fillAmount <= 0.6f && timerBar.fillAmount > 0.3f)
            timerBar.color = new Color(1, 0.66f, 0f, 1f);
        else if (timerBar.fillAmount <= 0.3f)
            timerBar.color = new Color(1, 0f, 0f, 1f);
    }

    void GameTime()
    {
        if (fGameTime > 0.1f)
            fGameTime -= fdeltaTime;
    }
}
