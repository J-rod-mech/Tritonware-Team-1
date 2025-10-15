using UnityEngine;

public class Randomizer : MonoBehaviour
{
    int[] magazine = new int[6];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Shoot()
    {
        /*int bullet = 0;
        int j = 0;
        while (bullet[j] < 6)
        {
            bullet == magazine[j];

            j += 1;
        }*/
    }
    void Reload()
    {
        int hit = -1;
        int doublehit = -2;
        int heal = 1;
        int miss = 0;
        int bulletmod = Random.Range(0, 99);
        for (int i = 0; i <= 5; i++)
        {
            if (bulletmod < 39)
            {
                magazine[i] = hit;
            }
            else if (bulletmod > 40 && bulletmod < 69)
            {
                magazine[i] = heal;
            }
            else if (bulletmod > 70 && bulletmod < 94)
            {
                magazine[i] = miss;
            }
            else if (bulletmod > 95 && bulletmod < 99)
            {
                magazine[i] = doublehit;
            }
        }
    }
}
