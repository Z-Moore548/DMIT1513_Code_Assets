using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject playButton, backButton, resumeButton, lobby;
    void Start()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
    }
    #region Results Screen
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Joust");
    }
    #endregion
    #region Main Menu
    public void StartGame()
    {
        SceneManager.LoadScene("Joust");
    }
    public void Controls()
    {
        EventSystem.current.SetSelectedGameObject(null);
        anim.SetBool("Controls", true);
        EventSystem.current.SetSelectedGameObject(backButton);
    }
    public void ControlsGone()
    {
        EventSystem.current.SetSelectedGameObject(null);
        anim.SetBool("Controls", false);
        EventSystem.current.SetSelectedGameObject(playButton);
    }
    public void Quit()
    {
        Application.Quit();
    }
    #endregion
    #region Pause Screen
    public void Resume()
    {
        lobby.GetComponent<LobbyW1>().ResumeGame();
    }
    public void BackMenu()
    {
        lobby.GetComponent<LobbyW1>().BackMenu();
    }
    #endregion
}
