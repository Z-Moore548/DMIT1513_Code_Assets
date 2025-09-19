using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Animator titleAnim;

    [SerializeField] TMP_InputField charaName;
    [SerializeField] TMP_InputField planetName;
    [SerializeField] TMP_Dropdown weapon;
    [SerializeField] private int image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}
