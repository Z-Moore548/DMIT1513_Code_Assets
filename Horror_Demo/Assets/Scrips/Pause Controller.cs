using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject player,pauseMenu;
    public void OnContinue()
    {
        player.GetComponent<PlayerController>().OnEnable();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
