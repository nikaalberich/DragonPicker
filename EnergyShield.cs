using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyShield : MonoBehaviour
{
   

    public TMP_Text scoreGT;
    public AudioSource audioSource;
    public TMP_Text victoryMessage; // Посилання на компонент TMP_Text для виведення повідомлення про перемогу
    
    //private string initialVictoryText = ""; // Початковий текст для повідомлення про перемогу


    private int score = 0; // Змінна для зберігання рахунку

    void Start()
    {
        GameObject scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<TMP_Text>();
        LoadScore(); // Завантаження рахунку при старті
        //victoryMessage.text = initialVictoryText; // Встановлення початкового тексту
    }

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScore();
        }

        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            // Повернення в головне меню та анулювання рахунку
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); // Замініть "MainMenu" на назву вашої сцени головного меню
            ResetScore(); // Виклик методу скидання рахунку
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            // Видалення повідомлення та продовження гри
            victoryMessage.text = "";
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collided = collision.gameObject;
        if (collided.tag == "DragonEgg")
        {
            Destroy(collided);

            score += 1; // Збільшуємо рахунок
            scoreGT.text = score.ToString();
            SaveScore(); // Зберігаємо рахунок
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();

            /* // Перевірка на перемогу
             if (score >= 100)
             {
                 victoryMessage.text = "You have won! Press 'Q' on the keyboard to exit, 'C' to continue the game.";
             }*/

            
        }
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
    }

    private void LoadScore()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
            scoreGT.text = score.ToString();
        }
    }


    public void ResetScore()
    {
        score = 0;
        scoreGT.text = "0";
        SaveScore();
      
    }
}
