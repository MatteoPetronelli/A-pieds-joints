using UnityEngine;

public class Return: MonoBehaviour
{
    public static Return instance;
    public int id;
    public Vector2 pos;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        DestroyTime();
        ToBase();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.tag = "return";
    }

    public void ToBase()
    {
        if (tag == "return")
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos.x, pos.y, 0), Time.deltaTime * 10);
        }

        if (transform.position.x == pos.x &&  transform.position.y == pos.y)
        {
            tag = "Untagged";
        }
    }

    public void DestroyTime()
    {
        if (tag == "toDestroy")
        {
            Destroy(gameObject);
        }
    }
}
