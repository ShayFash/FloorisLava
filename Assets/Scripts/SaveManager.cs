using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class SaveManager : MonoBehaviour
    {
        [SerializeField]public  GameObject[] objectsToSave;

        [System.NonSerialized]public List<Saveable> saveableObjects;
        
        
        
        
        
        private void Awake()
        {
            saveableObjects=new List<Saveable>();
    
            foreach (var objectToSave in objectsToSave)
            {
           
                Saveable saveableObject = objectToSave.gameObject.GetComponent<Saveable>();
                if (saveableObject!= null)
                {
                    saveableObjects.Add(saveableObject);
                }

            }
            
        }

        public void addSaveableObject(Saveable objToSave)
        {
            saveableObjects.Add(objToSave);
        }

        public void Update(){
            Debug.Log("fsafdsa");
            if(Input.GetKeyDown(KeyCode.S)){
                save();
            }
             if(Input.GetKeyDown(KeyCode.L)){
                load();
            }
        }

        /**&
         * It was not working if I directly called save method from the button
         * Couldn't figure out why but probably because the onclick method saves an instance of the function before
         * the SaveManager gameobject gets fully instantiated
         * So had to use a singleton class to access the savemanager and then call the save function from there
         */
        public void saveFromButton()
        {
            SaveManagerAccess.getInstance().save();
        }
        
        public void loadFromButton()
        {
            SaveManagerAccess.getInstance().load();
        }

        public void save()
        {
            Debug.Log("Saving...");
            try
            {
                SaveSystem.saveData(saveableObjects);
                Debug.Log("Saved");
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
            
        }

        public void load()
        {
            try
            {
            Debug.Log("Loading...");
            SaveSystem.loadData(saveableObjects);
            Debug.Log("Loading Completed");

            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

    }
