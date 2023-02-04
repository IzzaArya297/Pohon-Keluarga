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
    public struct Rambut
    {
        public Sprite depan;
        public Sprite belakang;
        public Sprite mid;
    }

    [Serializable]
    public struct bentuk_warna_rambut
    {
        public string bentuk;
        public List<Rambut> warna;
    }

    [Serializable]
    public struct bentuk_warna
    {
        public string bentuk;
        public List<Sprite> warna;
    }

    public bentuk_warna_rambut[] rambut_cowo;
    public bentuk_warna_rambut[] rambut_cewe;
    public bentuk_warna[] muka_kulit;

    public List<Sprite> bentuk_mata = new List<Sprite>();
    public List<Sprite> baju_cowo = new List<Sprite>();
    public List<Sprite> baju_cewe = new List<Sprite>();

    public List<int> currentCharacter = new List<int>();
    public List<int> currentPartner = new List<int>();

    public List<GameObject> cardChild;

    public int gender = Character.Cowo;

    public int[] same_traits = { 5, 4, 3, 2, 2 };

    public GameObject charCard;

    public CharCard mainCard;

    public GameObject hirarki;
    public GameObject answerCard;

    Vector3 mainCardPos;

    public Vector3 hirarkiOffset;
    public Vector3 parentPosOffset;
    public Vector3 answerPosOffset;
    public Vector3[] chileChoiceOffset;

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

        mainCardPos = mainCard.transform.position;
        SpawnPartner();
        SpawnKid();
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObject()
    {
        Instantiate(hirarki, mainCardPos + hirarkiOffset, Quaternion.identity);
        Instantiate(answerCard, mainCardPos + answerPosOffset, Quaternion.identity);
    }

    public IEnumerator NewLevel(Vector3 _mainCardPos, float duration=3)
    {
        cardChild.Remove(mainCard.gameObject);
        List<GameObject> temp = new List<GameObject>(cardChild);
        mainCardPos = _mainCardPos;

        SpawnPartner();
        SpawnKid();
        SpawnObject();
        yield return new WaitForSeconds(duration);
        foreach (GameObject go in temp)
        {
            Destroy(go);
        }
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
            charSprite[0] = rambut_cowo[data[0]].warna[data[1]].depan;
            charSprite[1] = rambut_cowo[data[0]].warna[data[1]].belakang;
            charSprite[2] = rambut_cowo[data[0]].warna[data[1]].mid;
            charSprite[3] = baju_cowo[UnityEngine.Random.Range(0, baju_cowo.Count)];
        }
        else
        {
            charSprite[0] = rambut_cewe[data[0]].warna[data[1]].depan;
            charSprite[1] = rambut_cewe[data[0]].warna[data[1]].belakang;
            charSprite[2] = rambut_cewe[data[0]].warna[data[1]].mid;
            charSprite[3] = baju_cewe[UnityEngine.Random.Range(0, baju_cewe.Count)];
        }

        charSprite[4] = muka_kulit[data[3]].warna[data[2]];
        charSprite[5] = bentuk_mata[data[4]];

        return charSprite;
    }

    public void SpawnPartner()
    {
        GameObject new_card = Instantiate(charCard, mainCardPos + parentPosOffset, Quaternion.identity);
        cardChild.Add(new_card);
        CharCard new_charCard = new_card.GetComponent<CharCard>();
        new_charCard.isPartner = true;
    }

    public void SpawnKid()
    {
        int i = 0;
        foreach(int trait in same_traits)
        {
            GameObject new_card = Instantiate(charCard, mainCardPos + chileChoiceOffset[i], Quaternion.identity);
            cardChild.Add(new_card);
            CharCard new_charCard = new_card.GetComponent<CharCard>();
            ObjectMovement new_object = new_card.GetComponent<ObjectMovement>();
            new_charCard.parentTraits = trait;
            new_object.isPartner = false;
            new_object.offsetTargetPosition = mainCardPos + answerPosOffset;
            if(i == 4)
            {
                new_charCard.sortingFix(21);
            }
            i++;
        }
    }

    public Sprite[] GetPartner()
    {
        currentPartner = charGen.GeneratePartner(currentCharacter);
        return GetCharSprite(charGen.GeneratePartner(currentCharacter), gender == Character.Cowo ? Character.Cewe : Character.Cowo);
    }

    public Sprite[]  GetKidChar(CharCard charCard)
    {
        charCard.charTraits = charGen.GenerateKid(currentCharacter, currentPartner, charCard.parentTraits);
        return GetCharSprite(charCard.charTraits, UnityEngine.Random.Range(0, 2));
    }
}
