using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Character
{
    public const int Cowo = 1;
    public const int Cewe = 0;
}

public class CharSpawnTemp : MonoBehaviour
{
    public CharacterGenerator charGen;

    [Serializable]
    public struct bentuk_warna
    {
        public string bentuk;
        public List<Sprite> warna;
    }
    public bentuk_warna[] rambut_cowo;
    public bentuk_warna[] rambut_cewe;
    public bentuk_warna[] muka_kulit;

    public List<Sprite> bentuk_mata = new List<Sprite>();
    public List<Sprite> baju_cowo = new List<Sprite>();
    public List<Sprite> baju_cewe = new List<Sprite>();

    public List<int> currentCharacter = new List<int>();
    public List<int> currentPartner = new List<int>();
    public int gender = Character.Cowo;

    public int[] same_traits = { 5, 4, 3, 2, 2 };

    public GameObject charCard;
    public CharCard firstCard;

    public static CharSpawnTemp charSpawn { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (charSpawn != null && charSpawn != this)
        {
            Destroy(this);
        }
        else
        {
            charSpawn = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentCharacter = charGen.GenerateCharacter();

        gender = UnityEngine.Random.Range(0, 2) == 0 ? Character.Cowo : Character.Cewe;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Sprite[] GetCharSprite(List<int> data=null, int _gender=-1)
    {
        Sprite[] charSprite = new Sprite[4];

        if (data == null)
            data = currentCharacter;
        if (_gender == -1)
            _gender = gender;

        if(gender == Character.Cowo)
        {
            charSprite[0] = rambut_cowo[data[0]].warna[data[1]];
            charSprite[3] = baju_cowo[UnityEngine.Random.Range(0, baju_cowo.Count)];
        }
        else
        {
            charSprite[0] = rambut_cewe[data[0]].warna[data[1]];
            charSprite[3] = baju_cewe[UnityEngine.Random.Range(0, baju_cewe.Count)];
        }

        charSprite[1] = muka_kulit[data[3]].warna[data[2]];
        charSprite[2] = bentuk_mata[data[4]];

        return charSprite;
    }

    public void SpawnPartner()
    {
        GameObject new_card = Instantiate(charCard);
        CharCard new_charCard = new_card.GetComponent<CharCard>();
        new_charCard.isPartner = true;
    }

    public void SpawnKid()
    {
        foreach(int trait in same_traits)
        {
            GameObject new_card = Instantiate(charCard);
            CharCard new_charCard = new_card.GetComponent<CharCard>();
            new_charCard.parentTraits = trait;
        }
    }

    public Sprite[] GetPartner()
    {
        currentPartner = charGen.GeneratePartner(currentCharacter);
        return GetCharSprite(charGen.GeneratePartner(currentCharacter), gender == Character.Cowo ? Character.Cewe : Character.Cowo);
    }

    public Sprite[]  GetKidChar(int same_traits)
    {
        return GetCharSprite(charGen.GenerateKid(currentCharacter, currentPartner, same_traits), UnityEngine.Random.Range(0, 2));
    }
}
