using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Tobias McGee: 1323946
//Andrew Bycroft: 16948980

public class PlayerHealth : MonoBehaviour {

    public Rigidbody2D rb2D;
    public HealthSystem healthSystem;
    Animator anim;

    public GameObject DeathScreen;
    public GameObject ScoreText;
    public GameObject GoldText;
    public GameObject GoldCoin;

    public int maxHealth;
    public GameObject bloodSplash;
    public float attackTime;
    private float attackTimeCounter;
    private bool attacking;

    //variables for invincibility frames
    private bool flashing;
    public float flashingLength;
    private float flashCounter;
    private SpriteRenderer playerSprite;

    public AudioClip heroTakingDamageSound1;
    public AudioClip heroTakingDamageSound2;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthSystem.SetUp(maxHealth);
        playerSprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //If health reaches 0, kill player and send to game over screen
        if (healthSystem.GetHealth() <= 0)
        {
            Destroy(gameObject);
            PlayerScore.FindObjectOfType<PlayerScore>().SendMessage("OnCompletion");
            //SoundManager.Instance.RandomPlayEnemyDeadSource(enemyDeadSound1, enemyDeadSound2);
            Debug.LogFormat(gameObject.name + " was killed");
            ScoreText.SetActive(false);
            GoldText.SetActive(false);
            GoldCoin.SetActive(false);
            PlayerScore.FindObjectOfType<PlayerScore>().deathGold = PlayerScore.FindObjectOfType<PlayerScore>().goldText;
            //GameStateManager.FindObjectOfType<GameStateManager>().GamePause();
            DeathScreen.SetActive(true);
        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        //Flash invincibility frames
        if(flashing)
        {   
            //sprite should be invisible if the flash counter is above 0.66 seconds
            //two-thirds of a second
            if(flashCounter > flashingLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.5f);
            }
            //one-third of a second
            else if(flashCounter > flashingLength * 0.33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.5f);
            }
            else
            {
                /*  Once player flashCounter reaches 0, turn off flashing and set opacity to full                 
                 */
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashing = false;
            }

            flashCounter -= Time.deltaTime;
        }

    }

    public void TakeDamage(int damage)
    {
        //Only let the player take damage when the counter is at zero
        if (attackTimeCounter <= 0)
        {
            attackTimeCounter = attackTime;
            attacking = true;
            Instantiate(bloodSplash, transform.position, Quaternion.identity);
            healthSystem.Damage(damage);

            //Tims
            flashing = true;
            flashCounter = flashingLength;

            SoundManager.Instance.RandomPlayHeroTakingDamageSource(heroTakingDamageSound1, heroTakingDamageSound2);
            Debug.LogFormat("Damage dealt to " + gameObject.name);
        }
    }
}
