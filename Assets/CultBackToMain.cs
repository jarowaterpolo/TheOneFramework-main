using UnityEngine;

public class CultBackToMain : PlayerActivatable
{
    public GameObject Player;
    override protected void OnActivate()
    {
        CharacterController cc = Player.GetComponent<CharacterController>();

        if (cc != null)
        {
            cc.enabled = false;
            Player.transform.position = new Vector3(-70, 0, -85);
            cc.enabled = true;
        }
    }
}
