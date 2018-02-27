using System.Collections;
using UnityEngine;

public class Typewriter : MonoBehaviour
{
    private TextMesh _Text;
    private string fullText;

    private bool _isAnimating;

    [Range(0.001f, 100.0f)]
    public float frequency = 1.0f;

    private IEnumerator _typewriterCoroutine;
    private IEnumerator _fastTypewriterCoroutine;
    private int _currentIndex = 0;

    private void Awake()
    {
        _Text = GetComponent<TextMesh>();
    }

    // Use this for initialization
    void Start()
    {
        fullText = _Text.text;

        float time = 1.0f / frequency;
        _isAnimating = false;

        _typewriterCoroutine = TypewriterEffect(time);
        _fastTypewriterCoroutine = TypewriterEffect(0.005f * time);

        _currentIndex = 0;
        StartCoroutine(_typewriterCoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetButtonDown("Skip") )
        {
            if(_isAnimating)
            {
                StopCoroutine(_typewriterCoroutine);
                StartCoroutine(_fastTypewriterCoroutine);
            }
        }
    }

    // every 2 seconds perform the print()
    private IEnumerator TypewriterEffect(float waitTime)
    {
        int size = fullText.Length;

        while (_currentIndex <= size )
        {
            _Text.text = fullText.Substring(0, _currentIndex);
            _isAnimating = true;
            ++_currentIndex;

            yield return new WaitForSeconds(waitTime);
        }

        _isAnimating = false;
        _currentIndex = 0;
    }

    public bool IsAnimating()
    { return _isAnimating; }
}
