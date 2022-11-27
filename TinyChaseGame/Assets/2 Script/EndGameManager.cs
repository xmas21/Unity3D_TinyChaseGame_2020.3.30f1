using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] [Header("µ²§ô Info")] Text endInfo_txt;

    [SerializeField] [Header("IG Link")] Button igLink_Btn;

    void Start()
    {
        SetPlayerID();
        igLink_Btn.onClick.AddListener(LinkToIg);
    }

    void SetPlayerID()
    {
        int irandomID = Random.Range(0, 10000);

        endInfo_txt.text = $"ª±®aÀH¾÷ID : {irandomID:D5}";
    }

    void LinkToIg()
    {
        Application.OpenURL("https://www.instagram.com/dejavu_ent_/");
    }
}
