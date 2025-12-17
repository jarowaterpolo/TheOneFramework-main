using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Yarn.Unity;
public class GameCommands : MonoBehaviour
{
    public GameObject CutsceneCamera;
    public GameObject FightCam;

    private Animator CutsceneAnimator;
    private Animator FightCamAnimator;

    [SerializeField] private StringVariable NameText;

    public static string Playername;

    public DialogueRunner dialogueSystem;
    private VariableStorageBehaviour variableStorage;

    //M1
    public AudioSource BattleMusic;

    //M2
    public GameObject MazePrefab;
    public GameObject[] MazeAnswerPrefab;

    //M3
    public static bool TP_Active = false;
    public TMP_Text[] CultistTexts;
    public AudioSource[] SummoningSounds;
    public AudioSource CultMusic;

    //Stones
    public GameObject[] Stones;

    //Player
    public GameObject Player;

    //NPC Sounds
    public AudioSource[] NPC_Sounds;
    public int TalkStarted;

    //Unity Event
    [Space]
    [SerializeField] private UnityEvent MoveRock;

    //Yarn stuff
    public DialogueRunner dialogueRunner;

    //Dev Cheats
    public static int DevCheatsNum;
    private int MinigameSkip = 0;

    [System.Obsolete]
    private void Start()
    {
        GetItems();

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SpawnSpaceMaze();
        }
    }
    private void Awake()
    {
        if (dialogueSystem == null && SceneManager.GetActiveScene().buildIndex == 1) 
        {
            GetItems();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            DevCheatsNum = 1;
            DevCheats();
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            DevCheatsNum = 2;
            DevCheats();
        }
        else if (Input.GetKeyDown(KeyCode.F12))
        {
            DevCheatsNum = 3;
            DevCheats();
        }
    }
    void GetItems()
    {
        if (dialogueSystem == null)
        {
            dialogueSystem = FindFirstObjectByType<DialogueRunner>();
        }
        if (dialogueSystem != null)
        {
            variableStorage = dialogueSystem.GetComponent<InMemoryVariableStorage>();
        }

        if (CutsceneCamera != null)
        {
            CutsceneAnimator = CutsceneCamera.GetComponent<Animator>();
        }

        if (FightCam != null)
        {
            FightCamAnimator = FightCam.GetComponent<Animator>();
        }
    }

    [YarnCommand("PlayerName")]
    public void PlayerName(string playerName)
    {
        Debug.Log($"The player's name is: {playerName}");
        // You could store this in a Unity variable here

    }

    [YarnCommand("Camera2On")]
    public void CinematicCameraOn()
    {
        CutsceneCamera.SetActive(true);
    }

    [YarnCommand("Cutscene")]
    public void Cutscene(int CutSceneNumber)
    {
        Debug.Log(CutSceneNumber);
        CutsceneAnimator.SetInteger("CameraMove", CutSceneNumber);
    }

    [YarnCommand("FightCamOn")]
    public void FightCamOn()
    {
        FightCam.SetActive(true);
    }

    [YarnCommand("FightCamMove")]
    public void FightCamMove(int FightCamNum)
    {
        Debug.Log(FightCamNum);
        FightCamAnimator.SetInteger("FightCamMove", FightCamNum);
    }

    [YarnCommand("FightCamOff")]
    public void FightCamOff()
    {
        FightCam.SetActive(false);
    }
    public void SetPlayerName(string Name)
    {
        //NameText = Name;
        Playername = Name;
        Debug.Log(Playername);
    }

    [YarnCommand("SetPlayerName")]
    public void YarnName()
    {
        if (variableStorage != null)
        {
            if (Playername == null)
            {
                Playername = "Thanos";
            }
            variableStorage.SetValue("$player_name", Playername);
        }
        else
        {
            Debug.Log("variableStorage = null");
        }
    }

    [YarnCommand("Check_TP")]
    public void CheckTP(bool tp_active)
    {
        TP_Active = tp_active;

        if (TP_Active == false)
        {
            TP_Inactive();
        }
    }

    public void TP_Inactive()
    {
        dialogueRunner.StartDialogue("TP_InActive");
    }

    [YarnCommand("SetCultistTexts")]
    public void SetCultistTexts(int ID, string Text)
    {
        CultistTexts[ID].text = Text;
    }

    [YarnCommand("PlayForestBattleMusic")]
    public void PlayBattleMusic()
    {
        BattleMusic.Play();
    }

    [YarnCommand("StopForestBattleMusic")]
    public void StopBattleMusic()
    {
        BattleMusic.Stop();
    }

    public void SpawnSpaceMaze()
    {
        Debug.Log("Spawn Maze");
        Vector3 MazeSpawnPos = new Vector3(0, 0, 3000);
        Vector3 AnswerSpawnPos = MazeSpawnPos + new Vector3(5, 99.01f, 650);

        int i = UnityEngine.Random.Range(0, 2);

        //CreationTest
        if (i == 0)
        {
            Instantiate(MazePrefab, MazeSpawnPos, Quaternion.identity);
        }
        else if (i == 1) 
        {
            Instantiate(MazePrefab, MazeSpawnPos + new Vector3(10, 0, 1300), Quaternion.Euler(0,180,0));
        }


        //Instantiate(MazeAnswerPrefab[i], AnswerSpawnPos, Quaternion.identity);
    }

    [YarnCommand("SummoningWhistle")]
    public void SummoningWhistle()
    {
        SummoningSounds[0].Play();
    }

    [YarnCommand("Summoned")]
    public void Summoned()
    {
        SummoningSounds[1].Play();
    }

    [YarnCommand("PlayCultMusic")]
    public void PlayCultMusic()
    {
        CultMusic.Play();
    }

    [YarnCommand("StopCultMusic")]
    public void StopCultMusic()
    {
        CultMusic.Stop();
    }
    [YarnCommand("Talk")]
    public void Talking()
    {
        TalkStarted = Random.Range(0, NPC_Sounds.Length);
        NPC_Sounds[TalkStarted].Play();
    }
    [YarnCommand("StopTalk")]
    public void StopTalking()
    {
        NPC_Sounds[TalkStarted].Stop();
    }

    public void DestroyTrailDots()
    {
        GameObject[] TrailDots = GameObject.FindGameObjectsWithTag("TrailDot");

        foreach (GameObject dot in TrailDots)
        {
            Destroy(dot);
        }
    }

    public void DevCheats()
    {
        switch (DevCheatsNum)
        {
            case 1:
                for (int i = 0; i < Stones.Length; i++)
                {
                    Instantiate(Stones[i], Player.transform.position + new Vector3(0,2,0), Quaternion.identity);
                }
                break;
                
            case 2:
                MoveRock.Invoke();
                break;

            case 3:
                Debug.Log("Minigame skips started");
                MinigameSkip++;
                if (variableStorage != null)
                {
                    variableStorage.SetValue("$DevSkipBool", true);
                    variableStorage.SetValue("$DevSkipInt", MinigameSkip);
                    dialogueRunner.StartDialogue("DevSkip");
                    Debug.Log("M skip = " + MinigameSkip);
                }
                else
                {
                    Debug.Log("variableStorage = null");
                }
                break;

            default:
                break;
        }
    }
}
