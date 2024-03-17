using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float JumpForce = 6.0f;
    public float hýz = 3.0f;
    private float MoveDirections;

    private bool jump;
    private bool grounded = true;
    private bool moving;
    private Rigidbody2D rb2;
    private SpriteRenderer spr;
    private Animator _anim;
    private AudioSource _audioSource;
    private bool isPlayingSound = false;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (rb2.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        rb2.velocity = new Vector2(hýz * MoveDirections, rb2.velocity.y);
        if (jump == true)
        {
            rb2.velocity = new Vector2(rb2.velocity.x, JumpForce);
            jump = false;
        }
    }

    private void Update()
    {
        // Karakter hareket ederken veya zýplarken sese izin ver
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W)) && grounded)
        {
            if (!isPlayingSound)
            {
                _audioSource.Play();
                isPlayingSound = true;
            }
        }
        else
        {
            // Karakter hareket etmiyorsa veya zýplamýyorsa sesi durdur
            _audioSource.Stop();
            isPlayingSound = false;
        }

        if (grounded && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                MoveDirections = -1.0f;
                spr.flipX = true;
                _anim.SetFloat("hýz", hýz);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                MoveDirections = 1.0f;
                spr.flipX = false;
                _anim.SetFloat("hýz", hýz);
            }

        }
        else if (grounded)
        {
            MoveDirections = 0.0f;
            _anim.SetFloat("hýz", 0.0f);
        }
        if (grounded && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            _anim.SetTrigger("jump");
            _anim.SetBool("jump", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            _anim.SetBool("grounded", true);
            grounded = true;
        }

    }
}
