using UnityEngine;

public class WatcherController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Animator anim;
    [SerializeField] float speed;
    bool activateScare;
    void Start()
    {
        activateScare = false;
    }
    void Update()
    {
        if (activateScare)
        {
            Debug.Log("Scary");
            anim.SetBool("JumpScare", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    public void JumpScareActivate()
    {
        activateScare = true;
    }

}
