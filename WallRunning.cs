using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class WallRunning : MonoBehaviour
{
    public AudioClip audioClip;
    private PlayerMovement cm;
    private Rigidbody rb;
    private bool isJumping;
    public bool isWall;
    private bool playAudio;
    private AudioSource audioSource;
    private void Start()
    {
        //Get attached components so we can interact with them in our script.
        cm = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
        audioSource =
       GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        bool jumpPressed = Input.GetButtonDown("Jump");
        float verticalAxis = Input.GetAxis("Vertical");
        //Check if the controller is grounded.
        if (cm.Grounded)
        {
            isJumping = false;
            isWall = false;
        }
        //Has the jump button been pressed.
        if (jumpPressed)
        {
            StartCoroutine(Jumping());
        }
        //If we are pushing forward, and not grounded, and touching a wall.
        if (verticalAxis > 0 && isJumping && isWall)
        {
            //We constrain the Y/Z directionto defy gravity and move off the wall.
            //But we can still run forward as we ignore the X direction.
            rb.useGravity = false;
            rb.constraints =
           RigidbodyConstraints.FreezePositionY |
           RigidbodyConstraints.FreezePositionX |
           RigidbodyConstraints.FreezeRotation;
            //We also telegraph to the player by playing a sound effect on contact.
            if (audioClip != null && playAudio == true)
            {
                audioSource.PlayOneShot(audioClip);
                //We block more audio being played while we are on the wall.
                playAudio = false;
            }
        }
        else
        {
            //We need to make sure we can playaudio again when touching the wall.
            playAudio = true;
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        //Are we touching a wall object?
        if (other.gameObject.tag == "Walls")
        {
            isWall = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        //Did we stop touching the wallobject?
        if (other.gameObject.tag != "Walls")
        {
            isWall = false;
        }
    }
    IEnumerator Jumping()
    {
        //Check for 5 frames after the jump button is pressed.
        int frameCount = 0;
        while (frameCount < 5)
        {
            frameCount++;
            //Are we airborne in those 5 frames ?
            if (!cm.Grounded)
            {
                isJumping = true;
            }
            yield return null;
        }
    }
}