using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 StartPosition;

    [Range(0, 10)] public float MVSpd = 1;
    [Range(0, 2)] public float phaseOffset = 0;

    public Vector3 movementRange;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartPosition = transform.position;
    }

    /*
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(EnterPipe.AreaStarter);

        if (EnterPipe.AreaStarter == true)
        {
            Vector3 positionOffset =
                transform.TransformVector(movementRange / 10) *
                Mathf.Sin(Time.time * MVSpd / 10 + phaseOffset * Mathf.PI);
            transform.position = StartPosition + positionOffset;
        }
        else if (EnterPipe.AreaStarter == false)
        {
            transform.position = StartPosition;
        }
        else
        {
            transform.position = StartPosition;
        }

    }
    */
    private void FixedUpdate()
    {
        if (EnterPipe.AreaStarter == true)
        {
            Vector3 positionOffset =
                transform.TransformVector(movementRange / 10) *
                Mathf.Sin(Time.time * MVSpd / 10 + phaseOffset * Mathf.PI);
            //transform.position = StartPosition + positionOffset;
            rb.MovePosition(StartPosition + positionOffset);
        }
        else if (EnterPipe.AreaStarter == false)
        {
            transform.position = StartPosition;
        }
        else
        {
            transform.position = StartPosition;
        }
    }
    //FixedUpdate, Kinematic Rigibody, rb.MovePosition
}
