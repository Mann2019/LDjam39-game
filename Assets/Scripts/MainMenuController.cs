using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public GameObject[] UIPanels;
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
            for (int i=0;i<UIPanels.Length;i++)
            {
                if(UIPanels[i].activeInHierarchy)
                {
                    UIPanels[i].SetActive(false);
                    AddInteraction();
                }
                else
                {
                    UIPanels[UIPanels.Length-1].SetActive(true);
                }
            }
        }
    }
}
