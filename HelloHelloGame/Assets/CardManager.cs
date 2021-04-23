using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;

    public Text PlayerHealth;
    public Text EnemyHealth;

    public int playerhealth = 100;
    public int enemyhealth = 100;

    public SpellCard[] EnemyTurn1;
    public SpellCard[] EnemyTurn2;

    public int cardCounter = 0;
    public int turnCounter = 1;

    public bool isDefence = false;
    public bool isBuff = false;

    public bool isPlayerDefence = false;
    public bool isPlayerBuff = false;

    public SpellCard playerCard;

    public HealthBar healthBar1;
    public HealthBar healthBar2;

    private void Start()
    {
        PlayerHealth.text = playerhealth.ToString();
        EnemyHealth.text = enemyhealth.ToString();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void endTurn()
    {
        CardTableManager.Instance.ClearCard();

        PlayerHealth.text = playerhealth.ToString();
        EnemyHealth.text = enemyhealth.ToString();

        healthBar1.SetHealth(playerhealth);
        healthBar2.SetHealth(enemyhealth);
    }

    public void giveDamagePlayer(int damage)
    {
        if (!isPlayerDefence)
        {
            if (isBuff)
            {
                playerhealth = playerhealth - damage*2;
            }

            else
            {
                playerhealth = playerhealth - damage;
            }
        }

        isPlayerDefence = false;
        isBuff = false;

    }

    public void defendEnemy()
    {
        if (playerCard.currCardType == SpellCard.cardType.attack)
        {
            enemyhealth = enemyhealth + playerCard.atk_dmg;
        }

        else
            isDefence = true;
    }

    public void healEnemy()
    {
        if (isBuff)
        {
            enemyhealth = enemyhealth + 20;
        }
        enemyhealth =enemyhealth + 10;
        isBuff = false;
    }

    public void buffEnemy()
    {
        isBuff = true;
    }


    public void playEnemyCard()
    {
        switch (turnCounter)
        {
            case 1:
                if (cardCounter <= 4)
                {
                    switch (EnemyTurn1[cardCounter].currCardType)
                    {
                        case SpellCard.cardType.attack:
                            giveDamagePlayer(EnemyTurn1[cardCounter].atk_dmg);
                            break;

                        case SpellCard.cardType.defence:
                            defendEnemy();
                            break;

                        case SpellCard.cardType.heal:
                            healEnemy();
                            break;

                        case SpellCard.cardType.buff:
                            buffEnemy();
                            break;
                    }
                    CardTableManager.Instance.EnemyObj = EnemyTurn1[cardCounter].gameObject;
                    CardTableManager.Instance.placeEnemyCard();


                    cardCounter = cardCounter + 1;
                }

                else
                {
                    turnCounter = 2;
                    cardCounter = 0;
                }
                break;

            case 2:
                break;
        }
        

        
        Invoke("endTurn", 3);

    }

    public void takeDamage(int damage)
    {
        enemyhealth = enemyhealth - damage;
    }

    public void healPlayer(int heal)
    {
        playerhealth = playerhealth + heal;
    }
}
