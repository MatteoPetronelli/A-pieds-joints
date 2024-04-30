using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();

    public static DontDestroyOnLoadScene instance;

    void Awake()
    {
        instance = this;
        foreach (var item in objects)
        {
            DontDestroyOnLoad(item);
        }
    }

    public void RemoveFromDontDestroyOnLoad(){
        foreach (var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }
}
