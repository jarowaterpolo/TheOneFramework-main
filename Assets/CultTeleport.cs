using UnityEngine;
using UnityEngine.Rendering;
using Yarn.Unity;

public class CultTeleport : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CharacterController cc = other.GetComponent<CharacterController>();

            if (GameCommands.TP_Active == true)
            {
                if (cc != null)
                {
                    cc.enabled = false;
                    other.transform.position = new Vector3(-90, 3, -4400);
                    cc.enabled = true;
                }
            }
        }
    }
}
