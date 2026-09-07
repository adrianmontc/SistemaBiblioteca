using System;

public record Prestamo(
    int CodigoLibro,
    int IdentificadorUsuario,
    DateTime FechaPrestamo,
    bool Activo
);