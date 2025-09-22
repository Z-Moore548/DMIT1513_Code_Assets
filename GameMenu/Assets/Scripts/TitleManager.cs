using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Animator titleAnim;
    [SerializeField] Animator pause;
    [SerializeField] GameObject menuButton;
    [SerializeField] Slider slider;
    [SerializeField] TMP_InputField charaName;
    [SerializeField] TMP_InputField planetName;
    [SerializeField] TMP_Dropdown weapon;
    [SerializeField] Image chara;
    [SerializeField] private int image;
    [SerializeField] Sprite[] sprites = new Sprite[5];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chara.sprite = sprites[image];
        menuButton.SetActive(false);
        slider.value = GameManger.instance.Volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetBool("Paused", true);
        }
    }

    public void TitleButton()
    {
        titleAnim.SetBool("NextPage", true);
    }
    public void BackButton()
    {
        titleAnim.SetBool("NextPage", false);
    }
    public void CharacterName()
    {
        GameManger.instance.CharacterName = charaName.text;
    }
    public void PlanetName()
    {
        GameManger.instance.PlanetName = planetName.text;
    }
    public void WeaponChoice()
    {
        GameManger.instance.Weapon = weapon.value;
    }
    public void PlayButton()
    {
        SceneManager.LoadSceneAsync("Game");
    }
    public void NextImage()
    {
        if (image == 4)
        {
            image = 0;
        }
        else
        {
            image++;
        }
        chara.sprite = sprites[image];
        GameManger.instance.Picture = image;
    }
    public void LastImage()
    {
        if (image == 0)
        {
            image = 4;
        }
        else
        {
            image--;
        }
        chara.sprite = sprites[image];
        GameManger.instance.Picture = image;
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
