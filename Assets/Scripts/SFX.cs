using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    [SerializeField]private AudioSource jump;
    [SerializeField]private AudioSource walk;

    public float CurrentVolumen { get {  return jump.volume; } set { jump.volume = value; walk.volume = value; } }

    public void PlayJump()
    {
        jump.Play();
    }
    public void PlayWalk()
    {
        walk.Play();
    }
    public void StopWalk()
    {
        walk.Stop();
    }

    /// <summary>
    /// Agregando La abilidad de cambiar el volumen de los effectos de Sonido
    /// </summary>
    public void CambioVolumen(float volumen) 
    {
        jump.volume = volumen;
        walk.volume = volumen;
    }
}
