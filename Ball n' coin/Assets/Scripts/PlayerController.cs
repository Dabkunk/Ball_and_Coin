using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed;

    Rigidbody rb;

    float xInput;
    float yInput;

    int score = 0;
    public int winScore;

    public GameObject winText;

    private AudioSource audioSource;
    public AudioClip CoinCollected;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        winText.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (!winText.activeInHierarchy)
        {
            if (transform.position.y < -5f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        rb.AddForce(xInput * speed, 0, yInput * speed);


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            audioSource.clip = CoinCollected;
            audioSource.Play();

            score++;

            if (score >= winScore) 
            { 
                winText.SetActive(true);
            
            
            }
        }
    }
}
