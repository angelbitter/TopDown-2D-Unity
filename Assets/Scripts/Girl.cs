using UnityEngine;

public class Girl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (GameManager.Instance.HasLeftCave)
        {
            // If not, set a default position and rotation
            transform.position = transform.position + new Vector3(1f, 0, 0);
        }
    }

}
