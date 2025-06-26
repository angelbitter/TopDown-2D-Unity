using System;
using UnityEngine;

public class NonPersistenObject : MonoBehaviour
{
    [SerializeField] protected string uniqueId;
    private void Awake()
    {
        // Ensure this object is not destroyed on scene load
        DontDestroyOnLoad(gameObject);
    }

    void OnValidate()
    {
        if (string.IsNullOrEmpty(uniqueId))
        {
            uniqueId = Guid.NewGuid().ToString();
        }
    }
}
