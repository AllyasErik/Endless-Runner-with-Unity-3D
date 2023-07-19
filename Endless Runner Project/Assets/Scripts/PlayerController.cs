using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public float jumpForce;
    public float gravityMod;
    public static bool isGameOver = false;
    public bool isCrouching = false;
    private bool isOnGround = false;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI finalScoreText;
    public float points = 0;
    public float pointspersec = 1f;
    public GameObject gameOverUI;
    public ParticleSystem dirtEffect;
    public AudioClip crashSound, jumpSound;
    AudioSource audiosource;
    Animator anim;
    public BoxCollider boxCollider;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
        audiosource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            Debug.Log("jumping");
            isOnGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dirtEffect.Stop();
            audiosource.PlayOneShot(jumpSound);
            anim.SetTrigger("Jump_trig");
        }
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && !isCrouching && !isGameOver)
            {
                boxCollider.size = new Vector3(1, boxCollider.size.y / 2, 1);
                boxCollider.center = new Vector3(0, boxCollider.center.y / 2, 0);
                isCrouching = true;
                anim.SetBool("isCrouching", true);
            }
            if (Input.GetKeyUp(KeyCode.LeftControl) && isCrouching && !isGameOver)
            {
                boxCollider.size = new Vector3(1, boxCollider.size.y * 2, 1);
                boxCollider.center = new Vector3(0, boxCollider.center.y * 2, 0);
                anim.SetBool("isCrouching", false);
                isCrouching = false;
            }
        }
        
        if (!isGameOver)
        {
            points += pointspersec * Time.deltaTime;
            pointsText.SetText("Points: " + (int)points);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground") && !isGameOver)
        {
            Debug.Log("Landed on ground");
            isOnGround = true;
            dirtEffect.Play();
        }

        if ((collision.gameObject.CompareTag("obstacle") ||
            collision.gameObject.CompareTag("monster"))
            && !isGameOver)
        {
            finalScoreText.SetText("Your final score was: " + (int)points);
            gameOverUI.SetActive(true);
            Debug.Log("collision happaned");
            isGameOver = true;
            audiosource.PlayOneShot(crashSound);
            dirtEffect.Stop();
            anim.SetBool("isDead", true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        points = points + 10;
        pointsText.SetText("Points: " + (int)points);
    }
}
