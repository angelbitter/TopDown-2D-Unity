using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float interactionRadius;
    [SerializeField] private Canvas pauseCanvas;
    private float inputH;
    private float inputV;
    private Vector3 destinationPoint;
    private Vector3 interactPoint;
    private Vector3 lastInput;
    private bool isMoving = false;
    private Collider2D colliderInFront;
    private Animator animator;
    private bool interacting = false;
    public bool Interacting { get => interacting; set => interacting = value; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = GameManager.Instance.LastSavedPosition;
        animator.SetFloat("inputH", GameManager.Instance.LastSavedRotation.x);
        animator.SetFloat("inputV", GameManager.Instance.LastSavedRotation.y);
        destinationPoint = transform.position;
        interactPoint = transform.position + Vector3.down;
        interacting = false;
    }

    // Update is called once per frame
    void Update()
    {
        InputReading();
        Move();
        GameManager.Instance.PauseGame(pauseCanvas);
    }

    private void InputReading()
    {
        if (inputV == 0)
        {
            inputH = Input.GetAxisRaw("Horizontal");
        }
        if (inputH == 0)
        {
            inputV = Input.GetAxisRaw("Vertical");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }
    private void TryInteract()
    {
        colliderInFront = CheckInteractPoint();
        if (colliderInFront)
        {
            if (colliderInFront.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }
    }
    private void Move()
    {
        if ((inputH != 0 || inputV != 0) && !isMoving && !interacting)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("inputH", inputH);
            animator.SetFloat("inputV", inputV);
            lastInput = new Vector3(inputH, inputV, 0);
            destinationPoint = transform.position + lastInput;
            interactPoint = destinationPoint;

            colliderInFront = CheckInteractPoint();
            if (!colliderInFront)
            {
                StartCoroutine(MoveToDestination());
            } 
            else if(colliderInFront.gameObject.CompareTag("Door"))
            {
                if (colliderInFront.gameObject.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }
        else if (inputH == 0 && inputV == 0)
        {
            animator.SetBool("isMoving", false);
        }
    }
    IEnumerator MoveToDestination()
    {
        isMoving = true;
        while (transform.position != destinationPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinationPoint, movementSpeed * Time.deltaTime);
            yield return null;
        }
        interactPoint = transform.position + lastInput;
        isMoving = false;
    }

    private Collider2D CheckInteractPoint()
    {
        return Physics2D.OverlapCircle(interactPoint, interactionRadius);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactPoint, interactionRadius);
    }
}
