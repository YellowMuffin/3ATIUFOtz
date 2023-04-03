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
        Rigidbody2D.AddForce(movement * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            Destroy(collision.gameObject);
            score++;
            ScoreUpdate(score);
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
