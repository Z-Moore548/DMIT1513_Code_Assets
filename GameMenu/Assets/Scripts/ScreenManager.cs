using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] Animator pause;
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text text;
    [SerializeField] Image image;
    [SerializeField] Sprite[] sprites = new Sprite[5];
    private string weapon;

    void Start()
    {
        switch (GameManger.instance.Weapon)
        {
            case 0:
                weapon = "Plasma Pistol";
                break;
            case 1:
                weapon = "Lightsaber";
                break;
            case 2:
                weapon = "Banana Gun";
                break;
            case 3:
                weapon = "BFG";
                break;
        }
        UpdateText();
        UpdateImage();
        slider.value = GameManger.instance.Volume;
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
        text.text = $"{GameManger.instance.CharacterName} has landed on Planet {GameManger.instance.PlanetName} with their trusty {weapon}";
    }
    private void UpdateImage()
    {
        image.sprite = sprites[GameManger.instance.Picture];
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
    public void SliderChange()
    {
        GameManger.instance.Volume = slider.value;
        Audio.instance.GetComponent<AudioSource>().volume = slider.value;
    }
}
