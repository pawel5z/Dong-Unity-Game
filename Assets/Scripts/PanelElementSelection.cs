using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelElementSelection : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject selectedOnInput;
    public string elementsLayout;
    private bool selected = false;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetAxisRaw(elementsLayout) != 0 && !selected)
        {
            eventSystem.SetSelectedGameObject(selectedOnInput);
            selected = true;
        }
    }

    private void OnDisable()
    {
        selected = false;
    }
}
