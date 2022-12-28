using System.Runtime.InteropServices;
using UnityEngine;

public class GoWebSite : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void OpenPage(string str);

    public static void ToWebSite()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        OpenPage("https://www.instagram.com/dejavu_ent_/");
        Debug.LogError("Open By WebGL");
#elif UNITY_EDITOR
        Application.OpenURL("https://www.instagram.com/dejavu_ent_/");
        Debug.LogError("Open By Editor");
#endif
    }

    public void ToWeb2()
    {
        Debug.LogError("2");
        System.Diagnostics.Process.Start("https://www.instagram.com/dejavu_ent_/");
    }

    public void ToWeb3()
    {
        Debug.LogError("3");
        Application.ExternalEval("https://www.instagram.com/dejavu_ent_/");
    }
}