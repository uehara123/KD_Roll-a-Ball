using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorController : MonoBehaviour
{
    public void ButtonHide(string btn)
    {
        GameObject button = GameObject.Find(btn);
        button.GetComponent<Image>().color = new Color(50f/255f, 40f/255f, 40f/255f, 140f/255f);
    }

    public void ButtonAppear(string btn)
    {
        GameObject button2 = GameObject.Find(btn);
        button2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
    }
}
