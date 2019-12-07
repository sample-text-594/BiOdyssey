using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlanetBuilder : MonoBehaviour {
    public Transform[] spawners;

    public Creature[] creatures;
    public Gradient creature1Colors;
    public Gradient creature2Colors;

    public GameObject enemyCreature;

    public PlayerController playerController;

    void Start() {
        Planet p = gameObject.AddComponent<Planet>();

        p.shapeSettings = Settings.planetSettings.shapeSettings;
        p.colourSettings = Settings.planetSettings.colourSettings;
        p.floraSettings = Settings.planetSettings.floraSettings;

        p.resolution = 120;
        p.shapeSettings.planetRadius = 50;
        p.floraSettings.generateFlora = true;

        p.GeneratePlanet();

        switch (Settings.planetSettings.tag) {
            case "Fire":
                Debug.Log("Fire");
                playerController.energyConsumeMultiplier *= 2;
                break;
            case "Poison":
                Debug.Log("Poison");
                playerController.poisonDamageEnabled = true;
                break;
            case "Death":
                Debug.Log("Death");
                GameObject enemy = Instantiate(enemyCreature);
                MonsterController mc = enemy.GetComponent<MonsterController>();
                mc.target = playerController;
                mc.sl = GetComponent<SceneLoader>();
                break;
            default:
                GameObject g = new GameObject("creatures");
                g.transform.SetParent(p.transform);

                for (int i = 0; i < spawners.Length; i += 2) {
                    GameObject creature;

                    if (Settings.system.planets[Settings.actualPlanet].creatures[i / 2].Equals("")) {
                        creature = BuildCreatureRandom();
                        Settings.system.planets[Settings.actualPlanet].creatures[i / 2] = creature.name;
                    } else {
                        creature = BuildCreature(i / 2);
                    }

                    for (int j = 0; j < 2; j++) {
                        creature.transform.SetParent(g.transform);
                        creature.transform.position = spawners[i + j].position;
                        if (i + j == 5) {
                            creature.transform.localEulerAngles = new Vector3(creature.transform.localEulerAngles.x + 180, creature.transform.localEulerAngles.y, creature.transform.localEulerAngles.z);
                        }

                        NavMeshAgent nma = creature.GetComponent<NavMeshAgent>();
                        nma.Warp(creature.transform.position);
                        nma.updateUpAxis = true;

                        for (int k = 0; k < Random.Range(2, 4); k++) {
                            nma = Instantiate(creature).GetComponent<NavMeshAgent>();
                            nma.Warp(nma.transform.position);
                            nma.updateUpAxis = true;

                            nma.transform.SetParent(g.transform);
                        }
                    }
                }
                break;
        }
    }

    GameObject BuildCreatureRandom() {
        GameObject creature;
        Color col;

        int type = Random.Range(0, 2);
        creature = Instantiate(creatures[type].creaturePrefab);

        int rand = Random.Range(0, 5);
        Instantiate(creatures[type].part1[rand]).transform.SetParent(creature.transform);
        creature.name = "" + type + rand;

        rand = Random.Range(0, 5);
        Instantiate(creatures[type].part2[rand]).transform.SetParent(creature.transform);
        creature.name += rand;

        rand = Random.Range(0, 5);
        Instantiate(creatures[type].part3[rand]).transform.SetParent(creature.transform);
        creature.name += rand;

        rand = Random.Range(0, 5);
        Instantiate(creatures[type].part4[rand]).transform.SetParent(creature.transform);
        creature.name += rand;

        rand = Random.Range(0, 5);
        Instantiate(creatures[type].part5[rand]).transform.SetParent(creature.transform);
        creature.name += rand;

        if (type == 0) {
            col = creature1Colors.Evaluate(Random.Range(0f, 1f));

            foreach (MeshRenderer m in creature.GetComponentsInChildren<MeshRenderer>()) {
                m.material.SetColor("_BaseColor", col);
            }
        } else {
            col = creature2Colors.Evaluate(Random.Range(0f, 1f));

            foreach (SkinnedMeshRenderer m in creature.GetComponentsInChildren<SkinnedMeshRenderer>()) {
                m.material.SetColor("_BaseColor", col);
            }
        }

        return creature;
    }

    GameObject BuildCreature(int index) {
        GameObject creature;
        Color col;

        int type = int.Parse(Settings.system.planets[Settings.actualPlanet].creatures[index].Substring(0, 1));
        creature = Instantiate(creatures[type].creaturePrefab);

        int rand = int.Parse(Settings.system.planets[Settings.actualPlanet].creatures[index].Substring(1, 1));
        Instantiate(creatures[type].part1[rand]).transform.SetParent(creature.transform);
        creature.name = "" + type + rand;

        rand = int.Parse(Settings.system.planets[Settings.actualPlanet].creatures[index].Substring(2, 1));
        Instantiate(creatures[type].part2[rand]).transform.SetParent(creature.transform);
        creature.name += rand;

        rand = int.Parse(Settings.system.planets[Settings.actualPlanet].creatures[index].Substring(3, 1));
        Instantiate(creatures[type].part3[rand]).transform.SetParent(creature.transform);
        creature.name += rand;

        rand = int.Parse(Settings.system.planets[Settings.actualPlanet].creatures[index].Substring(4, 1));
        Instantiate(creatures[type].part4[rand]).transform.SetParent(creature.transform);
        creature.name += rand;

        rand = int.Parse(Settings.system.planets[Settings.actualPlanet].creatures[index].Substring(5, 1));
        Instantiate(creatures[type].part5[rand]).transform.SetParent(creature.transform);
        creature.name += rand;

        if (type == 0) {
            col = creature1Colors.Evaluate(Random.Range(0f, 1f));

            foreach (MeshRenderer m in creature.GetComponentsInChildren<MeshRenderer>()) {
                m.material.SetColor("_BaseColor", col);
            }
        } else {
            col = creature2Colors.Evaluate(Random.Range(0f, 1f));

            foreach (SkinnedMeshRenderer m in creature.GetComponentsInChildren<SkinnedMeshRenderer>()) {
                m.material.SetColor("_BaseColor", col);
            }
        }

        return creature;
    }
}