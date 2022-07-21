using UnityEngine;

namespace Pools
{
    [AddComponentMenu("Pool/SetupPools")]
    public class SetupPools : MonoBehaviour {//обертка для управления статическим классом PoolManager
	
        [SerializeField] private PoolsManager.PoolPart[] pools; //структуры, где пользователь задает префаб для использования в пуле и инициализируемое количество 

        void OnValidate() {
            for (int i = 0; i < pools.Length; i++) {
                pools[i].name = pools[i].prefab.name; //присваиваем имена заранее, до инициализации
            }
        }

        void Awake() {
            Initialize ();
        }
        void Initialize () {
            PoolsManager.Initialize(pools); //инициализируем менеджер пулов
        }
    }
}
