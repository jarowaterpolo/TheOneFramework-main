using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPipe : MonoBehaviour
{
    public GameObject Player;

    public AudioSource clip;

    public Scene scene;
    public static int tpPlace;

    public static bool AreaStarter = false;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        tpPlace = scene.buildIndex;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //OldSceneSwitch();
        PlayerTP();
    }

    //public void OldSceneSwitch()
    //{
    //    clip.Play();

    //    if (tpPlace == 0)
    //    {
    //        tpPlace = 1;
    //        SceneManager.LoadScene(tpPlace);
    //    }
    //    else if (tpPlace == 1)
    //    {
    //        tpPlace = 0;
    //        SceneManager.LoadScene(tpPlace);
    //        MinigameStones.TimeStone = true;
    //    }
    //}
    public void PlayerTP()
    {
        CharacterController cc = Player.GetComponent<CharacterController>();

        if (cc != null)
        {
            cc.enabled = false;
            if (tpPlace == 1)
            {
                Player.transform.position = new Vector3(10000 - 1.5f, -2, -9);
                AreaStarter = true;
                tpPlace = 2;
            }
            else if (tpPlace == 2) 
            {
                Player.transform.position = new Vector3(98, 1, 1);
                AreaStarter = false;
                tpPlace = 1;
            }
            cc.enabled = true;
        }
    }
}
