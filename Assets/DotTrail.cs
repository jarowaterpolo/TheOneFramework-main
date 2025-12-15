using UnityEngine;

public class DotTrail : MonoBehaviour
{
    //player
    public GameObject Player;
    public GameObject MainPlayerDot;

    //spawning
    public float DotSpawnDelay;
    private float Timer;

    public Transform MazeDotCanvas;
    public GameObject Dot;

    private Vector3 SpawnPos;

    private bool InMaze;

    //star UI
    public GameObject StarDot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnPos = Player.transform.position + new Vector3(0,3645 + 50, -150);
        SpawnPos = Vector3.zero + new Vector3(0, .5f, 0) + Player.transform.position;

        Timer += Time.deltaTime;

        if (InMaze == true)
        {
            if (Timer > DotSpawnDelay)
            {
                Debug.Log("Spawn Dot");
                Instantiate(Dot, SpawnPos, Quaternion.Euler(90, 0, 0), MazeDotCanvas);
                Timer = 0;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            InMaze = true;
            MainPlayerDot.SetActive(false);
            StarDot.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InMaze = false;
            MainPlayerDot.SetActive(true);
            StarDot.SetActive(false);
        }
    }
}
