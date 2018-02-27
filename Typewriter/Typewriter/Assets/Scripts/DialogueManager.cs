using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text headerText;
    public Text bodyText;

    [Range(0.001f, 100.0f)]
    public float typeSpeed = 1.0f;

    private Queue<string> sentences;
    public Animator animator;

    // Use this for initialization
    void Start () {
        sentences = new Queue<string>();

        animator.SetBool("isOpen", false);
	}

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        headerText.text = dialogue.name;

        for (int i = 0; i < dialogue.sentenses.Length; i++)
        {
            sentences.Enqueue(dialogue.sentenses[i]);
        }

        animator.SetBool("isOpen", true);
        DisplayNextSentense();
    }

    public void DisplayNextSentense()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        bodyText.text = sentence;

        StopAllCoroutines();
        StartCoroutine(TypewriterSentence(sentence, 1.0f / typeSpeed));
    }

    private IEnumerator TypewriterSentence(string sentence, float time)
    {
        bodyText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            bodyText.text += letter;
            yield return new WaitForSeconds(time);
        }
    }

    private void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}
