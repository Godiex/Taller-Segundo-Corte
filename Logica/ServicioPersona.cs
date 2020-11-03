using System;
using System.Collections.Generic;
using Entidad;
using Datos;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class ServicioPersona
    {
        private readonly AyudaContext _context;
        public ServicioPersona(AyudaContext context)
        {
            _context = context;
        }
        public GuardarPersonaResponse Guardar(Persona persona)
        {
            try
            {
                var respuestaPersona  =  ObtenerPersonaValidada(persona);
                if(!respuestaPersona.Error)
                {
                    _context.Personas.Add(persona);
                    _context.SaveChanges();
                    respuestaPersona.Mensaje = $"{persona.Identificacion}, la donacion asociada se registro con exito";
                }
                return respuestaPersona;
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");
            }
        }
        public GuardarPersonaResponse ObtenerPersonaValidada (Persona persona)
        {
            var personaBuscada  =  _context.Personas.Find(persona.Identificacion);
            if(personaBuscada != null )
            {
                return new GuardarPersonaResponse("Error la Persona ya se encuentra registrada");
            }
            else
            {
                decimal ValorDonacion = persona.Donacion.ValorDonacion;
                return (ExcedeElMonto(ValorDonacion )) ? new GuardarPersonaResponse("Error el monto es excedido") : new GuardarPersonaResponse(persona);
            }   
        }
        public ConsultarPersonaResponse ConsultarTodos()
        {
            try 
            {
                var personas = _context.Personas
                                    .Include(d => d.Donacion)
                                    .ToList();
                return new ConsultarPersonaResponse(personas);
            }
            catch(Exception e)
            {
                return new ConsultarPersonaResponse(e.Message);
            }
        }
        public decimal TotalizarDonaciones ()
        {
            return _context.Donaciones.Sum(d => d.ValorDonacion);
        }
        public bool ExcedeElMonto (decimal valorDonado)
        {
            decimal totalDonaciones = TotalizarDonaciones();
            decimal monto = 600000000;
            bool resultado = (totalDonaciones + valorDonado > monto )? true : false;
            return resultado;
        }
    }
    public class GuardarPersonaResponse 
        {
            public GuardarPersonaResponse(Persona persona)
            {
                Error = false;
                Persona = persona;
            }
            public GuardarPersonaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Persona Persona { get; set; }
        }
        public class ConsultarPersonaResponse 
        {
            public ConsultarPersonaResponse(List<Persona> personas)
            {
                Error = false;
                Personas = personas;
            }
            public ConsultarPersonaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Persona> Personas { get; set; }
        }
}
