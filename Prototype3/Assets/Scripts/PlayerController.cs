
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forceSpeed = 15f;
    public bool fastSpeed = false;
    private float doubleJumpForceSpeed = 7f;
    public float gravityModifier;

    private Rigidbody playerRB;
    private Animator playerAnim;
    private AudioSource audioSource;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpClip;
    public AudioClip crushClip;


    [SerializeField] private bool isOnGround = true;
    [SerializeField] private bool doubleJumpUsed = false;
     public bool gameOver = false;

    public GameObject gameOverUI;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        forceSpeed = 15f;
        Physics.gravity *= gravityModifier;

    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * forceSpeed, ForceMode.Impulse);
            isOnGround = false; // yer temasý false
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            audioSource.PlayOneShot(jumpClip, 0.7f);
            doubleJumpUsed = false;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && !doubleJumpUsed && !isOnGround)
        {
            doubleJumpUsed = true;
            playerRB.AddForce(Vector3.up * doubleJumpForceSpeed, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            audioSource.PlayOneShot(jumpClip, 0.7f);
           
        }
        if (Input.GetKey(KeyCode.LeftShift)&&!gameOver)
        {
            fastSpeed = true;
            playerAnim.SetFloat("Speed_Multiplier", 1.5f);
        }
        else if (fastSpeed)
        {
            fastSpeed = false;
            playerAnim.SetFloat("Speed_Multiplier", 1.0f);
        }





    }
    
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;


            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!!");
            
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dirtParticle.Stop();
            explosionParticle.Play();
            audioSource.PlayOneShot(crushClip);
            gameOverUI.SetActive(true);
            
        }
        else
        {
            gameOver = false;
            
        }


    }
}
