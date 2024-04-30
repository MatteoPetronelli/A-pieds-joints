using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    public GameObject startPanel;
    public GameObject continuePanel;
    public GameObject endPanel;
    public GameObject malus;
    public GameObject inventory;
    public GameObject timer;
    public GameObject monster;
    private int count;
    private bool end = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (endPanel.activeSelf)
        {
            DialogueManager.instance.Coach.SetActive(true);
        }
        if (TimerUI.instance.loosePanel.activeSelf)
        {
            DialogueManager.instance.Coach.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (end)
        {
            count++;
        }
        if (count >= 250)
        {
            count = 0;
            if (LvlChoiceManager.instance.idTableaux == 3)
            {
                endPanel.SetActive(true);
            }
            else
            {
                continuePanel.SetActive(true);
            }
        }
    }

    public void clickOnMonster()
    {
        Inventory.instance.AddSanity(Mathf.FloorToInt(TimerUI.instance.timer)+1);
        TimerUI.instance.timer = 60;
        TimerUI.instance.txtTimerUI.text = string.Format("{0:0}:{1:00}", Mathf.Floor(TimerUI.instance.timer / 60), TimerUI.instance.timer % 60);
        TimerUI.instance.enabled = false;
        MalusManage.instance.DestroyAllMalus();
        MalusManage.instance.enabled = false ;
        end = true;
        malus.SetActive(false);
        TimerUI.instance.StopAllCoroutines();
    }

    public void clickOnStart()
    {
        if(LvlChoiceManager.instance.idTableaux == 0)
        {
            LvlChoiceManager.instance.LoadPainting("tableau1");
        }
        malus.SetActive(true);
        inventory.SetActive(true);
        timer.SetActive(true);
        monster.SetActive(true);
        startPanel.SetActive(false);
        TimerUI.instance.enabled = true;
        MalusManage.instance.enabled = true;
        Time.timeScale = 1;
        end = false;
    }

    public void clickOnContinue()
    {
        if (LvlChoiceManager.instance.idTableaux < 3)
        {
            LvlChoiceManager.instance.idTableaux++;
        }
        continuePanel.SetActive(false);
        startPanel.SetActive(true);
        LvlChoiceManager.instance.LoadPainting("tableau" + LvlChoiceManager.instance.idTableaux);
        MalusManage.instance.Spawn();
        TimerUI.instance.StartCoroutine(TimerUI.instance.Timer());
    }
}
