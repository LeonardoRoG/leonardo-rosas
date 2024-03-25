namespace Novit.Academia.Endpoints.DTO;

public class UsuarioDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class UsuarioRegisterDto : UsuarioDto
{
    public string Role { get; set; } = string.Empty;
}

public class UsuarioReservaDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
}

public class UsuarioReservaRequestDto
{
    public Guid Id { get; set; }
}

public class UsuarioReservaResponseDto
{
    public string Userame { get; set; } = string.Empty;
}