using System.Text.Json;
using CadeteNamespace;
using CadeteriaNamespace;

namespace AccesoNameSpace;

public class AccesoJSON : AccesoADatos
{
    public override Cadeteria cargarCadeteria(string path)
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

    public override bool cargarCadetes(string path, Cadeteria cadeteria)
    {
        try{
            string jsonExterno = File.ReadAllText(path);
            List<Cadete> listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonExterno);
            if(listaCadetes!=null){
                foreach (var cadete in listaCadetes)
                {
                    cadeteria.ContratarCadete(cadete.Id,cadete.Nombre,cadete.Direccion,cadete.Telefono);
                }
                return true;
            }else{
                Console.WriteLine("Los datos fueron cargados de forma incorrecta");
            }
        }catch{
            Console.WriteLine("No se pudo cargar los datos de los cadetes correctamente");
        }
        return false;
    }
}