using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private WallController controller;
    private bool isActive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActive)
        {
            isActive = true;
            controller.SwitchActivated();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (isActive)
        {
            isActive = false;
            controller.SwitchDeactivated();
        }
    }
}
