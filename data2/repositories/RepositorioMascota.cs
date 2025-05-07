using data.models;
using data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace data.repositories
{
    public class RepositorioMascota
    {
        public List<Mascota> listarMascotas()
        {
            List<Mascota> listaMascotas = new List<Mascota>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT nombre,especie,raza,edad,sexo,descripcion,estadoAdopcion,fechaLlegada FROM Mascotas");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mascota aux = new Mascota();
                    aux.nombre = (string)datos.Lector["nombre"];
                    aux.especie = (string)datos.Lector["especie"];
                    aux.raza = (string)datos.Lector["raza"];
                    aux.edad = (int)datos.Lector["edad"];
                    aux.sexo = (string)datos.Lector["sexo"];
                    aux.descripcion = (string)datos.Lector["descripcion"];
                    aux.estadoAdopcion = (string)datos.Lector["estadoAdopcion"];
                    aux.fechaLlegada = (DateTime)datos.Lector["fechaLlegada"];

                    listaMascotas.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return listaMascotas;
        }

        public void agregarMascota(Mascota nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Mascotas (nombre, especie, raza, edad, sexo, descripcion, estadoAdopcion, fechaLlegada) " +
                                     "VALUES (@nombre, @especie, @raza, @edad, @sexo, @descripcion, @estadoAdopcion, @fechaLlegada)");

                datos.comando.Parameters.AddWithValue("@nombre", nueva.nombre);
                datos.comando.Parameters.AddWithValue("@especie", nueva.especie);
                datos.comando.Parameters.AddWithValue("@raza", nueva.raza);
                datos.comando.Parameters.AddWithValue("@edad", nueva.edad);
                datos.comando.Parameters.AddWithValue("@sexo", nueva.sexo);
                datos.comando.Parameters.AddWithValue("@descripcion", nueva.descripcion);
                datos.comando.Parameters.AddWithValue("@estadoAdopcion", nueva.estadoAdopcion);
                datos.comando.Parameters.AddWithValue("@fechaLlegada", nueva.fechaLlegada);

                datos.ejecutarAccion();
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

        public void modificarMascota(Mascota mascota)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Mascotas SET nombre=@nombre, especie=@especie, raza=@raza, edad=@edad, sexo=@sexo, " +
                                     "descripcion=@descripcion, estadoAdopcion=@estadoAdopcion, fechaLlegada=@fechaLlegada WHERE id=@id");

                datos.comando.Parameters.AddWithValue("@id", mascota.id);
                datos.comando.Parameters.AddWithValue("@nombre", mascota.nombre);
                datos.comando.Parameters.AddWithValue("@especie", mascota.especie);
                datos.comando.Parameters.AddWithValue("@raza", mascota.raza);
                datos.comando.Parameters.AddWithValue("@edad", mascota.edad);
                datos.comando.Parameters.AddWithValue("@sexo", mascota.sexo);
                datos.comando.Parameters.AddWithValue("@descripcion", mascota.descripcion);
                datos.comando.Parameters.AddWithValue("@estadoAdopcion", mascota.estadoAdopcion);
                datos.comando.Parameters.AddWithValue("@fechaLlegada", mascota.fechaLlegada);

                datos.ejecutarAccion();
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

        public void eliminarMascota(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Mascotas WHERE id=@id");
                datos.comando.Parameters.AddWithValue("@id", id);

                datos.ejecutarAccion();
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

        public Mascota buscarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT * FROM Mascotas WHERE id=@id");
                datos.comando.Parameters.AddWithValue("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Mascota aux = new Mascota();
                    aux.id = (int)datos.Lector["id"];
                    aux.nombre = (string)datos.Lector["nombre"];
                    aux.especie = (string)datos.Lector["especie"];
                    aux.raza = (string)datos.Lector["raza"];
                    aux.edad = (int)datos.Lector["edad"];
                    aux.sexo = (string)datos.Lector["sexo"];
                    aux.descripcion = (string)datos.Lector["descripcion"];
                    aux.estadoAdopcion = (string)datos.Lector["estadoAdopcion"];
                    aux.fechaLlegada = (DateTime)datos.Lector["fechaLlegada"];

                    return aux;
                }

                return null;
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
