using Unity.VisualScripting;
using UnityEngine;

public class InstructionUI : MonoBehaviour
{
    public GameObject InstructionPanel;
    private bool isOn = false;

    public void TogglePanel()
    {
        if (isOn == false) 
        {
            PanelOn();
        }
        else 
            PanelOff();
    }

    public void PanelOn()
    {
        InstructionPanel.SetActive(true);
        isOn = true;
    }

    public void PanelOff()
    {
        InstructionPanel.SetActive(false);
        isOn = false;
    }
}
