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
    private string currentFullText = "";
    private bool isTyping = false;

    [System.Serializable]
    public class DialogueLine
    {
        public string characterName;
        public Sprite characterSprite;
        [TextArea(2, 5)]
        public string text;
    }

    void Awake()
    {
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (!dialoguePanel.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                // Si está escribiendo, mostrar toda la línea de golpe
                StopCoroutine(typingCoroutine);
                dialogueText.text = currentFullText;
                isTyping = false;
            }
            else
            {
                DisplayNextLine();
            }
        }
    }

    public void StartDialogue(DialogueLine[] lines)
    {
        if (lines == null || lines.Length == 0)
        {
            Debug.LogWarning("No hay líneas de diálogo para mostrar.");
            return;
        }

        Time.timeScale = 0f;
        dialoguePanel.SetActive(true);

        dialogueQueue.Clear();

        foreach (DialogueLine line in lines)
        {
            dialogueQueue.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine line = dialogueQueue.Dequeue();

        nameText.text = line.characterName;
        characterImage.sprite = line.characterSprite;
        currentFullText = line.text;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeSentence(currentFullText));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in sentence)
        {
            dialogueText.text += c;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }

        isTyping = false;
    }

    void EndDialogue()
    {
        Time.timeScale = 1f;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        nameText.text = "";
        characterImage.sprite = null;
    }

    public bool IsDialogoActivo()
    {
        return dialoguePanel.activeSelf && (isTyping || dialogueQueue.Count > 0);
    }

    public void ForzarCierre()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        EndDialogue();
    }
}
