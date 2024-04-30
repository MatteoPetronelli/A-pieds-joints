using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public static DialogueTrigger instance;
    public Dialogue dialogueOp;
    public Dialogue dialogueLoose;
    public Dialogue dialogueWin;
    public bool isInDialogue;
    private bool alreadyLoose;
    private bool alreadyWin;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        Situation();
    }

    public void Situation()
    {
        
        if (isInDialogue) return;
        isInDialogue = true;
        TriggerDialogue();
        
    }

    private void ActiveCoach()
    {
        if (TimerUI.instance.loosePanel.activeSelf)
        {
            DialogueManager.instance.Coach.SetActive(true);
        }

        if (Controller.instance.endPanel.activeSelf)
        {
            DialogueManager.instance.Coach.SetActive(true);
        }
    }

    public void TriggerDialogue()
    {
        DialogueManager.instance.Coach.SetActive(true);

        if (LvlChoiceManager.instance.idTableaux == 0)
        {
            DialogueManager.instance.StartDialogue(dialogueOp);
        }

        if (TimerUI.instance.loosePanel.activeSelf)
        {
            if (alreadyLoose) return;
            alreadyLoose = true;
            DialogueManager.instance.StartDialogue(dialogueLoose);
        }

        if (Controller.instance.endPanel.activeSelf)
        {
            if(alreadyWin) return;
            alreadyWin = true;
            DialogueManager.instance.StartDialogue(dialogueWin);
        }
    }
}
