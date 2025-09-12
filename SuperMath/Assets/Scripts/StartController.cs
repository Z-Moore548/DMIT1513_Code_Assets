using UnityEngine;

public class StartController : MonoBehaviour
{
    [SerializeField] Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NextScreen()
    {
        anim.SetBool("NextPanel", true);
    }
    public void Back()
    {
        anim.SetBool("NextPanel", false);
    }
}
