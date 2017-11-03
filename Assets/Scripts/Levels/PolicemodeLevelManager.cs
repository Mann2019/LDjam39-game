using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PolicemodeLevelManager : MonoBehaviour {

    public Button[] butts;

    public void RemoveInteraction()
    {
        for (int i = 0; i < butts.Length; i++)
        {
            butts[i].interactable = false;
        }
    }

    public void AddInteraction()
    {
        for (int i = 0; i < butts.Length; i++)
        {
            butts[i].interactable = true;
        }
    }
}
