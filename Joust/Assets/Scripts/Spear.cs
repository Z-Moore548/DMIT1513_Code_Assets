using UnityEngine;

public class Spear : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().Killed();
            gameObject.GetComponentInParent<PlayerController>().Score();
        }
    }
}
