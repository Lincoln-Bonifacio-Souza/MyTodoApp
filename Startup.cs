using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyTodoApp.Data;
using Microsoft.EntityFrameworkCore;

namespace MyTodoApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; } // Interface para acessar a configuração do aplicativo

        public Startup(IConfiguration configuration) // Construtor da classe Startup, recebe uma instância de IConfiguration
        {
            Configuration = configuration; // Armazena a instância de IConfiguration na propriedade Configuration
        }

        public void ConfigureServices(IServiceCollection services) // Configuração dos serviços necessários para o aplicativo
        {
            services.AddControllersWithViews(); // Adiciona serviços para suportar controladores MVC
            services.AddRazorPages(); // Adiciona serviços para suportar páginas Razor

            var connectionString = Configuration.GetConnectionString("DefaultConnection"); // Obtém a string de conexão do arquivo de configuração

            services.AddDbContext<TaskContext>(options =>
                options.UseSqlServer(connectionString)); // Configura o contexto do banco de dados usando o provedor do SQL Server e a string de conexão
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // Configuração do pipeline de middleware do aplicativo
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Exibe páginas de exceção detalhadas durante o desenvolvimento
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); // Manipula exceções e redireciona para uma página de erro padrão em produção
                app.UseHsts(); // Adiciona o cabeçalho HTTP Strict Transport Security (HSTS) para garantir que o aplicativo seja acessado por HTTPS
            }

            app.UseHttpsRedirection(); // Redireciona solicitações HTTP para HTTPS
            app.UseStaticFiles(); // Serve arquivos estáticos, como CSS, JavaScript e imagens

            app.UseRouting(); // Configura o roteamento das solicitações HTTP

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"); // Define uma rota padrão para o controlador Home e a ação Index

                endpoints.MapRazorPages(); // Mapeia as páginas Razor para que possam ser acessadas por meio do roteamento
            });
        }
    }
}
