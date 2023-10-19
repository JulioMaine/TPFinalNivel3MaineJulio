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
                datos.setearConsulta("insert into favoritos (IdUser, IdArticulo) values (@idUser, @idArticulo)");
                datos.setearParametros("@idUser", idUser);
                datos.setearParametros("idArticulo", idArticulo);
                datos.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
