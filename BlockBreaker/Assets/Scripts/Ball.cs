using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;
    [SerializeField] AudioClip[] ballSounds;

    float diff;
    bool hasStarted = false;

    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        diff = transform.position.y - paddle.transform.position.y;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            LockBallToPadle();
            LaunchBallOnMouseClick();
        }
    }

    private void LaunchBallOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    void LockBallToPadle()
    {
        //Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        Vector2 ballPos = new Vector2(paddle.transform.position.x, paddle.transform.position.y + diff);
        transform.position = ballPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
