using UnityEngine;

public class Randomizer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Reload()
    {
        int hit = -1;
        int doublehit = -2;
        int heal = 1;
        int miss = 0;
        int[] bullets = new int[6];
        int bulletmod = Random.Range(0, 99);
        for (int i = 0; i <= 5; i++)
        {
            if (bulletmod < 39)
            {
                bullets[i] = hit;
            }
            else if (bulletmod > 40 && bulletmod < 69)
            {
                bullets[i] = heal;
            }
            else if (bulletmod > 70 && bulletmod < 94)
            {
                bullets[i] = miss;
            }
            else if (bulletmod > 95 && bulletmod < 99)
            {
                bullets[i] = doublehit;
            }
        }
    }
}
