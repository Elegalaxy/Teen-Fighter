using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VicMenu : MonoBehaviour
{
    public bool vic = false;
    public GameObject player;
    public GameObject player2;
    public GameObject ground;
    public GameObject VicMenuUI;
    public GameObject VicText;
    public MapIndex mapIndex;
    public GameObject bullet;
    public GameObject bullet2;

    private void Update()
    {
        if(player.GetComponent<PlayerHealth>().Health <= 0)
        {
            victory(2);
        }
        else if (player2.GetComponent<PlayerHealth>().Health <= 0)
        {
            victory(1);

        }
    }

    void victory(int playerInd)
    {
        Time.timeScale = 0f;
        vic = true;
        VicMenuUI.SetActive(true);
        if (playerInd == 1)
        {
            VicText.GetComponent<TextMeshProUGUI>().SetText("Congrats! Player1 wins!");
        }
        else if(playerInd == 2)
        {
            VicText.GetComponent<TextMeshProUGUI>().SetText("Congrats! Player2 wins!");
        }
        bullet.SetActive(false);
        bullet2.SetActive(false);
    }
    public void Restart()
    {
        bullet.SetActive(true);
        bullet2.SetActive(true);
        int lvlIndex = MapIndex.mapInd;
        mapIndex.setCharInd(player.GetComponent<PlayerController>().playerIndex, player2.GetComponent<PlayerController>().playerIndex);
        SceneManager.LoadScene(lvlIndex); //load next scene
    }
}
