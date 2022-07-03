using System;
public class HashTable{
    private int TABLE_SIZE;
    string[] hash_table;

    ////Construtor
    public HashTable(){
        TABLE_SIZE = 100;
        hash_table = new string[TABLE_SIZE];
    }    

    ///Metódo Adicionar
    public bool Add( string key, string value){
        Node node = new Node(key,value);
        if(node == null){
            return false;
        }            
        int index = hashFunc(node.Key);            
        if(hash_table[index] != null){
            return false;
        }
        hash_table[index] = node.Key;
        return false;
    }

    //Função de espalhamento
    int hashFunc(string key){
        if(key == null)
            return 0;
        int lenght = key.Length;
        int hash_value =0;
        for(int i =0;i <lenght; i++){
            hash_value += key[i];
            hash_value = (hash_value * key[i])%TABLE_SIZE;
        }            
        return hash_value;            
    }
    ///Mostrar Tabela
    public void print_table(){
        for(int i =0; i < hash_table.Length ;i++){
            if(hash_table[i] != null){
                Console.WriteLine(hash_table[i]+" " + i);
            }
        }
    }
    //Verificar se contem um dado
    public bool Contains(string key){
        int index = hashFunc(key);
        if(hash_table[index] != null && (hash_table[index].Length == key.Length)){
            return true;
        }else{
            return false;
        }
    }
    class Node {
        string key;
        string value;

        public Node(string _key, string _value){
            this.key = _key;
            this.value = _value;
        }

        public string Key{
            get{
                return key;
            }
        }

        public string Value{
            get{
                 return value;
            }
        }
    }    
}