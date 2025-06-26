using UnityEngine;

public class Lock : NonPersistenObject, IInteractable
{
    [SerializeField] private string lockType;
    private bool isLocked = true;

    public void Interact()
    {
        if (isLocked)
        {
            Debug.Log($"Attempting to unlock the {lockType} lock.");
            Unlock();
        }
        else
        {
            Debug.Log($"The {lockType} lock is already unlocked.");
        }
    }
    private void Unlock()
    {
        isLocked = false;
        Debug.Log($"The {lockType} lock has been unlocked.");
    }
}
