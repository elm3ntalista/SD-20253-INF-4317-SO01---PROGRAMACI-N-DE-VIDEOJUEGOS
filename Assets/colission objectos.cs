using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private ContadorJuego contadorJuego;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            contadorJuego.SumarPuntos(gameObject.tag);
            Destroy(gameObject);
        }
    }
}
