using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    public int bentuk_rambut = new int();
    public int warna_rambut = new int();
    public int warna_kulit = new int();
    public int bentuk_muka = new int();
    public int bentuk_mata = new int();

    List<int> traits = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        traits.Add(bentuk_rambut);
        traits.Add(warna_rambut);
        traits.Add(warna_kulit);
        traits.Add(bentuk_muka);
        traits.Add(bentuk_mata);


        // Log each element one at a time
        List<int> character = GenerateCharacter();
        Debug.Log("--------------");

        List<int> partner = GeneratePartner(character);

        List<int> kid_5 = GenerateKid(character, partner, 5);
        List<int> kid_4 = GenerateKid(character, partner, 4);
        List<int> kid_3 = GenerateKid(character, partner, 3);
        List<int> kid_2 = GenerateKid(character, partner, 2);
        List<int> kid_2_1 = GenerateKid(character, partner, 2);
        int i = 0;

        string dads = "Dad: ";
        string moms = "mom: ";
        string kids_5 = "kid-5: ";
        string kids_4 = "kid-4: ";
        string kids_3 = "kid-3: ";
        string kids_2 = "kid-2: ";
        string kids_2_1 = "kid-2: ";
        foreach (var item in kid_5)
        {
            kids_5 += item.ToString() + ", ";
            kids_4 += kid_4[i].ToString() + ", ";
            kids_3 += kid_3[i].ToString() + ", ";
            kids_2 += kid_2[i].ToString() + ", ";
            kids_2_1 += kid_2_1[i].ToString() + ", ";
            dads += character[i].ToString() + ", ";
            moms += partner[i].ToString() + ", ";
            i++;
        }
        Debug.Log(dads);
        Debug.Log(moms);
        Debug.Log(kids_5);
        Debug.Log(kids_4);
        Debug.Log(kids_3);
        Debug.Log(kids_2);
        Debug.Log(kids_2_1);

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public List<int> GenerateCharacter()
    {
        List<int> character = new List<int>();

        character.Add(Random.Range(0, bentuk_rambut));
        character.Add(Random.Range(0, warna_rambut));
        character.Add(Random.Range(0, warna_kulit));
        character.Add(Random.Range(0, bentuk_muka));
        character.Add(Random.Range(0, bentuk_mata));


        return character;
    }

    public List<int> GeneratePartner(List<int> partner)
    {
        List<int> character = new List<int>(new int[5]);

        int same_traits = Random.Range(2, 4);
        Debug.Log("same_traits " + same_traits);
        Debug.Log("++++++++++++++");
        int[] position = new int[] { 0, 1, 2, 3, 4 };
        position = Shuffle(position);
        for (int i = 0; i < 5; i++)
        {
            if(same_traits > 0)
            {
                character[position[i]] = partner[position[i]];
                same_traits--;
                continue;
            }

            Debug.Log("aaaaaa" + i);
            int value = Random.Range(0, traits[position[i]]);
            while (value == partner[position[i]])
            {
                value = Random.Range(0, traits[position[i]]);
            }
            character[position[i]] = value;


        }

        return character;
    }

    public List<int> GenerateKid(List<int> dad, List<int> mom, int same_trait)
    {
        List<int> character = new List<int>(new int[] { -1, -1, -1, -1, -1});


        for (int i = 0; i < 5; i++)
        {
            if (dad[i] == mom[i])
            {
                character[i] = dad[i];
                same_trait--;
                if(same_trait == 0)
                {
                    break;
                }
            }
        }


        int[] position = new int[] { 0, 1, 2, 3, 4 };
        position = Shuffle(position);

        for (int i = 0; i < 5; i++)
        {
            if (character[position[i]] != -1)
            {
                continue;
            }

            if(same_trait == 0)
            {
                int value = Random.Range(0, traits[position[i]]);
                while(value == dad[position[i]] || value == mom[position[i]])
                {
                    value = Random.Range(0, traits[position[i]]);
                }
                character[position[i]] = value;
                continue;
            }

            if(same_trait % 2 == 0)
            {
                character[position[i]] = dad[position[i]];
            }
            else
            {
                character[position[i]] = mom[position[i]];
            }
            same_trait--;
           
            //character[position[i]] = Random.Range(0, 2) == 0 ? dad[position[i]] : mom[position[i]];

        }

        return character;
    }


    int[] Shuffle(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int rnd = Random.Range(i, array.Length);
            int tempGO = array[rnd];
            array[rnd] = array[i];
            array[i] = tempGO;
        }
        return array;
    }
}
