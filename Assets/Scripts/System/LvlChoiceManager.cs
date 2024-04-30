using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlChoiceManager : MonoBehaviour
{
    public static LvlChoiceManager instance;
    public int idTableaux = 0;
    public GameObject[] buttons = new GameObject[4];
    public Image BackgroundUI;
    public Sprite[] Backgrounds = new Sprite[4];
    public GameObject[] hitboxes = new GameObject[2];

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (idTableaux != 0)
        {
            SetBackground(idTableaux - 1);
            if (idTableaux == 2)
            {
                hitboxes[0].SetActive(true);
                hitboxes[1].SetActive(true);
            }
            if (idTableaux == 3)
            {
                hitboxes[0].SetActive(false);
                hitboxes[1].SetActive(false);
            }
        }
        Tableaux();
    }

    public void Tableaux()
    {
        for (int i = 0; i < idTableaux; i++)
        {
            buttons[i].SetActive(true);
        }
    }

    public void LoadPainting(string tableau)
    {
        SceneManager.LoadScene(tableau);
        idTableaux = int.Parse(tableau[(tableau.Length - 1)..]);
        
    }

    public void SetBackground(int tab)
    {
        BackgroundUI.sprite = Backgrounds[tab];
    }
}