using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> dialogues;

    void Start()
    {
        dialogues = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue) {
        
    }

}
