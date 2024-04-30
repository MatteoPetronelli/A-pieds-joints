using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MalusManage : MonoBehaviour
{
    public static MalusManage instance;
    public Sprite[] sprites = new Sprite[4];
    public List<GameObject> malusList = new List<GameObject>();
    private int count;
    private int idSprite;
    private bool isMalus;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Spawn();
        instance.enabled = false;
    }

    private void FixedUpdate()
    {
        count++;
        if (count == 250)
        {
            DestroyMalus();
            count = 0;
        }
    }

    public void Spawn()
    {
        for (int i = 0; i < 400; i++)
        {
            if (idSprite == 3) idSprite = 0;
            GameObject malus = new GameObject();
            GameObject hitbox = new GameObject();
            GameObject text = new GameObject();
            malus.name = "malus " + i.ToString();
            hitbox.name = "hitbox";
            text.name = "text";
            malus.transform.SetParent(transform);
            hitbox.transform.SetParent(malus.transform);
            text.transform.SetParent(hitbox.transform);
            malus.AddComponent<Image>();
            malus.AddComponent<Rigidbody2D>();
            malus.AddComponent<CircleCollider2D>();
            malus.AddComponent<Return>();
            hitbox.AddComponent<RectTransform>();
            hitbox.AddComponent<Button>();
            text.AddComponent<Text>();

            Image image = malus.GetComponent<Image>();
            image.sprite = sprites[idSprite];
            RectTransform rect = malus.GetComponent<RectTransform>();
            rect.position = new Vector3(UnityEngine.Random.Range(100, 1860), UnityEngine.Random.Range(30, 1000), 0);
            idSprite++;

            Button button = malus.GetComponentInChildren<Button>();
            button.transition = Selectable.Transition.None;
            button.onClick.AddListener(delegate() { Malus(); });
            malusList.Add(malus);

            Rigidbody2D rigidbody = malus.GetComponent<Rigidbody2D>();
            rigidbody.gravityScale = 0;
            rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

            CircleCollider2D coll = malus.GetComponent<CircleCollider2D>();
            coll.radius = 30;

            Return ret = malus.GetComponent<Return>();
            ret.id = i;
            ret.pos.x = rect.position.x;
            ret.pos.y = rect.position.y;

            hitbox.GetComponent<RectTransform>().sizeDelta = new Vector2(33, 41);
        }
    }

    public void DestroyMalus()
    {
        if (LvlChoiceManager.instance.idTableaux < 3) {
            for (int i = 0; i < 7; i++)
            {
                Destroy(malusList[i]);
                malusList.Remove(malusList[i]);
            }
        }
        if (LvlChoiceManager.instance.idTableaux == 3)
        {
            for (int i = 0; i < 20; i++)
            {
                Destroy(malusList[i]);
                malusList.Remove(malusList[i]);
            }
        }
    }

    public void DestroyAllMalus()
    {
        do
        {
            isMalus = false;
            for (int i = 0; i < malusList.Count; i++)
            {
                Destroy(malusList[i]);
                malusList.Remove(malusList[i]);
                isMalus = true;
                break;
            }
        }

        while (isMalus);
    }

    public void Malus()
    {
        TimerUI.instance.timer -= 10;
    }
}
