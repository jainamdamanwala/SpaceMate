using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float bulletforce = 20f;
    public GameObject ImpactEffect;
    public GameObject ImpactEffectPoint;

    private Transform player;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, bulletforce * Time.deltaTime);
        Physics2D.IgnoreLayerCollision(layer1: 12, layer2: 12);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {

            GameObject blast = Instantiate(ImpactEffect ,ImpactEffectPoint.transform.position, ImpactEffectPoint.transform.rotation);
            Destroy(blast,1f);
            Destroy(gameObject);
        }
    }
}
