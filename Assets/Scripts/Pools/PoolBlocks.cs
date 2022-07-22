using System.Collections.Generic;
using UnityEngine;

namespace Pools
{
    //[AddComponentMenu("Pool/ObjectPooling ")]
    public class PoolBlocks : MonoBehaviour
    {
        List<Block> objects;
        Transform objectsParent;

        void AddObject(Block sample, Transform objects_parent)
        {
            GameObject temp = GameObject.Instantiate(sample.gameObject);
            temp.name = sample.name;
            temp.transform.SetParent(objects_parent);
            objects.Add(temp.GetComponent<Block>());
            temp.SetActive(false);
        }

        public void Initialize(int count, Block sample, Transform objects_parent)
        {
            objects = new List<Block>(); //инициализируем List
            objectsParent = objects_parent; //инициализируем локальную переменную для последующего использования
            for (int i = 0; i < count; i++)
            {
                AddObject(sample, objects_parent); //создаем объекты до указанного количества
            }
        }

        public Block GetObject()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].gameObject.activeInHierarchy == false)
                {
                    return objects[i];
                }
            }

            AddObject(objects[0], objectsParent);
            return objects[objects.Count - 1];
        }
    }
}