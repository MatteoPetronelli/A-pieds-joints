using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public Animator animator;
    public Animator generique;
    public Text dialogueText;
    private Queue<string> sentences;
    public GameObject Coach;
    public  GameObject generiquePanel;

    private void Awake()
    {
        instance = this;

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Coach.SetActive(true);
        animator.SetBool("isOpen", true);
        sentences.Clear();
        foreach (string sentence in dialogue.sentences) 
        { 
            sentences.Enqueue(sentence); 
        }
        DisplayNextSentence();
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
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        DialogueTrigger.instance.isInDialogue = false;
        if (LvlChoiceManager.instance.idTableaux == 0)
        {
            Controller.instance.startPanel.SetActive(true);
        }
        if (LvlChoiceManager.instance.idTableaux == 3)
        {
            generiquePanel.SetActive(true);
            animator.SetBool("isEnd", true);
        }
        Coach.SetActive(false);
    }
}