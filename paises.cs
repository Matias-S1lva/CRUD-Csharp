public class Paises : IEquatable<Paises>
{
    public Paises(string nombre, int codigo)
    {
        this.nombre = nombre;
        this.codigo = codigo;
    }
    public int codigo { get; set; }
    public string nombre { get; set; }

    public override string ToString()
    {
        return "nombre: " + nombre + " codigo: " + codigo; //ESTE CODIGO ANDA BIEN
    }


    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        Paises objAsPart = obj as Paises;
        if (objAsPart == null) return false;
        else return Equals(objAsPart);
    }
    public override int GetHashCode()
    {
        return codigo;                   // despues tenes que sacarle el comentario aca y borrar el otro GetHashCode
    }
    public bool Equals(Paises other)
    {


        if (other == null) return false;
        return (this.codigo.Equals(other.codigo));
    }
}