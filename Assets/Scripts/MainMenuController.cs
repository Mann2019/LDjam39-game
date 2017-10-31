using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public GameObject QuitPanel;
    public Button[] butts;

    public void RemoveInteraction()
    {
        for(int i=0; i<butts.Length; i++)
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

	public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(QuitPanel.activeInHierarchy)
            {
                QuitPanel.SetActive(false);
                AddInteraction();
            }
            else
            {
                QuitPanel.SetActive(true);
            }
        }
    }
}
