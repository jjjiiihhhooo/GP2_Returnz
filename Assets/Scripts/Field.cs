using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public Enemy myEnemy;
    public Transform enemyTransform;
    public Vector3 nextPos; 

    public void EnemySet(Enemy enemy)
    {
        myEnemy = enemy;
        Instantiate(myEnemy, enemyTransform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            transform.position += nextPos;
            EnemySet(GameManager.instance.GetEnemy());
        }
    }

}
