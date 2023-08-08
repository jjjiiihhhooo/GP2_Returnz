using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public static FieldManager instance;

    public Field[] fields;
    public Field currentField;

    public int fieldIndex;

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


    public void EnemySet(Enemy enemy)
    {
        currentField.EnemySet(enemy);
        
    }

    public void FieldSet()
    {
        if (fieldIndex == 5) fieldIndex = 0;
        else fieldIndex++;
        currentField = fields[fieldIndex];
        PlayerController.instance.GetEnemy(currentField.myEnemy);
    }
}
