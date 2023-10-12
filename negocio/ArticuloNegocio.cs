using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar(string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, M.Descripcion Marca, A.IdMarca, C.Descripcion Categoria, A.IdCategoria, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id and A.IdCategoria = C.Id ";
                if (id != "")
                    consulta += "and A.Id = " + id;

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Codigo = datos.Lector.GetString(1);
                    aux.Nombre = datos.Lector.GetString(2);
                    aux.Descripcion = datos.Lector.GetString(3);
                    aux.ImagenUrl = datos.Lector.GetString(4);
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = datos.Lector.GetString(5);
                    aux.Marca.Id = datos.Lector.GetInt32(6);
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = datos.Lector.GetString(7);
                    aux.Categoria.Id = datos.Lector.GetInt32(8);
                    aux.Precio = datos.Lector.GetDecimal(9);
                        

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregarArticulo(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS  (Codigo, Nombre, Descripcion, ImagenUrl, IdMarca, IdCategoria, Precio) values (@Codigo, @Nombre, @Descripcion, @ImagenUrl, @IdMarca, @IdCategoria, @Precio)");
                datos.setearParametros("@Codigo", articulo.Codigo);
                datos.setearParametros("@Nombre", articulo.Nombre);
                datos.setearParametros("@Descripcion", articulo.Descripcion);
                datos.setearParametros("@ImagenUrl", articulo.ImagenUrl);
                datos.setearParametros("@IdMarca", articulo.Marca.Id);
                datos.setearParametros("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametros("@Precio", articulo.Precio);

                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from ARTICULOS where id = @Id");
                datos.setearParametros("@Id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            

        }

        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio  where Id = @Id");
                datos.setearParametros("@Codigo", articulo.Codigo);
                datos.setearParametros("@Nombre", articulo.Nombre);
                datos.setearParametros("@Descripcion", articulo.Descripcion);
                datos.setearParametros("@IdMarca", articulo.Marca.Id);
                datos.setearParametros("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametros("@ImagenUrl", articulo.ImagenUrl);
                datos.setearParametros("@Precio", articulo.Precio);
                datos.setearParametros("@Id", articulo.Id);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, M.Descripcion Marca, A.IdMarca, C.Descripcion Categoria, A.IdCategoria, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id and A.IdCategoria = C.Id and ";

                if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Empieza con:":
                            consulta += "A.Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con:":
                            consulta += "A.Nombre like '%" + filtro + "'";
                            break;
                        case "Contiene:":
                            consulta += "A.Nombre like '%" + filtro + "%'";
                            break;
                        default:
                            break;
                    }
                } 
                else if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor o igual a:":
                            consulta += "A.Precio >= " + filtro;
                            break;
                        case "Menor o igual a:":
                            consulta += "A.Precio <= " + filtro;
                            break;
                        case "Precio exacto:":
                            consulta += "A.Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Descripción")
                {
                    switch (criterio)
                    {
                        case "Empieza con:":
                            consulta += "A.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con:":
                            consulta += "A.Descripcion like '%" + filtro + "'";
                            break;
                        case "Contiene:":
                            consulta += "A.Descripcion like '%" + filtro + "%'";
                            break;
                        default:
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Codigo = datos.Lector.GetString(1);
                    aux.Nombre = datos.Lector.GetString(2);
                    aux.Descripcion = datos.Lector.GetString(3);
                    aux.ImagenUrl = datos.Lector.GetString(4);
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = datos.Lector.GetString(5);
                    aux.Marca.Id = datos.Lector.GetInt32(6);
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = datos.Lector.GetString(7);
                    aux.Categoria.Id = datos.Lector.GetInt32(8);
                    aux.Precio = datos.Lector.GetDecimal(9);


                    lista.Add(aux);
                }

                return lista;


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            
        }
    }

}
