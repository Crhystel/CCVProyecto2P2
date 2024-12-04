using CCVProyecto2P2.DataAccess;
using CCVProyecto2P2.Dto;
using CCVProyecto2P2.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using CCVProyecto2P2.Utilidades;

namespace CCVProyecto2P2.ViewsModels
{
    public partial class EstudianteViewModel : ObservableObject, IQueryAttributable
    {
        private readonly DbbContext _dbContext;

        public List<GradoEnum> GradosDisponibles { get; } = Enum.GetValues(typeof(GradoEnum)).Cast<GradoEnum>().ToList();
       
        [ObservableProperty]
        private EstudianteDto estudianteDto = new();

        [ObservableProperty]
        private string tituloPagina;

        private int IdEstudiante;

        [ObservableProperty]
        private bool loadingEstudiante = false;

        public EstudianteViewModel(DbbContext context)
        {
            _dbContext = context;
        }
        public EstudianteViewModel()
        {

        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var id = int.Parse(query["id"].ToString());
            IdEstudiante = id;

            if (IdEstudiante == 0)
            {
                TituloPagina = "Nuevo Estudiante";
            }
            else
            {
                TituloPagina = "Editar Estudiante";
                LoadingEstudiante = true;

                var encontrado = await _dbContext.Estudiante.FirstOrDefaultAsync(c => c.Id == id);
                if (encontrado != null)
                {
                    EstudianteDto = new EstudianteDto
                    {
                        Id = encontrado.Id,
                        Edad = encontrado.Edad,
                        Cedula = encontrado.Cedula,
                        Contrasenia = encontrado.Contrasenia,
                        Nombre = encontrado.Nombre,
                        NombreUsuario = encontrado.NombreUsuario,
                        Grado= encontrado.Grado,
                    };
                }

                MainThread.BeginInvokeOnMainThread(() => { LoadingEstudiante = false; });
            }
        }

        [RelayCommand]
        public async Task Guardar()
        {
            LoadingEstudiante = true;

            var mensaje = new Cuerpo();

            await Task.Run(async () =>
            {
                if (IdEstudiante == 0)
                {
                    var tbEstudiante = new Estudiante
                    {
                        Nombre = EstudianteDto.Nombre,
                        NombreUsuario = EstudianteDto.NombreUsuario,
                        Contrasenia = EstudianteDto.Contrasenia,
                        Edad = EstudianteDto.Edad,
                        Cedula = EstudianteDto.Cedula,
                        Grado= EstudianteDto.Grado,
                    };

                    _dbContext.Estudiante.Add(tbEstudiante);
                    await _dbContext.SaveChangesAsync();

                    EstudianteDto.Id = tbEstudiante.Id;

                    mensaje = new Cuerpo
                    {
                        EsCrear = true,
                        EstudianteDto = EstudianteDto
                    };
                }
                else
                {
                    var encontrado = await _dbContext.Estudiante.FirstOrDefaultAsync(c => c.Id == IdEstudiante);

                    if (encontrado != null)
                    {
                        encontrado.Nombre = EstudianteDto.Nombre;
                        encontrado.NombreUsuario = EstudianteDto.NombreUsuario;
                        encontrado.Contrasenia = EstudianteDto.Contrasenia;
                        encontrado.Edad = EstudianteDto.Edad;
                        encontrado.Cedula = EstudianteDto.Cedula;
                        encontrado.Grado = EstudianteDto.Grado;

                        await _dbContext.SaveChangesAsync();

                        mensaje = new Cuerpo
                        {
                            EsCrear = false,
                            EstudianteDto = EstudianteDto
                        };
                    }
                }

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    LoadingEstudiante = false;
                    WeakReferenceMessenger.Default.Send(new Mensajeria(mensaje));
                    Shell.Current.Navigation.PopAsync();
                });
            });
        }
    }
}
