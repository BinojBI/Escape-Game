Spawning Pool (c) 2016 Digital Ruby, LLC
Created by Jeff Johnson

http://www.digitalruby.com/unity-plugins/

Spawning Pool is a simple, yet very powerful caching and pooling system for Unity. Even for simple objects like cubes, spheres, etc. the performance is 4x better what you get from creating from a prefab. This performance gain only increases as your prefabs become more complex.

Spawning Pool works by taking a set of prefabs (template objects) and allowing you to make copies of them very quickly.

Setup
- Add the spawning pool script to your start scene only. You do NOT need to add the spawning pool script to any additional scenes as it lives for the lifetime of your game.
- In the inspector, add prefabs, with keys, to the spawning pool script for any prefabs that you want to enable caching / pooling on. Be sure to add prefabs for all the levels / scenes in your games.
- Do NOT add GameObject's from your scene in the inspector to the script, only add prefabs.
- Call SpawningPool.AddPrefab for each prefab that you want to pool that was not added to the spawning pool script in the inspector. It's probably easiest to just add them in the inspector, but for advanced users this scripting interface is also provided.
- The keys for each prefab must be unique. I'd suggest making a bunch of string constants in your code so you avoid typos, etc.
- Add SpawningPoolScript to an empty game object with no children and at the root of the hierarchy for best results, since this object will live for the life-time of your game.

Scripting
- Be sure to add "using DigitalRuby.Pooling" to any script files that need to do use this script
- Call SpawningPool.CreateFromCache and pass the key for the type of prefab you want to create
- Call SpawningPool.ReturnToCache (extension method for GameObject). This does NOT destroy the game object. It recycles and deactivates it and puts it back in the cache.
- (Optional) Implement IPooledObject on a script in your prefab to get notifications about spawning pool events: PooledObjectInstantiated, PooledObjectSpawned and PooledObjectReturnedToPool.
- SpawningPoolScript calls DontDestroyOnLoad on all objects, so they persist for the life of your game until manually removed by you.
- Call SpawningPool.RemovePrefab if you want to remove a prefab and its cached objects and active objects from memory and destroy the cached and active objects
- The SpawningPool class has additional methods to clear everything, report stats, etc.
- When SceneManager sceneLoaded is called, the spawning pool script clears out all active objects and puts them back into the cache. You can change this via script property ReturnToCacheOnLevelLoad.
- SpawningPool.DefaultHideFlags can be changed to provide different hide flags to newly created objects. The default is HideFlags.HideInHierarchy | HideFlags.HideInInspector.
- There is no limit to the number of cached objects. Putting a limit would not help because you would need to spawn an instance of a prefab if the limit was hit, using the same amount of memory as an unlimited cache size.

See DemoSceneInspector and SpawningPoolDemoScript.cs for a complete demo.

I'm Jeff Johnson and I created Spawning Pool just for you. Please email support@digitalruby.com if you have feedback or bug reports.

- Jeff Johnson
