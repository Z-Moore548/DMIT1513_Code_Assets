using UnityEngine;

public class Targets : MonoBehaviour
{
    [SerializeField] int targetNum;
    [SerializeField] CarnivalGame game;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        game.Hits[targetNum] = true;
        gameObject.SetActive(false);
    }
}
