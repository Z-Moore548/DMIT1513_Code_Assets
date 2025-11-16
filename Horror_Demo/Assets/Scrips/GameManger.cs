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

    public void ReturnPlayer()
    {
        canvas.GetComponent<CanvasController>().Fade(true);
        StartCoroutine(MovePlayer());
    }

    public void StartMonsterChase()
    {
        
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
        yield return new WaitForSeconds(5);
    }
}
