using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPanel : MonoBehaviour
{

    List<GameObject> optionPanels;
    GameObject currentPanelOpen;

    // Use this for initialization
    void Start()
    {
        optionPanels = new List<GameObject>();
        GameObject temp;

        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            temp = this.gameObject.transform.GetChild(i).gameObject;
            temp.SetActive(false);
            optionPanels.Add(temp);
        }
    }

    public void setOptionPanel(string panelname)
    {
        GameObject temp;

        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            temp = this.gameObject.transform.GetChild(i).gameObject;
            if (temp.name == panelname)
            {
                temp.SetActive(true);
                currentPanelOpen = temp;
                return;
            }
        }
    }

    public void disableOptionPanel()
    {
        if(currentPanelOpen != null)
            currentPanelOpen.SetActive(false);
    }
}