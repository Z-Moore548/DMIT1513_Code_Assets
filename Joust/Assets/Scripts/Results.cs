using UnityEngine;

public class Results : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] int first, second, third, fourth;
    [SerializeField] GameObject[] players, podiumPlaces;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        first = 4;
        second = 4;
        third = 4;
        fourth = 4;
        GetResults();
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
    }
}
