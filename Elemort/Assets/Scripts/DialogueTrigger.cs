using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;


    public void TriggerDialogue()
    {
        if (dialogue.sentences.Length > 0)
            GameManager.instance.dialogueManager.StartDialogue(dialogue);
    }
}
