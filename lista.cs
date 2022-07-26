public class ListaAlumnos
    {
        private List<Alumnos> listaAlumnos = new List<Alumnos>();

        //Acceso a las listas
        public List<Alumnos> AccesoLista()
        {
            return listaAlumnos;
        }

        //------ALTA------
        public void Agregar(string nomb, string ape, int doc, int leg, string cur, string tur, string nac,int cp)
        {
            listaAlumnos.Add(new Alumnos() { nombre = nomb, apellido = ape, dni = doc, legajo = leg, curso = cur, turno = tur, Nacionalidad = nac,codPais = cp });
        }
        //-----MODIFICAR--------
        public void Modificar(int ind, string nomb, string ape, int doc, int leg, string cur, string tur, string nac)
        {
            listaAlumnos.Remove(listaAlumnos.Find(x => x.dni.ToString().Contains(doc.ToString())));
            listaAlumnos.Insert(ind, new Alumnos() { nombre = nomb, apellido = ape, dni = doc, legajo = leg, curso = cur, turno = tur, Nacionalidad = nac });
        }
        public int Indice(int docu)
        {
            return listaAlumnos.IndexOf((Alumnos)listaAlumnos.Find(x => x.dni.ToString().Contains(docu.ToString())));
        }
       
        //-----------BAJA-----------
        public void Borrar(int docu)
        {
            listaAlumnos.Remove(listaAlumnos.Find(x => x.dni.ToString().Contains(docu.ToString())));
        }

        //--------CONSULTA------------
        public object Buscar(int dni)
        {
            return listaAlumnos.Find(x => x.dni.ToString().Contains(dni.ToString()));
        }
        public object Buscar2(int leg)
        {
            return listaAlumnos.Find(x => x.legajo.ToString().Contains(leg.ToString()));
        }
        public bool Existe(int doc)
        {
            return listaAlumnos.Exists(x => x.dni == doc);
        }
        public bool Existe2(int leg)
        {
            return listaAlumnos.Exists(x => x.legajo == leg);
        }
        public int Contar()
        {
            return listaAlumnos.Count;
        }
    }