using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Drive : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI NextlevelText;
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
    public Rigidbody playerrigid;
    public static int socreValue; 
    public static int level = 1;

    void Start()
    {
        updateScore(0);
        playerScript = GameObject.Find("Spongebob_Cute").GetComponent<MoveLocal>();
        playerrigid = GetComponent<Rigidbody>();
        socreValue = 3 + (level - 1);
        levelText.text = "Level: " + level;
        speed = 10.0f + (level - 1) * 1.1f;

        Vector3 startingPosition = GetStartingPosition();
        transform.position = startingPosition;

        if (level > 1)
        {
            NextlevelText.gameObject.SetActive(true);
            NextlevelText.text = "Level " + level;
            StartCoroutine(HideLevelText());
        }
    }

    IEnumerator HideLevelText()
    {
        yield return new WaitForSeconds(0.6f);
        NextlevelText.gameObject.SetActive(false);
    }

    Vector3 GetStartingPosition() {
        Vector3 startingPosition = Vector3.zero;
        switch (Drive.level)
        {
            case 1:
                startingPosition = new Vector3(26.7F, 0.06F, -5.11F);
                break;
            case 2:
                startingPosition = new Vector3(-3.19F, 0.08F, -3.23F);
                break;
            case 3:
                startingPosition = new Vector3(-26, 0.3F, 26.8F); 
                break;
            case 4:
                startingPosition = new Vector3(-3.19F, 0.08F, -3.23F);
                break;
            case 5:
                startingPosition = new Vector3(26.7F, 0.06F, -5.11F);
                break;
            default:
                startingPosition = new Vector3(26.7F, 0.06F, -5.11F); 
                break;
        }
        return startingPosition;
    }

    void Update() {
        if (!gameover || !gameover2)
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }
        if (score == socreValue)
        {
            if (level < 5) 
            {
                level += 1; 
                socreValue = 3 + (level - 1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                GameOverrrr();
                gameover = true;
                gameover2 = true;
            }
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
    //winner
    public void GameOverrrr()
    {
        WinnerText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    //lose game
    public void GameOver2()
    {
        gameoverText2.gameObject.SetActive(true);
        restartButton2.gameObject.SetActive(true);
        // playerScript.gameover = true;
    }
    public void RestartGame()
    {
        level = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
} 