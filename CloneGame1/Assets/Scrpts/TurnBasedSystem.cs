using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN,ENEMYTURNREPEAT, WON, LOST }

public class TurnBattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject [] enemyPrefab = new GameObject[2] ;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit_Info playerUnit;
    Unit_Info enemyUnit;

    public Text dialogueText;
    public Text BraveText;
    public Text FinalAmount;
    public Text Goldtext;
    public int BP_Points;
    public int Brave_counter = 0;
    public int FinalAttack;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    public GameObject [] AttackCards = new GameObject[4];
    public Text[] AttackCardsNumbers = new Text[4];
    public GameObject AttackCardUI;
    public GameObject PlayerUIABDR;
    public GameObject BattleScreenUI;
    public TriggerSystem ts;
    public GameObject grass;
    public PlayerMovement pm;
    public CameraFollow camerafollow;


    // Start is called before the first frame update
    public void StartBattle()
    {

        BattleScreenUI.SetActive(true);
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit_Info>();

        if (pm.Enemy1 == true)
        {
            GameObject enemyGO = Instantiate(enemyPrefab[0], enemyBattleStation);
            enemyUnit = enemyGO.GetComponent<Unit_Info>();
        }else if (pm.Enemy2 == true)
        {
            GameObject enemyGO = Instantiate(enemyPrefab[1], enemyBattleStation);
            enemyUnit = enemyGO.GetComponent<Unit_Info>();
        }


        dialogueText.text = "A wild " + enemyUnit.Enemy_Name + " approaches...";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.EnemyTakeDamage(FinalAttack);

        enemyHUD.SetHP(enemyUnit.Enemy_Health_Curr);
        dialogueText.text = "The attack is successful!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.Enemy_Name + " attacks!";

        yield return new WaitForSeconds(1f);
        bool MoveAgain = true;
        if(playerUnit.BP_Point > -1)
        {
            MoveAgain = false;
        }

            bool isDead = playerUnit.PlayerTakeDamage(enemyUnit.damageEnemy += Random.Range(10, 40));

            playerHUD.SetHP(playerUnit.Player_Health_Curr);

            yield return new WaitForSeconds(1f);
            if (isDead)
            {
                state = BattleState.LOST;
                EndBattle();
            }
            else if (MoveAgain)
            {
                state = BattleState.ENEMYTURNREPEAT;
            StartCoroutine(EnemyTurnAgain());
            playerUnit.BP_Point += 1;
            BraveText.text = playerUnit.BP_Point.ToString();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    IEnumerator EnemyTurnAgain()
    {
        dialogueText.text = enemyUnit.Enemy_Name + " attacks! again";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.PlayerTakeDamage(enemyUnit.damageEnemy += Random.Range(10, 40));

        playerHUD.SetHP(playerUnit.Player_Health_Curr);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {           
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
            playerUnit.Gold += (playerUnit.GoldEnemy += Random.Range(10, 60));
            Goldtext.text = "Gold: "+playerUnit.Gold.ToString();
            BattleScreenUI.SetActive(false);
            grass.SetActive(true);

            camerafollow.ExitBattle();

        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";

        playerUnit.damage01 = Random.Range(10, 50);
        playerUnit.damage02 = Random.Range(20, 40);
        playerUnit.damage03 = Random.Range(30, 60);
        playerUnit.damage04 = Random.Range(10, 70);

        AttackCardsNumbers[0].text = playerUnit.damage01.ToString();
        AttackCardsNumbers[1].text = playerUnit.damage02.ToString();
        AttackCardsNumbers[2].text = playerUnit.damage03.ToString();
        AttackCardsNumbers[3].text = playerUnit.damage04.ToString();

        playerUnit.BP_Point += 1;
        BraveText.text = "BP" + playerUnit.BP_Point.ToString();
        FinalAttack = 0;
        FinalAmount.text = FinalAttack.ToString();
        Brave_counter = 0;

        foreach (GameObject i in AttackCards)
        {
            i.SetActive(true);
        }

    }

    IEnumerator PlayerHeal()
    {
        if (playerUnit.Gold >= 30)
        {
            playerUnit.HealPlayer(Random.Range(5, 40));

            playerUnit.Gold -= 30;
            playerHUD.SetHP(playerUnit.Player_Health_Curr);
            dialogueText.text = "You feel renewed strength!";

            yield return new WaitForSeconds(2f);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        else
        {
            state = BattleState.PLAYERTURN;
            dialogueText.text = "Not Enough Gold";
        }
    }
    IEnumerator OnBrave()
    {
        if (playerUnit.BP_Point > -1)
        {
            playerUnit.PlayerBrave();

            dialogueText.text = "You Braved";
            BraveText.text = "BP" + playerUnit.BP_Point.ToString();
            Brave_counter++;
            yield return new WaitForSeconds(2f);
        }
        else
        {
            dialogueText.text = "Cannot Brave";
        }


    }

    IEnumerator OnDefault()
    {
        playerUnit.PlayerDefault();

        dialogueText.text = "You Defaulted";
        BraveText.text = "BP" + playerUnit.BP_Point.ToString();

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButtonShow()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        ShowAttacks();
    }

    public void OnAttackButtonConfirm()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerAttack());
        playerUnit.BP_Point -= 1;
    }

    public void OnAttackButton01()
    {
        bool Brave_counter_bool = false;
        if (Brave_counter > 0)
        {
            Brave_counter_bool = true;
        }
        if (state != BattleState.PLAYERTURN)
            return;
            FinalAttack += playerUnit.damage01;
        FinalAmount.text = FinalAttack.ToString();
        AttackCards[0].SetActive(false);
        if(Brave_counter_bool == false)
        {
            AttackCards[1].SetActive(false);
            AttackCards[2].SetActive(false);
            AttackCards[3].SetActive(false);
        }
        else
        {
            Brave_counter--;
        }
           
    }
    public void OnAttackButton02()
    {
        bool Brave_counter_bool = false;
        if (Brave_counter > 0)
        {
            Brave_counter_bool = true;
        }
        if (state != BattleState.PLAYERTURN)
            return;
            FinalAttack += playerUnit.damage02;
        FinalAmount.text = FinalAttack.ToString();
        AttackCards[1].SetActive(false);
        if (Brave_counter_bool == false)
        {
            AttackCards[0].SetActive(false);
            AttackCards[2].SetActive(false);
            AttackCards[3].SetActive(false);
        }
        else
        {
            Brave_counter--;
        }


    }
    public void OnAttackButton03()
    {
        bool Brave_counter_bool = false;
        if (Brave_counter > 0)
        {
            Brave_counter_bool = true;
        }
        if (state != BattleState.PLAYERTURN)
            return;
        FinalAttack += playerUnit.damage03;
        FinalAmount.text = FinalAttack.ToString();
        AttackCards[2].SetActive(false);
        if (Brave_counter_bool == false)
        {
            AttackCards[1].SetActive(false);
            AttackCards[0].SetActive(false);
            AttackCards[3].SetActive(false);
        }
        else
        {
            Brave_counter--;
        }



    }
    public void OnAttackButton04()
    {
        bool Brave_counter_bool = false;
        if (Brave_counter > 0)
        {
            Brave_counter_bool = true;
        }
        if (state != BattleState.PLAYERTURN)
            return;
        FinalAttack += playerUnit.damage04;
        FinalAmount.text = FinalAttack.ToString();
        AttackCards[3].SetActive(false);
        if (Brave_counter_bool == false)
        {
            AttackCards[1].SetActive(false);
            AttackCards[2].SetActive(false);
            AttackCards[0].SetActive(false);
        }
        else
        {
            Brave_counter--;
        }

    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

    public void OnBraveButton()
    {
        if(state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(OnBrave());
    }
    public void OnDefaultButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(OnDefault());
    }
    public void ShowAttacks()
    {
        PlayerUIABDR.SetActive(false);
        AttackCardUI.SetActive(true);
    }
    public void  ShowMenuAgain()
    {
        PlayerUIABDR.SetActive(true );
        AttackCardUI.SetActive(false);

    }

    public void OnRun()
    {
        BattleScreenUI.SetActive(false);
        grass.SetActive(true);
    }
}



