public class Program
{

    public static void Main()
    {

        int respuesta;


        ListaAlumnos objlista = new ListaAlumnos();
        listaPaises listaPais = new listaPaises();

        do
        {
            int rsp;


            Console.WriteLine("1)agregar");
            Console.WriteLine("2)mostrar");
            Console.WriteLine("3)buscar");
            Console.WriteLine("4)borrar");
            Console.WriteLine("5)modificar");
            Console.WriteLine("6)paises");
            Console.WriteLine("7)filtrar por paises");

            try
            {
                rsp = int.Parse(Console.ReadLine());
            }

            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("ingresa solo numeros !");
                Console.ReadKey();

                rsp = 0;


            }
            catch (OverflowException)
            {
                Console.Clear();
                Console.WriteLine("no ingrese valores numericos muy altos");
                Console.ReadKey();
                rsp = 0;
            }


            respuesta = rsp;

            switch (rsp)
            {

                //------------------------ALTA------------------------
                case 1:

                    Console.Clear();
                    Alumnos alumnos = new Alumnos();
                    string nom, apell, turno, curs, nac, mensaje;
                    int Dni, legaj, nacionalidad;

                    Console.WriteLine("ingresar nombre ");
                    alumnos.nombre = Console.ReadLine();

                    Console.WriteLine("ingresar apellido ");
                    alumnos.apellido = Console.ReadLine();

                    Console.WriteLine("ingresar curso ");
                    alumnos.curso = Console.ReadLine();

                    Console.WriteLine("ingresar turno ");
                    alumnos.turno = Console.ReadLine();

                    if (listaPais.AccesoLista().Count() != 0)
                    {
                        Console.WriteLine("seleccione su pais de origen");
                        int items = 1;
                        foreach (var i in listaPais.AccesoLista())
                        {

                            Console.WriteLine(items + ")" + i.nombre );
                            items++;
                        }
                        int indice = int.Parse(Console.ReadLine()) - 1;
                        alumnos.Nacionalidad = listaPais.AccesoLista().ElementAt(indice).nombre;
                        alumnos.codPais = listaPais.AccesoLista().ElementAt(indice).codigo;
                    }
                    else
                    {
                        Console.WriteLine("para poder agregar la nacionalidad primero tiene que crear un pais");
                    }
                    Console.ReadKey();






                    if (alumnos.nombre == string.Empty || alumnos.apellido == string.Empty || alumnos.curso == string.Empty || alumnos.turno == string.Empty)
                    {

                        Console.WriteLine("por favor no ingrese un campo vacio");

                    }

                    else
                    {

                        //fallaria con numeros negativos pero es casi imposible que alguien introduzca un numero negativo

                        Console.WriteLine("ingresar dni: ");


                        do
                        {

                            mensaje = string.Empty;
                            try
                            {
                                alumnos.dni = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException ex)
                            {
                                Console.Clear();
                                mensaje = ex.Message;
                                Console.WriteLine("por favor ingrese solo numeros");
                                alumnos.dni = 0;
                            }
                            catch (OverflowException)
                            {
                                Console.Clear();
                                Console.WriteLine("no ingrese valores tan altos");
                                alumnos.dni = 0;
                            }

                            if (mensaje != "Input string was not in a correct format.")
                            {
                                Console.Clear();
                                Console.WriteLine("el numero ingresado tiene que ser de 8 digitos");
                            }
                            Console.WriteLine("ingresar dni: ");

                        } while (alumnos.dni <= 10000000 || alumnos.dni >= 99999999);

                        Console.Clear();
                        legaj = objlista.Contar();
                        legaj++;


                        if (objlista.Existe(alumnos.dni) != true)
                        {


                            Console.Clear();
                            objlista.Agregar(nomb: alumnos.nombre, ape: alumnos.apellido, doc: alumnos.dni, leg: legaj, cur: alumnos.curso, tur: alumnos.turno, nac: alumnos.Nacionalidad, cp: alumnos.codPais);
                            Console.WriteLine("El alumno " + alumnos.nombre + " ha sido ingresado correctamente.");




                        }

                        else Console.WriteLine("Ya existe un alumno con ese dni");
                        Console.ReadKey();
                    }

                    break;


                 //-----------------------CONSULTA--------------------------------------
                case 2:


                    Console.Clear();
                    if (objlista.Contar() != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Alumnos registrados");
                        foreach (Alumnos alumno in objlista.AccesoLista())
                        {
                            Console.WriteLine("Nombre: " + alumno.nombre);
                            Console.WriteLine("Apellido: " + alumno.apellido);
                            Console.WriteLine("Curso: " + alumno.curso);
                            Console.WriteLine("Turno: " + alumno.turno);
                            Console.WriteLine("Dni: " + alumno.dni);
                            Console.WriteLine("legajo:" + alumno.legajo);
                            Console.WriteLine("Nacionalidad:" + alumno.Nacionalidad);
                            Console.WriteLine("CodPais:" + alumno.codPais);
                            Console.WriteLine("");
                        }
                        Console.ReadKey();


                    }
                    else
                    {
                        Console.Clear();

                        Console.WriteLine("no hay ningun alumno registrado");
                        Console.ReadKey();
                    }
                    break;

                 //------------------------------------BUSCAR------------------------------
                case 3:

                    if (objlista.Contar() != 0)
                    {
                        Console.Clear();
                        int doc;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("ingresar dni del alumno");
                            try
                            {
                                doc = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("tiene que ingresar un valor !");
                                doc = 0;
                                Console.ReadKey();
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("no ingrese valores tan altos!");
                                doc = 0;
                                Console.ReadKey();
                            }

                        } while (objlista.Existe(doc) != true);


                        Console.WriteLine("alumno encontrado");


                        Console.WriteLine(objlista.Buscar(doc));


                        if (objlista.Existe(doc) == false) Console.WriteLine("no existe el alumno");




                    }
                    else Console.WriteLine("no hay ningun alumno para buscar");
                    Console.ReadKey();
                    break;

                 //--------------------------------------BAJA-------------------------------------------------------
                case 4:

                    if (objlista.Contar() != 0)
                    {
                        int docu;
                        Console.Clear();

                        Console.WriteLine("ingresar dni del alumno que desea borrar");

                        try
                        {
                            docu = int.Parse(Console.ReadLine());
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine(err.Message);
                            docu = 0;
                        }
                        if (objlista.Existe(docu) == true)
                        {

                            objlista.Borrar(docu);
                            Console.WriteLine("alumno eliminado");
                        }
                        //objlista.AccesoLista().Remove(objlista.AccesoLista().Find(x => x.dni.ToString().Contains(docu.ToString())));

                        else Console.WriteLine("el dni ingresado no coincide con ninguno de los registros");

                        Console.ReadKey();
                    }
                    else Console.WriteLine("no hay ningun alumno registrado");
                    break;

                case 5:

                    if (objlista.Contar() != 0)
                    {
                        Console.WriteLine("ingresar dni");
                        try
                        {
                            Dni = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("por favor ingrese solo numeros ");
                            Dni = 0;
                        }
                        if (objlista.Existe(Dni) == true)
                        {
                            Console.WriteLine(objlista.Indice(Dni));

                            int indice = objlista.AccesoLista().IndexOf((Alumnos)objlista.Buscar(Dni));

                            Console.WriteLine("ingrese datos para modificar..");

                            Console.WriteLine("ingresar nombre ");
                            nom = Console.ReadLine();

                            Console.WriteLine("ingresar apellido ");
                            apell = Console.ReadLine();

                            Console.WriteLine("ingresar curso ");
                            curs = Console.ReadLine();

                            Console.WriteLine("ingresar turno ");
                            turno = Console.ReadLine();

                            Console.WriteLine("Ingresar nacionalidad, sin mayuscula");
                            nac = Console.ReadLine();

                            if (nom == string.Empty || apell == string.Empty || curs == string.Empty || turno == string.Empty)
                            {

                                Console.WriteLine("por favor no ingrese un campo vacio");

                            }
                            Console.WriteLine("ingresar legajo");
                            legaj = int.Parse(Console.ReadLine());

                            if (objlista.Existe2(legaj) == false)
                            {
                                objlista.Modificar(ind: indice, nomb: nom, ape: apell, doc: Dni, leg: legaj, cur: curs, tur: turno, nac: nac);
                                Console.ReadKey();
                            }

                            else Console.WriteLine("el legajo no puede repetirse entre los alumnos");
                        }
                        else Console.WriteLine("No existe un alumno con ese dni ");
                        Console.ReadKey();
                    }
                    else Console.WriteLine("no hay alumnos registrados");
                    break;

                case 6:
                    Console.Clear();
                    string nombre;
                    int codigo;
                    Console.WriteLine("ingresar nombre del pais");
                    nombre = Console.ReadLine();

                    Console.WriteLine("ingresar codigo pais");
                    codigo = int.Parse(Console.ReadLine());

                    Paises nuevoPais = new Paises(nombre, codigo);

                    if (listaPais.Existe(nombre) != true)
                    {
                        listaPais.Agregar(nomb: nuevoPais.nombre, cod: nuevoPais.codigo);
                        Console.WriteLine("-----------Paises------------");

                        foreach (var i in listaPais.AccesoLista())
                        {

                            Console.WriteLine("Pais: " + i.nombre);
                            Console.WriteLine("Codigo: " + i.codigo);
                            Console.WriteLine("-----------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ya existe ese pais");
                    }
                    Console.ReadKey();
                    break;

                case 7:
                    int data, ind, item;

                    item = 1;
                    foreach (var i in listaPais.AccesoLista())
                    {

                        Console.WriteLine(item + ")" + i.nombre);
                        item++;
                    }
                    Console.WriteLine("ingresar codigo del pais");
                    data = int.Parse(Console.ReadLine());

                    if (listaPais.Existe2(data) == true)
                    {
                        ind = listaPais.AccesoLista().FindIndex(x => x.codigo == data);

                        Console.WriteLine("\nalumnos de " + listaPais.AccesoLista().ElementAt(ind).nombre);
                        List<Alumnos> lista = new List<Alumnos>();
                        lista = objlista.AccesoLista().FindAll(x => x.codPais == data).ToList();

                        foreach (var i in lista)
                        {
                            Console.WriteLine("nombre: " + i.nombre);
                            Console.WriteLine("apellido: " + i.apellido);
                            Console.WriteLine("nacionalidad: " + i.Nacionalidad);
                            Console.WriteLine("--------------------------------");
                        }

                    }

                    else Console.WriteLine("no existe ese pais ");

                    Console.ReadKey();
                    break;

            }
            Console.Clear();

        } while (respuesta == 0 ||respuesta == 1 || respuesta == 2 || respuesta == 3 || respuesta == 4 || respuesta == 5 || respuesta == 6 || respuesta == 7);
       
        Console.WriteLine("ha salido del sistema");
        Console.ReadKey();
    }
}