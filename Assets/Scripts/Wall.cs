using UnityEngine;

public class Wall : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Activa los interruptores para abrirte paso");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
