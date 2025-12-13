using UnityEngine;

public class MinigameStones : MonoBehaviour
{
    public GameObject[] Stones;

    public Quaternion Rot = Quaternion.Euler(-90, 0, 0);
    public Vector3 Pos = new Vector3(3, 37, -2);

    private static GameObject[] StaticStones;
    private static Quaternion StaticRot;
    private static Vector3 StaticPos;

    public static bool TimeStone = false;
    public static bool TimeStoneCollectedBefore = false;
    public bool StoneTest = true;

    public int TimeStoneSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StaticStones = Stones;
        StaticRot = Rot;
        StaticPos = Pos;

        TimeStoneSpawn = 0;

        if (TimeStone == true)
        {
            SpawnTimeStone();
            TimeStoneSpawn = 1;
        }

        //if (TimeStoneCollectedBefore == true)
        //{
        //    if (TimeStoneSpawn == 0)
        //    {
        //        SpawnTimeStone();
        //        TimeStoneSpawn = 1;
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public static void SpawnTimeStone()
    {
        Instantiate(StaticStones[4], StaticPos, StaticRot);
        TimeStone = false;
        TimeStoneCollectedBefore = true;
    }
}
