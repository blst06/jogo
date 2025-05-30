using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        Application.Quit();
        Debug.Log("Jogo fechado.");
    }

    // 👇 AQUI ESTÁ O Update(), no final da classe
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool estaAtivo = painelMenuInicial.activeSelf;
            painelMenuInicial.SetActive(!estaAtivo);
            painelOpcoes.SetActive(false);
        }
    }
}
