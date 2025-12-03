using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        
    }
    public void Quit()
    {
        Application.Quit();
    }
    #endregion
    #region Pause Screen

    #endregion
}
