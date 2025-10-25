using UnityEngine;
using TMPro;

public class ContadorJuego : MonoBehaviour
{
    private int balas;
    private int carnes;
    private int pollos;

    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = $"Balas: {balas} | Carnes: {carnes} | Pollos: {pollos}";
    }

    public void SumarPuntos(string recurso)
    {
        if (recurso == "bala")
        {
            balas += 1;
        } else if (recurso == "carne")
        {
            carnes += 1;
        } else if (recurso == "pollo")
        {
            pollos += 1;
        }
    }
}
