using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarnivalGame : MonoBehaviour
{
    [SerializeField] GameObject UI, map, mapSpawn;
    [SerializeField] GameObject[] targets = new GameObject[5];
    private bool[] hits = new bool[5];

    bool playing, canPlay, gameOver, lose;

    public bool[] Hits { get => hits; set => hits = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playing = false;
        canPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay)//check to decide if you can play
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                playing = true;
                canPlay = false;
                gameOver = true;
                lose = false;
                StartCoroutine(StartGame());
            }
        }
        if (playing)//all of this is the carnival game playing
        {
            gameOver = true;
            for (int i = 0; i < Hits.Length; i++)
            {
                if (!Hits[i])
                {
                    gameOver = false;
                }
            }
            if (gameOver)
            {
                EndGame();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI.GetComponent<QuestAndUI>().PlayText(true);
            canPlay = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI.GetComponent<QuestAndUI>().PlayText(false);
            canPlay = false;
        }
    }
    IEnumerator StartGame()
    {
        targets[0].SetActive(true);
        targets[1].SetActive(true);
        targets[2].SetActive(true);
        targets[3].SetActive(true);
        targets[4].SetActive(true);
        yield return new WaitForSeconds(15);
        playing = false;
        lose = true;
        
        EndGame();
    }
    void EndGame()
    {
        targets[0].SetActive(false);
        targets[1].SetActive(false);
        targets[2].SetActive(false);
        targets[3].SetActive(false);
        targets[4].SetActive(false);
        if (lose)
        {

        }
        else
        {
            Instantiate(map, mapSpawn.transform);
        }
        for (int i = 0; i < hits.Length; i++)
        {
            hits[i] = false;
        }
        
    }
}
