using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _forceJump = 700f;
    [SerializeField] private float _gravityModifier = 2f;
    [SerializeField] private ParticleSystem _explotion;
    [SerializeField] private ParticleSystem _trail;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _crashSound;

    public bool GameOver = false;
    private bool StayInGround = true;
    private Rigidbody rbPlayer;
    private Animator PlayerAnimation;
    private AudioSource PlayerSound;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        Physics.gravity *= _gravityModifier;
        PlayerAnimation = GetComponent<Animator>();
        PlayerSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            && StayInGround && !GameOver)
        {
            rbPlayer.AddForce(Vector3.up * _forceJump, ForceMode.Impulse);
            StayInGround = false;
            PlayerAnimation.SetTrigger("Jump_trig");
            _trail.Stop();
            PlayerSound.PlayOneShot(_jumpSound, 0.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !GameOver)
        {
            StayInGround = true;
            _trail.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GameOver");
            GameOver = true;
            PlayerAnimation.SetBool("Death_b", true);
            PlayerAnimation.SetInteger("DeathType_int", 1);
            _explotion.Play();
            _trail.Stop();
            PlayerSound.PlayOneShot(_crashSound, 0.75f);
        }
    }
}
