using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool paused = false;
    public GameObject panel;
    public EnergyShield energyShield;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!paused)
            {
                Time.timeScale = 0;
                paused = true;
                panel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
                panel.SetActive(false);
            }

            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // energyShield.SaveScore(); // Зберегти рахунок перед переходом до меню
            //energyShield.ResetScoreByKeyboard(); // Скидання рахунку
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
       
    }
}
