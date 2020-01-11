using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private Animator Anim;
    Rigidbody2D Rb;
    [SerializeField] int Speed = 5;
    Joystick Joystick;
    public bool Ground;
    public Transform attackPos;
    public float attackRange;
    public float damage = 1;
    public LayerMask isEnemy;
    bool attack = true;
    public float health = 10;
    bool death = false;
    float startHealth;
    public int Score = 3;
    public int ScoreF = 0;

    private void Start()
    {
        startHealth = health;
        Joystick = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

    }


    private void FixedUpdate()
    {
        if (Joystick.Horizontal == 0)
            Anim.SetBool("Walk", false);
        else
            Anim.SetBool("Walk", true);
        transform.Translate(transform.right * Joystick.Horizontal * Speed * Time.fixedDeltaTime);
        if (Joystick.Vertical > 0.5f)
            Jump();
        Flip();
        if (ScoreF > 0)
        {

            GameObject.Find("Canvas/ScoreText").GetComponent<Text>().text = Score.ToString();
            ScoreF--;

        }
    }
    void Jump()
    {
        if (Ground == true && death == false)
        {
            Rb.AddForce(transform.up * 5, ForceMode2D.Impulse);
            Anim.SetTrigger("Jump");
        }
    }
    void Flip()
    {
        if (Joystick.Horizontal > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Joystick.Horizontal < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    public void Attack()
    {
        if (attack == true && death == false)
        {
            attack = false;
            Anim.SetTrigger("Attack");
            Collider2D[] enemiscToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, isEnemy);
            for (int i = 0; i < enemiscToDamage.Length; i++)
            {
                enemiscToDamage[i].GetComponent<Enemy>().Damage(damage);
                print("!!!");
            }
            Invoke("AttackReset", 1);
        }
    }
    void AttackReset()
    {
        attack = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    public void Damage(float damage)
    {
        health -= damage;
        GameObject.Find("HealthBar").GetComponent<Image>().fillAmount = health / startHealth;
        if (health <= 0)
        {
            death = true;
            Anim.SetTrigger("Death");
            SceneManager.LoadScene("Game");
        }
    }
    public void Help()
    {
        if (health <= (startHealth - 5))
            health += 5;
        else
            health = startHealth;

        GameObject.Find("HealthBar").GetComponent<Image>().fillAmount = health / startHealth;
    }

}
