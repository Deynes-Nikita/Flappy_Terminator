using UnityEngine;
using UnityEngine.Pool;

namespace Flappy_Terminator
{
    public abstract class Spawner <T> : MonoBehaviour where T : MonoBehaviour
    {
        protected ObjectPool<T> Pool;

        private void Awake()
        {
            CreatePool();
        }

        protected abstract T CreateFunc();
        protected abstract void ActionOnGet(T spawnedObject);
        protected abstract void ActionOnRelease(T spawnedObject);
        protected abstract void ActionOnDestroy(T spawnedObject);
        protected abstract void GetSpawnedObject(Vector2 position);
        protected abstract void Release(T spawnedObject);

        private void CreatePool()
        {
            Pool = new ObjectPool<T>
                (
                createFunc: () => CreateFunc(),
                actionOnGet: (spawnedObject) => ActionOnGet(spawnedObject),
                actionOnRelease: (spawnedObject) => ActionOnRelease(spawnedObject),
                actionOnDestroy: (spawnedObject) => ActionOnDestroy(spawnedObject),
                collectionCheck: false
                );
        }
    }
}
