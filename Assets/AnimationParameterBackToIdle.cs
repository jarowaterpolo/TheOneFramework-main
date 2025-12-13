using UnityEngine;

public class AnimationParameterBackToIdle : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetIntFightCam(int value)
    {
        Debug.Log("set the fight cam par to " + value);
        animator.SetInteger("FightCamMove", value);
    }
}
