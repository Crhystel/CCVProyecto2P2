using CCVProyecto2P2.DataAccess;
using CCVProyecto2P2.ViewsModels;
using Microsoft.Extensions.Logging;
using CCVProyecto2P2.Models;
using CCVProyecto2P2.ViewsAdmin;
using CCVProyecto2P2.ViewsProfesor;


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
            var dbContext = new DbbContext();

            builder.Services.AddDbContext<DbbContext>();
            builder.Services.AddTransient<AgregarEstudianteView>();
            builder.Services.AddTransient<EstudianteViewModel>();
            builder.Services.AddTransient<EMainPage>();
            builder.Services.AddTransient<EMainViewModel>();

            builder.Services.AddTransient<AgregarProfesorView>();
            builder.Services.AddTransient<PMainPage>();
            builder.Services.AddTransient<PMainViewModel>();
            builder.Services.AddTransient<ProfesorViewModel>();
            dbContext.Database.EnsureCreated();
            dbContext.Dispose();

            Routing.RegisterRoute(nameof(AgregarEstudianteView), typeof(AgregarEstudianteView));
            Routing.RegisterRoute(nameof(AgregarProfesorView), typeof(AgregarProfesorView));

#if DEBUG
            builder.Logging.AddDebug();
            builder.Services.AddSingleton<EstudianteViewModel>();
            builder.Services.AddSingleton<ProfesorViewModel>();
#endif

            return builder.Build();
        }
    }
}
