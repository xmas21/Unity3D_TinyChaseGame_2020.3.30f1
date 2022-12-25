using System.Runtime.InteropServices;
using UnityEngine;

public class GoWebSite : MonoBehaviour
{
    [DllImport("__Internal")]

    private static extern void OpenPage(string str);

    public void ToWebSite()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        OpenPage("https://www.instagram.com/dejavu_ent_/");
#endif
        Application.OpenURL("https://www.instagram.com/dejavu_ent_/");
    }
}
