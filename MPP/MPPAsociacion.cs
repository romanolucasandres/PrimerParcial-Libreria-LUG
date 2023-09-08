using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace MPP
{
    public class MPPAsociacion
    {
        AccesoDatos acceso;
        string query = null;
        public MPPAsociacion()
        {
            acceso = new AccesoDatos();
        }

        public List<BEAsociacion> Listar()
        {
            DataTable dataTable = Listar1();

            if (dataTable != null)
            {
                List<BEAsociacion> listaAsociaciones = new List<BEAsociacion>();

                foreach (DataRow row in dataTable.Rows)
                {
                    BEAsociacion asociacion = new BEAsociacion();

                    BECliente cliente = new BECliente();
                    cliente.Apellido = row["Apellido"].ToString();
                    asociacion.Cliente = cliente;

                    string tipoLibro = row["Genero"].ToString();
                    BELibro libro;

                    if (tipoLibro == "Ciencia_Ficcion")
                    {
                        libro = new BELibroCF();
                    }
                    else if (tipoLibro == "Policial")
                    {
                        libro = new BELibroPolicial();
                    }
                    else
                    {
                        
                        continue;
                    }

                    libro.Titulo = row["Titulo"].ToString();
                    asociacion.Libro = libro;

                    asociacion.Estado = row["Estado"].ToString();
                    asociacion.Descuento = Convert.ToDecimal(row["Descuento"].ToString());
                    
                    

                    listaAsociaciones.Add(asociacion);
                }

                return listaAsociaciones;
            }
            else
            {
                return null;
            }
        }
        public DataTable Listar1()
        {
            try
            {
                query = $"select Clientes.Apellido,Libros.Titulo,Libros.Genero, Cliente_Libro.Estado,  Cliente_Libro.Descuento from Clientes,Libros,Cliente_Libro where Cliente_libro.Id_Libro = Libros.Id and Cliente_libro.Id_Cliente = Clientes.Id ;";

                DataSet dSet = acceso.LeerDS(query);
                DataTable dataTable = new DataTable();
                if (dSet.Tables[0].Rows.Count > 0)
                {
                    dataTable.Merge(dSet.Tables[0]);
                    dataTable = dataTable.DefaultView.ToTable(true);
                }
                else
                {
                    return null;
                }
                

                return dataTable;


            }
            catch (SqlException x)
            {

                throw x;
            }
            
        }
        public List<BEAsociacion> ListarDes()
        {
            DataTable dataTable = Listar2();

            if (dataTable != null)
            {
                List<BEAsociacion> listaAsociacionesDescuento = new List<BEAsociacion>();

                foreach (DataRow row in dataTable.Rows)
                {
                    BEAsociacion asociacionDescuento = new BEAsociacion();

                    BECliente cliente = new BECliente();
                    cliente.Apellido = row["Apellido"].ToString();
                    asociacionDescuento.Cliente = cliente;

                    asociacionDescuento.Descuento = decimal.Parse(row["Descuento"].ToString());

                    listaAsociacionesDescuento.Add(asociacionDescuento);
                }

                return listaAsociacionesDescuento;
            }
            else
            {
                return null;
            }
        }
        public DataTable Listar2()
        {
            try
            {
                query = $"SELECT Clientes.Apellido, SUM(Cliente_Libro.Descuento) AS Descuento " +
                       $"FROM Clientes INNER JOIN Cliente_Libro ON Cliente_Libro.Id_Cliente = Clientes.Id " +
                       $"GROUP BY Clientes.Apellido " +
                       $"ORDER BY Descuento DESC;";


                DataSet dSet = acceso.LeerDS(query);

                DataTable dataTable = new DataTable();

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    dataTable.Merge(dSet.Tables[0]);
                    dataTable = dataTable.DefaultView.ToTable(true);
                }
                else
                {
                    return null;
                }



                return dataTable;

            }
            catch (SqlException x)
            {

                throw x;
            }
           

        }
        public List<BEAsociacion> ListarPoliciales()
        {
            DataTable dataTable = ListarPolicial();

            if (dataTable != null)
            {
                List<BEAsociacion> listaAsociaciones = new List<BEAsociacion>();

                foreach (DataRow row in dataTable.Rows)
                {
                    BEAsociacion asociacion = new BEAsociacion();

                    string tipoLibro = row["Genero"].ToString();
                    BELibro libro;

                    if (tipoLibro == "Ciencia_Ficcion")
                    {
                        libro = new BELibroCF();
                    }
                    else if (tipoLibro == "Policial")
                    {
                        libro = new BELibroPolicial();
                    }
                    else
                    {

                        continue;
                    }

                    libro.Titulo = row["Titulo"].ToString();
                    asociacion.Libro = libro;
                   



                    listaAsociaciones.Add(asociacion);
                }

                return listaAsociaciones;
            }
            else
            {
                return null;
            }
        }
        public DataTable ListarPolicial()
        {
            try
            {
                query = $"SELECT TOP 3 Libros.Titulo, Libros.Genero, COUNT(*) AS Repeticiones " +
                        $"FROM Libros, Cliente_Libro " +
                        $"WHERE Cliente_Libro.Estado = 'Pagado' and Libros.Genero = 'Policial'  " +
                        $"GROUP BY Libros.Titulo, Libros.Genero " +
                        $"ORDER BY COUNT(*) DESC;";


                DataSet dSet = acceso.LeerDS(query);

                DataTable dataTable = new DataTable();

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    dataTable.Merge(dSet.Tables[0]);
                    dataTable = dataTable.DefaultView.ToTable(true);
                }
                else
                {
                    return null;
                }



                return dataTable;
            }
            catch (SqlException x)
            {

                throw x;
            }
         

        }

        public List<BEAsociacion> ListarCF()
        {
            DataTable dataTable = ListarCFDT();

            if (dataTable != null)
            {
                List<BEAsociacion> listaAsociaciones = new List<BEAsociacion>();

                foreach (DataRow row in dataTable.Rows)
                {
                    BEAsociacion asociacion = new BEAsociacion();

                    string tipoLibro = row["Genero"].ToString();
                    BELibro libro;

                    if (tipoLibro == "Ciencia_Ficcion")
                    {
                        libro = new BELibroCF();
                    }
                    else if (tipoLibro == "Policial")
                    {
                        libro = new BELibroPolicial();
                    }
                    else
                    {

                        continue;
                    }

                    libro.Titulo = row["Titulo"].ToString();
                    asociacion.Libro = libro;
                   

                


                    listaAsociaciones.Add(asociacion);
                }

                return listaAsociaciones;
            }
            else
            {
                return null;
            }
        }
        public DataTable ListarCFDT()
        {
            try
            {
                query = $"SELECT TOP 3 Libros.Titulo, Libros.Genero, COUNT(*) AS Repeticiones " +
                          $"FROM Libros, Cliente_Libro " +
                          $"WHERE Cliente_Libro.Id_Libro = Libros.Id and Libros.Genero = 'Ciencia_Ficcion'  " +
                          $"GROUP BY Libros.Titulo, Libros.Genero " +
                          $"ORDER BY COUNT(*) ASC;";


                DataSet dSet = acceso.LeerDS(query);

                DataTable dataTable = new DataTable();

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    dataTable.Merge(dSet.Tables[0]);
                    dataTable = dataTable.DefaultView.ToTable(true);
                }
                else
                {
                    return null;
                }



                return dataTable;
            }
            catch (SqlException x)
            {

                throw x;
            }
      

        }


        public void Alta(BEAsociacion asociacion)
        {
           
                string query = $"insert into Cliente_Libro(Id_Cliente, Id_Libro, Estado) values ('{asociacion.Cliente.Codigo}','{asociacion.Libro.Codigo}','{asociacion.Estado}')";
                acceso.EjecutarConsulta(query);    

        }
        public void AltaPago(BEAsociacion asociacion)
        {
            if (asociacion.Libro.Genero == "Policial")
            {
                BELibroPolicial policial = new BELibroPolicial();
                policial = (BELibroPolicial)asociacion.Libro;
                query = null;
                decimal descuentoRedondeado = Math.Round(asociacion.Descuento);
                query = $"UPDATE Cliente_Libro SET Id_Cliente='{asociacion.Cliente.Codigo}', Id_Libro='{asociacion.Libro.Codigo}', Estado='{asociacion.Estado}', Descuento={descuentoRedondeado} WHERE Id_Cliente='{asociacion.Cliente.Codigo}' AND Id_Libro='{asociacion.Libro.Codigo}'";
                acceso.EjecutarConsulta(query);
            }
            else if(asociacion.Libro.Genero == "Ciencia_Ficcion")
            {
                BELibroCF cf = new BELibroCF();
                cf = (BELibroCF)asociacion.Libro;
                query = null;
                decimal descuentoRedondeado = Math.Round(asociacion.Descuento);
                query = $"UPDATE Cliente_Libro SET Id_Cliente='{asociacion.Cliente.Codigo}', Id_Libro='{asociacion.Libro.Codigo}', Estado='{asociacion.Estado}', Descuento={descuentoRedondeado} WHERE Id_Cliente='{asociacion.Cliente.Codigo}' AND Id_Libro='{asociacion.Libro.Codigo}'";
                acceso.EjecutarConsulta(query);
            }
            

        }
        public void stock(BELibro libro)
        {
            query = null;
           
            query = $"UPDATE Libros SET Cantidad='{libro.Cantidad}'where Id='{libro.Codigo}'";
            acceso.EjecutarConsulta(query);
        }

        public void Baja(BEAsociacion x)
        {
            query = null;
            query = $"delete from Cliente_Libro where Id_Cliente = '{x.Cliente.Codigo}' and Id_Libro ='{x.Libro.Codigo}';";

            acceso.EjecutarConsulta(query);
        }



       
    }
}
