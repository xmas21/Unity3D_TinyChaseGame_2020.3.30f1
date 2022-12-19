using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] [Header("�}�l���s")] Button start_Btn;
    [SerializeField] [Header("�W�r��J��")] InputField name_field;

    void Start()
    {
        start_Btn.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        if (name_field)
        {
            if (name_field.text.Length > 5 || name_field.text.Length <= 0)
                return;
            else
            {
                GlobalData.SetPlayerName(name_field.text);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
