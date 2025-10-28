using UnityEngine;

public class TopCam : MonoBehaviour
{
    [SerializeField] GameObject topCamSpot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = topCamSpot.transform.position;
    }
}
