using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;

    private void Start()
    {
        currentLives = maxLives;
    }

    public void AddLife()
    {
        if (currentLives < maxLives)
        {
            currentLives++;
        }
    }

    public void LoseLife()
    {
        currentLives--;
        if (currentLives <= 0)
        {
            // Que pasa cuando el jugador se queda sin vidas
            // Mostrar un Game Over.
        }
    }
}
