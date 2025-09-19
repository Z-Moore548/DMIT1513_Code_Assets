using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] Animator pause;
    [SerializeField] TMP_Text text;
    [SerializeField] Image image;

    void Start()
    {
        UpdateText();
        UpdateImage();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetBool("Paused", true);
        }
    }
    private void UpdateText()
    {

    }
    private void UpdateImage()
    {

    }

    public void Resume()
    {
        pause.SetBool("Paused", false);
    }
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
