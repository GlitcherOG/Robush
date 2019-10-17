using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueOptions : MonoBehaviour
{
    public string[] text;
    public int index, option;
    public bool showDlg;
    public Text dlg;
    public GameObject dialoge;
    //public GameObject button;
    public GameObject nextButton;
    public GameObject acceptDeny;
    public GameObject byeButton;

    //    public void TurnOnGUI()
    //    {
    //        //button.GetComponent<Button>.on
    //        dialoge.SetActive(true);
    //        //Button test = dialoge.GetComponent<Button>.;
    //    }
    //    public void NextDlg()
    //    {
    //        if (!(index >= text.Length - 1))
    //        {
    //            dlg.text = text[index];
    //            index++;
    //        }
    //        else if (option == index)
    //        {
    //            acceptDeny.SetActive(true);
    //            nextButton.SetActive(false);
    //        }
    //        else
    //        {
    //            nextButton.SetActive(false);
    //            acceptDeny.SetActive(false);
    //            byeButton.SetActive(true);
    //        }
    //    }
    //    public void ByeDlg(bool final = true)
    //    {
    //        if (final)
    //        {
    //            index = 0;
    //            nextButton.SetActive(true);
    //            byeButton.SetActive(false);
    //            dialoge.SetActive(false);
    //        }
    //        else
    //        {
    //            index = text.Length-1;
    //            dlg.text = text[index];
    //            nextButton.SetActive(false);
    //            acceptDeny.SetActive(false);
    //            byeButton.SetActive(true);
    //        }
    //    }
    //}

    private void OnGUI()
    {
        if (showDlg)
        {
            Vector2 scr = new Vector2(Screen.width / 16, Screen.height / 9);

            GUI.Box(new Rect(0, scr.y * 6, Screen.width, scr.y * 3), text[index]);
            if (!(index >= text.Length - 1) && index != option)
            {
                if (GUI.Button(new Rect(scr.x * 14.75f, scr.y * 8.5f, scr.x, scr.y * 0.5f), "Next"))
                {
                    index++;
                }
            }
            else if (index == option)
            {
                if (GUI.Button(new Rect(scr.x * 14.75f, scr.y * 8.0f, scr.x, scr.y * 0.5f), "Decline"))
                {
                    index = text.Length - 1;
                }
                if (GUI.Button(new Rect(scr.x * 14.75f, scr.y * 8.5f, scr.x, scr.y * 0.5f), "Accept"))
                {
                    index++;
                }
            }
            else
            {
                if (GUI.Button(new Rect(scr.x * 14.75f, scr.y * 8.5f, scr.x, scr.y * 0.5f), "Bye."))
                {
                    index = 0;
                    showDlg = false;
                }
            }
        }
    }
}
