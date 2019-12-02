using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlanetBuilder : MonoBehaviour {
    public Transform[] spawners;
    public Creature[] creatures;

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

            if (i % 2 == 0) {
                creature = Instantiate(creatures[0].creaturePrefab);
                Instantiate(creatures[0].part1[Random.Range(0, 5)]).transform.SetParent(creature.transform);
                Instantiate(creatures[0].part2[Random.Range(0, 5)]).transform.SetParent(creature.transform);
                Instantiate(creatures[0].part3[Random.Range(0, 5)]).transform.SetParent(creature.transform);
                Instantiate(creatures[0].part4[Random.Range(0, 5)]).transform.SetParent(creature.transform);
                Instantiate(creatures[0].part5[Random.Range(0, 5)]).transform.SetParent(creature.transform);
            } else {
                creature = Instantiate(creatures[1].creaturePrefab);
                Instantiate(creatures[1].part1[Random.Range(0, 5)]).transform.SetParent(creature.transform);
                Instantiate(creatures[1].part2[Random.Range(0, 5)]).transform.SetParent(creature.transform);
                Instantiate(creatures[1].part3[Random.Range(0, 5)]).transform.SetParent(creature.transform);
                Instantiate(creatures[1].part4[Random.Range(0, 5)]).transform.SetParent(creature.transform);
                Instantiate(creatures[1].part5[Random.Range(0, 5)]).transform.SetParent(creature.transform);
            }

            creature.transform.SetParent(g.transform);
            creature.transform.position = spawners[i].position;

            NavMeshAgent nma = creature.GetComponent<NavMeshAgent>();
            nma.Warp(creature.transform.position);
            nma.updateUpAxis = true;

            for (int j = 0; j < Random.Range(2, 4); j++) {
                nma = Instantiate(creature).GetComponent<NavMeshAgent>();
                nma.Warp(nma.transform.position);
                nma.updateUpAxis = true;
            }
        }
    }
}