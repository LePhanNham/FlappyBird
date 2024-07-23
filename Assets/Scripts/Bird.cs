using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public float JumpForce;
    private Rigidbody2D Rigidbody;
    [SerializeField] private GameObject ready;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Text score;
    [SerializeField] private Button reset;
    private int Diem;
    private void Awake()
    {

        Rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody.gravityScale = 0;
        ready.SetActive(true);
        gameOver.SetActive(false);
        reset.gameObject.SetActive(false);
        Diem = 0;
    }
    private void Start()
    {
        score.text = "0";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundController.instance.PlayThisSound("wing", 0.5f);
            ready.SetActive(false);
            Rigidbody.gravityScale = 8;
            BirdMoveUp();
        }

    }

    private void BirdMoveUp()
    {
        Rigidbody.velocity = Vector3.up * JumpForce;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundController.instance.PlayThisSound("die",0.5f);
        GameLose();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Diem++;
        score.text = Diem.ToString();
        SoundController.instance.PlayThisSound("point", 0.5f);
    }
    [SerializeField] Text currentScore;
    [SerializeField] Text highScore;
    public int HighScore
    {
        get => PlayerPrefs.GetInt("HighScore", 0);
        set => PlayerPrefs.SetInt("HighScore", value);
    }
    private void GameLose()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
        currentScore.text = "Current Score : " + Diem.ToString();
        if (Diem>HighScore)
        {
            HighScore = Diem;
        }
        highScore.text = "High Score : " + HighScore.ToString();
        Diem = 0;
        score.text = "0";
        reset.gameObject.SetActive(true);
        reset.onClick.AddListener(ResetButton);
    }
    public void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        reset.gameObject.SetActive(false);
        
    }
}
