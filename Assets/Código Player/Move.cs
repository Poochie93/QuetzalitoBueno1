using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
public Vector3 delta = new Vector3(0.0f, 0.0f, 0.0f), velocidad, escala = new Vector3();
readonly Vector3 escalaIni = new Vector3(2.5f,2.5f,2.5f);
//Y agregar las siguientes líneas de código al método de actualización

void Start(){
    escala = escalaIni;
}

void Update()
{
delta.x = Input.GetAxis("Horizontal");
if (delta.x > 0){
    escala.x = escalaIni.x;
    gameObject.GetComponent<Animator>().SetInteger("EstadosPlayer", 1);
}

else if (delta.x <0) {
escala.x =- escalaIni.x;
            gameObject.GetComponent<Animator>().SetInteger("EstadosPlayer", 1);
        }
else if (delta.x == 0)
        {
            gameObject.GetComponent<Animator>().SetInteger("EstadosPlayer", 0);
        }

delta.x *= velocidad.x;
 
 
transform.localScale = escala;


transform.Translate(delta);
}
}