using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Drive : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public int score = 0;
    public float speed = 3.0F;
    public float rotationSpeed = 200.0F;
    public TextMeshProUGUI WinnerText;
    public bool gameover = false;
    public Button restartButton;
    private MoveLocal playerScript;
    public bool gameover2 = false;
    public Button restartButton2;
    public TextMeshProUGUI gameoverText2;
    public ParticleSystem ExplosionPlayer;


    void Start()
    {
        updateScore(0);
        playerScript = GameObject.Find("Spongebob_Cute").GetComponent<MoveLocal>();
    }
    void Update()
    {
        if (!gameover || !gameover2)
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }
        if (score == 7)
        {
            gameover = true;
            gameover2 = true;
            GameOverrrr();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bottle"))
        {
            Destroy(other.gameObject);
            updateScore(1);
        }
        if (other.gameObject.CompareTag("spongebob") && !gameover && !gameover2)
        {
            gameover = true;
            gameover2 = true;
            ExplosionPlayer.Play();
            GameOver2();
        }
    }
    public void updateScore(int scoreVal)
    {
        score += scoreVal;
        scoreText.text = "Score : " + score;
    }
    public void GameOverrrr()
    {
        WinnerText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        // playerScript.gameover2 = true;
        // gameover = false;
    }

    public void GameOver2()
    {
        gameoverText2.gameObject.SetActive(true);
        restartButton2.gameObject.SetActive(true);
        // playerScript.gameover = true;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}