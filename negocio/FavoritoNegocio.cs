using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class FavoritoNegocio
    {
        public void insertarFavorito(string idUser, string idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select * from favoritos where IdArticulo = @idArt and IdUser = @idUs");
                datos.setearParametros("@idArt", idArticulo);
                datos.setearParametros("@idUs", idUser);
                datos.ejecutarLectura();
                Favorito favorito = new Favorito();

                while (datos.Lector.Read())
                    favorito.Id = datos.Lector.GetInt32(0);
                
                datos.cerrarConexion();

                if (favorito.Id == 0)
                {
                    datos.setearConsulta("insert into favoritos (IdUser, IdArticulo) values (@idUser, @idArticulo)");
                    datos.setearParametros("@idUser", idUser);
                    datos.setearParametros("@idArticulo", idArticulo);
                    datos.EjecutarAccion();
                    datos.cerrarConexion();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminarFavorito(int IdArt, int IdU)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from favoritos where IdArticulo = @idArticulo and IdUser = @idUser");
                datos.setearParametros("@idArticulo", IdArt);
                datos.setearParametros("@idUser", IdU);
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
    }
}
