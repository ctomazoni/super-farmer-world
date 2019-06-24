using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobo : MonoBehaviour
{
    public Transform DetectaLobo;
    public float distancia = 0;
    public bool olhandoParaDireita;
    public float velocidade = 3;

    // Start is called before the first frame update
    void Start()
    {
        olhandoParaDireita = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Patrulha();
    }

    private void Patrulha()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(DetectaLobo.position, Vector2.down, distancia);
        if (!groundInfo.collider)
        {
            if (olhandoParaDireita)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                olhandoParaDireita = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                olhandoParaDireita = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Placar").GetComponent<Placar>().vidas -= 1;
        }
    }
}
