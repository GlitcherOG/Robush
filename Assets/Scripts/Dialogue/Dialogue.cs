using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public string[] text;
    public int index;
    public bool showDlg;
    public Text dlg;
    public GameObject dialoge;
    public GameObject nextButton;
    public GameObject byeButton;

    //public void TurnOnGUI()
    //{
    //    dialoge.SetActive(true);
    //}
    //public void NextDlg()
    //{
    //    if (!(index >= text.Length - 1))
    //    {
    //        dlg.text = text[index];
    //        index++;
    //    }
    //    else
    //    {
    //        nextButton.SetActive(false);
    //        byeButton.SetActive(true);
    //    }
    //}
    //public void ByeDlg()
    //{
    //    index = 0;
    //    nextButton.SetActive(true);
    //    byeButton.SetActive(false);
    //    dialoge.SetActive(false);
    //}
    private void OnGUI()
    {
        if (showDlg)
        {
            Vector2 scr = new Vector2(Screen.width / 16, Screen.height / 9);

            GUI.Box(new Rect(0, scr.y * 6, Screen.width, scr.y * 3), text[index]);
            if (!(index >= text.Length - 1))
            {
                if (GUI.Button(new Rect(scr.x * 14.75f, scr.y * 8.5f, scr.x, scr.y * 0.5f), "Next"))
                {
                    index++;
                }
            }
            else
            {
                if (GUI.Button(new Rect(scr.x * 14.75f, scr.y * 8.5f, scr.x, scr.y * 0.5f), "Bye."))
                {
                    Time.timeScale = 1;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    index = 0;
                    showDlg = false;
                }
            }
        }
    }
}
