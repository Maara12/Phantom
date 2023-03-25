using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float runSpeed = 5f;
    [SerializeField]
    private Collider2D jumpCheckCollider;

    Animator charAnimator;
    bool canJump = false;
    bool canRun = false;
    float horizontalInput;
    float flipScale = 1;

    enum CharStates
    {
        idle,
        run,
        jump
    }

    Rigidbody2D rb2d;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        charAnimator = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) &&
            !charAnimator.GetBool("isJump"))
        {
            canJump = true;
        }

        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0)
        {
            FlipCharacter();
            canRun = true;

        }
        else
        {
            canRun = false;
            charAnimator.SetBool("canCharacterRun", false);
        }

    }

    private void FlipCharacter()
    {
        if (horizontalInput > 0)
        {
            if(gameObject.transform.localScale.x < 0)
            {
                gameObject.transform.localScale = new Vector3(x:1, y: gameObject.transform.localScale.y,
               z: gameObject.transform.localScale.z);
                Debug.Log("Flipped Right");
            }
           
        }
        else
        {
            if (gameObject.transform.localScale.x > 0)
            {
                gameObject.transform.localScale = new Vector3(x: - 1, 
                y: gameObject.transform.localScale.y,
                z: gameObject.transform.localScale.z);
                Debug.Log("Flipped Left");
            }
                
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Jumpable" )
        {
            charAnimator.SetBool("isJump", false);
            Debug.Log(other.name);
        }
        
    }

    private void FixedUpdate()
    {
        if(canJump)
        {
            Jump();
            
        }
        
        if(canRun)
        {
            Run();
            
        }
        
    }

    void Run()
    {
        
        rb2d.velocity = new Vector2(x: horizontalInput * runSpeed,y: rb2d.velocity.y);
        charAnimator.SetBool("canCharacterRun", true);
        if(charAnimator.GetBool("isJump"))
        {
            charAnimator.SetBool("canCharacterRun", false);
        }

    }

    void Jump()
    {
        //charAnimator.Play("Character_JUMP_Animation");
        charAnimator.SetBool("isJump", true);
        rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        
        charAnimator.SetBool("canCharacterRun", false);
        canJump = false;
        
       
    }

    void Dash()
    {
       
    }

}
