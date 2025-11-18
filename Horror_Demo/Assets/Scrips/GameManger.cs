using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManger : MonoBehaviour
{
    [SerializeField] GameObject player, monsterScavanger, monsterWatcher;
    [SerializeField] GameObject playerSpawn, canvas, JumpscareSpawn;
    [SerializeField] GameObject[] monsterPoints = new GameObject[5], lights = new GameObject[7];

    int monsterIndex;
    [SerializeField] bool notTriggered, doorReached;

    void Start()
    {
        player.transform.position = playerSpawn.transform.position;
        player.transform.rotation = playerSpawn.transform.rotation;
        monsterIndex = 0;
        notTriggered = true;
        doorReached = false;
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
        if (doorReached)
        {
            monsterScavanger.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && notTriggered)
        {
            StartMonsterChase();
            notTriggered = false;
        }
        if(other.gameObject.CompareTag("Player") && doorReached)
        {
            DoJumpScare();
        }
    }

    public void ReturnPlayer()
    {
        canvas.GetComponent<CanvasController>().Fade(true);
        doorReached = true;
        StartCoroutine(MovePlayer());
    }
    

    public void StartMonsterChase()
    {
        StartCoroutine(MonsterChase());
    }
    void DoJumpScare()
    {
        monsterWatcher.transform.position = new Vector3(monsterPoints[0].transform.position.x, monsterPoints[0].transform.position.y - 8f, monsterPoints[0].transform.position.z);
        StartCoroutine(JumpScareStart());
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
                lights[i].GetComponent<Light>().intensity = 2;
            }
        }
        
    }

    void MonsterNearCheck()
    {
        if(Vector3.Distance(monsterPoints[monsterIndex].transform.position, player.transform.position) < Vector3.Distance(monsterPoints[monsterIndex].transform.position, monsterPoints[monsterIndex - 1].transform.position))
        {
            //this detects if the monster is closer to you than the next jump point.
        }
    }

    IEnumerator MovePlayer()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = playerSpawn.transform.position;
        player.transform.rotation = playerSpawn.transform.rotation;
        canvas.GetComponent<CanvasController>().Fade(false);
    }
    IEnumerator JumpScareStart() //Figure out how to detect when you have died.
    {
        yield return new WaitForSeconds(2);
        monsterWatcher.GetComponent<WatcherController>().JumpScareActivate();
        
    }
    IEnumerator MonsterChase() //Holy shit thats a long coroutine need to add distance check to see if the player is closer to the mosnter. and fine tune the time between jumps
    {
        LightsOff(true);
        monsterScavanger.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        LightsOff(false);
        yield return new WaitForSeconds(6);

        if (!doorReached)
        {
            LightsOff(true);
            monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
            monsterIndex++;
            yield return new WaitForSeconds(0.5f);
            LightsOff(false);
            yield return new WaitForSeconds(6);
        }
        

        if (!doorReached)
        {
            LightsOff(true);
            MonsterNearCheck();
            monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
            monsterIndex++;
            yield return new WaitForSeconds(0.5f);
            LightsOff(false);
            yield return new WaitForSeconds(6);
        }
        

        if (!doorReached)
        {
            LightsOff(true);
            MonsterNearCheck();
            monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
            monsterIndex++;
            yield return new WaitForSeconds(0.5f);
            LightsOff(false);
            yield return new WaitForSeconds(6);
        }
        

        if (!doorReached)
        {
            LightsOff(true);
            MonsterNearCheck();
            monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
            monsterIndex++;
            yield return new WaitForSeconds(0.5f);
            LightsOff(false);
            yield return new WaitForSeconds(6);
        }
        

        if (!doorReached)
        {
            LightsOff(true);
            MonsterNearCheck();
            monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
            monsterIndex++;
            yield return new WaitForSeconds(0.5f);
            LightsOff(false);
            yield return new WaitForSeconds(6);
        }
        

        if (!doorReached)
        {
            LightsOff(true);
            MonsterNearCheck();
            monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
            monsterIndex++;
            yield return new WaitForSeconds(0.5f);
            LightsOff(false);
            yield return new WaitForSeconds(6);
        }
        

        if (!doorReached)
        {
            LightsOff(true);
            MonsterNearCheck();
            monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
            monsterIndex++;
            yield return new WaitForSeconds(0.5f);
            LightsOff(false);
            yield return new WaitForSeconds(6);
        }
        

        if (!doorReached)
        {
            LightsOff(true);
            MonsterNearCheck();
            monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
            monsterIndex++;
            yield return new WaitForSeconds(0.5f);
            LightsOff(false);
            yield return new WaitForSeconds(6);
        }
        
    }
}
