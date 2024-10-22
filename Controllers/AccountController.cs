using System;
using System.Data.SqlClient;
using Dapper;

public class AccountController
{
    // Método para manejar el login de usuarios
    public void Login(string nombreUsuario, string contraseña)
    {
        using (var connection = BD.GetConnection()) // Utilizando la clase BD para obtener la conexión
        {
            string query = "SELECT * FROM Usuarios WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña";
            var usuario = connection.QueryFirstOrDefault<Usuario>(query, new { NombreUsuario = nombreUsuario, Contraseña = contraseña });

            if (usuario != null)
            {
                Console.WriteLine("Login exitoso. Bienvenido, " + usuario.Nombre + " " + usuario.Apellido + "!");
            }
            else
            {
                Console.WriteLine("Usuario o contraseña incorrecta.");
            }
        }
    }

    // Método para manejar el registro de un nuevo usuario
    public void Registro(string nombre, string apellido, string nombreUsuario, string gmail, string contraseña)
    {
        using (var connection = BD.GetConnection())
        {
            string query = "INSERT INTO Usuarios (Nombre, Apellido, NombreUsuario, Gmail, Contraseña) " +
                           "VALUES (@Nombre, @Apellido, @NombreUsuario, @Gmail, @Contraseña)";

            var filasAfectadas = connection.Execute(query, new
            {
                Nombre = nombre,
                Apellido = apellido,
                NombreUsuario = nombreUsuario,
                Gmail = gmail,
                Contraseña = contraseña
            });

            if (filasAfectadas > 0)
            {
                Console.WriteLine("Registro exitoso. Bienvenido, " + nombreUsuario + "!");
            }
            else
            {
                Console.WriteLine("Error durante el registro.");
            }
        }
    }

    // Método para manejar la opción de "Olvidé mi contraseña"
    public void OlvideMiContraseña(string gmail)
    {
        using (var connection = BD.GetConnection())
        {
            string query = "SELECT * FROM Usuarios WHERE Gmail = @Gmail";
            var usuario = connection.QueryFirstOrDefault<Usuario>(query, new { Gmail = gmail });

            if (usuario != null)
            {
                // Simulación de envío de enlace de recuperación de contraseña
                Console.WriteLine("Se ha enviado un enlace de recuperación de contraseña al correo: " + gmail);
            }
            else
            {
                Console.WriteLine("No se encontró un usuario con ese correo.");
            }
        }
    }
}