using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] [Header("Player Name")] Text playerName_txt;
    [SerializeField] [Header("Random ID")] Text randomID_txt;

    [SerializeField] [Header("IG Link")] Button igLink_Btn;
    [SerializeField] [Header("Menu Btn")] Button toMenu_Btn;

    void Start()
    {
        SetEndInfo();
        igLink_Btn.onClick.AddListener(LinkToIg);
        toMenu_Btn.onClick.AddListener(ToMenu);
    }

    void SetEndInfo()
    {
        playerName_txt.text = GlobalData.GetPlayerName();

        int irandomID = Random.Range(0, 100000);

        randomID_txt.text = $"ID : {irandomID:D6}";
    }

    void LinkToIg()
    {
        //Application.OpenURL("https://www.instagram.com/dejavu_ent_/");
    }

    void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
