using UnityEngine;
using UnityEngine.InputSystem;

public class WatcherController : MonoBehaviour
{
    [SerializeField] GameObject player, gameManager;
    [SerializeField] Animator anim;
    [SerializeField] AudioSource sound;
    [SerializeField] AudioClip growl, yell;
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
            anim.SetBool("JumpScare", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    public void JumpScareActivate()
    {
        activateScare = true;
        PlayYell();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            gameManager.GetComponent<GameManger>().EndDemo();
        }
    }

    public void PlayGrowl()
    {
        sound.PlayOneShot(growl, 1);
    }
    public void PlayYell()
    {
        sound.PlayOneShot(yell, 0.1f);
    }

}
