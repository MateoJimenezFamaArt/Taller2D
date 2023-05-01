using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    //Timers
    [SerializeField] float BulletAtimer = 0;
    [SerializeField] float BulletBtimer = 0;
    [SerializeField] float BulletCtimer = 0;
    [SerializeField] float GeneralTimer = 0;
  
    public Text Timertxt;

    //Boss Values
    private Rigidbody2D rb;
    private float health = 50;
    [SerializeField]private float InvincibleTimer;
    private float TimeInvincible = 4f;
    [SerializeField]private bool IsInvincible;



    //Bullets A,B,C
    public GameObject bullet;
    public Transform bulletposA,bulletposB,bulletposC;

    //Homming Bullet
    public GameObject HommingBullet;
    public Transform HommingBulletPos;
    [SerializeField] private int BossHitForHommingBullet;

    //Biopolymer
    public GameObject Pill;
    public Transform Pillpos;
    [SerializeField]private int BossHitForBioPolymer;


    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Personaje");
    }

    // Update is called once per frame
    void Update()
    {
        //General Timer and Time Management
        GeneralTimer += Time.deltaTime;
        //Holy Timer

        //Bullet Timers
        BulletAtimer += Time.deltaTime;
        BulletBtimer += Time.deltaTime;
        BulletCtimer += Time.deltaTime;

        //Canva timer
        Timertxt.text = "" + GeneralTimer.ToString("f2");

        //InvencibilityTimer
        if (IsInvincible)
        {

            InvincibleTimer -= Time.deltaTime;
            //Set Animation of idle to stop
            //Set Animation of hit to begin

            if (InvincibleTimer < 0)
            {
                IsInvincible = false;
                //Set Animation of hit to stop
                //Set Animation of idle to begin
            }
        }


        //Bullets Go crazy A,B,C
        if (BulletAtimer > 3f)
        {
            Debug.Log("ABullet Shot");
            BulletAtimer = 0;
            shootA();
        }

        if (BulletBtimer > 2f)
        {
            Debug.Log("BBullet Shot");
            BulletBtimer = 0;
            shootB();
        }

        if (BulletCtimer > 1.5f)
        {
            Debug.Log("CBullet Shot");
            BulletCtimer = 0;
            shootC();
        }
        //Starts Homming instantiation
        if (BossHitForHommingBullet == 1)
        {
            Instantiate(HommingBullet, HommingBulletPos.position, Quaternion.identity);
            BossHitForHommingBullet = 0;
        }
        //Spawns Bio Polymer WORK IN PROGRESS
        if (BossHitForBioPolymer == 2)
        {
            Instantiate(Pill, Pillpos.position, Quaternion.identity);
            BossHitForBioPolymer = 0;
        }
        //Done

    }//UPDATE END
    void shootA()
    {
        //AudioManagerScript.instance.PlaySFXs(AudioManagerScript.AudioSamples.EnemyShoot);
        Instantiate(bullet, bulletposA.position, Quaternion.identity);
    }
    void shootB()
    {
        //AudioManagerScript.instance.PlaySFXs(AudioManagerScript.AudioSamples.EnemyShoot);
        Instantiate(bullet, bulletposB.position, Quaternion.identity);
    }
    void shootC()
    {
        //AudioManagerScript.instance.PlaySFXs(AudioManagerScript.AudioSamples.EnemyShoot);
        Instantiate(bullet, bulletposC.position, Quaternion.identity);
    }

    //Bullets Done





    //Start Boss Take dmg and invincibility
    public void DMG(int damage)
    {

        if (IsInvincible)
        {
            Debug.Log("Boss is invincible");
            return;
        }


        IsInvincible = true;
        InvincibleTimer = TimeInvincible;

        BossHitForHommingBullet++;
        BossHitForBioPolymer++;
        health -= damage;
        Debug.Log("BossHit");
        


        if (health == 0)
        {
            Die();
        }
    }

    public void Die()
    {

        Destroy(gameObject);
        LoadNextLvl();
    }

    [SerializeField] private int level = 5;
    public void LoadNextLvl()
    {
        SceneManager.LoadScene(5);
    }

} /// Script END



