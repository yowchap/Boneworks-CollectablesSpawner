using MelonLoader;
using ModThatIsNotMod;
using ModThatIsNotMod.BoneMenu;
using StressLevelZero.Data;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;

namespace YOWC.SpawnAllCollectables
{
    public static class BuildInfo
    {
        public const string Name = "Spawn All Collectables"; // Name of the Mod.  (MUST BE SET)
        public const string Author = "YOWChap"; // Author of the Mod.  (Set as null if none)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class Main : MelonMod
    {
        private List<SpawnableObject> collectables = new List<SpawnableObject>();
        private Vector3 randomOffset => new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-0.5f, 1f), Random.Range(-2.5f, 2.5f));

        // These ones have item balls instead
        private string[] blockedItems = new string[]
        {
            "Monitor",
            "Shopping Cart",
            "Melon",
            "Plant",
            "Wooden Crate Destructable",
            "Indestructable 2m Crate",
            "Hexagonal Container",
            "Concrete Barrier",
            "Cardboard Box",
            "Indestructable 1m Crate",
            "Pallet Jack",
            "Vehicle OmniWay",
            "The Wasp"
        };


        public override void OnApplicationStart()
        {
            MenuCategory category = MenuManager.CreateCategory("Collectables Spawner", Color.cyan);
            category.CreateFunctionElement("Spawn All Collectables", Color.white, new Action(SpawnCollectables));
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (buildIndex == 1) // Main menu
            {
                UnlockableDisplayCase displayCase = GameObject.FindObjectOfType<UnlockableDisplayCase>();
                if (displayCase != null)
                {
                    collectables.AddRange(displayCase.spawn_fantasy);
                    collectables.AddRange(displayCase.spawn_melee);
                    collectables.AddRange(displayCase.spawn_misc.Where(x => !x.title.ToLower().Contains("gym ") && !blockedItems.Contains(x.title)).ToArray());
                    collectables.AddRange(displayCase.spawn_physics.Where(x => !blockedItems.Contains(x.title)).ToArray());
                    collectables.AddRange(displayCase.spawn_ranged);
                }

                SpawnableObject[] itemBalls = Resources.FindObjectsOfTypeAll<SpawnableObject>().Where(x => x.title.ToLower().Contains("item ball") || x.title.ToLower().Contains("capsule ")).ToArray();
                collectables.AddRange(itemBalls);
            }
        }

        private void SpawnCollectables()
        {
            Vector3 headPos = Player.GetPlayerHead().transform.position;
            foreach (SpawnableObject spawnable in collectables)
            {
                GameObject newObj = GameObject.Instantiate(spawnable.prefab, headPos + randomOffset, Quaternion.identity);
                newObj.SetActive(true);
            }
            MenuManager.CloseMenu();
        }
    }
}
