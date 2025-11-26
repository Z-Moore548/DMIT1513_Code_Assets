using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManger : MonoBehaviour
{
    [SerializeField] GameObject player, monsterScavanger, monsterWatcher;
    [SerializeField] GameObject playerSpawn, canvas, JumpscareSpawn, invisWall, roomLight;
    [SerializeField] TMP_Text taskText;
    [SerializeField] GameObject[] monsterPoints = new GameObject[5], lights = new GameObject[7];

    int monsterIndex;
    [SerializeField] bool notTriggered, doorReached, firstRun;

    public bool DoorReached { get => doorReached; set => doorReached = value; }

    void Start()
    {
        player.transform.position = playerSpawn.transform.position;
        player.transform.rotation = playerSpawn.transform.rotation;
        monsterIndex = 0;
        notTriggered = true;
        DoorReached = false;
        firstRun = true;
        Cursor.visible = false;
        StartCoroutine(TaskAnim());
    }

    void Update()
    {
        // if (Keyboard.current.escapeKey.wasPressedThisFrame)
        // {
        //     Application.Quit();
        // }
        if (DoorReached)
        {
            monsterScavanger.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && firstRun)
        {
            
        }
        if (other.gameObject.CompareTag("Player") && notTriggered && !firstRun)
        {
            StartMonsterChase();
            notTriggered = false;
        }
        if(other.gameObject.CompareTag("Player") && DoorReached && !firstRun)
        {
            DoJumpScare();
            invisWall.SetActive(true);
        }
    }

    public void ReturnPlayer()
    {
        if (firstRun)
        {
            firstRun = false;
            taskText.text = "Jobs Done: What arE you still d0ing her3?";
        }
        else
        {
            DoorReached = true;
            taskText.text = "Jobs Done: Y0u eed to g3t ou1 o hr3!";
        }
        canvas.GetComponent<CanvasController>().Fade(true);
        StartCoroutine(MovePlayer());
    }
    

    public void StartMonsterChase()
    {
        StartCoroutine(MonsterChase());
    }
    void DoJumpScare()
    {
        monsterWatcher.transform.position = new Vector3(monsterPoints[0].transform.position.x, monsterPoints[0].transform.position.y - 8f, monsterPoints[0].transform.position.z);
        monsterWatcher.GetComponent<WatcherController>().PlayGrowl();
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
                lights[i].GetComponent<Light>().intensity = 5;
            }
        }
        
    }

    void MonsterNearCheck()
    {
        if(Vector3.Distance(monsterPoints[monsterIndex].transform.position, player.transform.position) < Vector3.Distance(monsterPoints[monsterIndex].transform.position, monsterPoints[monsterIndex - 1].transform.position))
        {
            
        }
    }

    public void EndDemo()
    {
        LightsOff(true);
        Destroy(roomLight);
        canvas.GetComponent<CanvasController>().EndScreen();
        Time.timeScale = 0;
        player.GetComponent<PlayerController>().OnDisable();
        StartCoroutine(End());
        
    }

    IEnumerator TaskAnim()
    {
        yield return new WaitForSeconds(1);
        canvas.GetComponent<CanvasController>().Task();
    }
    IEnumerator End()
    {
       yield return new WaitForSeconds(1);
       canvas.GetComponent<CanvasController>().EndScreen();
    }
    IEnumerator MovePlayer()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = playerSpawn.transform.position;
        player.transform.rotation = playerSpawn.transform.rotation;
        canvas.GetComponent<CanvasController>().Fade(false);
        StartCoroutine(TaskAnim());
    }
    IEnumerator JumpScareStart() //Figure out how to detect when you have died.
    {
        yield return new WaitForSeconds(4);
        monsterWatcher.GetComponent<WatcherController>().JumpScareActivate();
        
    }
    IEnumerator MonsterChase() //Holy shit thats a long coroutine need to add distance check to see if the player is closer to the mosnter. and fine tune the time between jumps
    {
        LightsOff(true);
        monsterScavanger.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        LightsOff(false);
        yield return new WaitForSeconds(6);

        if (!DoorReached)
        {
            LightsOff(true);
            monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
            monsterScavanger.GetComponent<ScavangerMonster>().PlayAudio();
            monsterIndex++;
            yield return new WaitForSeconds(0.5f);
            LightsOff(false);
            yield return new WaitForSeconds(5);
        }
        

        if (!DoorReached)
        {
            LightsOff(true);
            MonsterNearCheck();
            monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
            monsterScavanger.GetComponent<ScavangerMonster>().PlayAudio();
            monsterIndex++;
            yield return new WaitForSeconds(0.5f);
            LightsOff(false);
            yield return new WaitForSeconds(4);
        }
        

        if (!DoorReached)
        {
            LightsOff(true);
            MonsterNearCheck();
            monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
            monsterScavanger.GetComponent<ScavangerMonster>().PlayAudio();
            monsterIndex++;
            yield return new WaitForSeconds(0.5f);
            LightsOff(false);
            yield return new WaitForSeconds(4);
        }
        

        if (!DoorReached)
        {
            LightsOff(true);
            MonsterNearCheck();
            monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
            monsterScavanger.GetComponent<ScavangerMonster>().PlayAudio();
            monsterIndex++;
            yield return new WaitForSeconds(0.5f);
            LightsOff(false);
            yield return new WaitForSeconds(3);
        }
        

        if (!DoorReached)
        {
            LightsOff(true);
            MonsterNearCheck();
            monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
            monsterScavanger.GetComponent<ScavangerMonster>().PlayAudio();
            monsterIndex++;
            yield return new WaitForSeconds(0.5f);
            LightsOff(false);
            yield return new WaitForSeconds(3);
        }
        

        if (!DoorReached)
        {
            LightsOff(true);
            MonsterNearCheck();
            monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
            monsterScavanger.GetComponent<ScavangerMonster>().PlayAudio();
            monsterIndex++;
            yield return new WaitForSeconds(0.5f);
            LightsOff(false);
            yield return new WaitForSeconds(4);
        }
        

        if (!DoorReached)
        {
            LightsOff(true);
            MonsterNearCheck();
            monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
            monsterScavanger.GetComponent<ScavangerMonster>().PlayAudio();
            monsterIndex++;
            yield return new WaitForSeconds(0.5f);
            LightsOff(false);
            yield return new WaitForSeconds(2);
        }
        

        if (!DoorReached)
        {
            LightsOff(true);
            MonsterNearCheck();
            monsterScavanger.transform.position = monsterPoints[monsterIndex].transform.position;
            monsterScavanger.GetComponent<ScavangerMonster>().PlayAudio();
            monsterIndex++;
            yield return new WaitForSeconds(0.5f);
            LightsOff(false);
            yield return new WaitForSeconds(2);
        }
        
    }
}
