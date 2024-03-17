using UnityEngine;

public class Enemy : MonoBehaviour {
      
    public Transform jogador;
    public float velocidade = 5f; 

    void Update(){
        Vector3 posicaoJogador = jogador.position;
        Vector3 novaPosicao = Vector3.MoveTowards(transform.position, posicaoJogador, velocidade * Time.deltaTime);
        transform.position = new Vector3(novaPosicao.x, transform.position.y, novaPosicao.z);
        transform.LookAt(new Vector3(jogador.position.x, transform.position.y, jogador.position.z));
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Player")){
            collision.gameObject.SetActive(false);
            Debug.Log("Colidiu com o inimigo!");
        }
    } 
}