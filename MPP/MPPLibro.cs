using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPLibro : Igestor<BELibro>
    {
        //declaro objeto para acceso a datos
        AccesoDatos oAccesoDatos;
        //declaro la variable para la query
        string query = null;
        public MPPLibro()
        {
            oAccesoDatos = new AccesoDatos();
        }


        public DataTable Listar()
        {
            try
            {
                query = "SELECT Libros.Id,ISBN,Titulo,Precio,Genero,Autor,Formato,Cantidad,Editoriales.RazonSocial as Editorial,Estado,Categoria,AdaptacionFilmografica FROM Libros,Editoriales WHERE (Id_Editorial = Editoriales.Id);" +
                   "SELECT Libros.Id,ISBN,Titulo,Precio,Genero,Autor,Formato,Cantidad,Editoriales.RazonSocial as Editorial,Estado,AdaptacionFilmografica FROM Libros,Editoriales WHERE (Id_Editorial = Editoriales.Id);";

                DataSet dSet = oAccesoDatos.LeerDS(query);

                DataTable dataTable = new DataTable();

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    dataTable.Merge(dSet.Tables[0]);

                }
                else
                {
                    return null;
                }

                // Ordena el DataTable por género
                DataView dataView = dataTable.DefaultView;
                dataView.Sort = "Id ASC";
                dataTable = dataView.ToTable();

                return dataTable;
            }
            catch (SqlException x)
            {

                throw x;
            }
           
        }

        public DataTable ListarPorGenero()
        {
            try
            {
                query = "SELECT Libros.Id,ISBN,Titulo,Precio,Genero,Autor,Formato,Cantidad,Editoriales.RazonSocial as Editorial,Estado,Categoria,AdaptacionFilmografica FROM Libros,Editoriales WHERE (Id_Editorial = Editoriales.Id);" +
                    "SELECT Libros.Id,ISBN,Titulo,Precio,Genero,Autor,Formato,Cantidad,Editoriales.RazonSocial as Editorial,Estado,AdaptacionFilmografica FROM Libros,Editoriales WHERE (Id_Editorial = Editoriales.Id);";

                DataSet dSet = oAccesoDatos.LeerDS(query);

                DataTable dataTable = new DataTable();

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    dataTable.Merge(dSet.Tables[0]);

                }
                else
                {
                    return null;
                }

                // Ordena el DataTable por género
                DataView dataView = dataTable.DefaultView;
                dataView.Sort = "Genero ASC";
                dataTable = dataView.ToTable();

                return dataTable;
            }
            catch (SqlException x)
            {

                throw x;
            }
            

        }
        public List<BELibro> ListarLibros()
        {
            DataTable dataTable = ListarLibrosDT();

            if (dataTable != null)
            {
                List<BELibro> listaLibros = new List<BELibro>();

                foreach (DataRow row in dataTable.Rows)
                {
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

                    libro.Codigo = Convert.ToInt32(row["Id"]);
                    libro.ISBN = Convert.ToInt32(row["ISBN"].ToString());
                    libro.Titulo = row["Titulo"].ToString();
                    libro.Precio = Convert.ToDecimal(row["Precio"]);
                    libro.Genero = row["Genero"].ToString();
                    libro.Autor = row["Autor"].ToString();
                    libro.Formato = row["Formato"].ToString();
                    libro.Cantidad = Convert.ToInt32(row["Cantidad"]);
                    BEEditorial bEEditorial = new BEEditorial();
                    bEEditorial.RazonSocial = row["Editorial"].ToString();
                    libro.Editorial = bEEditorial;
                    libro.Estado = row["Estado"].ToString();
                    

                    listaLibros.Add(libro);
                }

                return listaLibros;
            }
            else
            {
                return null;
            }
        }
        public DataTable ListarLibrosDT()
        {
            try
            {
                query = "SELECT Libros.Id,ISBN,Titulo,Precio,Genero,Autor,Formato,Cantidad,Editoriales.RazonSocial as Editorial,Estado,Categoria,AdaptacionFilmografica FROM Libros,Editoriales WHERE (Id_Editorial = Editoriales.Id);" +
                   "SELECT Libros.Id,ISBN,Titulo,Precio,Genero,Autor,Formato,Cantidad,Editoriales.RazonSocial as Editorial,Estado,AdaptacionFilmografica FROM Libros,Editoriales WHERE (Id_Editorial = Editoriales.Id);";

                DataSet dSet = oAccesoDatos.LeerDS(query);

                DataTable dataTable = new DataTable();

                if (dSet.Tables[0].Rows.Count > 0)
                {
                    dataTable.Merge(dSet.Tables[0]);

                }
                else
                {
                    return null;
                }

                // Ordena el DataTable por género
                DataView dataView = dataTable.DefaultView;
                dataView.Sort = "Id ASC";
                dataTable = dataView.ToTable();

                return dataTable;
            }
            catch (SqlException x)
            {

                throw x;
            }
           
        }
           

            public void Alta(BELibro x)
        {
            if(x is BELibroPolicial)
            {
                BELibroPolicial bELibroPolicial = (BELibroPolicial)x;
                query = null;
                query = $"insert into Libros(ISBN,Titulo,Precio,Genero,Autor,Formato,Cantidad,Id_Editorial,Estado,Categoria) values ('{bELibroPolicial.ISBN}','{bELibroPolicial.Titulo}','{bELibroPolicial.Precio}','{bELibroPolicial.Genero}','{bELibroPolicial.Autor}','{bELibroPolicial.Formato}','{bELibroPolicial.Cantidad}','{bELibroPolicial.Editorial.Codigo}','{bELibroPolicial.Estado}','{bELibroPolicial.Categoria}')";
                oAccesoDatos.EjecutarConsulta(query);
            }
            else
            {
                BELibroCF bELibroCF = (BELibroCF)x;
                query = null;
                query = $"insert into Libros(ISBN,Titulo,Precio,Genero,Autor,Formato,Cantidad,Id_Editorial,Estado,AdaptacionFilmografica) values ('{bELibroCF.ISBN}','{bELibroCF.Titulo}','{bELibroCF.Precio}','{bELibroCF.Genero}','{bELibroCF.Autor}','{bELibroCF.Formato}','{bELibroCF.Cantidad}','{bELibroCF.Editorial.Codigo}','{bELibroCF.Estado}','{bELibroCF.AdaptacionFilmografica}')";
                oAccesoDatos.EjecutarConsulta(query);
            }
        }

        public void Baja(BELibro x)
        {
            query = $"DELETE FROM Libros WHERE ISBN  = '{x.ISBN}'";
            oAccesoDatos.EjecutarConsulta(query);
        }

        public void Modifcacion(BELibro x)
        {
            if (x is BELibroPolicial)
            {
                BELibroPolicial bELibroPolicial = (BELibroPolicial)x;
                query = null;
                query = $"update Libros set ISBN = '{bELibroPolicial.ISBN}',Titulo = '{bELibroPolicial.Titulo}' ,Precio = '{bELibroPolicial.Precio}',Genero = '{bELibroPolicial.Genero}',Autor = '{bELibroPolicial.Autor}',Formato = '{bELibroPolicial.Formato}',Cantidad = '{bELibroPolicial.Cantidad}',Id_Editorial = '{bELibroPolicial.Editorial.Codigo}',Estado = '{bELibroPolicial.Estado}',Categoria = '{bELibroPolicial.Categoria}' where ISBN = '{x.ISBN}' ";
                oAccesoDatos.EjecutarConsulta(query);
            }
            else 
            {

                BELibroCF bELibroCF = (BELibroCF)x;
                query = null;
                query = $"update Libros set ISBN = '{bELibroCF.ISBN}',Titulo = '{bELibroCF.Titulo}' ,Precio = '{bELibroCF.Precio}',Genero = '{bELibroCF.Genero}',Autor = '{bELibroCF.Autor}',Formato = '{bELibroCF.Formato}',Cantidad = '{bELibroCF.Cantidad}',Id_Editorial = '{bELibroCF.Editorial.Codigo}',Estado = '{bELibroCF.Estado}',AdaptacionFilmografica = '{bELibroCF.AdaptacionFilmografica}' where ISBN = '{x.ISBN}' ";
                oAccesoDatos.EjecutarConsulta(query);
            }
        }

    }
}
