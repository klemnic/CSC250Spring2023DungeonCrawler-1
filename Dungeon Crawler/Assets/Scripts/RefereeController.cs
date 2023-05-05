using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RefereeController : MonoBehaviour
{
    public GameObject monsterGO;
    public GameObject playerGO;
    public TextMeshPro monsterSB;
    public TextMeshPro playerSB;
    private Monster theMonster;
    private DeathMatch theMatch;
    public GameObject winnerJukeBox;

    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("Monster");
        this.updateScore();
        this.theMatch = new DeathMatch(MasterData.thePlayer, this.theMonster, this.playerGO, this.monsterGO, this);
        StartCoroutine(DelayBeforeFight());   
    }

    public void playWinnerMusic()
    {
        //this.winnerJukeBox.SetActive(true);
        StartCoroutine(ShowDungeonScene());
    }

    public void playLoserMusic()
    {
        StartCoroutine(ShowGameOverScene());
    }

    public void updateScore()
    {
        this.monsterSB.text = this.theMonster.getData();
        this.playerSB.text = MasterData.thePlayer.getData();
    }

    IEnumerator ShowGameOverScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameOverScene");
    }

    IEnumerator ShowDungeonScene()
    {
        yield return new WaitForSeconds(2f);
        MasterData.isExiting = false;
        SceneManager.LoadScene("DungeonRoom");
    }

    IEnumerator DelayBeforeFight()
    {
        MasterData.canGetIntoFight = false;
        yield return new WaitForSeconds(0.5f);
        this.theMatch.fight();
        
    }

    

// Update is called once per frame
    void Update()
    {
        
    }
}