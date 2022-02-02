using Assets.Script.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Capacites.MinionAttacks;

public class LandMine : MonoBehaviour
{
    [SerializeField]
    private float TimeToLive;
    [SerializeField]
    private float InvisibleTimer;
    [SerializeField]
    private Color TargetColor;
    [SerializeField]
    private GameObject ExplosionPrefab;
    public GameObject parent;
    private int damage;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (!GameConfiguration.isDemo)
            damage = (int)Damage.veryStrong;
        else
            damage = GameConfiguration.damageDemoBaseAttack;

        StartCoroutine(Invisible());
        Destroy(gameObject, TimeToLive);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") && collision.gameObject != parent)
        {
            Debug.Log("Boom");
            GameObject explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            explosion.transform.SetParent(transform.parent);
            Destroy(gameObject);

            Player enemy = collision.gameObject.GetComponent<Player>();
            enemy.HurtPlayer(damage);
        }
    }

    private IEnumerator Invisible()
    {
        sr.color = TargetColor;

        yield return new WaitForSeconds(InvisibleTimer);

        sr.color = Color.white;
    }

    
}
