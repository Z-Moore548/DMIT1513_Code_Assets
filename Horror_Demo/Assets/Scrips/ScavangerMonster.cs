using UnityEngine;
using UnityEngine.InputSystem;

public class ScavangerMonster : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] AudioSource sound;
    [SerializeField] AudioClip thump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
    }

    public void PlayAudio()
    {
        sound.PlayOneShot(thump, 2f);
    }
    public void PlayScreem()
    {
        sound.Play();
    }
}
