using UnityEngine;

public class RoomLightFlicker : MonoBehaviour
{   
    [SerializeField] int maxRange;
    int rand, timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {   if(timer == 25)
        {
            rand = Random.Range(0, maxRange);
            if(rand == 0)
            {
                gameObject.GetComponent<Light>().intensity = 1;
            }
            else
            {
                gameObject.GetComponent<Light>().intensity = 10;
            }
            timer = 0;
        }
        else
        {
            timer++;
        }
        
    }
}
