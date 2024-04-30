using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public static TimerUI instance;
    public Text txtTimerUI;
    public GameObject timerUI;
    public Text timerBonusUI;
    public float timer = 60f;
    public float timerBonus;
    public GameObject loosePanel;
    private void Awake()
    {
        instance = this;
        instance.enabled = false;
    }
    void Start()
    {
        StartCoroutine(Timer());
    }
    void Update()
    {
        TimerUIRefresh();
    }
    public IEnumerator Timer()
    {
        while (timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1f);
            txtTimerUI.text = string.Format("{0:0}:{1:00}", Mathf.Floor(timer / 60), timer % 60);
        }
        if (timer <= 0) 
        {
            TimerUI.instance.enabled = false;
            loosePanel.SetActive(true);
        }
    }

    IEnumerator TimerBonus()
    {
        while (timerBonus > 0)
        {
            timerBonus--;
            yield return new WaitForSeconds(1f);
            timerBonusUI.text = string.Format("{0:0}:{1:00}", Mathf.Floor(timerBonus / 60), timerBonus % 60);
        }
        if (timerBonus <= 0)
        {
            timerBonusUI.gameObject.SetActive(false);
            StartCoroutine(Timer());
            MalusManage.instance.enabled = true;
        }
    }

    public void AddTime(int time)
    {
        timer += time;
    }

    public void RemoveTime(int time)
    {
        timer -= time;
    }

    public void FreezeTime(int freezeTime)
    {
        timerBonusUI.gameObject.SetActive(true);
        MalusManage.instance.enabled = false;
        timerBonus += freezeTime + 1;
        StopAllCoroutines();
        StartCoroutine(TimerBonus());
    }

    private void TimerUIRefresh()
    {
        if (timer <= 60 && timer >= 30 && txtTimerUI.color != new Color(74 / 255f, 243 / 255f, 103 / 255f))
        {
            txtTimerUI.color = new Color(74 / 255f, 243 / 255f, 103 / 255f);
        }
        if (timer <= 29 && timer > 10 && txtTimerUI.color != new Color(204 / 255f, 93 / 255f, 47 / 255f))
        {
            txtTimerUI.color = new Color(204 / 255f, 93 / 255f, 47 / 255f);
        }
        if (timer <= 9 && txtTimerUI.color != new Color(130 / 255f, 38 / 255f, 44 / 255f))
        {
            txtTimerUI.color = new Color(130 / 255f, 38 / 255f, 44 / 255f);
        }
    }
}
