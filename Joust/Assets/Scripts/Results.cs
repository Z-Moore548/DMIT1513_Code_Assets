using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Results : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] int first, second, third, fourth;
    [SerializeField] GameObject[] players, podiumPlaces;
    [SerializeField] GameObject again;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        first = 4;
        second = 4;
        third = 4;
        fourth = 4;
        GetResults();
        EventSystem.current.SetSelectedGameObject(null);
        Invoke("AllowButtons", 2f);
    }
    void AllowButtons()
    {
        EventSystem.current.SetSelectedGameObject(again);
    }

    void GetResults()
    {
        for (int i = 0; i < gameManager.Scores.Length; i++)//figure out first
        {
            if(gameManager.Scores[i] > gameManager.Scores[first])
            {
                first = i;
            }
        }
        for (int i = 0; i < gameManager.Scores.Length; i++)//figure out Second
        {
            if(gameManager.Scores[i] > gameManager.Scores[second] && gameManager.Scores[i] < gameManager.Scores[first] && i != first)
            {
                second = i;
            }
        }
        for (int i = 0; i < gameManager.Scores.Length; i++)//figure out Third
        {
            if(gameManager.Scores[i] > gameManager.Scores[third] && gameManager.Scores[i] < gameManager.Scores[second]&& i != first && i != second)
            {
                third = i;
            }
        }
        for (int i = 0; i < gameManager.Scores.Length; i++)//figure out fourth
        {
            if(gameManager.Scores[i] < gameManager.Scores[third] && gameManager.Scores[i] > gameManager.Scores[fourth] && i != third)
            {
                fourth = i;
            }
        }
        PlaceOnPodium();
    }
    void PlaceOnPodium()
    {
        for (int i = 0; i < players.Length; i++)// THIS IS MAKING NO FUCKING SENSE
        {
            if(i == first)
            {
                players[i].transform.position = podiumPlaces[0].transform.position;
            }
            if(i == second)
            {
                players[i].transform.position = podiumPlaces[1].transform.position;
            }
            if(i == third)
            {
                players[i].transform.position = podiumPlaces[2].transform.position;
            }
            if(i == fourth)
            {
                players[i].transform.position = podiumPlaces[3].transform.position;
            }
        }
        PlaceTies();
    }
    void PlaceTies()
    {
        bool tiedFirst = false;
        bool tiedSecond = false;
        bool tiedThird = false;
        for (int i = 0; i < players.Length; i++)
        {
            if(i != first && gameManager.Scores[i] == gameManager.Scores[first])
            {
                
                if(tiedFirst)
                {
                    players[i].transform.position = new Vector3(podiumPlaces[0].transform.position.x, podiumPlaces[0].transform.position.y + 4, podiumPlaces[0].transform.position.z);
                    
                }
                else if (!tiedFirst)
                {
                    players[i].transform.position = new Vector3(podiumPlaces[0].transform.position.x, podiumPlaces[0].transform.position.y + 2, podiumPlaces[0].transform.position.z);
                    tiedFirst = true;
                }

            }
            if(i != second && gameManager.Scores[i] == gameManager.Scores[second] && second != 4)
            {
                
                if(tiedSecond)
                {
                    players[i].transform.position = new Vector3(podiumPlaces[1].transform.position.x, podiumPlaces[1].transform.position.y + 4, podiumPlaces[1].transform.position.z);  
                }
                else if (!tiedSecond)
                {
                    players[i].transform.position = new Vector3(podiumPlaces[1].transform.position.x, podiumPlaces[1].transform.position.y + 2, podiumPlaces[1].transform.position.z);
                    tiedSecond = true; 
                }
            }
            if(i != third && gameManager.Scores[i] == gameManager.Scores[third] && third != 4)
            {
                
                if(tiedThird)
                {
                    players[i].transform.position = new Vector3(podiumPlaces[2].transform.position.x, podiumPlaces[2].transform.position.y + 4, podiumPlaces[2].transform.position.z);
                    
                }
                else if (!tiedThird)
                {
                    players[i].transform.position = new Vector3(podiumPlaces[2].transform.position.x, podiumPlaces[2].transform.position.y + 2, podiumPlaces[2].transform.position.z);
                    tiedThird = true;
                }            }
        }
    }
}
