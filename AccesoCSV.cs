using CadeteNamespace;
using CadeteriaNamespace;

namespace AccesoNameSpace;

public class AccesoCSV : AccesoADatos
{
    public override Cadeteria? cargarCadeteria(string path)
    {
        string[] campos = cargarCSV(path).FirstOrDefault();
        if(campos!=null && campos.Count() == 2){
            return new Cadeteria(campos[0],campos[1]);
        }
        Console.WriteLine("No se pudo cargar la cadeteria correctamente");
        return null;
    }

    public override List<Cadete>? cargarCadetes(string path)
    {
        var campos = cargarCSV(path);
        List<Cadete> cadetes = new List<Cadete>();
        if(campos.Count != 0){
            try{
                foreach (var c in campos)
                {
                    cadetes.Add(new Cadete(int.Parse(c[0]),c[1],c[2],c[3]));
                }
                return cadetes;
            }catch{
                return null;
            }
        }else{
            return null;
        }

    }

    private List<string[]> cargarCSV(string path){
        if(File.Exists(path)){
            string[] lineas = File.ReadAllLines(path);
            List<string[]> obtenerContenido = (from l in lineas
                                   let campos = l.Split(',')
                                   select campos).ToList();
            return obtenerContenido;
        }
        return new List<string[]>();
    }
}
