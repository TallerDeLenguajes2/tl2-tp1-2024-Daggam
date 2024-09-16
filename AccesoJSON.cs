using System.Text.Json;
using CadeteNamespace;
using CadeteriaNamespace;

namespace AccesoNameSpace;

public class AccesoJSON : AccesoADatos
{
    public override Cadeteria? cargarCadeteria(string path)
    {
        try{
            string jsonExterno = File.ReadAllText(path);
            Cadeteria cadeteria = JsonSerializer.Deserialize<Cadeteria>(jsonExterno);
            if(cadeteria==null){
                throw new Exception();
            }
            return cadeteria;
        }catch{
            Console.WriteLine("No se pudo cargar los datos de cadeteria");
        }
        return null;
    }

    public override List<Cadete>? cargarCadetes(string path)
    {
        try{
            string jsonExterno = File.ReadAllText(path);
            List<Cadete> listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonExterno);
            return listaCadetes;
        }catch{
            return null;
        }
    }
}