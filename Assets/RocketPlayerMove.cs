using UnityEngine;

public class RocketPlayerMove : PlayerActivatable
{
    public GameObject Player;

    private int ToSpaceOrBack = 0;
    override protected void OnActivate()
    {
        CharacterController cc = Player.GetComponent<CharacterController>();

        if (cc != null)
        {
            cc.enabled = false;
            if (ToSpaceOrBack == 0)
            {
                Player.transform.position = new Vector3(5, 100, 3600);
                ToSpaceOrBack++;
                StarMovement.InSpace = true;
            }
            else if(ToSpaceOrBack >= 1)
            {
                StarMovement.InSpace = false;
                Player.transform.position = new Vector3(5, 0, 85);
                ToSpaceOrBack = 0;
            }
            cc.enabled = true;
        }
    }
}
