using CCVProyecto2P2.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using CCVProyecto2P2.Dto;
using CCVProyecto2P2.DataAccess;
using CCVProyecto2P2.Utilidades;
using System.Collections.ObjectModel;
using CCVProyecto2P2.ViewsAdmin;

namespace CCVProyecto2P2.ViewsModels
{
    public partial class EMainViewModel : ObservableObject
    {
        private readonly DbbContext _dbContext;
        [ObservableProperty]
        private ObservableCollection<EstudianteDto> listaEstudiante = new ObservableCollection<EstudianteDto>();
        public EMainViewModel(DbbContext context)
        {
            _dbContext = context;
            MainThread.BeginInvokeOnMainThread(new Action(async () => await Obtener()));
            WeakReferenceMessenger.Default.Register<Mensajeria>(this, (r, m) =>
            {
                EstudianteMensajeRecibido(m.Value);

            });
        }
        public async Task Obtener()
        {
            var lista = await _dbContext.Estudiante.ToListAsync();
            if (lista.Any())
            {
                foreach (var item in lista)
                {
                    ListaEstudiante.Add(new EstudianteDto
                    {
                        Id = item.Id,
                        NombreUsuario = item.NombreUsuario,
                        Contrasenia = item.Contrasenia,
                        Nombre = item.Nombre,
                        Cedula = item.Cedula,
                        Edad = item.Edad,
                        Grado = item.Grado,
                    });
                }
            }
        }
        private void EstudianteMensajeRecibido(Cuerpo estudianteCuerpo)
        {
            var estudianteDto = estudianteCuerpo.EstudianteDto;
            if (estudianteCuerpo.EsCrear)
            {
                ListaEstudiante.Add(estudianteDto);

            }
            else
            {
                var encontrado = ListaEstudiante.First(c => c.Id == estudianteDto.Id);
                encontrado.Nombre = estudianteDto.Nombre;
                encontrado.NombreUsuario = estudianteDto.Nombre;
                encontrado.Contrasenia = estudianteDto.Contrasenia;
                encontrado.Cedula = estudianteDto.Cedula;
                encontrado.Edad = estudianteDto.Edad;
                encontrado.Grado = estudianteDto.Grado;
            }
        }
        [RelayCommand]
        private async Task Crear()
        {
            var uri = $"{nameof(AgregarEstudianteView)}?id=0";
            await Shell.Current.GoToAsync(uri);
        }
        [RelayCommand]
        private async Task Editar(EstudianteDto estudianteDto)
        {
            var uri = $"{nameof(AgregarEstudianteView)}?id={estudianteDto.Id}";
            await Shell.Current.GoToAsync(uri);
        }
        [RelayCommand]
        private async Task Eliminar(EstudianteDto estudianteDto)
        {
            bool anwser = await Shell.Current.DisplayAlert("Mensaje", "Desea eliminar al estudiante?", "Si", "No");
            if (anwser)
            {
                var encontrado = await _dbContext.Estudiante
                    .FirstAsync(c => c.Id == estudianteDto.Id);
                _dbContext.Estudiante.Remove(encontrado);
                await _dbContext.SaveChangesAsync();
                ListaEstudiante.Remove(estudianteDto);
            }
        }
    }
}
