using System.Collections;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [SerializeField] GameObject player, monsterScavanger, monsterWatcher;
    [SerializeField] GameObject playerSpawn, canvas;
    [SerializeField] GameObject[] monsterPoints = new GameObject[5], lights = new GameObject[7];

    int monsterIndex;
    bool notTriggered;

    void Start()
    {
        player.transform.position = playerSpawn.transform.position;
        player.transform.rotation = playerSpawn.transform.rotation;
        monsterIndex = 0;
        notTriggered = true;
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && notTriggered)
        {
            StartMonsterChase();
            notTriggered = false;
        }
    }

    public void ReturnPlayer()
    {
        canvas.GetComponent<CanvasController>().Fade(true);
        StartCoroutine(MovePlayer());
    }
    

    public void StartMonsterChase()
    {
        StartCoroutine(MonsterChase());
    }

    void LightsOff(bool off)
    {
        if(off == true)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].GetComponent<Light>().intensity = 0;
            }
        }
        else
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].GetComponent<Light>().intensity = 5;
            }
        }
        
    }

    IEnumerator MovePlayer()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = playerSpawn.transform.position;
        player.transform.rotation = playerSpawn.transform.rotation;
        canvas.GetComponent<CanvasController>().Fade(false);
    }
    IEnumerator MonsterChase() //Holy shit thats a long coroutine need to add distance check to see if the player is closer to the mosnter.
    {
        LightsOff(true);
        monsterScavanger.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        LightsOff(false);
        yield return new WaitForSeconds(6);

        LightsOff(true);
        monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
        monsterIndex++;
        yield return new WaitForSeconds(0.5f);
        LightsOff(false);
        yield return new WaitForSeconds(6);

        LightsOff(true);
        monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
        monsterIndex++;
        yield return new WaitForSeconds(0.5f);
        LightsOff(false);
        yield return new WaitForSeconds(6);

        LightsOff(true);
        monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
        monsterIndex++;
        yield return new WaitForSeconds(0.5f);
        LightsOff(false);
        yield return new WaitForSeconds(6);

        LightsOff(true);
        monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
        monsterIndex++;
        yield return new WaitForSeconds(0.5f);
        LightsOff(false);
        yield return new WaitForSeconds(6);

        LightsOff(true);
        monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
        monsterIndex++;
        yield return new WaitForSeconds(0.5f);
        LightsOff(false);
        yield return new WaitForSeconds(6);

        LightsOff(true);
        monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
        monsterIndex++;
        yield return new WaitForSeconds(0.5f);
        LightsOff(false);
        yield return new WaitForSeconds(6);

        LightsOff(true);
        monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
        monsterIndex++;
        yield return new WaitForSeconds(0.5f);
        LightsOff(false);
        yield return new WaitForSeconds(6);

        LightsOff(true);
        monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
        monsterIndex++;
        yield return new WaitForSeconds(0.5f);
        LightsOff(false);
        yield return new WaitForSeconds(6);
    }
}
