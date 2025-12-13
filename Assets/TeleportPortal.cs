using UnityEngine;

public class TeleportPortal : MonoBehaviour
{
    public TeleportPortal TargetPortal;

    public Vector3 TP_Offset = new Vector3(0, 0, 1);

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("tp");
        if (other.gameObject.CompareTag("Player"))
        {
            CharacterController cc = other.GetComponent<CharacterController>();

            if (cc != null)
            {
                cc.enabled = false;
                other.transform.position = TargetPortal.transform.position + TP_Offset;
                Debug.Log("did tp");
                cc.enabled = true;
            }
        }
    }
}
