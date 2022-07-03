using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;


public class Dicionario : MonoBehaviour
{
    public string readText;
    public TMP_InputField ifText;
    public TMP_Text scrowText;
    char[] divisores = {' ',',','.',';','-',':'};
    string entrada = "testes mais teste, hoje.";
    string arquivo;
    string[] arrayEntrada;
    Hashtable dicionario;
    List<string> naoConhecidas;

    // Start is called before the first frame update
    void Start(){
        naoConhecidas = new List<string>();
        dicionario = new Hashtable();
    }

    public void abrirArquivo(){
        string path = EditorUtility.OpenFilePanel("","","txt");
        string readText = System.IO.File.ReadAllText(path);
        ifText.text = "";
        ifText.text = readText;
        verificarTexto();
    }

    public void verificarTexto(){
        limparLista();
        preencherLista();            
        arquivo = ifText.text;
        arrayEntrada = arquivo.Split(divisores);
        foreach (string palavras in arrayEntrada){
            try{
                if (palavras != string.Empty){

                    if (!naoConhecidas.Contains(palavras)){
                        naoConhecidas.Add(palavras);
                        scrowText.text += palavras+"\n";
                    }
                }
            }
            catch (Exception e){
                Debug.Log($"Erro: {e.Message}");
            }
        }
        
    }
    
    public void adicionarPalavras(){
        arquivo += ifText.text;
        arrayEntrada = arquivo.Split(divisores);
        foreach (string palavras in arrayEntrada){
            try{
                if (palavras != string.Empty){

                    if (!dicionario.Contains(palavras)){
                        dicionario.Add(palavras, palavras.Length);
                    }
                }
            }
            catch (Exception e){
                Debug.Log($"Erro: {e.Message}");
            }
        }
        limparLista();
    }
    void limparLista(){
        naoConhecidas.Clear();
        scrowText.text = "";
    }

    void preencherLista(){
        
        if(dicionario.Count > 0){
            limparLista();
            foreach(string s in dicionario.Keys){
                naoConhecidas.Add(s);
            }
        }
        
    }
}
