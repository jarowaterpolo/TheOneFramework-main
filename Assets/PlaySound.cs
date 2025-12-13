using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource[] audioSource; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int i = 0;
            foreach (var audio in audioSource)
            {
                i++;
            }

            for (int k = 0; k < i; k++)
            {
                audioSource[k].Play();
            }

            Debug.Log("Player stepped in soundzone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int i = 0;
            foreach (var audio in audioSource)
            {
                i++;
            }

            for (int k = 0; k < i; k++)
            {
                audioSource[k].Stop();
            }

            Debug.Log("Player left soundzone");

        }
    }
}
