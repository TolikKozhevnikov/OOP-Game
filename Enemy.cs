using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Spawner
{
    private Animator Anim;
    Rigidbody2D Rb;
    GameObject Player;
    bool run = false;
    int Range = 1;
    Vector2 EnemyPos;
    bool death = false;
    public Transform attackPos;
    public float attackRange;
    public float damage;
    public LayerMask isPlayer;
    bool attack = true;
    float startHealth;
    public GameObject HealthBarEnemy;
    public bool PlayerTriger = false;
    

    private void Start()
    {
        health = GetHealth();
        Speed = GetSpeed();
        startHealth = health;
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Player = GameObject.Find("Player");
        InvokeRepeating("RandomEvent", 5, 3);
    }
    private void FixedUpdate()
    {
        if (death == false)
        {
            if (Vector2.Distance(transform.position, Player.transform.position) > Range && run == false)
            {
                Anim.SetBool("Walk", true);
                EnemyPos = Vector2.MoveTowards(transform.position, Player.transform.position, Speed * Time.fixedDeltaTime);
                if (transform.position.x > Player.transform.position.x)
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                else if (transform.position.x < Player.transform.position.x)
                    transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Vector2.Distance(transform.position, Player.transform.position) > Range && run == true)
            {
                Anim.SetBool("Walk", true);
                EnemyPos = Vector2.MoveTowards(transform.position, Player.transform.position, -Speed * Time.fixedDeltaTime);
                if (transform.position.x > Player.transform.position.x)
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                else if (transform.position.x < Player.transform.position.x)
                    transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Vector2.Distance(transform.position, Player.transform.position) <= Range && death == false)
                Attack();

            transform.position = new Vector2(EnemyPos.x, transform.position.y);
        }
    }

void RandomEvent()
{
    if (death == false)
    {
        switch (Random.Range(0, 3))
        {
            case 1:
                run = true;
                Invoke("Run", 1);
                break;
            case 2:
                Jump();
                break;
        }
    }
}
void Run()
{
    run = false;
}
public void Jump()
{
    Rb.AddForce(transform.up * 10, ForceMode2D.Impulse);
    Anim.SetTrigger("Jump");
}
public void Damage(float damage)
{
    health -= damage;
    HealthBarEnemy.transform.localScale = new Vector2((health / startHealth) * 0.05f, 0.035f);
    if (health <= 0)
    {
        
        death = true;
        Anim.SetTrigger("Death");
        Invoke("Death", 1);
    }
}
public void Attack()
{
    if (attack == true)
    {
        attack = false;
        Anim.SetTrigger("Attack");
        Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, isPlayer);
        for (int i = 0; i < playerToDamage.Length; i++)
        {
            playerToDamage[i].GetComponent<PlayerController>().Damage(damage);

        }
        Invoke("AttackReset", 1);
    }
}
void AttackReset()
{
    attack = true;
}

}
   

