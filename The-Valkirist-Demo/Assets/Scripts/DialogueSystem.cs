using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [Header("Referencias UI")]
    public GameObject dialoguePanel;
    public Image characterImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    [Header("Configuración")]
    public float typingSpeed = 0.03f;

    private Queue<DialogueLine> dialogueQueue = new Queue<DialogueLine>();
    private Coroutine typingCoroutine;
    private bool waitingToClose = false;


    [System.Serializable]
    public class DialogueLine
    {
        public string characterName;
        public Sprite characterSprite;
        [TextArea(2, 5)]
        public string text;
    }


    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (!dialoguePanel.activeSelf) return;

        if (waitingToClose && Input.GetKeyDown(KeyCode.Space))
        {
            EndDialogue();
            waitingToClose = false;
        }
        else if (!waitingToClose && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextLine();
        }
    }

    public void StartDialogue(DialogueLine[] lines)
    {
        Time.timeScale = 0f; // Pausar el juego

        dialogueQueue.Clear();
        foreach (DialogueLine line in lines)
        {
            dialogueQueue.Enqueue(line);
        }

        dialoguePanel.SetActive(true);
        waitingToClose = false;
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        if (dialogueQueue.Count == 0)
        {
            waitingToClose = true;
            return;
        }

        DialogueLine line = dialogueQueue.Dequeue();

        nameText.text = line.characterName;
        characterImage.sprite = line.characterSprite;

        typingCoroutine = StartCoroutine(TypeSentence(line.text));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed); // ⏱ respetar pausa con Time.timeScale = 0
        }
        typingCoroutine = null;
    }

    void EndDialogue()
    {
        Time.timeScale = 1f; // Reanudar el juego

        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        nameText.text = "";
        characterImage.sprite = null;
    }
    public bool IsDialogoActivo()
{
    return dialoguePanel.activeSelf && (dialogueQueue.Count > 0 || typingCoroutine != null || waitingToClose);
}

public void ForzarCierre()
{
    if (typingCoroutine != null)
    {
        StopCoroutine(typingCoroutine);
        typingCoroutine = null;
    }

    EndDialogue();
}

}
