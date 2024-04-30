using UnityEngine;
using UnityEngine.UI;

public class ManageMonster : MonoBehaviour
{
    public Sprite[] MonsterImg = new Sprite[2];
    public static ManageMonster instance;
    public GameObject hitbox;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        Monster();
    }

    public void Monster()
    {
        if (LvlChoiceManager.instance.idTableaux == 1 && transform.position != new Vector3(756, -294, 0))
        {
            transform.localPosition = new Vector3(756, -294, 0);
            GetComponent<Image>().sprite = MonsterImg[0];
            transform.eulerAngles = new Vector3(0, 0, 0);
            GetComponent<RectTransform>().sizeDelta = new Vector2(0.0197f, 0.0301f);
            hitbox.GetComponent<RectTransform>().localPosition = Vector3.zero;
            hitbox.GetComponent<RectTransform>().sizeDelta = new Vector2(0.008f, 0.027f);

        }
        if (LvlChoiceManager.instance.idTableaux == 2 && transform.position != new Vector3(730, 300, 0))
        {

            transform.localPosition = new Vector3(730, 300, 0);
            GetComponent<Image>().sprite = MonsterImg[1];
            transform.eulerAngles = new Vector3(0, 0, 2.88f);
            GetComponent<RectTransform>().sizeDelta = new Vector2(0.0634f, 0.0704f);
            hitbox.GetComponent<RectTransform>().localPosition = new Vector3(0.0158f, 0.0237f, 0);
            hitbox.GetComponent<RectTransform>().sizeDelta = new Vector2(0.014f, 0.017f);
        }
        else if (LvlChoiceManager.instance.idTableaux == 3 && transform.position != new Vector3(-452, -291, 0))
        {
            transform.localPosition = new Vector3(-452, -291, 0);
            gameObject.GetComponent<Image>().sprite = MonsterImg[2];
            transform.eulerAngles = new Vector3(0, 0, 0);
            GetComponent<RectTransform>().sizeDelta = new Vector2(0.0211f, 0.0234f);
            hitbox.GetComponent<RectTransform>().localPosition = Vector3.zero;
            hitbox.GetComponent<RectTransform>().sizeDelta = new Vector2(0.014f, 0.017f);
        }
    }
}
