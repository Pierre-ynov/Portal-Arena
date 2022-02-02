using Assets.Script.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    [SerializeField]
    private float TimeToLive;
    [SerializeField]
    private float InvisibleTimer;
    [SerializeField]
    private Color TargetColor;
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
        }
    }

    private IEnumerator Invisible()
    {
        sr.color = TargetColor;

        yield return new WaitForSeconds(InvisibleTimer);

        sr.color = Color.white;
    }

    
}
