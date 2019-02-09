using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Config
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.6f;
    [SerializeField] float health = 200f;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.6f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.3f;
    [SerializeField] AudioClip shootSound;

    [Header("Projectiles")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float projectileFiringPeriod = 0.05f;

   

    Coroutine firingCoRoutine;
    


    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Use this for initialization
    void Start() {
        SetUpMoveBoundaries();
    }


    // Update is called once per frame
    void Update () {
        Move();
        Fire();
	}

    public float GetHealth()
    {
        return health;
    }

    private void Fire()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            firingCoRoutine = StartCoroutine(FireContinuously());
          
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoRoutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;

            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            yield return new WaitForSeconds(projectileFiringPeriod);
            
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);

    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        
        FindObjectOfType<Level>().LoadGameOver();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        

    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void Move()
    {
        //defines deltas (movement additions)
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        

        //Updates movement on inputs
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        

        transform.position = new Vector2(newXPos, newYPos);
        

    }
}
