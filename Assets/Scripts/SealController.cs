using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    float angle;
    bool isDead;

    public float maxHeight;
    public float flapVelocity;
    public float relativeVelocityX;
    public GameObject sprite;//Sprite ������Ʈ ����

    public bool IsDead()
    {
        return isDead;
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = sprite.GetComponent<Animator>(); //Animator ������Ʈ ���
    }

    // Update is called once per frame
    void Update()
    {
        // �ְ� ���� �������� ���� ��쿡�� ���� �Է��� �޴´�.
        if(Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
        {
            Flap();
        }

        // ������ �ݿ�
        ApplyAngle();

        // angle�� ���� �̻��̶�� �ִϸ������� flap�÷��׸� true�� �Ѵ�.
        animator.SetBool("flap", angle >= 0.0f);
    }

    private void ApplyAngle()
    {
        float targetAngle;

        // ����ϸ� �׻� �Ʒ��� ���Ѵ�.
        if (isDead)
        {
            targetAngle = -90.0f;
        }
        else
        {
            targetAngle = Mathf.Atan2(rb2d.velocity.y, relativeVelocityX) * Mathf.Rad2Deg; //���ͷκ��� ���� ���
        }

        // ȸ�� �ִϸ��̼��� ������
        angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * 10.0f);

        // Rotation�� �ݿ�
        sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }

    public void Flap()
    {
        // ������ ���� ������ �ʴ´�.
        if(isDead)
        {
            return;
        }

        // Velocity�� ���� �ٲ� �Ἥ ���� �������� ����
        rb2d.velocity = new Vector2(0.0f, flapVelocity);//�ӵ� ����
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDead)
        {
            return;
        }
        // ���� �ε�ġ�� ��� �÷��׸� true�� �Ѵ�.
        isDead = true;
    }
}
