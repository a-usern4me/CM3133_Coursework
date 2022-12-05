using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroCollisions : MonoBehaviour {
    private float guarding = 0f;
    private float rolling = 0f;

    private Vector3 startPosition;

    private int enemyCount;
    
    public bool vulnerable;
    private float vulnerableTime = 0f;

    public Collider2D triggeringCollider;
    private bool tripped = false;

    Animator anim;
    public Rigidbody2D heroRigid;
    public Rigidbody2D newEnemy;
    public Rigidbody2D heavyEnemy;
    private ParticleSystem myPart;
    private GameStateManager gsm;
    public heavyAmountManager hsm;
    public AudioSource audio;
    public AudioClip parrySFX;
    public AudioClip rollSFX;

    public GameObject playerStatus;
    public GameObject rootCanvas;

    void Start(){
        anim = this.GetComponent<Animator>();
        heroRigid = this.GetComponent<Rigidbody2D>();
        heavyEnemy = GameObject.Find("heavyEnemy").GetComponent<Rigidbody2D>();
        myPart = this.GetComponent<ParticleSystem>();
        gsm = GameObject.Find("Player").GetComponent<GameStateManager>();
        audio = this.GetComponent<AudioSource>();

        startPosition = newEnemy.transform.position;

        vulnerable = false;
        tripped = false;
        
        enemyCount = 0;

    }

    void Update(){
        guarding -= Time.deltaTime;
        rolling -= Time.deltaTime;
        vulnerableTime -= Time.deltaTime;

        if (Input.GetKey("a") && guarding <= 0){
            guarding = 1f;
        }

        if (Input.GetKey("d") && rolling <= 0){
            rolling = 1f;
            
            audio.clip = rollSFX;
            audio.Play();
        }

    }

    //Regular Enemy
    private void OnCollisionEnter2D(Collision2D collision){
        if (GameStateManager.IsInputEnabled){
            if (collision.gameObject.tag == "newEnemy"){
                if (guarding >= 0.5){
                    anim.Play("counterAnimation");
                    myPart.Play();
                    audio.clip = parrySFX;
                    audio.Play();
                    enemyCount += 1;

                    guarding = 0f;
                    rolling = 0f;
        
                } else {
                    anim.Play("damageAnimation");
                    gsm.adjustHealth(-1);

                    guarding = 0f;
                    rolling = 0f;

                }

                if (enemyCount <= 5){
                    Instantiate(collision.gameObject, startPosition, Quaternion.identity);
                    Destroy(collision.gameObject, 0.5f);
                
                } else {
                    Destroy(collision.gameObject, 0.5f);
                    anim.SetBool("Victory", true);
                    heroRigid.AddForce(Vector3.right * 500);
                    print("You Win!");
                    GameStateManager.IsInputEnabled = false;

                }

            }

        }

    }
    
    private void OnCollisionExit2D(Collision2D collision){
        heroRigid.velocity = Vector3.zero;
        
    }

    //Heavy Enemy
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "heavyEnemy"){
            if (heavyAmountManager.vulnerable == false){
                if (guarding >= 0f){
                    myPart.Play();
                    collider.transform.localScale += new Vector3(-0.5f,-0.5f,-0.5f);
                    heavyAmountManager.vulnerable = true;
                    vulnerableTime = 3f;
                    print("NOW!!!");
     
                } else {
                    anim.Play("damageAnimation");
                    heroRigid.AddForce(Vector3.left * 300);
                    gsm.adjustHealth(-1);

                }

            }

            if (heavyAmountManager.vulnerable == true && rolling > 0){
                if (vulnerableTime > 0){
                    triggeringCollider = collider;
                    tripped = true;
                    hsm.adjustAmount(-1);

                
                } else {
                    anim.Play("damageAnimation");
                    heroRigid.AddForce(Vector3.left * 300);
                    gsm.adjustHealth(-1);

                }
                
            }

        }

        //Fast Enemy
        if (collider.gameObject.tag == "fastEnemy"){
            if (rolling > 0){
                Destroy(collider.gameObject, 1f);
                SceneManager.LoadScene(3);
                Destroy(rootCanvas);
                Destroy(playerStatus);
                
            } else {
                anim.Play("damageAnimation");
                gsm.adjustHealth(-2);

            }

        }

    }

    void RotateEnemy(){
        if (tripped == true){
            triggeringCollider.gameObject.transform.Rotate(0f, 50f, 0f);
            triggeringCollider.gameObject.transform.Translate(0f, 0.5f, 0f);
            
        }

    }

    private void FixedUpdate(){
        RotateEnemy();

    }

}