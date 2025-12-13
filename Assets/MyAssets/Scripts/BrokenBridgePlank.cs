using UnityEngine;

public class BrokenBridgePlank : MonoBehaviour
{
    public GameObject OldPlankRemains;
    public GameObject VinePlankRemains;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (gameObject.name.Contains("Old"))
            {
                Vector3 pos = gameObject.transform.position;
                Destroy(gameObject);
                Instantiate(OldPlankRemains, pos, Quaternion.identity);
            }
            else if (gameObject.name.Contains("Overgrown"))
            {
                Vector3 pos = gameObject.transform.position;
                Destroy(gameObject);
                Instantiate(VinePlankRemains, pos, Quaternion.identity);
            }
            else
            {

            }
        }
    }
}
