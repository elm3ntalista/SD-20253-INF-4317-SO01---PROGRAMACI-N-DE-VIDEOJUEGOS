using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleEnemy : MonoBehaviour
{
    [SerializeField] private float velocidad = 2f;
    [SerializeField] private float distanciaMovimiento = 5f;

    private Vector3 puntoInicial;
    private bool moviendoseDerecha = true;

    void Start()
    {
        puntoInicial = transform.position;
    }

    void Update()
    {
        MoverEnemigo();
    }

    private void MoverEnemigo()
    {
        float limiteDerecho = puntoInicial.x + distanciaMovimiento;
        float limiteIzquierdo = puntoInicial.x - distanciaMovimiento;
        Vector3 escalaActual = transform.localScale;

        if (moviendoseDerecha)
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);

            if (transform.position.x >= limiteDerecho)
            {
                moviendoseDerecha = false;
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);

            if (transform.position.x <= limiteIzquierdo)
            {
                moviendoseDerecha = true;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ReiniciarJuego();
        }
    }

    public void ReiniciarJuego()
    {
        string nombreEscenaActual = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nombreEscenaActual);
    }
}