using System.Collections;
using UnityEngine;

public class pointerColl : MonoBehaviour
{
    public static pointerColl instace;
    public bool boolDestroy;
    private void Awake()
    {
        instace = this;
    }
    private void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        transform.position = mousePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!boolDestroy) 
        {
            collision.gameObject.tag = "return";
        }
        else
        {
            collision.gameObject.tag = "toDestroy";
        }
    }

    public void UpgradeZone(int ammount)
    {
        GetComponent<CircleCollider2D>().radius += ammount;
    }
}
