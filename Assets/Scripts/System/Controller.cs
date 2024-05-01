using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    public GameObject startPanel;
    public GameObject continuePanel;
    public GameObject endPanel;
    public GameObject paintingsButton;
    public GameObject MonsterButton;    
    public GameObject malus;
    public GameObject inventory;
    public GameObject timer;
    public GameObject monster;
    public GameObject starting;
    public Text startText;
    private int countEnd;
    private bool end;
    private int countStart;
    private bool start;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (LvlChoiceManager.instance.idTableaux == 0 ) paintingsButton.SetActive( false ); 
        else paintingsButton.SetActive( true );
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
        Starting();
        Ending();
    }

    public void clickOnMonster()
    {
        MonsterButton.SetActive(false);
        Inventory.instance.AddSanity(Mathf.FloorToInt(TimerUI.instance.timer)+1);
        TimerUI.instance.timer = 60;
        TimerUI.instance.txtTimerUI.text = string.Format("{0:0}:{1:00}", Mathf.Floor(TimerUI.instance.timer / 60), TimerUI.instance.timer % 60);
        TimerUI.instance.enabled = false;
        timer.SetActive(false);
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
        monster.SetActive(true);
        startPanel.SetActive(false);
        starting.SetActive(true);
        MalusManage.instance.enabled = true;
        start = true;
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
    }

    private void Starting()
    {
        if (start)
        {
            countStart++;
        }
        if (countStart >= 125)
        {
            countStart = 0;
            start = false;
            starting.SetActive(false);
            MonsterButton.SetActive(true);
            TimerUI.instance.enabled = true;
            TimerUI.instance.StartCoroutine(TimerUI.instance.Timer());
            timer.SetActive(true);
        }
    }

    private void Ending()
    {
        if (LvlChoiceManager.instance.idTableaux != 1 && LvlChoiceManager.instance.idTableaux != 0)
        {
            startText.text = "The monster has changed form !!";
        }
        if (end)
        {
            countEnd++;
        }
        if (countEnd >= 250)
        {
            countEnd = 0;
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
}
