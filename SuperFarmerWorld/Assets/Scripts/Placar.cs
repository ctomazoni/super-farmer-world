using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placar : MonoBehaviour
{
    public int vidas;
    public int ovelhasRestantes;
    private UnityEngine.UI.Text status;

    // Start is called before the first frame update
    void Start()
    {
        status = GameObject.FindGameObjectWithTag("Status").GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ovelhasRestantes > 0)
        {
            status.text = ovelhasRestantes.ToString() + " Ovelha(s) restante(s)";
        }
        else
        {
            status.text = "Você venceu!";
            status.color = Color.green;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }

        if (vidas == 2)
        {
            Destroy(GameObject.FindGameObjectWithTag("Vida3"));
        }
        else if (vidas == 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("Vida3"));
            Destroy(GameObject.FindGameObjectWithTag("Vida2"));
        }
        else if (vidas < 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("Vida3"));
            Destroy(GameObject.FindGameObjectWithTag("Vida2"));
            Destroy(GameObject.FindGameObjectWithTag("Vida1"));
            status.text = "Você perdeu!";
            status.color = Color.red;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }
}
