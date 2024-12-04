using CCVProyecto2P2.DataAccess;
using CCVProyecto2P2.Dto;
using CCVProyecto2P2.Models;
using CCVProyecto2P2.Utilidades;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;

namespace CCVProyecto2P2.ViewsModels
{
    public partial class ProfesorViewModel : ObservableObject, IQueryAttributable
    {
        private readonly DbbContext _dbContext;

        public List<MateriaEnum> MateriasDisponibles { get; } = Enum.GetValues(typeof(MateriaEnum)).Cast<MateriaEnum>().ToList();

        [ObservableProperty]
        private ProfesorDto profesorDto = new();

        [ObservableProperty]
        private string tituloPagina;

        private int IdProfesor;

        [ObservableProperty]
        private bool loadingProfesor = false;

        public ProfesorViewModel(DbbContext context)
        {
            _dbContext = context;
        }
        public ProfesorViewModel()
        {

        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var id = int.Parse(query["id"].ToString());
            IdProfesor = id;

            if (IdProfesor == 0)
            {
                TituloPagina = "Nuevo Profesor";
            }
            else
            {
                TituloPagina = "Editar Profesor";
                LoadingProfesor = true;

                var encontrado = await _dbContext.Profesor.FirstOrDefaultAsync(c => c.Id == id);
                if (encontrado != null)
                {
                    ProfesorDto = new ProfesorDto
                    {
                        Id = encontrado.Id,
                        Edad = encontrado.Edad,
                        Cedula = encontrado.Cedula,
                        Contrasenia = encontrado.Contrasenia,
                        Nombre = encontrado.Nombre,
                        NombreUsuario = encontrado.NombreUsuario,
                        Materia = encontrado.Materia,
                    };
                }

                MainThread.BeginInvokeOnMainThread(() => { LoadingProfesor = false; });
            }
        }

        [RelayCommand]
        public async Task Guardar()
        {
            LoadingProfesor = true;

            var mensaje = new CuerpoP();

            await Task.Run(async () =>
            {
                if (IdProfesor == 0)
                {
                    var tbProfesor = new Profesor
                    {
                        Nombre = ProfesorDto.Nombre,
                        NombreUsuario = ProfesorDto.NombreUsuario,
                        Contrasenia = ProfesorDto.Contrasenia,
                        Edad = ProfesorDto.Edad,
                        Cedula = ProfesorDto.Cedula,
                        Materia=ProfesorDto.Materia,
                    };

                    _dbContext.Profesor.Add(tbProfesor);
                    await _dbContext.SaveChangesAsync();

                    ProfesorDto.Id = tbProfesor.Id;

                    mensaje = new CuerpoP
                    {
                        EsCrear =true,
                        ProfesorDto= ProfesorDto,
                        
                    };
                }
                else
                {
                    var encontrado = await _dbContext.Profesor.FirstOrDefaultAsync(c => c.Id == IdProfesor);

                    if (encontrado != null)
                    {
                        encontrado.Nombre = ProfesorDto.Nombre;
                        encontrado.NombreUsuario = ProfesorDto.NombreUsuario;
                        encontrado.Contrasenia = ProfesorDto.Contrasenia;
                        encontrado.Edad = ProfesorDto.Edad;
                        encontrado.Cedula = ProfesorDto.Cedula;
                        encontrado.Materia=ProfesorDto.Materia;

                        await _dbContext.SaveChangesAsync();

                        mensaje = new CuerpoP
                        {
                            EsCrear = false,
                            ProfesorDto = ProfesorDto
                        };
                    }
                }

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    LoadingProfesor = false;
                    WeakReferenceMessenger.Default.Send(new MensajeriaP(mensaje));
                    Shell.Current.Navigation.PopAsync();
                });
            });
        }
    }
}
