using UnityEngine;
using System.Collections.Generic;

public class EnemyGeneratorController : MonoBehaviour {
    private float InitialTime  = 3.0f;
    private float RangeMin      = 1.0f;
    private float RangeMax      = 5.0f;
    private int   MaxEnemyCount = 6;
    private float NewEnemyTime  = 20.0f;
    private List<GameObject> EnemiesToSpawn = null;
    public  List<GameObject> Tier0Enemies;
    public  List<GameObject> Tier1Enemies;
    public  List<GameObject> Tier2Enemies;
    public  List<GameObject> Tier3Enemies;

    void ChangeDifficulty(float aRangeMin, float aRangeMax, int aMaxEnemy)
    {
        this.RangeMin      = aRangeMin;
        this.RangeMax      = aRangeMax;
        this.MaxEnemyCount = aMaxEnemy;
    }

    void Start()
    {
        EnemiesToSpawn = new List<GameObject>();
        this.AddNewEnemy();
        Invoke("Spawn", this.InitialTime);
        Invoke("AddNewEnemy", this.InitialTime + this.NewEnemyTime);
    }

    private void AddNewEnemy()
    {
        List<GameObject> ListToUse = null;
        if (this.Tier0Enemies.Count > 0)
        {
            ListToUse = this.Tier0Enemies;
            this.ChangeDifficulty(1.0f, 3.5f, 8);
        }
        else if (this.Tier1Enemies.Count > 0)
        {
            ListToUse = this.Tier1Enemies;
            this.ChangeDifficulty(1.0f, 3.5f, 10);
        }
        else if (this.Tier2Enemies.Count > 0)
        {
            ListToUse = this.Tier2Enemies;
            this.ChangeDifficulty(1.0f, 3.0f, 10);
        }
        else if (this.Tier3Enemies.Count > 0)
        {
            ListToUse = this.Tier3Enemies;
            this.ChangeDifficulty(1.0f, 3f, 8);
        }

        if ((ListToUse != null) && (ListToUse.Count > 0))
        {
            GameObject enemy = ListToUse[Random.Range(1, ListToUse.Count) - 1].gameObject;
            this.EnemiesToSpawn.Add(enemy);
            ListToUse.Remove(enemy);
        }
        Invoke("AddNewEnemy", NewEnemyTime);
    }

    void Spawn()
    {        
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < MaxEnemyCount)
        { 
            Instantiate(this.EnemiesToSpawn[Random.Range(0, this.EnemiesToSpawn.Count)],
                        this.transform.position,
                        Quaternion.identity);
        }
        Invoke("Spawn", Random.Range(RangeMin, RangeMax));
    }
}
