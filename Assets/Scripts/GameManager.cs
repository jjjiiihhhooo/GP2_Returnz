using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Enemy[] enemies;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ChangeField()
    {
        FieldManager.instance.FieldSet();
    }

    public Enemy GetEnemy()
    {
        int rand = Random.Range(0, enemies.Length);

        return enemies[rand];
    }

}
