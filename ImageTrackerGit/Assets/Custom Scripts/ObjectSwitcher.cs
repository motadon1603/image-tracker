using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSwitcher : MonoBehaviour
{
    private List<GameObject> models = new List<GameObject>();
    public Button changeObjectButton;
    private int switchCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //parent = GameObject.Find("ControllerObject").transform;
        //Debug.Log("Model Name: " + parent.name);
        changeObjectButton.enabled = false;
        changeObjectButton.onClick.AddListener(switchObject);
    }

    void populateModelsArray(Transform parent)
    {
        Debug.Log("Populating Models Array for " + parent.childCount + " children...");
        foreach(Transform child in parent)
        {
            GameObject model = child.gameObject;
            models.Add(model);
        }
        changeObjectButton.GetComponent<Image>().color = Color.green;
        changeObjectButton.enabled = true;
    }

    private void switchObject()
    {
        Debug.Log("Switch Count: " + switchCount);
        var pos = 0;
        Debug.Log("Switching Object...");
        if(switchCount == 0)
        {
            pos = switchCount;
            switchCount++;
        }
        else
        {
            if(switchCount >= models.Count)
            {
                models[models.Count - 1].SetActive(false);
                switchCount = 0;
                pos = switchCount;
            }
            else
            {              
                pos = switchCount;
                models[pos - 1].SetActive(false);
            }
            switchCount++;
        }
        models[pos].SetActive(true);
    }
}
