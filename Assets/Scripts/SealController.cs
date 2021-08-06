using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    float angle;

    public float maxHeight;
    public float flapVelocity;
    public float relativeVelocityX;
    public GameObject sprite;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // �ְ� ������ �������� ���� ��쿡�� ���� �Է��� �޴´�.
        if(Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
        {
            Flap();
        }
    }

    public void Flap()
    {
        // Velocity�� ���� �ٲ� �Ἥ ���� �������� ����
        rb2d.velocity = new Vector2(0.0f, flapVelocity);//�ӵ� ����
    }
}