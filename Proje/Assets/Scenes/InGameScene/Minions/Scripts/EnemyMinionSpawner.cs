using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMinionSpawner : MonoBehaviour
{
    public float meleeMinionMoveSpeed;      // Yak�n d�v�� minion hareket h�z�
    public float rangedMinionMoveSpeed;     // Uzak d�v�� minion hareket h�z�

    public GameObject meleeMinionPrefab;    // Yak�n d�v�� minion prefab�
    public GameObject rangedMinionPrefab;   // Uzak d�v�� minion prefab�
    public Transform[] spawnPoints;         // Minionlar�n do�aca�� noktalar
    public float spawnInterval = 20.0f;     // Minion dalgalar� aras�ndaki aral�k
    public int minionsPerWave = 10;         // Her dalga i�in minion say�s� (5 melee, 5 ranged)
    public float delayBetweenMinions;       // Minionlar aras� gecikme s�resi

    private ObjectPool meleeMinionPool;     // Yak�n d�v�� minionlar� i�in obje havuzu
    private ObjectPool rangedMinionPool;    // Uzak d�v�� minionlar� i�in obje havuzu

    private void Start()
    {
        // meleeMinionPool ve rangedMinionPool boyutlar�n� 5 yaparak her dalga i�in yeterli say�da minion sa�l�yoruz
        meleeMinionPool = new ObjectPool(meleeMinionPrefab, 5, transform);
        rangedMinionPool = new ObjectPool(rangedMinionPrefab, 5, transform);

        StartCoroutine(SpawnMinions()); // Minionlar� do�urma i�lemini ba�lat
    }

    private IEnumerator SpawnMinions()
    {
        while (true)
        {
            for (int i = 0; i < minionsPerWave; i++)
            {
                // �lk 5 minion melee olacak, sonraki 5 minion ranged olacak
                if (i < 5) // �lk 5 minion melee
                {
                    SpawnMinion(meleeMinionPool, meleeMinionMoveSpeed);
                }
                else // Sonraki 5 minion ranged
                {
                    SpawnMinion(rangedMinionPool, rangedMinionMoveSpeed);
                }

                yield return new WaitForSeconds(delayBetweenMinions);
            }

            yield return new WaitForSeconds(spawnInterval - delayBetweenMinions * minionsPerWave);
        }
    }

    private void SpawnMinion(ObjectPool pool, float moveSpeed)
    {
        GameObject minion = pool.Get();                             // Obje havuzundan bir minion al
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];  // Do�um noktas�n� rastgele se�
        minion.transform.position = spawnPoint.position;           // Minionu do�um noktas�na yerle�tir
        minion.transform.rotation = spawnPoint.rotation;           // Minionun do�um noktas�na g�re rotasyonunu ayarla

        UnityEngine.AI.NavMeshAgent minionAgent = minion.GetComponent<UnityEngine.AI.NavMeshAgent>();
        minionAgent.speed = moveSpeed;                              // Minionun hareket h�z�n� ayarla
    }

    // Obje havuzu s�n�f�
    private class ObjectPool
    {
        private Queue<GameObject> poolQueue;    // Obje havuzu kuyru�u
        private GameObject prefab;              // Havuzdaki obje prefab�
        private Transform parent;               // Havuzun parent�

        public ObjectPool(GameObject prefab, int initialSize, Transform parent)
        {
            this.prefab = prefab;
            this.parent = parent;
            poolQueue = new Queue<GameObject>();

            for (int i = 0; i < initialSize; i++)
            {
                GameObject obj = Instantiate(prefab, parent);    // Prefab� havuza ekleyerek obje olu�tur
                obj.SetActive(false);                             // Objeyi etkisiz hale getir
                poolQueue.Enqueue(obj);                           // Objeyi havuza ekle
            }
        }

        public GameObject Get()
        {
            if (poolQueue.Count == 0)
            {
                AddObjects(1);          // Havuzda obje kalmazsa yeni objeler ekle
            }

            GameObject obj = poolQueue.Dequeue();    // Kuyruktan bir obje al
            obj.SetActive(true);                    // Objeyi etkin hale getir
            return obj;                             // Objeyi d�nd�r
        }

        public void ReturnToPool(GameObject obj)
        {
            obj.SetActive(false);       // Objeyi etkisiz hale getir
            poolQueue.Enqueue(obj);     // Objeyi havuza geri ekle
        }

        private void AddObjects(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject obj = Instantiate(prefab, parent);    // Prefabtan obje olu�tur
                obj.SetActive(false);                             // Objeyi etkisiz hale getir
                poolQueue.Enqueue(obj);                           // Objeyi havuza ekle
            }
        }
    }
}
