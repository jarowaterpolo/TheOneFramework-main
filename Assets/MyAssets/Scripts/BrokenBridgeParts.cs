using UnityEngine;

public class BrokenBridgeParts : MonoBehaviour
{
    private float Timer;
    private float DestroyTime = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > DestroyTime) 
        { 
            Destroy(gameObject);        
        }
    }
}
