using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

[SerializeField]
public class SaveGame : MonoBehaviour
{
    public GameObject playerposition;
    public GameObject Atributte;
    public UnityEvent pegarDados;
    float localX, localY, localZ;
    public string[] oqueDesejaFazer;
    private string save;
    public int a = 1;

    void LocateAtribute(string[] theAtribute)
    {
        for(int i = 0; i < 0; i++)
        {
            if (theAtribute[i] == "transfom")
            {
                localX = Atributte.transform.position.x;
                localY = Atributte.transform.position.y;
                localZ = Atributte.transform.position.z;
            }
            else if (theAtribute[2] == "valorInteiro")
            {

            }
        }
    }

    private void Start()
    {
        LocateAtribute(oqueDesejaFazer);
        save = Application.persistentDataPath + "/save1.dat";
        Load();
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.S))
            Save();
        if (Input.GetKey(KeyCode.L))
            Load();
    }
    void Save()
    {
        if (File.Exists(save))
            File.Delete(save);
        else
            File.Create(save);

        XmlSerializer x = new XmlSerializer(typeof(Dados));
        StreamWriter writer = new StreamWriter(save, true);

        Dados d = new Dados();
        d.posx = localX;
        d.posy = localY;

        x.Serialize(writer, d);

        writer.Close();
    }
    void Load()
    {
        XmlSerializer x = new XmlSerializer(typeof(Dados));
        StreamReader reader = new StreamReader(save);

        Dados d = (Dados)x.Deserialize(reader);
        reader.Close();

        playerposition.transform.position = new Vector2(d.PosX, d.PosY);
    }
}
[XmlRoot("dados")]
public class Dados
{
    public float posx;
    public float posy;

    [XmlElement("PosX", typeof(float))]
    public float PosX
    {
        get { return this.posx; }
        set { this.posx = value; }
    }
    [XmlElement("PosY", typeof(float))]
    public float PosY
    {
        get { return this.posy; }
        set { this.posy = value; }
    }
}