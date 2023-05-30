using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    public float speed;
    int score;
    public Text scoreText;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        score = 0;
       AudioManager.instance.PlayMusic("Podk³ad");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if (movement.x > 0 || movement.x <0 || movement.y > 0 || movement.y <0)
        {
            AudioManager.instance.PlaySFX("Latanie");
        }
        Rigidbody2D.AddForce(movement * speed);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            AudioManager.instance.PlaySFX("Pickup");
            Destroy(collision.gameObject);
            score++;
            ScoreUpdate(score);
        }
        if (collision.gameObject.CompareTag("Background"))
        {
            AudioManager.instance.PlaySFX("Uderzenie");
        }
    }
    void ScoreUpdate(int score)
    {
        scoreText.text = $"Score: {score.ToString()}";
        if (score >= 5)
        {
            winText.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
        }

    }
}
