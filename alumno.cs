public class Alumnos : Persona, IEquatable<Alumnos>
    {
        public Alumnos()
        {
            nombre = "";
        }
        public string curso { get; set; }
        public int legajo { get; set; }
        public string turno { get; set; }


        public override string ToString()
        {
            return "nombre: " + nombre + " apellido: " + apellido + " curso: " + curso + " turno: " + turno + " dni: " + dni + " legajo: " + legajo + " nacionalidad: " + Nacionalidad; //ESTE CODIGO ANDA BIEN
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Alumnos objAsPart = obj as Alumnos;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return dni ;                   // despues tenes que sacarle el comentario aca y borrar el otro GetHashCode
        }
        public bool Equals(Alumnos other)
        {


            if (other == null) return false;
            return (this.dni.Equals(other.dni));
        }

    }