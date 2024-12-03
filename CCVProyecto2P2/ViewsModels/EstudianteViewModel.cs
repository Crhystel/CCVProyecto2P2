using CCVProyecto2P2.Models;
using CCVProyecto2P2.Services.EstudianteService;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CCVProyecto2P2.ViewsModels
{
    public class EstudianteViewModel : INotifyPropertyChanged
    {
        private readonly IEstudiante _estudianteService;

        private Estudiante _estudiante;
        public Estudiante Estudiante
        {
            get => _estudiante;
            set
            {
                _estudiante = value;
                OnPropertyChanged();
            }
        }
        public EstudianteViewModel()
        {
            
        }

        public ObservableCollection<Estudiante> Estudiantes { get; set; } = new ObservableCollection<Estudiante>();
        public ObservableCollection<RolEnum> Roles { get; } = new ObservableCollection<RolEnum>(Enum.GetValues<RolEnum>());
        public ObservableCollection<GradoEnum> Grados { get; } = new ObservableCollection<GradoEnum>(Enum.GetValues<GradoEnum>());

        public ICommand GuardarEstudianteCommand { get; }
        public ICommand CargarEstudiantesCommand { get; }
        public ICommand EliminarEstudianteCommand { get; }

        public EstudianteViewModel(IEstudiante estudianteService)
        {
            _estudianteService = estudianteService;
            Estudiante = new Estudiante();

            GuardarEstudianteCommand = new Command(async () => await GuardarEstudiante());
            CargarEstudiantesCommand = new Command(async () => await CargarEstudiantes());
            EliminarEstudianteCommand = new Command<int>(async id => await EliminarEstudiante(id));
        }

        private async Task GuardarEstudiante()
        {
            var success = await _estudianteService.AddUpdateEstudianteAsync(Estudiante);
            if (success)
            {
                await App.Current.MainPage.DisplayAlert("Éxito", "Estudiante guardado correctamente", "OK");
                await CargarEstudiantes(); 
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "No se pudo guardar el estudiante", "OK");
            }
        }

        private async Task CargarEstudiantes()
        {
            var estudiantes = await _estudianteService.GetEstudiantesAsync();
            Estudiantes.Clear();
            foreach (var estudiante in estudiantes)
            {
                Estudiantes.Add(estudiante);
            }
        }

        private async Task EliminarEstudiante(int id)
        {
            var success = await _estudianteService.DeleteEstudianteAsync(id);
            if (success)
            {
                await App.Current.MainPage.DisplayAlert("Éxito", "Estudiante eliminado correctamente", "OK");
                await CargarEstudiantes(); // Actualizar lista
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar el estudiante", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
