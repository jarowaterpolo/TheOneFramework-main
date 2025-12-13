using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityFundamentals;
using Yarn.Unity;

public class MyVariableGetter : MonoBehaviour
{
    public DialogueRunner dialogueSystem;

    public string identifier;
    private VariableStorageBehaviour variableStorage;

    private float Timer = 0;
    private float MinTime = 60;

    [System.Obsolete]
    void Start() 
    {
        if (dialogueSystem == null) {
            dialogueSystem = FindFirstObjectByType<DialogueRunner>();
        }
        if (dialogueSystem != null) {
            variableStorage = dialogueSystem.GetComponent<InMemoryVariableStorage>();
        }
        if (identifier != "") {
            if (identifier.Substring(0, 1) != "$") {
                identifier = "$" + identifier;
            }
        }

        Activate();
    }

    void Update()
    {
        if (Timer < MinTime)
        {
            Activate();
            MinTime++;
        }
    }
    public void Activate()
    {
        if (variableStorage != null && !string.IsNullOrEmpty(identifier))
        {
            //variableStorage.TryGetValue(identifier, out int variableValue);
            //variableStorage.SetValue(identifier, variableValue);
            //Debug.Log(variableValue);
            variableStorage.TryGetValue(identifier, out int variableValue);
            Debug.Log(variableValue);
        }
    }
}
