using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{   
    [SerializeField] GameObject panel;
    [SerializeField] Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            anim.SetBool("LightOff", true);
        }
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            anim.SetBool("LightOff", false);
        }
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            anim.SetBool("FadeOut", true);
        }
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            anim.SetBool("FadeOut", false);
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
}
