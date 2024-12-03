using CCVProyecto2P2.Services.EstudianteService;
using CCVProyecto2P2.ViewsModels;
using Microsoft.Extensions.Logging;

namespace CCVProyecto2P2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("TheStudentsTeacher-Regular.ttf", "TheStudentsTeacherFont");
                    fonts.AddFont("Schoolwork-Regular.ttf", "SchoolworkFont");

                });

#if DEBUG
            builder.Logging.AddDebug();
            builder.Services.AddSingleton<IEstudiante, EstudianteService>();
            builder.Services.AddSingleton<EstudianteViewModel>();

#endif

            return builder.Build();
        }
    }
}
