using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Horror_Demo");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
