using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] attackPrefabs;
    [SerializeField] float timeBetweenAttacks = 8f;

    float timeElapsed = 0f;
    System.Random random;

    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= timeBetweenAttacks)
        {
            timeElapsed = 0f;
            Attack();
        }
    }

    private void Attack()
    {
        int randomAttack = random.Next(0, attackPrefabs.Length);
        Instantiate(attackPrefabs[randomAttack], transform.position, Quaternion.identity);
    }
}
