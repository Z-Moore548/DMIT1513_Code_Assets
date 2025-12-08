using UnityEngine;

public class Foot : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(other.gameObject.GetComponent<PlayerController>().Invincible != true)
            {
                Debug.Log("footKilled");
                gameObject.GetComponentInParent<PlayerController>().Score();
            }
            other.gameObject.GetComponent<PlayerController>().Killed();
            
        }
    }
}
