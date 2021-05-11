using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Map
{
    public class LiveEnemyForClients : MonoBehaviour
    {
        [ModAPI.Attributes.ExecuteOnGameStart]
        public static void Init()
        {
            liveEnemies = new List<GameObject>();
        }
        internal static List<GameObject> liveEnemies;
        void OnEnable()
        {
            if (!liveEnemies.Contains(gameObject))
                liveEnemies.Add(gameObject);
        }  
        void Start()
        {
            if (!liveEnemies.Contains(gameObject))
                liveEnemies.Add(gameObject);
        }
        void OnDisable()
        {
            if (liveEnemies.Contains(gameObject))
                liveEnemies.Remove(gameObject);
        }
        void OnDelete()
        {
            if (liveEnemies.Contains(gameObject))
                liveEnemies.Remove(gameObject);
        }

    }
    public class EnemyWeaponMeleeExtension : enemyWeaponMelee
    {
        protected override void Start()
        {
            if (transform.root.gameObject.GetComponent<LiveEnemyForClients>() == null)
                transform.root.gameObject.AddComponent<LiveEnemyForClients>();
            base.Start();
        }
    }
    public class MutantAINetworkExtension : mutantAI_net
    {
        protected override void Start()
        {
            if (transform.root.gameObject.GetComponent<LiveEnemyForClients>() == null)
                transform.root.gameObject.AddComponent<LiveEnemyForClients>();
            base.Start();
        }
    }
}
