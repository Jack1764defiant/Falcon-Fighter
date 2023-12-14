using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossControllerNew : MonoBehaviour
{
    public float speed = 4f;
    public List<GameObject> turrets = new List<GameObject>();
    public bool rotateTurrets = true;
    public bool attackWhileHasTurrets = false;
    public GameObject projectile;
    public GameObject AltProjectile;
    GameObject largeBullet;
    private GameObject bullet;
    [Header("Attacks")]
    public bool hasStarShoot = false;
    public float amountOfBullets = 8;
    public bool hasLineStrike = false;
    public float timeBeforeStrike = 1.75f;
    public GameObject line;
    public bool hasCrush = false;
    public GameObject wall;
    public bool hasRain = false;
    public int waves = 2;
    public bool hasChaseAirStrike = false;
    public float chaseSpeed = 0.22f;
    public GameObject largeAirStrike;
    public bool hasRandomAirStrike = false;
    public int amountOfStrikes = 20;
    public float betweenStrikes = 0.25f;
    public GameObject smallAirStrike;
    public bool hasCrunch;
    public float crunchSpeed = 2.5f;
    public GameObject giantBullet;
    public GameObject AltGiantBullet;
    public bool hasCircleStrike;
    public float escapeDistance = 15f;
    public GameObject laser;
    public bool hasSummon;
    public GameObject[] planePrefabs1;
    public int amountPerSummon = 1;
    private float spawnRangeX = 10;
    public float spawnPosZ = 30;
    public float rotation = 0;


    List<int> attacks = new List<int>();
    bool isAttacking = false;
    GameObject player;
    List<GameObject> projectiles = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (SceneManager.GetActiveScene().buildIndex != 7 && SceneManager.GetActiveScene().buildIndex != 12)
        {
            bullet = projectile;
            largeBullet = giantBullet;
        }
        else
        {
            bullet = AltProjectile;
            largeBullet = AltGiantBullet;
        }
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
        if (hasStarShoot)
        {
            attacks.Add(0);
        }
        if (hasLineStrike)
        {
            attacks.Add(1);
        }
        if (hasCrush)
        {
            attacks.Add(2);
        }
        if (hasRain)
        {
            attacks.Add(3);
        }
        if (hasChaseAirStrike)
        {
            attacks.Add(4);
        }
        if (hasRandomAirStrike)
        {
            attacks.Add(5);
        }
        if (hasCrunch)
        {
            attacks.Add(6);
        }
        if (hasCircleStrike)
        {
            attacks.Add(7);
        }
        if (hasSummon)
        {
            attacks.Add(8);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < turrets.Count; i++)
        {
            if (turrets[i] == null)
            {
                turrets.RemoveAt(i);
            }
        }
        if (turrets.Count <= 0)
        {
            GetComponent<DetectCollisions>().enabled = true;
            GetComponent<DetectCollisions>().enemyTag = "PlayerBullet";
        }
        if (transform.position.z > 22)
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (!isAttacking && (turrets.Count <= 0 || attackWhileHasTurrets))
        {
            int attack = attacks[Random.Range(0, attacks.Count)];
            isAttacking = true;
            if (attack == 0)
            {
                Debug.Log("Starshoot");
                StartCoroutine(StarShoot());
            }
            else if (attack == 1)
            {
                Debug.Log("Linestrike");
                StartCoroutine(LineStrike());
            }
            else if (attack == 2)
            {
                Debug.Log("Crush");
                StartCoroutine(Crush());
            }
            else if (attack == 3)
            {
                Debug.Log("Rain");
                StartCoroutine(Rain());
            }
            else if (attack == 4)
            {
                Debug.Log("ChaseStrike");
                StartCoroutine(ChaseAirStrike());
            }
            else if (attack == 5)
            {
                Debug.Log("RandomStrike");
                StartCoroutine(RandomAirStrike());
            }
            else if (attack == 6)
            {
                Debug.Log("Crunch");
                StartCoroutine(Crunch());
            }
            else if (attack == 7)
            {
                Debug.Log("CircleAttack");
                StartCoroutine(circleStrike());
            }
            else if (attack == 8)
            {
                Debug.Log("Summon");
                StartCoroutine(Summon());
            }
        }
    }

    IEnumerator StarShoot()
    {
        for (int i = 0; i < amountOfBullets; i++)
        {
            var b = Instantiate(bullet, transform.position, Quaternion.identity).transform;
            b.Rotate(new Vector3(0, 360f * (i/amountOfBullets), 0));
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < amountOfBullets-1f; i++)
        {
            var b = Instantiate(bullet, transform.position, Quaternion.identity).transform;
            b.Rotate(new Vector3(0, 360f * (i / (amountOfBullets-1f)), 0));
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < amountOfBullets; i++)
        {
            var b = Instantiate(bullet, transform.position, Quaternion.identity).transform;
            b.Rotate(new Vector3(0, 360f * (i / amountOfBullets), 0));
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < amountOfBullets - 1f; i++)
        {
            var b = Instantiate(bullet, transform.position, Quaternion.identity).transform;
            b.Rotate(new Vector3(0, 360f * (i / (amountOfBullets - 1f)), 0));
        }
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
    IEnumerator LineStrike()
    {
        projectiles = new List<GameObject>();
        //-10 to 25
        int gap = Random.Range(-2, 5);
        for (float i = -3f; i <= 7f; i++)
        {
            if (i != gap)
            {
                var b = Instantiate(line, new Vector3(0, transform.position.y, i * 3.5f), Quaternion.identity).transform;
                projectiles.Add(b.gameObject);
            }
        }
        yield return new WaitForSeconds(1.65f);
        foreach (GameObject line in projectiles)
        {
            Destroy(line);
        }
        for (float i = -3f; i <= 7f; i++)
        {
            if (i != gap)
            {
                var b = Instantiate(bullet, new Vector3(12f, transform.position.y, i * 3.5f), Quaternion.identity).transform;
                b.GetComponent<MoveForward>().speed = 50f;
                b.Rotate(new Vector3(0, -90, 0));
            }
        }
        for (float i = -3f; i <= 7f; i++)
        {
            if (i != gap)
            {
                var b = Instantiate(bullet, new Vector3(-12f, transform.position.y, i * 3.5f), Quaternion.identity).transform;
                b.Rotate(new Vector3(0, 90, 0));
                b.GetComponent<MoveForward>().speed = 50f;
            }
        }
        yield return new WaitForSeconds(2f);
        isAttacking = false;
    }
    IEnumerator Crush()
    {
        int point = Random.Range(-7, 8);
        Transform leftWall = Instantiate(wall, new Vector3(-12f, transform.position.y, 7.5f), Quaternion.identity).transform;
        Transform rightWall = Instantiate(wall, new Vector3(12f, transform.position.y, 7.5f), Quaternion.identity).transform;
        projectiles.Clear();
        projectiles.Add(leftWall.gameObject);
        projectiles.Add(rightWall.gameObject);
        float timeToReachPoint = 30f;
        float timer = 0;

        while (timer < 3)
        {
            if (leftWall != null)
                leftWall.position = Vector3.Lerp(leftWall.position, new Vector3(point-3.3f, leftWall.position.y, leftWall.position.z), timer/ timeToReachPoint);
            if (rightWall != null)
                rightWall.position = Vector3.Lerp(rightWall.position, new Vector3(point+3.3f, rightWall.position.y, rightWall.position.z),  timer/ timeToReachPoint);
            timer += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        if (leftWall != null)
            Destroy(leftWall.gameObject);
        if (rightWall != null)
            Destroy(rightWall.gameObject);
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
    IEnumerator Rain()
    {
        for (int x = 0; x < waves; x++)
        {
            Debug.Log("Yes");
            if (x % 2 == 0)
            {
                for (float i = -7f; i <= 7f; i++)
                {
                    var b = Instantiate(bullet, new Vector3((i * 6f) + 3f, transform.position.y, transform.position.z + 5), Quaternion.identity).transform;
                    b.Rotate(new Vector3(0, 180, 0));
                }
            }
            else
            {
                for (float i = -7f; i <= 7f; i++)
                {
                    var b = Instantiate(bullet, new Vector3(i * 6f, transform.position.y, transform.position.z + 5), Quaternion.identity).transform;
                    b.Rotate(new Vector3(0, 180, 0));
                }
            }
            yield return new WaitForSeconds(0.75f);
        }

        yield return new WaitForSeconds(1.25f);
        isAttacking = false;
    }
    IEnumerator ChaseAirStrike()
    {
        var a = Instantiate(largeAirStrike, player.transform.position + new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)), Quaternion.identity);
        float timer = 0;
        a.GetComponent<AirStrike>().Trigger(4.51f);
        while (timer < 1)
        {
            a.transform.position = Vector3.MoveTowards(a.transform.position, player.transform.position, 0.4f);
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0;
        while (timer < 3.5f)
        {
            a.transform.position = Vector3.MoveTowards(a.transform.position, player.transform.position, chaseSpeed);
            timer += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
    IEnumerator RandomAirStrike()
    {
        for (int i = 0; i < amountOfStrikes; i++)
        {
            var a = Instantiate(smallAirStrike, player.transform.position + new Vector3(Random.Range(-3,3), 0, Random.Range(-3, 3)), Quaternion.identity);
            a.GetComponent<AirStrike>().Trigger(0.75f);
            yield return new WaitForSeconds(betweenStrikes);
        }
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }

    IEnumerator Crunch()
    {
        projectiles = new List<GameObject>();
        for (float i = -0.5f; i <= 0.5f; i++)
        {
            var b = Instantiate(giantBullet, new Vector3(player.transform.position.x + 7, transform.position.y, player.transform.position.z + 7), Quaternion.identity).transform;
            b.Rotate(new Vector3(0, 225, 0));
            b.GetComponent<MoveForward>().speed = crunchSpeed;
            projectiles.Add(b.gameObject);
            b = Instantiate(giantBullet, new Vector3(player.transform.position.x - 7, transform.position.y, player.transform.position.z - 7), Quaternion.identity).transform;
            b.Rotate(new Vector3(0, 45, 0));
            b.GetComponent<MoveForward>().speed = crunchSpeed;
            projectiles.Add(b.gameObject);
        }
        for (float i = -0.5f; i <= 0.5f; i++)
        {
            var b = Instantiate(giantBullet, new Vector3(player.transform.position.x + 7, transform.position.y, player.transform.position.z - 7), Quaternion.identity).transform;
            b.Rotate(new Vector3(0, -45, 0));
            b.GetComponent<MoveForward>().speed = crunchSpeed;
            projectiles.Add(b.gameObject);
            b = Instantiate(giantBullet, new Vector3(player.transform.position.x - 7, transform.position.y, player.transform.position.z + 7), Quaternion.identity).transform;
            b.Rotate(new Vector3(0, 135, 0));
            b.GetComponent<MoveForward>().speed = crunchSpeed;
            projectiles.Add(b.gameObject);
        }

        yield return new WaitForSeconds(3.5f);
        foreach (GameObject proj in projectiles)
        {
            if (proj != null)
                Destroy(proj);
        }
        yield return new WaitForSeconds(0.5f);

        projectiles = new List<GameObject>();
        for (float i = -0.5f; i <= 0.5f; i++)
        {
            var b = Instantiate(giantBullet, new Vector3(player.transform.position.x + (i*0.25f), transform.position.y, player.transform.position.z + 10), Quaternion.identity).transform;
            b.Rotate(new Vector3(0, 180, 0));
            b.GetComponent<MoveForward>().speed = crunchSpeed;
            projectiles.Add(b.gameObject);
            b = Instantiate(giantBullet, new Vector3(player.transform.position.x + (i * 0.25f), transform.position.y, player.transform.position.z - 10), Quaternion.identity).transform;
            b.GetComponent<MoveForward>().speed = crunchSpeed;
            projectiles.Add(b.gameObject);
        }
        for (float i = -0.5f; i <= 0.5f; i++)
        {
            var b = Instantiate(giantBullet, new Vector3(player.transform.position.x + 10, transform.position.y, player.transform.position.z + (i * 0.25f)), Quaternion.identity).transform;
            b.Rotate(new Vector3(0, -90, 0));
            b.GetComponent<MoveForward>().speed = crunchSpeed;
            projectiles.Add(b.gameObject);
            b = Instantiate(giantBullet, new Vector3(player.transform.position.x - 10, transform.position.y, player.transform.position.z + (i * 0.25f)), Quaternion.identity).transform;
            b.Rotate(new Vector3(0, 90, 0));
            b.GetComponent<MoveForward>().speed = crunchSpeed;
            projectiles.Add(b.gameObject);
        }
        yield return new WaitForSeconds(3.5f);
        foreach(GameObject proj in projectiles)
        {
            if (proj != null)
                Destroy(proj);
        }
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }

    IEnumerator circleStrike()
    {
        var l = Instantiate(laser, transform.position, Quaternion.identity);
        l.transform.position = transform.position + (player.transform.position - transform.position) / 2f;
        l.transform.LookAt(player.transform.position);
        l.transform.localScale = new Vector3(1, 1, Vector3.Distance(player.transform.position, transform.position));
        Destroy(l, 0.1f);
        player.GetComponent<Renderer>().material.color = Color.blue;
        player.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        var s = Instantiate(largeBullet, transform.position, Quaternion.identity);
        s.transform.LookAt(player.transform.position);
        while (Vector3.Distance(player.transform.position, s.transform.position) > escapeDistance)
        {
            yield return null;
        }
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1.75f);
        isAttacking = false;
    }

    IEnumerator Summon()
    {
        for (int i = 0; i < amountPerSummon; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int animalIndex = Random.Range(0, planePrefabs1.Length);
            var SummonedPrefab = Instantiate(planePrefabs1[animalIndex], spawnPos, planePrefabs1[animalIndex].transform.rotation);
            SummonedPrefab.transform.Rotate(0, rotation, 0);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < amountPerSummon; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int animalIndex = Random.Range(0, planePrefabs1.Length);
            var SummonedPrefab = Instantiate(planePrefabs1[animalIndex], spawnPos, planePrefabs1[animalIndex].transform.rotation);
            SummonedPrefab.transform.Rotate(0, rotation, 0);
        }
        yield return new WaitForSeconds(3f);
        isAttacking = false;
    }

    void OnDestroy()
    {
        foreach (GameObject proj in projectiles)
        {
            if (proj != null)
                Destroy(proj);
        }
    }
}
