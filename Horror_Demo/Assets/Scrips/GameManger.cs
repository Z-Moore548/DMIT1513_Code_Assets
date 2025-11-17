using System.Collections;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [SerializeField] GameObject player, monsterScavanger, monsterWatcher;
    [SerializeField] GameObject playerSpawn, canvas;
    [SerializeField] GameObject[] monsterPoints = new GameObject[5];

    void Start()
    {
        player.transform.position = playerSpawn.transform.position;
        player.transform.rotation = playerSpawn.transform.rotation;
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartMonsterChase();
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

    IEnumerator MovePlayer()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = playerSpawn.transform.position;
        player.transform.rotation = playerSpawn.transform.rotation;
        canvas.GetComponent<CanvasController>().Fade(false);
    }
    IEnumerator MonsterChase()
    {
        canvas.GetComponent<CanvasController>().Blink(true);
        monsterScavanger.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        canvas.GetComponent<CanvasController>().Blink(false);
        
    }
}
