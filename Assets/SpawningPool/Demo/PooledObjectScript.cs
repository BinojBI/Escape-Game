//
// Spawning Pool for Unity
// (c) 2016 Digital Ruby, LLC
// Source code may be used for personal or commercial projects.
// Source code may NOT be redistributed or sold.
// 
// http://www.digitalruby.com
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.Pooling
{
    public class PooledObjectScript : MonoBehaviour, IPooledObject
    {
        internal static int instantiatedCount;
        internal static int spawnCount;
        internal static int returnToPoolCount;

        public void PooledObjectInstantiated()
        {
            instantiatedCount++;
        }

        public void PooledObjectSpawned()
        {
            spawnCount++;
        }

        public void PooledObjectReturnedToPool()
        {
            returnToPoolCount++;
        }
    }
}
