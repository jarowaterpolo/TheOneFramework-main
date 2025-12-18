using System.Collections.Generic;
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

    //dots itself
    public List<GameObject> Dots;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnPos = Player.transform.position + new Vector3(0,3645 + 50, -150);
        SpawnPos = Vector3.zero + new Vector3(0, .1f, 0) + Player.transform.position;

        Timer += Time.deltaTime;

        if (InMaze == true)
        {
            if (Timer > DotSpawnDelay)
            {
                Debug.Log("Spawn Dot");
                Instantiate(Dot, SpawnPos, Quaternion.Euler(90, 0, 0), MazeDotCanvas);
                GetAllDots();
                Timer = 0;
            }
        }

        if (Dots != null)
        {
            DrawLinesInBetweenDots();
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

    public void GetAllDots()
    {
        Dots.Clear();

        GameObject[] TrailDots = GameObject.FindGameObjectsWithTag("TrailDot");

        foreach (GameObject dot in TrailDots)
        {
            Dots.Add(dot);
        }
    }
    public void DrawLinesInBetweenDots()
    {
        for (int i = 0; i < Dots.Count; i++)
        {
            if (i > 0)
            {
                DrawLine(Dots[i - 1].transform.position, Dots[i].transform.position, Color.green);
            }
        }
    }

    //ray drawing outside gizmo
    public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.1f)
    {
        GameObject lineObj = new GameObject("RuntimeRay");
        LineRenderer lr = lineObj.AddComponent<LineRenderer>();

        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.5f;
        lr.endWidth = 0.5f;
        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);

        // Destroy after duration
        Object.Destroy(lineObj, duration);
    }
}
