using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;

    [SerializeField] private string characterName;
    [SerializeField] private int weapon;
    [SerializeField] private string planetName;
    [SerializeField] private int picture;

    public string CharacterName { get => characterName; set => characterName = value; }
    public int Weapon { get => weapon; set => weapon = value; }
    public string PlanetName { get => planetName; set => planetName = value; }
    public int Picture { get => picture; set => picture = value; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
