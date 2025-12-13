using UnityEngine;

public class LavaRising : MonoBehaviour
{
    public GameObject Player;

    private CharacterController cc;
    public float LavaRiseSpd = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = Player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnterPipe.AreaStarter == true)
        {
            transform.Translate(transform.up * Time.deltaTime * LavaRiseSpd);
        }
        else
        {
            transform.position = new Vector3(10000,-60,0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (cc != null)
            {
                cc.enabled = false;
                EnterPipe.tpPlace = 1;
                Player.transform.position = new Vector3(98, 1, 1);
                EnterPipe.AreaStarter = false;
                cc.enabled = true;
            }
        }

    }
}
