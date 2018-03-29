using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandUI : MonoBehaviour
{
    Text consoleText;
    Button startButton;
    InputField playerName;
    public void Start()
    {
        gameObject.tag = "LandUI";
        startButton = transform.Find("StartButton").GetComponent<Button>();
        startButton.interactable = false;
        consoleText = transform.Find("ConsoleText").GetComponent<Text>();
        playerName = transform.Find("PlayerNameIn").GetComponent<InputField>();
        playerName.onEndEdit.AddListener(PlayerName);
        playerName.text = PlayerPrefs.GetString("PlayerName");
        GetPlayerName();
        startButton.onClick.AddListener(GameMgr.Instance.LobbyMgr.StartMacting);
    }

    private void PlayerName(string arg0)
    {
        GetPlayerName();
    }

    public void TextShow(string str)
    {
        consoleText.text = str;
    }
    private void OnDestroy()
    {
        Destroy(gameObject);
    }
    public string GetPlayerName()
    {
        //if (PlayerPrefs.GetString("PlayerName") != "")
        //{
        //    playerName.text = PlayerPrefs.GetString("PlayerName");
        //    startButton.interactable = true;
        //}
        /*else */if (playerName.text != "")
        {
            PlayerPrefs.SetString("PlayerName", playerName.text);
            startButton.interactable = true;
        }
        return playerName.text;
    }
}
