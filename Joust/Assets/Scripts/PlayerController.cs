using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction moveAction, jump, dash;
    void Start()
    {
        Enable();
    }

    void Update()
    {
        
    }

    void Enable()
    {
        moveAction.Enable();
        jump.Enable();
        dash.Enable();
    }
    void Disable()
    {
        moveAction.Disable();
        jump.Disable();
        dash.Disable();
    }
}
