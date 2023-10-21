using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public float speed = 2f;
    private bool moveRight = true;

    private void Update()
    {
        Vector2 movementDirection = moveRight ? Vector2.right : Vector2.left;
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tube"))
        {
            moveRight = !moveRight;
        }
    }
}

public class Hongo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Agrega una vida al jugador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.AddLife();
            }

            // Aumenta la velocidad del jugador en un 10%
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.IncreaseSpeed(1.1f);
            }

            // Activa la animación "grow up"
            PlayerAnimator playerAnimator = other.GetComponent<PlayerAnimator>();
            if (playerAnimator != null)
            {
                playerAnimator.ActivateGrowUpAnimation();
            }

            // Destruye el hongo
            Destroy(gameObject);
        }
    }

    public void LoseLife(PlayerMovement playerMovement, PlayerAnimator playerAnimator)
    {
        // Reduce la velocidad del jugador al valor original
        playerMovement.ResetSpeed();

        // Activa la animación "down"
        playerAnimator.ActivateDownAnimation();
    }
}

public class Estrella : MonoBehaviour
{
    public float duration = 40.0f; // Duración de la invencibilidad en segundos

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Activa la invencibilidad y duplica la velocidad
            PlayerInvincibility playerInvincibility = other.GetComponent<PlayerInvincibility>();
            if (playerInvincibility != null)
            {
                playerInvincibility.ActivateInvincibility(duration);
            }

            // Activa la animación "Star"
            PlayerAnimator playerAnimator = other.GetComponent<PlayerAnimator>();
            if (playerAnimator != null)
            {
                playerAnimator.ActivateStarAnimation();
            }

            // Destruye la estrella
            Destroy(gameObject);

            // Inicia una corrutina para desactivar la invencibilidad 
            StartCoroutine(DeactivateInvincibilityAfterDuration(playerInvincibility));
        }
    }

    private IEnumerator DeactivateInvincibilityAfterDuration(PlayerInvincibility playerInvincibility)
    {
        yield return new WaitForSeconds(duration);
        playerInvincibility.DeactivateInvincibility();
    }
}