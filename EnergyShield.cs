using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyShield : MonoBehaviour
{
   

    public TMP_Text scoreGT;
    public AudioSource audioSource;
    public TMP_Text victoryMessage; // ��������� �� ��������� TMP_Text ��� ��������� ����������� ��� ��������
    
    //private string initialVictoryText = ""; // ���������� ����� ��� ����������� ��� ��������


    private int score = 0; // ����� ��� ��������� �������

    void Start()
    {
        GameObject scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<TMP_Text>();
        LoadScore(); // ������������ ������� ��� �����
        //victoryMessage.text = initialVictoryText; // ������������ ����������� ������
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
            // ���������� � ������� ���� �� ���������� �������
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); // ������ "MainMenu" �� ����� ���� ����� ��������� ����
            ResetScore(); // ������ ������ �������� �������
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            // ��������� ����������� �� ����������� ���
            victoryMessage.text = "";
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collided = collision.gameObject;
        if (collided.tag == "DragonEgg")
        {
            Destroy(collided);

            score += 1; // �������� �������
            scoreGT.text = score.ToString();
            SaveScore(); // �������� �������
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();

            /* // �������� �� ��������
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
