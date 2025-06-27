using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Door : MonoBehaviour, IInteractable

{
    [SerializeField] private int targetSceneIndex;
    [SerializeField] private Vector3 newPlayerPosition;
    [SerializeField] private Vector2 newPlayerRotation;
    [SerializeField] private bool puertaBloqueada;
    [SerializeField] private AudioClip doorLockedSound;
    [SerializeField] private AudioClip doorEnterSound;
    [SerializeField] private AudioSource audioSource;
    private bool canInteract = true;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if (!canInteract) return;
        StartCoroutine(WaitForInteract());
        CheckAllKeys();

        if (!puertaBloqueada)
        {
            GameManager.Instance.LoadNewScene(targetSceneIndex, newPlayerPosition, newPlayerRotation);
        }
    }
    private void CheckAllKeys()
    {
        if (puertaBloqueada)
        {
            Debug.Log("Puerta bloqueada, necesitas las llaves");
            if (InventoryController.Instance.Items.Count > 3)
            {
                List<int> keyIDs = new();
                foreach (ItemData item in InventoryController.Instance.Items)
                {
                    if (item.id == 1 || item.id == 2 || item.id == 3 || item.id == 4)
                    if (item.id == 1 || item.id == 2)
                    {
                        keyIDs.Add(item.id);
                    }
                }
                if (keyIDs.Contains(1) && keyIDs.Contains(2) && keyIDs.Contains(3) && keyIDs.Contains(4))
                {
                    puertaBloqueada = false;

                    audioSource.PlayOneShot(doorEnterSound);
                    return;
                }
            }
            audioSource.PlayOneShot(doorLockedSound);
        }
        else
        {
            audioSource.PlayOneShot(doorEnterSound);
        }
    }
    IEnumerator WaitForInteract()
    {
        canInteract = false;
        yield return new WaitForSeconds(1f);
        canInteract = true;
    }
    // NO ESCALABLE, mejorar con un SO que tenga requisitos para puertas 
}
