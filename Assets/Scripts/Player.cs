using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;//1.769122
    private int health = 5;
    public bool died = false;
    public ParticleSystem blood;
    
    public bool touched;
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;
    public float SWIPE_THRESHOLD = 20f;
    private float distToGround;
    private CapsuleCollider runnerCollider;
    public Text lifeText;
    public ParticleSystem spellImapct;
    public ParticleSystem healthParticle;
    public GameObject sheildParticle;
    public bool sheildOn = false;
    public GameController gameController;
    public AudioSource[] playerAudio;

    // Update is called once per frame
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        runnerCollider = GetComponent<CapsuleCollider>();
        distToGround = runnerCollider.bounds.min.y;
        sheildParticle.SetActive(false);
        playerAudio[0].Play();
    }
    void Update()
    {
      
       

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
                touched = true;
            }

            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }

            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                touched = false;
            }
        }
    }

    void checkSwipe()
    {
        //Check if Vertical swipe
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
    
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                OnSwipeUp();
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
         
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                OnSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {
                OnSwipeLeft();
            }
            fingerUp = fingerDown;
        }

        //No Movement at-all
        else
        {
            //Debug.Log("No Swipe!");
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    //////////////////////////////////CALLBACK FUNCTIONS/////////////////////////////
    void OnSwipeUp()
    {
        if (touched && IsGrounded())
        {
          
            rb.AddForce(transform.up * 200f);
            anim.Play("jump");
            touched = false;
        }
       
    }

    void OnSwipeDown()
    {
        if (touched && IsGrounded())
        {
            runnerCollider.height = 0.76f;
            runnerCollider.center = new Vector3(0,0.39f,0);
            anim.Play("slide");
            StartCoroutine(waitforSecond());
            touched = false;
        }
   
    }

    void OnSwipeLeft()
    {
      
        if (transform.position.x > -0.1 && transform.position.x < 0.1 && touched)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-0.82f, transform.position.y, transform.position.z), 50);
            touched = false;
        }
        else if(transform.position.x == 0.82f && touched)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), 50);
            touched = false;
        }
    }

    void OnSwipeRight()
    {
       
        if (transform.position.x == -.82f && touched)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), 50);
            touched = false;
        }
        else if(transform.position.x > -0.1 && transform.position.x < 0.1 && touched)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0.82f, transform.position.y, transform.position.z), 50);
            touched = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Blocks" || other.gameObject.tag == "Enemy")
        {
            if (!gameController.sheildActiveTime)
            {
                health -= 1;
                playerAudio[2].Play();
                CameraShaker.Instance.ShakeOnce(2f, 5f, .1f, .5f);
                blood.Play();
                checkHealth();
            }
           
    

        }

        if (other.gameObject.tag == "Spell")
        {
            if (!gameController.sheildActiveTime)
            {
                health -= 1;
                playerAudio[3].Play();
                spellImapct.Play();
                other.gameObject.SetActive(false);
                checkHealth();
            }

        }

        if (other.gameObject.tag == "Health")
        {
            if (health<5)
            {

                health += 1;
                playerAudio[1].Play();
                healthParticle.Play();
                checkHealth();
            }
                other.gameObject.SetActive(false);

        }

        if (other.gameObject.tag == "Sheild")
        {
            playerAudio[4].Play();
            sheildOn = true;
            other.gameObject.SetActive(false);
        }


    }

    private void checkHealth()
    {
        lifeText.text = health.ToString();
        if (health == 0)
        {
            
            //player die
            died = true;
            playerAudio[0].Stop();
            anim.Play("death");
            lifeText.text = "0";
        }
    }


    public bool IsGrounded(){

        return Physics.Raycast(transform.position, -Vector3.up, distToGround);
 }

    IEnumerator waitforSecond()
    {

        yield return new WaitForSeconds(1.15f);
        runnerCollider.height = 1.769122f;
        runnerCollider.center = new Vector3(0, 0.876738f, 0);
    }
}
