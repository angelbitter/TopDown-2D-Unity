using UnityEngine;

public class MovableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private float moveSpeed;

    private Player player;
    private float moveDistance = 1f;
    private Rigidbody2D rb;
    private Vector3 targetPosition;
    private Vector3 newPosition;
    private float radioNewPosition = 0.45f;
    private bool isMoving = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = rb.position;
    }
    
    private void FixedUpdate()
    {
        if (!isMoving) return;

        rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime));

        if (Vector3.Distance(rb.position, targetPosition) < 0.01f)
        {
            rb.position = targetPosition;
            isMoving = false;
        }
    }

    public void Interact()
    {
        if (isMoving) return;

        // Buscar jugador
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        Vector3 playerPos = player.transform.position;
        Vector3 currentPos = rb.position;

        // Calcular dirección desde el jugador hacia el objeto
        Vector3 rawDirection = (currentPos - playerPos).normalized;

        // Redondear la dirección a uno de los 4 ejes cardinales
        Vector3 moveDir = GetCardinalDirection(rawDirection);

        // Calcular destino
        newPosition = currentPos + moveDir * moveDistance;
        Collider2D colliderNewPosition = Physics2D.OverlapCircle(newPosition, radioNewPosition);
        //Solo movemos el objeto si no hay colliders en destino o si el destino es un interruptor
        if (colliderNewPosition == null || colliderNewPosition.gameObject.CompareTag("Switch"))
        {
            targetPosition = newPosition;
        }
        isMoving = true;
    }

    private Vector3 GetCardinalDirection(Vector3 dir)
    {
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            return new Vector3(Mathf.Sign(dir.x), 0, 0); // Izquierda o derecha
        }
        else
        {
            return new Vector3(0, Mathf.Sign(dir.y), 0); // Arriba o abajo
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(newPosition, radioNewPosition);
    }
}
