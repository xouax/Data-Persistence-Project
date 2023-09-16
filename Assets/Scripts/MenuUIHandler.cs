using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour {

    public Button startButton;
    public InputField playerNameInput;

    void Start() {
        startButton.interactable = false;
        playerNameInput.onValueChanged.AddListener(ShowStartButton);
    }

    // Update is called once per frame
    void Update() {

    }

    public void SetPlayerName() {
        GameManager.Instance.playerName = playerNameInput.text;
    }

    private void ShowStartButton(string inputText) {
        if (!string.IsNullOrEmpty(inputText)) {
            startButton.interactable = true;
        } else {
            startButton.interactable = false;
        }
    }

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void Exit() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
