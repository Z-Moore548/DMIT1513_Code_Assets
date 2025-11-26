using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{   
    [SerializeField] GameObject panel, pauseMenu, player, endScreen, gameManager, gameOver;
    [SerializeField] Animator anim;
    bool ended;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ended = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && !ended)
        {
            pauseMenu.SetActive(true);
            Cursor.visible = true;
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

    public void EndScreen()
    {
        if (!gameManager.GetComponent<GameManger>().DoorReached)
        {
            gameOver.SetActive(true);
        }
        ended = true;
        endScreen.SetActive(true);
        Cursor.visible = true;
    }

    public void Task()
    {
        anim.SetTrigger("Task");
        
    }
}
