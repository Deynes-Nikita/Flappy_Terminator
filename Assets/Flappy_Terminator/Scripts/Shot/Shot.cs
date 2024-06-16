using UnityEngine;

namespace Flappy_Terminator
{
    public abstract class Shot : MonoBehaviour
    {
        [SerializeField] protected BulletSpawner BulletSpawner;
        [SerializeField] protected float RechargeTime;
    }
}
