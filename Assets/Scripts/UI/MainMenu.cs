using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public menuSelect MenuSelect = menuSelect.Play;
    public Settings SettingsGO;
    // Start is called before the first frame update
    void Start()
    {
        if(SettingsGO.SettingsOpen)
        {
            SettingsGO.Panel.SetActive(true);
        }
        else if (!SettingsGO.SettingsOpen)
        {
            SettingsGO.Panel.SetActive(false);
        }
    }

    public void ClickButton()
    {
        switch (MenuSelect)
        {
            case menuSelect.Play:
                break;
            case menuSelect.Settings:
                SettingsGO.SettingsOpen = !SettingsGO.SettingsOpen;
                break;
            case menuSelect.Quit:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SettingsGO.SettingsOpen)
        {
            SettingsGO.gameObject.SetActive(true);
        }
    }

    public enum menuSelect
    {
        Play,
        Settings,
        Quit
    };
}
