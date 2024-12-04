using CCVProyecto2P2.DataAccess;
using CCVProyecto2P2.Dto;
using CCVProyecto2P2.Utilidades;
using CCVProyecto2P2.ViewsAdmin;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCVProyecto2P2.ViewsModels
{
    public partial class PMainViewModel:ObservableObject
    {
        private readonly DbbContext _dbContext;
        [ObservableProperty]
        private ObservableCollection<ProfesorDto> listaProfesor = new ObservableCollection<ProfesorDto>();
        public PMainViewModel(DbbContext context)
        {
            _dbContext = context;
            MainThread.BeginInvokeOnMainThread(new Action(async () => await Obtener()));
            WeakReferenceMessenger.Default.Register<MensajeriaP>(this, (r, y) =>
            {
                ProfesorMensajeRecibido(y.Value);

            });
        }
        public async Task Obtener()
        {
            var lista = await _dbContext.Profesor.ToListAsync();
            if (lista.Any())
            {
                foreach (var item in lista)
                {
                    ListaProfesor.Add(new ProfesorDto
                    {
                        Id = item.Id,
                        NombreUsuario = item.NombreUsuario,
                        Contrasenia = item.Contrasenia,
                        Nombre = item.Nombre,
                        Cedula = item.Cedula,
                        Edad = item.Edad,
                        Materia = item.Materia,
                    });
                }
            }
        }
        private void ProfesorMensajeRecibido(CuerpoP profesorCuerpo)
        {
            var profesorDto = profesorCuerpo.ProfesorDto;
            if (profesorCuerpo.EsCrear)
            {
                ListaProfesor.Add(profesorDto);

            }
            else
            {
                var encontrado = ListaProfesor.First(c => c.Id == profesorDto.Id);
                encontrado.Nombre = profesorDto.Nombre;
                encontrado.NombreUsuario = profesorDto.Nombre;
                encontrado.Contrasenia = profesorDto.Contrasenia;
                encontrado.Cedula = profesorDto.Cedula;
                encontrado.Edad = profesorDto.Edad;
                encontrado.Materia = profesorDto.Materia;
            }
        }
        [RelayCommand]
        private async Task Crear()
        {
            var uri = $"{nameof(AgregarProfesorView)}?id=0";
            await Shell.Current.GoToAsync(uri);
        }
        [RelayCommand]
        private async Task Editar(ProfesorDto profesorDto)
        {
            var uri = $"{nameof(AgregarProfesorView)}?id={profesorDto.Id}";
            await Shell.Current.GoToAsync(uri);
        }
        [RelayCommand]
        private async Task Eliminar(ProfesorDto profesorDto)
        {

            try
            {
                bool anwser = await Shell.Current.DisplayAlert("Mensaje", "Desea eliminar al estudiante?", "Si", "No");
                if (anwser)
                {
                    var encontrado = await _dbContext.Profesor
                        .FirstAsync(c => c.Id == profesorDto.Id);
                    _dbContext.Profesor.Remove(encontrado);
                    await _dbContext.SaveChangesAsync();
                    ListaProfesor.Remove(profesorDto);
                }// 
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
            
        }
    }
}
