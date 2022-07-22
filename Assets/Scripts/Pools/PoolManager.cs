using UnityEngine;

namespace Pools
{
    public static class PoolsManager
    {
        private static PoolPart[] pools;
        private static GameObject objectsParent;

        [System.Serializable]
        public struct PoolPart
        {
            public string name; //имя префаба
            public Block prefab; //сам префаб, как образец
            public int count; //количество объектов при инициализации пула
            public PoolBlocks ferula; //сам пул
        }

        public static void Initialize(PoolPart[] newPools)
        {
            pools = newPools; //заполняем информацию
            objectsParent = new GameObject();
            objectsParent.name = $"Pool_" + newPools[0].name; //создаем на сцене объект Pool, чтобы не засорять иерархию
            for (int i = 0; i < pools.Length; i++)
            {
                if (pools[i].prefab != null)
                {
                    pools[i].ferula = new PoolBlocks(); //создаем свой пул для каждого префаба
                    pools[i].ferula
                        .Initialize(pools[i].count, pools[i].prefab,
                            objectsParent.transform); //инициализируем пул заданным количество объектов
                }
            }
        }

        public static GameObject GetObject(string name, Vector3 position, Quaternion rotation)
        {
            GameObject result = null;
            if (pools != null)
            {
                for (int i = 0; i < pools.Length; i++)
                {
                    if (string.Compare(pools[i].name, name) == 0)
                    {
                        //если имя совпало с именем префаба пула
                        result = pools[i].ferula.GetObject().gameObject; //дергаем объект из пула
                        result.transform.position = position;
                        result.transform.rotation = rotation;
                        result.SetActive(true); //выставляем координаты и активируем
                        return result;
                    }
                }
            }

            return result; //если такого объекта нет в пулах, вернет null
        }
    }
}