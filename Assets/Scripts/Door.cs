using UnityEngine;

public class Door : MonoBehaviour, IInteractable

{
    [SerializeField] private int targetSceneIndex;
    [SerializeField] private Vector3 newPlayerPosition;
    [SerializeField] private Vector2 newPlayerRotation;
    [SerializeField] private bool puertaBloqueada;

    public void Interact()
    {
        if (!puertaBloqueada)
        {
            GameManager.Instance.LoadNewScene(targetSceneIndex, newPlayerPosition, newPlayerRotation);
        }
    }
}
