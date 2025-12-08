using UnityEngine;

public class Spear : MonoBehaviour
{
    [SerializeField] GameObject myself;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(other.gameObject.GetComponent<PlayerController>().Invincible != true)
            {
                Debug.Log("Killed");
                myself.GetComponent<PlayerController>().Score();
            }
            other.gameObject.GetComponent<PlayerController>().Killed();
        }
    }
}
