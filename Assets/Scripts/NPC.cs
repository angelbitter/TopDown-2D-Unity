using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private GameManagerSO gameManger;
    [SerializeField, TextArea(1, 5)] private string[] dialogues;
    [SerializeField] private float timeBetweenLetters;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private bool talking = false;
    private int currentDialogueIndex = -1;
    void Start()
    {

    }
    void Update()
    {

    }


    public void Interact()
    {
        gameManger.ChangePlayerState(false);
        dialogueBox.SetActive(true);
        if (!talking)
        {
            NextDialogue();
        }
        else
        {
            CompleteDialogue();
        }
    }
    IEnumerator WriteDialogue()
    {
        talking = true;
        dialogueText.text = "";
        char[] charsDialoge = dialogues[currentDialogueIndex].ToCharArray();
        foreach (char c in charsDialoge)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
        talking = false;
    }
    private void CompleteDialogue()
    {
        StopAllCoroutines();
        dialogueText.text = dialogues[currentDialogueIndex];
        talking = false;
    }
    private void NextDialogue()
    {
        currentDialogueIndex++;
        if (currentDialogueIndex >= dialogues.Length)
        {
            FinishDialogue();
        }
        else
        {
            StartCoroutine(WriteDialogue());
        }
    }
    private void FinishDialogue()
    {
        dialogueBox.SetActive(false);
        currentDialogueIndex = -1;
        dialogueText.text = "";
        talking = false;
        gameManger.ChangePlayerState(true);
    }
}
