using SQLite;
using People.Models;

namespace People;

public class PersonRepository
{
    private string _dbPath;
    private SQLiteConnection conn; // Campo privado para la conexión SQLite

    public string StatusMessage { get; set; }

    private void Init()
    {
        if (conn != null)
            return; // Evita reinicializar la conexión si ya está creada

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<Person>(); // Crea la tabla Person si no existe
    }

    public PersonRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public void AddNewPerson(string name)
    {
        int result = 0;
        try
        {
            Init(); // Asegura que la base de datos está inicializada

            // Validación básica del nombre
            if (string.IsNullOrEmpty(name))
                throw new Exception("Valid name required");

            // Inserta la nueva persona en la base de datos
            result = conn.Insert(new Person { Name = name });

            StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
        }
    }

    public List<Person> GetAllPeople()
    {
        try
        {
            Init(); // Asegura que la base de datos está inicializada

            return conn.Table<Person>().ToList(); // Obtiene la lista de personas
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            return new List<Person>();
        }
    }
}
