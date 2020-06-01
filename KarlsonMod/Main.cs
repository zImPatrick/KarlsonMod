using UnityEngine;
using System;
using System.IO;
using System.Linq;
namespace KarlsonMod
{
    class Main : MonoBehaviour
    {
        bool airjump = false;
        public static double Version = 1.0;
        string t = "KarlsonMod";
        private PlayerMovement _player;
        public void Awake()
        {

        }
        public void Update()
        {
            _player = PlayerMovement.Instance;
            if (_player == null) return;
            if (airjump) _player.grounded = true;
        }
        public void OnGUI()
        {
            GUI.Label(new Rect(20, 20, 1920, 20), t);
            if (_player != null) GUI.Label(new Rect(20, 40, 1920, 20), 
                "x: " + _player.transform.localPosition.x + 
                ", y: " + _player.transform.localPosition.y + 
                ", z: " + _player.transform.localPosition.z);

            if (_player != null && _player.paused != true) return;
            if(GUI.Button(new Rect(20, 60, 180, 20), "load custom level"))
            {
                foreach (Pickup pickup in FindObjectsOfType<Pickup>()) { Destroy(pickup.gameObject); }
                foreach (Barrel barrel in FindObjectsOfType<Barrel>()) { Destroy(barrel.gameObject); }
                foreach (GameObject go in Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.layer == LayerMask.NameToLayer("Enemy"))) { Destroy(go); }
                foreach (GameObject go in Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.layer == LayerMask.NameToLayer("Ground"))) { Destroy(go); };
                foreach (GameObject go in Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.StartsWith("Table"))) { Destroy(go); };


                // warning: the code you are about to analyse is complete shit.
                String text = File.ReadAllText(Directory.GetCurrentDirectory()+"\\Export.txt");
                String[] lines = text.Split(new string[] { "\n" }, StringSplitOptions.None);

                Material platformMaterial = Resources.FindObjectsOfTypeAll<Material>().Where(obj => obj.name == "Prototype_512x512_Grey3").FirstOrDefault();
                Material barrelMaterial = Resources.FindObjectsOfTypeAll<Material>().Where(obj => obj.name == "Barrel").FirstOrDefault();

                foreach (String line in lines)
                {
                    String[] parts = line.Split(new string[] { "|" }, StringSplitOptions.None);
                    Console.WriteLine("Name: " + parts[0]);
                    Console.WriteLine("X: " + parts[1]);
                    Console.WriteLine("Y: " + parts[2]);
                    Console.WriteLine("Z: " + parts[3]);
                    Vector3 loc = Helper.StringToVec3(parts[1], parts[2], parts[3]);
                    Vector3 scale = Helper.StringToVec3(parts[4], parts[5], parts[6]);
                    Quaternion rot = Quaternion.Euler(Helper.StringToVec3(parts[7], parts[8], parts[9]));

                    GameObject gameObject;
                    if (parts[0] == "Platform")
                    {
                        gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        gameObject.layer = LayerMask.NameToLayer("Ground");
                        gameObject.name = parts[0];
                        gameObject.transform.localPosition = loc;
                        gameObject.transform.localScale = scale;
                        gameObject.GetComponent<Renderer>().material = platformMaterial;
                    } else if (parts[0] == "KarlsonSpawnpoint")
                    {
                        _player.transform.localPosition = loc; continue;
                    } else if (parts[0] == "Milk")
                    {
                        gameObject = GameObject.FindObjectOfType<Milk>().gameObject;
                        scale = gameObject.transform.localScale;
                    } else if (parts[0] == "Barrel")
                    {
                        gameObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                        gameObject.layer = LayerMask.NameToLayer("Ground");
                        gameObject.AddComponent<Barrel>();
                        gameObject.GetComponent<Renderer>().material = barrelMaterial;
                    } else continue;

                     
                    gameObject.transform.localPosition = loc;
                    gameObject.transform.localScale = scale;
                    gameObject.transform.localRotation = rot;






                }

            }
            if (GUI.Button(new Rect(20, 80, 180, 20), "be gone enemies"))
            {
                
                foreach(Enemy enemy in FindObjectsOfType<Enemy>())
                {
                    enemy.DropGun(new Vector3(0, 0, 0));
                }
            }
            if(GUI.Button(new Rect(20, 100, 180, 20), "toggle airjump")) {
                airjump = !airjump;
                Console.WriteLine("airjump: " + airjump);
            }
            if (GUI.Button(new Rect(20, 120, 180, 20), "dump"))
            {
                String a = "";
                foreach (/*GameObject go in Resources.FindObjectsOfTypeAll<GameObject>()*/Material mat in Resources.FindObjectsOfTypeAll(typeof(Material))) {
                    a += mat.name + "\n";
                }
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\dump.txt", a);
            }
        }
    }
}