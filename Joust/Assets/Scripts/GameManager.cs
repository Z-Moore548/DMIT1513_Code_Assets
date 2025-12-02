
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject Timer;
    [SerializeField] TMP_Text[] scores;
    [SerializeField] float startTime = 60f, currentTime;
    [SerializeField] bool timerActive;
    void Start()
    {
        timerActive = false;
        currentTime = startTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (timerActive)
        {
            if(currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                currentTime = 0;
                timerActive = false;
                Timer.GetComponent<TMP_Text>().text = "0";
                Debug.Log("Timer Over");
            }
        }
    }

    void UpdateTimerDisplay()
    {
        int seconds = Mathf.FloorToInt(currentTime % 60);
        Timer.GetComponent<TMP_Text>().text = $"{seconds}";
    }

    void PauseTimer()
    {
        timerActive = false;
    }
    void StartTimer()
    {
        timerActive = true;
    }
}
