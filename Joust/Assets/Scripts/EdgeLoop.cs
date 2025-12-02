using UnityEngine;

public class EdgeLoop : MonoBehaviour
{
    [SerializeField] Which trig;

    enum Which
    {
        Top, Bot, Left, Right
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            switch (trig)
            {
                case Which.Top:
                other.transform.position = new Vector3(other.transform.position.x,-8,other.transform.position.z);
                break;
                case Which.Bot:
                other.transform.position = new Vector3(other.transform.position.x,19,other.transform.position.z);
                break;
                case Which.Left:
                other.transform.position = new Vector3(other.transform.position.x,other.transform.position.y,-22);
                break;
                case Which.Right:
                other.transform.position = new Vector3(other.transform.position.x,other.transform.position.y,21);
                break;
                default:
                other.transform.position = new Vector3(other.transform.position.x,0,0);
                break;
            }
        }
    }
}
