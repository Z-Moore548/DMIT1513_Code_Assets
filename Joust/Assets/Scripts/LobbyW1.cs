using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LobbyW1 : MonoBehaviour
{
    [SerializeField] GamepadManager gamepadManager;
    [SerializeField] List<TMP_Text> playerText;
    [SerializeField] Button startButton;

    [SerializeField] List<GameObject> playerObjects;

    [SerializeField] PlayerInputManager playerInputManager;
    GameManager gameManager;
    [SerializeField]Timer timer;
    [SerializeField] GameObject start, ConncetMenu, pauseMenu, resume;
    bool gameStarted;
    

    // Start is called before the first frame update
    void Start()
    {
        gamepadManager = GameObject.Find("GamepadManager").GetComponent<GamepadManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameStarted = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current != null)
        {
            if (Gamepad.current.startButton.wasPressedThisFrame)
            {
                gamepadManager.PlayerJoined(Gamepad.current.deviceId);
            }
        }

        for (int i = 0; i < gamepadManager.PlayerCount(); i++)
        {
            if (gamepadManager.PlayerStatus(i) > -1)
            {
                playerText[i].text = "Connected";
            }
            if (gamepadManager.PlayerStatus(i) == -1)
            {
                playerText[i].text = "Disconnected";
            }
        }

        if (gamepadManager.PlayerCount() == 0 && !gameStarted)
        {
            startButton.interactable = false;
            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
            if (!gameStarted)
            {
                startButton.interactable = true;
                EventSystem.current.SetSelectedGameObject(start);
            }
            
        }
        if (gameStarted)
        {
            if (Keyboard.current.tabKey.wasPressedThisFrame || Gamepad.current.startButton.wasPressedThisFrame)
            {
                timer.PauseTimer();
                Time.timeScale = 0;
                EventSystem.current.SetSelectedGameObject(null);
                pauseMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(resume);
                for (int i = 0; i < gamepadManager.PlayerCount(); i++)
                {
                    playerObjects[i].GetComponent<PlayerController>().Paused = true;
                }
                
            }
        }
        
    }

    public void StartGame()
    {
        gameManager.ResetScores();
        gameStarted = true;
        for (int i = 0; i < gamepadManager.PlayerCount(); i++)
        {
            playerObjects[i].GetComponent<PlayerController>().SetGamepadID(gamepadManager.PlayerStatus(i));
            playerObjects[i].SetActive(true);
        }
        ConncetMenu.SetActive(false);
        timer.StartTimer();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        EventSystem.current.SetSelectedGameObject(null);
        pauseMenu.SetActive(false);
        for (int i = 0; i < gamepadManager.PlayerCount(); i++)
        {
            playerObjects[i].GetComponent<PlayerController>().Paused = false;
        }
        timer.StartTimer();
    }
    public void BackMenu()
    {
        Time.timeScale = 1;
        EventSystem.current.SetSelectedGameObject(null);
        pauseMenu.SetActive(false);
        for (int i = 0; i < gamepadManager.PlayerCount(); i++)
        {
            playerObjects[i].GetComponent<PlayerController>().Paused = false;
        }
        timer.StartTimer();
        SceneManager.LoadScene("MainMenu");
    }
}
