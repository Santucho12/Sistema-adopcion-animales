using System;
using System.Collections.Generic;
using data.models;
using data.repositories;

namespace logic.presenter
{
    public class MascotaPresenter
    {
        private RepositorioMascota repositorioMascota;

        public MascotaPresenter()
        {
            // Instanciamos el repositorio
            repositorioMascota = new RepositorioMascota();
        }

        // Método para listar todas las mascotas
        public List<Mascota> ListarMascotas()
        {
            try
            {
                return repositorioMascota.listarMascotas();
            }
            catch (Exception ex)
            {
                // Aquí podrías agregar lógica para manejar errores de manera más detallada
                throw new Exception("Error al obtener las mascotas: " + ex.Message);
            }
        }

        // Método para agregar una nueva mascota
        public void AgregarMascota(Mascota nuevaMascota)
        {
            try
            {
                repositorioMascota.agregarMascota(nuevaMascota);
            }
            catch (Exception ex)
            {
                // Aquí también se podría agregar más lógica para manejo de errores
                throw new Exception("Error al agregar la mascota: " + ex.Message);
            }
        }

        // Método para modificar una mascota existente
        public void ModificarMascota(Mascota mascota)
        {
            try
            {
                repositorioMascota.modificarMascota(mascota);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar la mascota: " + ex.Message);
            }
        }

        // Método para eliminar una mascota por su ID
        public void EliminarMascota(int id)
        {
            try
            {
                repositorioMascota.eliminarMascota(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la mascota: " + ex.Message);
            }
        }

        // Método para buscar una mascota por su ID
        public Mascota BuscarMascotaPorId(int id)
        {
            try
            {
                return repositorioMascota.buscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la mascota por ID: " + ex.Message);
            }
        }
    }
}
