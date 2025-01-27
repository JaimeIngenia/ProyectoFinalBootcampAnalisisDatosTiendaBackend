﻿namespace AnalisisDeDatosBetekTienda.ViewModels.Empleado
{
    public class GetAllEmpleadosViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public Guid HorarioId { get; set; } // Id del horario asociado
        public Guid PuestoId { get; set; } // Id del puesto asociado
    }

}
