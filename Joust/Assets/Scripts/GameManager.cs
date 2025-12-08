using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] int[] scores = new int[4];
    

    public int[] Scores { get => scores; set => scores = value; }

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
    void Start()
    {
        
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            UpdateScores(0);
        }
        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            UpdateScores(1);
        }
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            UpdateScores(2);
        }
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            UpdateScores(3);
        }
        
        // for (int i = 0; i < scoresText.Length; i++)
        // {
        //     scoresText[i].text = $"{scores[i]}";
        // }
    }

    public void UpdateScores(int slot)
    {
        Scores[slot]++;
        
    }
    public void ResetScores()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            Scores[i] = 0;
        }
    } 
    public void EndGame()
    {
        SceneManager.LoadScene("Results");
    }
}
