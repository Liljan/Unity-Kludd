using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedIcon : MonoBehaviour {

    private Animator animator;
    public Typewriter Dialogue;
    public string animationName = "";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool isAnimating = Dialogue.IsAnimating();
        animator.SetBool(animationName, isAnimating);
	}
}
