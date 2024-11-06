using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDog : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    private bool isChasing;
    private int health = 3;

    private Transform target;
    [SerializeField] Animator animator;

    private CapsuleCollider enemyCollider;

    void Start()
    {
        enemyCollider = GetComponent<CapsuleCollider>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        isChasing = true;
        animator.SetBool("isAlive", true);
        StartCoroutine(Chase());
    }

    private IEnumerator Chase()
    {
        Debug.Log("Start Chase");
        while (isChasing)
        {

            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            RotateToTarget(target);

            yield return null;
        }
    }

    private void RotateToTarget(Transform target)
    {
        Vector3 difference = target.position - transform.position;
        float rotationY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, rotationY, 0.0f);
    }

    private IEnumerator OnHit()
    {
        health--;
        animator.SetTrigger("Hit");

        if (health <= 0 && animator.GetBool("isAlive"))
        {
            //EventsManager.OnEnemyDied();
            animator.SetBool("isAlive", false);
            isChasing = false;
            //enemyCollider.enabled = false;
            StopCoroutine(Chase());

            yield return new WaitForSeconds(5f);

            //Destroy(gameObject);

        }
    }

    public void EnemyHit()
    {
        StartCoroutine(OnHit());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(OnHit());
            //score.text = (int.Parse(score.text) + 1).ToString();
        }
    }

    public void SetChaseState(bool state)
    {
        isChasing = state;
        if (state == true)
            StartCoroutine(Chase());
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
