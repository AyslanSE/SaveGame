using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("dados")] public class Dados
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
[SerializeField] public class SaveGame : MonoBehaviour
{
    public GameObject playerposition;
    private string save;

    private void Start()
    {
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
        d.posx = playerposition.transform.position.x;
        d.posy = playerposition.transform.position.y;

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