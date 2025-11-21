using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{   
    [SerializeField] GameObject panel, pauseMenu, player;
    [SerializeField] Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            pauseMenu.SetActive(true);
            player.GetComponent<PlayerController>().OnDisable();
            Time.timeScale = 0;
        }
    }
    public void Fade(bool fadeOut)
    {
        if(fadeOut == true)
        {
            anim.SetBool("FadeOut", true);
        }
        else
        {
            anim.SetBool("FadeOut", false);
        }
    }

    public void Blink(bool dark)
    {
        if (dark == true)
        {
            anim.SetBool("LightOff", true);
        }
        else
        {
            anim.SetBool("LightOff", false);
        }
    }
}
