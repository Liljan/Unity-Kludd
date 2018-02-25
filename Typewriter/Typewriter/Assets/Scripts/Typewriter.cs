using System.Collections;
using UnityEngine;

public class Typewriter : MonoBehaviour
{
    private TextMesh Text;
    private string fullText;
    private string sourceText;

    [Range(0.001f, 100.0f)]
    public float frequency = 1.0f;

    private void Awake()
    {
        Text = GetComponent<TextMesh>();
    }

    // Use this for initialization
    void Start()
    {
        fullText = Text.text;

        float time = 1.0f / frequency;

        StartCoroutine(TypewriterEffect(time));
    }

    // Update is called once per frame
    void Update()
    {

    }

    // every 2 seconds perform the print()
    private IEnumerator TypewriterEffect(float waitTime)
    {
        int size = Text.text.Length;

        for (int i = 0; i <= size; ++i)
        {
            Text.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
