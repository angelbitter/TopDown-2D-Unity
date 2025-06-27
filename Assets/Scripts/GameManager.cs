using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Dictionary<string, bool> NonPersistentObjects { get; private set; } = new Dictionary<string, bool>();

    public Vector3 LastSavedPosition { get; private set; } = new Vector3(0.5f, 0.5f, 0);
    public Vector2 LastSavedRotation { get; private set; } = new Vector2(0, -1);

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
    internal void LoadNewScene(int targetSceneIndex, Vector3 newPlayerPosition, Vector2 newPlayerRotation)
    {
        LastSavedPosition = newPlayerPosition;
        LastSavedRotation = newPlayerRotation;
        SceneManager.LoadScene(targetSceneIndex);
    }

    internal void PauseGame(Canvas pauseCanvas)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0f; // Se pausa el juego
        }
    }
    internal void EndGame(Canvas endCanvas)
    {
        endCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f; // Se pausa el juego
    }
}
