using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlanetBuilder : MonoBehaviour {
    public Transform[] spawners;
    public Creature[] creatures;

    public Gradient creature1Colors;
    public Gradient creature2Colors;

    void Start() {
        Planet p = gameObject.AddComponent<Planet>();

        p.shapeSettings = Settings.planetSettings.shapeSettings;
        p.colourSettings = Settings.planetSettings.colourSettings;
        p.floraSettings = Settings.planetSettings.floraSettings;

        p.resolution = 120;
        p.shapeSettings.planetRadius = 50;
        p.floraSettings.generateFlora = true;

        p.GeneratePlanet();

        GameObject g = new GameObject("creatures");
        g.transform.SetParent(p.transform);

        for (int i = 0; i < spawners.Length; i++) {
            GameObject creature;
            Color col;

            if (i % 2 == 0) {
                creature = Instantiate(creatures[0].creaturePrefab);

                int rand = Random.Range(0, 5);
                Instantiate(creatures[0].part1[rand]).transform.SetParent(creature.transform);
                creature.name = "" + rand;

                rand = Random.Range(0, 5);
                Instantiate(creatures[0].part2[rand]).transform.SetParent(creature.transform);
                creature.name += rand;

                rand = Random.Range(0, 5);
                Instantiate(creatures[0].part3[rand]).transform.SetParent(creature.transform);
                creature.name += rand;

                rand = Random.Range(0, 5);
                Instantiate(creatures[0].part4[rand]).transform.SetParent(creature.transform);
                creature.name += rand;

                rand = Random.Range(0, 5);
                Instantiate(creatures[0].part5[rand]).transform.SetParent(creature.transform);
                creature.name += rand;

                col = creature1Colors.Evaluate(Random.Range(0f, 1f));
            } else {
                creature = Instantiate(creatures[1].creaturePrefab);

                int rand = Random.Range(0, 5);
                Instantiate(creatures[1].part1[rand]).transform.SetParent(creature.transform);
                creature.name = "" + rand;

                rand = Random.Range(0, 5);
                Instantiate(creatures[1].part2[rand]).transform.SetParent(creature.transform);
                creature.name += rand;

                rand = Random.Range(0, 5);
                Instantiate(creatures[1].part3[rand]).transform.SetParent(creature.transform);
                creature.name += rand;

                rand = Random.Range(0, 5);
                Instantiate(creatures[1].part4[rand]).transform.SetParent(creature.transform);
                creature.name += rand;

                rand = Random.Range(0, 5);
                Instantiate(creatures[1].part5[rand]).transform.SetParent(creature.transform);
                creature.name += rand;

                col = creature2Colors.Evaluate(Random.Range(0f, 1f));
            }

            creature.transform.SetParent(g.transform);
            creature.transform.position = spawners[i].position;
            if (i == 5) {
                creature.transform.localEulerAngles = new Vector3(creature.transform.localEulerAngles.x + 180, creature.transform.localEulerAngles.y, creature.transform.localEulerAngles.z);
            }

            NavMeshAgent nma = creature.GetComponent<NavMeshAgent>();
            nma.Warp(creature.transform.position);
            nma.updateUpAxis = true;

            foreach (MeshRenderer m in creature.GetComponentsInChildren<MeshRenderer>()) {
                m.material.SetColor("_BaseColor", col);
            }

            foreach (SkinnedMeshRenderer m in creature.GetComponentsInChildren<SkinnedMeshRenderer>()) {
                m.material.SetColor("_BaseColor", col);
            }

            for (int j = 0; j < Random.Range(2, 4); j++) {
                nma = Instantiate(creature).GetComponent<NavMeshAgent>();
                nma.Warp(nma.transform.position);
                nma.updateUpAxis = true;

                nma.transform.SetParent(g.transform);
            }
        }
    }
}