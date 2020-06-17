//
// Spawning Pool for Unity
// (c) 2016 Digital Ruby, LLC
// Source code may be used for personal or commercial projects.
// Source code may NOT be redistributed or sold.
// 
// http://www.digitalruby.com/unity-plugins/
//

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace DigitalRuby.Pooling
{
    public class SpawningPoolDemoScript : MonoBehaviour
    {
        public Dropdown Options;
        public Button SpawnButton;
        public Button RegularButton;
        public Text Results;
        public GameObject[] Prefabs;

        private readonly List<GameObject> regular = new List<GameObject>();

        private void Start()
        {
            UpdateResults(0.0);
        }

        private void Cleanup()
        {
            SpawningPool.RecycleActiveObjects();
            foreach (GameObject obj in regular)
            {
                GameObject.Destroy(obj);
            }
            regular.Clear();

            // note- to send just one object back to the cache, call SpawningPool.ReturnToCache. This is an extension method for GameObject.
        }

        private void UpdateResults(double milliseconds)
        {
            Results.text = "Time: " + milliseconds.ToString("0.00") + "ms" + System.Environment.NewLine +
                (SpawningPool.ActiveCount + regular.Count) + " active." + System.Environment.NewLine +
                SpawningPool.CacheCount + " cached. Instantiate count: " + PooledObjectScript.instantiatedCount +
                ", Spawn count: " + PooledObjectScript.spawnCount + ", Return to pool count: " + PooledObjectScript.returnToPoolCount;
        }

        public void SpawnButtonClicked()
        {
            Cleanup();
            string key = Options.options[Options.value].text;

            System.Diagnostics.Stopwatch w = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                // get or create and object from cache
                GameObject obj = SpawningPool.CreateFromCache(key);
                if (obj == null)
                {
                    Debug.LogErrorFormat("Unable to find object for key: {0}", key);
                    return;
                }
                // random position and rotation
                Vector3 pos = Random.onUnitSphere;
                obj.transform.position = pos * UnityEngine.Random.Range(-5.0f, 5.0f);
                obj.transform.rotation = Random.rotation;
            }

            w.Stop();

            UpdateResults(w.Elapsed.TotalMilliseconds);
        }

        public void RegularButtonClicked()
        {
            Cleanup();
            GameObject template = Prefabs[Options.value];

            System.Diagnostics.Stopwatch w = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                // copy the prefab
                GameObject obj = GameObject.Instantiate(template);

                // hide it
                obj.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;

                // random position and rotation
                Vector3 pos = Random.onUnitSphere;
                obj.transform.position = pos * UnityEngine.Random.Range(-5.0f, 5.0f);
                obj.transform.rotation = Random.rotation;
                regular.Add(obj);
            }

            w.Stop();

            UpdateResults(w.Elapsed.TotalMilliseconds);
        }

        public void ReloadLevelClicked()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0, UnityEngine.SceneManagement.LoadSceneMode.Single);
            PooledObjectScript.instantiatedCount = PooledObjectScript.spawnCount = PooledObjectScript.returnToPoolCount = 0;
        }
    }
}
