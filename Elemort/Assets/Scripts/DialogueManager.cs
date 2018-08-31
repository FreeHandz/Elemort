using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Queue<string> sentences;

    public Text dialogueText;

    public Text NPCName;

    public bool isDialogShown;

    private bool isCurrentlyCounting;

	void Awake () {
        sentences = new Queue<string>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
	}

    
    public void StartDialogue(Dialogue dialogue)
    {
        gameObject.SetActive(true);
        isDialogShown = true;
        NPCName.text = dialogue.NPCName;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
        Time.timeScale = 0;
    }

    IEnumerator TypeSentece(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentece(sentence));

    }

    public void EndDialogue()
    {
        gameObject.SetActive(false);
        isDialogShown = false;
        Time.timeScale = 1;
    }
}
