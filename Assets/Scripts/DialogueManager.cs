using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// to update the UI elements
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;


    public Animator animator;
    private Queue<string> sentences;     //FIFO, better than a list to track sentences
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        
    }

   public void StartDialogue (Dialogue dialogue)
   {
       //Debug.Log("Starting conversation with " + dialogue.name);

       animator.SetBool("IsOpen", true);

       nameText.text = dialogue.name;

       sentences.Clear();       // clears teh log

       //loop through the dialogue and add them to a queu
       foreach (string sentence in dialogue.sentences)
       {
           sentences.Enqueue(sentence);     //pulls the text items in teh queue
       }

        DispalyNextSentence();
   }

   public void DispalyNextSentence()
   {
       if (sentences.Count == 0)
       {
           EndDialogue();
           return;
       }

       string sentence = sentences.Dequeue();

       //statement below just prints the whole text at once, for flavor just individually
       // dialogueText.text = sentence;

        // want to check if it has stopped animating before new text
       StopAllCoroutines();
       StartCoroutine(TypeSentence(sentence));
   }

    //prints letters one by one
   IEnumerator TypeSentence (string sentence)
   {
       dialogueText.text = "";
       foreach (char letter in sentence.ToCharArray())
       {
           // throws characters from the text field into array
           dialogueText.text += letter;
           yield return null;
       }
   }

   void EndDialogue()
   {
       Debug.Log("End Convo");
       animator.SetBool("IsOpen", false);
   }
}
