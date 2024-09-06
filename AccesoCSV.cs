using CadeteriaNamespace;

namespace AccesoNameSpace;

public class AccesoCSV : AccesoADatos
{
    public override Cadeteria cargarCadeteria(string path)
    {
        string[] campos = cargarCSV(path).FirstOrDefault();
        if(campos!=null && campos.Count() == 2){
            return new Cadeteria(campos[0],campos[1]);
        }
        Console.WriteLine("No se pudo cargar la cadeteria correctamente");
        return null;
    }

    public override bool cargarCadetes(string path, Cadeteria cadeteria)
    {
        var campos = cargarCSV(path);
        if(campos.Count != 0 && cadeteria!=null){
            try{
                foreach (var c in campos)
                {
                    cadeteria.ContratarCadete(int.Parse(c[0]),c[1],c[2],c[3]);
                }
                return true;
            }catch{
                Console.WriteLine("Ocurrio un error en el formato de carga de los cadetes.");
            }
        }else{
            Console.WriteLine("Los cadetes no fueron cargados correctamente");
        }
        return false;
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
