using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Scriptable Objects/GameManager")]
public class GameManagerSO : ScriptableObject
{
    private Player player;
    private InventoryController inventory;
    public InventoryController Inventory {get => inventory;}
    private void OnEnable()
    {
        SceneManager.sceneLoaded += NewSceneLoaded;
    }
    private void NewSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        player = FindFirstObjectByType<Player>();
        inventory = FindFirstObjectByType<InventoryController>();
    }
    public void ChangePlayerState(bool state)
    {
        player.Interacting = !state;
    }
}
