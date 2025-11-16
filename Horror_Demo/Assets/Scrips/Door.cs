using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameManager.GetComponent<GameManger>().ReturnPlayer();
        }
    }
}
