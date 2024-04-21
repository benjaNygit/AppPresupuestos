# AppPresupuestos

## Comandos

Generar Migración Entity Framework

- Este comando posee la cadena de conección en su interior.
- Sobre escrive los archivos ya creados.
- Se debe se procurrar no borrar el metodo Instance del Context

```c#
Scaffold-DbContext "Server=(local);Database=Presupuestos;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context Context -Namespace Presupuestos -Force
``` 