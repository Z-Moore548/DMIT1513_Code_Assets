using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject gameTracker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameTracker = GameObject.FindGameObjectWithTag("GameTracker");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameTracker.GetComponent<GameTracker>().GotMap = true;
            Destroy(this.gameObject);
        }
    }
}
