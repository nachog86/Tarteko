using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization; // Agregado
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServidorApi.Data;
using ServidorApi.Service;
using ServidorApi.DTOs;

namespace ServidorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService _jwtService;

        public UsuariosController(ApplicationDbContext context, JwtService jwtService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest("Usuario ID mismatch");
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.UsuarioId }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuarioId == id);
        }
    [HttpPost("Register")]
public async Task<ActionResult<Usuario>> Register([FromBody] RegisterRequest request)
{
    // Validación inicial del request.
    if (request == null || 
        string.IsNullOrEmpty(request.Username) || 
        string.IsNullOrEmpty(request.Password) ||
        string.IsNullOrEmpty(request.Email))
    {
        return BadRequest("User and password are required");
    }
    
    // Crear un nuevo usuario basado en el request.
    var usuario = new Usuario
    {
        Username = request.Username,
        Email = request.Email,
        
        
        // otras propiedades necesarias...
    };
    

    // Validar que el nombre de usuario no esté tomado
    if (await _context.Usuarios.AnyAsync(x => x.Username == usuario.Username))
    {
        return BadRequest("Username is already taken");
    }

    // Validar y asignar la contraseña
    try
    {
        usuario.SetPassword(request.Password);
    }
    catch (ArgumentNullException)
    {
        return BadRequest("Password cannot be null or empty");
    }

    // Asignar rol al usuario
    if(!_context.Usuarios.Any())
    {
        usuario.Rol = Rol.Admin; // El primer usuario es un Admin.
    }
    else 
    {
        usuario.Rol = Rol.Propietario; // Los usuarios subsiguientes son Propietarios por defecto.
    }

    // Intentar agregar al usuario y guardar los cambios en la base de datos
    try
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
        // Aquí podrías loggear el error para revisión y debugging
        // Log.Error(ex, "Error registering user");
        return StatusCode(500, "An error occurred while registering the user");
    }

    // Retorna el usuario creado con el ID asignado
    return CreatedAtAction(nameof(GetUsuario), new { id = usuario.UsuarioId }, usuario);
}

      [HttpPost("Login")]
public async Task<ActionResult<string>> Login([FromBody] LoginRequest request)
{
    if (request == null || 
        string.IsNullOrEmpty(request.Username) || 
        string.IsNullOrEmpty(request.Password))
    {
        return BadRequest("Username and password are required");
    }

    var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == request.Username);
    if(usuario == null || !usuario.VerifyPassword(request.Password))
    {
        return Unauthorized("Invalid username or password");
    }

    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, usuario.Username),
        new Claim(ClaimTypes.Role, usuario.Rol.ToString())
    };

    return _jwtService.GenerateSecurityToken(claims);
}


       [HttpPut("{id}/Role")]
[Authorize(Roles = "Admin")] // Asegurarse de que solo el Admin puede acceder a esto.
public async Task<IActionResult> ChangeUserRole(int id, Rol newRole)
{
    var user = await _context.Usuarios.FindAsync(id);
    if (user == null) return NotFound();

    if(newRole != Rol.Comercial)
    {
        return BadRequest("Can only change role to Comercial");
    }

    user.Rol = newRole;
    await _context.SaveChangesAsync();

    return NoContent();
}
[HttpPut("{id}/ChangePassword")]
[Authorize] // Asegúrate de que solo los usuarios autenticados puedan cambiar su propia contraseña.
public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangePasswordDto dto)
{
    // Obtener el usuario de la base de datos.
    var usuario = await _context.Usuarios.FindAsync(id);
    if (usuario == null)
    {
        return NotFound();
    }

    // Verificar que la contraseña antigua es correcta.
    if (!usuario.VerifyPassword(dto.OldPassword))
    {
        return BadRequest("Old password is incorrect");
    }

    // Establecer la nueva contraseña.
    usuario.SetPassword(dto.NewPassword);
    
    // Guardar los cambios en la base de datos.
    await _context.SaveChangesAsync();

    return NoContent();
}



      
        
        

    


        


    }
}

