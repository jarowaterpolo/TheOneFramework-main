using UnityEngine;

public class PortalActivator : MonoBehaviour
{
    private Portal_Controller[] portalSimpleScripts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        portalSimpleScripts = GetComponentsInChildren<Portal_Controller>();
        ActivatePortals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivatePortals()
    {
        for (int i = 0; i < portalSimpleScripts.Length; i++)
        {
            portalSimpleScripts[i].TogglePortal(true);
        }
    }
}
