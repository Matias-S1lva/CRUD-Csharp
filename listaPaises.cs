public class listaPaises{
     private List<Paises> listaPais = new List<Paises>();

      public void Agregar(string nomb,int cod)
        {
            listaPais.Add(new Paises(nomb,cod));
        }
         public List<Paises> AccesoLista()
        {
            return listaPais;
        }
     public object Buscar(string nombre)
        {
            return listaPais.Find(x => x.nombre.ToString().Contains( nombre.ToString()));
        }

        public int Indice(int ind)
        {
            return listaPais.IndexOf((Paises)listaPais.Find(x => x.codigo.ToString().Contains(ind.ToString())));
        }
        public bool Existe(string nombre){
            return listaPais.Exists(x => x.nombre == nombre);
        }
           public bool Existe2(int cod){
            return listaPais.Exists(x => x.codigo == cod);
        }


        
}