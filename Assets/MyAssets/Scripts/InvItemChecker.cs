using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]


public class InvItemChecker : MonoBehaviour
{
    [Serializable]
    public class ItemEvent
    {
        public string itemName;
        public UnityEvent eventToFire;
    }

    public ItemEvent[] itemEvents;


    public void OnItemClick(string pItemName)
    {
        Debug.Log(pItemName);
        foreach (ItemEvent itemEvent in itemEvents)
        {
            if (itemEvent.itemName == pItemName)
            {
                itemEvent.eventToFire.Invoke();
            }
        }
    }
}
