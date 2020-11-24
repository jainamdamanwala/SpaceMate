using UnityEngine;

public class Range : MonoBehaviour
{
    [SerializeField] private float scanRadius = 3f;
    [SerializeField] private LayerMask layer;
    private Collider2D target;
    public float offSet = 180f;

    private void Update()
    {
        CheckEnvironment();
        LookAtTarget();
    }
    
    private void CheckEnvironment()
    {
        target = Physics2D.OverlapCircle(transform.position, scanRadius, layer);
    }

    private void LookAtTarget()
    {
        if(target != null)
        {
            Vector2 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - offSet;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }
}
