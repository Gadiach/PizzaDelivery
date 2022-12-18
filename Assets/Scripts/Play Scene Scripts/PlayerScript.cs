using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Text scoreText; 
    [SerializeField] private FixedJoystick joystick;

    private Rigidbody rb;
    private Animator animator;    

    public float highSpeed;
    public float lowSpeed;
    public float normalSpeed;
    private int score;
    
    public static bool isTriggered = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        StartCoroutine("ScoreCount");
    }

    private void FixedUpdate()
    {
        if (joystick.Horizontal > 0f)
        {
            rb.velocity = new Vector3(highSpeed, 0f, 0f);            
        }
        else if (joystick.Horizontal < 0f)
        {
            rb.velocity = new Vector3(lowSpeed, 0f, 0f);            
        }
        else
        {
            rb.velocity = new Vector3(normalSpeed, 0f, 0f);           
        }
    }

    private void Update()
    {        
        scoreText.text = score.ToString();        
       
        if (isTriggered == false)
        {
            if (joystick.Horizontal > 0f)
            {
                animator.Play("RidingFast");
            }
            else if (joystick.Horizontal < 0f)
            {
                animator.Play("RidingSlow");
            }
            else
            {
                animator.Play("Riding");
            }
        }
        else if (isTriggered == true)
        {
            animator.Play("PizzaDrop");            
        }       
    }

    private IEnumerator ScoreCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            score++;
        }
    }  
}
