using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnEnable : MonoBehaviour
{
    public EventSystem eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem.SetSelectedGameObject(gameObject);
    }
}
