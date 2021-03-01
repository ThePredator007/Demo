using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class OyunKontrol : MonoBehaviour
{
    public GameObject[] Oyuncular;
    public Transform[] SpawnPoints;

    public GameObject PausePanel;
    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject RakipSayısıPanel;

    public GameObject PauseButon;

    public GameObject EnemyPre;
    public GameObject PlayerObject;

    public Text KalanOyuncu;

    public Camera DeadKamera;

    bool Finder = false;

    private void Awake()
    {
        Time.timeScale = 0;
        
    }
    void Start()
    {
        
        PlayerObject = GameObject.Find("Player");
    }

    void Update()
    {



        Oyuncular = GameObject.FindGameObjectsWithTag("Players");

        KalanOyuncu.text = "Kalan Oyuncu " + Oyuncular.Length;

        if (Oyuncular.Length > 1) 
                Finder = true;
        

        if (PlayerObject != null && Oyuncular.Length == 1 && Finder)
        {
            WinPanel.SetActive(true);
            Time.timeScale = 0;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        Destroy(other.gameObject);

        if (other.gameObject.transform.parent.name == "Player")
        {
            Destroy(PlayerObject);
            DeadKamera.enabled = true;        
            LosePanel.SetActive(true);
        }
        
       

    }


    public void RakipSayısı(int GelenSayı)
    {
        for (int i = 0; i < GelenSayı; i++)
        {
            Instantiate(EnemyPre, SpawnPoints[i].position, Quaternion.LookRotation(SpawnPoints[i].forward));
        }
        RakipSayısıPanel.SetActive(false);
        Time.timeScale = 1;
        PauseButon.SetActive(true);
        Oyuncular = GameObject.FindGameObjectsWithTag("Players");
    }


    
    public void PauseButton()
    {
        PauseButon.SetActive(false);
        Time.timeScale = 0;
        PausePanel.SetActive(true);

    }

    public void ResumeButton()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        PauseButon.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("AnaMenu");
    }
}
