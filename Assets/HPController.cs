using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPController : MonoBehaviour
{
    public float HP;
    bool isColliding = false;
    float timer = 0.05f;

    float hpReloadTimer = 0;

    void Start()
    {
        HP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding)
            timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 1;
            HP -= 10;
        }

        if (hpReloadTimer <= 0 && HP < 100)
        {
            HP += Time.deltaTime * 2;
        }

        if (hpReloadTimer > 0 && !isColliding)
            hpReloadTimer -= Time.deltaTime;

        if (HP <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            isColliding = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            isColliding = false;
            timer = 0.05f;
            hpReloadTimer = 5;
        }
    }
}
