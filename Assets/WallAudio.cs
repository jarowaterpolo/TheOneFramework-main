using UnityEngine;

public class WallAudio : MonoBehaviour
{
    private AudioSource wallAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject wallAudioGameObject = GameObject.FindWithTag("WallAudio");
        wallAudio = wallAudioGameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (wallAudio != null)
            {
                wallAudio.Play();
            }
        }
    }
}
