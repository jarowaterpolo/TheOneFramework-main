using Unity.Cinemachine;
using UnityEngine;

public class StarMovement : MonoBehaviour
{
    public static bool InSpace = false;
    public static bool InRocketArea = false;

    public Transform playerTransform;
    private Vector3 TargetPos;

    public float StarForwardOffset = 1.3f;
    private Rigidbody rb;

    public RaycastHit hit;
    public float RayMult = .5f;

    private Vector3 R;
    private Vector3 L;
    private Vector3 F;
    private Vector3 B;
    public Vector3 OffSet;
    //work on the others aswell

    private void Awake()
    {
        InSpace = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        R = Vector3.right * RayMult;
        L = Vector3.left * RayMult;
        F = Vector3.forward * RayMult;
        B = Vector3.back * RayMult;

    }

    // Update is called once per frame
    void Update()
    {
        TargetPos = playerTransform.position;

        if (InSpace == true && InRocketArea == false) 
        { 
            transform.position = TargetPos + new Vector3(0, 1.5f, 0) - transform.forward * StarForwardOffset;

            //R Ray
            Physics.Raycast(rb.position + R, Vector3.right, out hit, Mathf.Infinity);
            //Debug.DrawRay(rb.position + R, Vector3.right * hit.distance, Color.yellow, 0, false); 
            DrawRay(rb.position + R + OffSet, Vector3.right * hit.distance, Color.yellow);

            //L Ray
            Physics.Raycast(rb.position + L, Vector3.left, out hit, Mathf.Infinity);
            //Debug.DrawRay(rb.position + L, Vector3.left * hit.distance, Color.yellow, 0, false);
            DrawRay(rb.position + L + OffSet, Vector3.left * hit.distance, Color.yellow);

            //F Ray
            Physics.Raycast(rb.position + F, Vector3.forward, out hit, Mathf.Infinity);
            //Debug.DrawRay(rb.position + F, Vector3.forward * hit.distance, Color.yellow, 0, false);
            DrawRay(rb.position + F + OffSet, Vector3.forward * hit.distance, Color.yellow);

            //B Ray
            Physics.Raycast(rb.position + B, Vector3.back, out hit, Mathf.Infinity);
            //Debug.DrawRay(rb.position + B, Vector3.back * hit.distance, Color.yellow, 0, false);
            DrawRay(rb.position + B + OffSet, Vector3.back * hit.distance, Color.yellow);
        }

    }

    //ray drawing outside gizmo
    public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration = 0.1f)
    {
        GameObject lineObj = new GameObject("RuntimeRay");
        LineRenderer lr = lineObj.AddComponent<LineRenderer>();

        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.02f;
        lr.endWidth = 0.02f;
        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, start + dir);

        // Destroy after duration
        Object.Destroy(lineObj, duration);
    }
}
