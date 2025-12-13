using UnityEngine;

public class SFXController : MonoBehaviour
{
    [SerializeField] AudioSource sound;
    [SerializeField] AudioClip squawk, pop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySquawk()
    {
        sound.PlayOneShot(squawk);
    }
    public void PlayPop()
    {
        sound.PlayOneShot(pop);
    }
}
