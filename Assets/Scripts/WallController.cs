using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] private GameObject wallObject;
    [SerializeField] private int requiredSwitches = 1;
    private int activeSwitches = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (wallObject != null)
        {
            wallObject.SetActive(true);
        }
    }

    public void SwitchActivated()
    {
        activeSwitches++;
        UpdateWallState();
    }

    public void SwitchDeactivated()
    {
        activeSwitches = Mathf.Max(0, activeSwitches - 1);
        UpdateWallState();
    }

    private void UpdateWallState()
    {
        if (wallObject != null)
        {
            wallObject.SetActive(activeSwitches < requiredSwitches);
        }
    }
}
