using Projeto_Web_Lh_Pets_versão_1;

namespace LHPetsEntrega;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Web Project - LH Pets V1.0");
        
        app.MapGet("/index", (HttpContext Context) => {
            
            Context.Response.Redirect("index.html", false);
        });

        Banco dba = new Banco();
        app.MapGet("/customerslist", (HttpContext Context) => {

            Context.Response.WriteAsync( dba.GetListString());
        });        
        app.UseStaticFiles();
        app.Run();
    }
}
