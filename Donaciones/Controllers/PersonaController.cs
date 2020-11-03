using System.Net;
using System.Linq;
using Logica;
using Datos;
using Entidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Donaciones.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Donaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly ServicioPersona _servicioPersona;
        public PersonaController(AyudaContext context)
        {
            _servicioPersona = new ServicioPersona(context);
        }
         // GET: api/Persona
        [HttpGet]
        public ActionResult<IEnumerable<PersonaViewModel>> Gets()
        {
            var personasResponse = _servicioPersona.ConsultarTodos();
            if(!personasResponse.Error)
            {
                return Ok(personasResponse.Personas.Select(p=> new PersonaViewModel(p)));
            }
            return BadRequest(personasResponse.Mensaje);
        }
        [HttpGet("{totalDonaciones}")]
        public ActionResult<decimal> ObtenerTotalDonaciones(string totalDonaciones)
        {
            return _servicioPersona.TotalizarDonaciones();
        }
        // POST: api/Persona
        [HttpPost]
        public ActionResult<GuardarPersonaResponse> Post(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            var response = _servicioPersona.Guardar(persona);
            return response;
        }
        private Persona MapearPersona(PersonaInputModel personaInput)
        {
            var persona = new Persona
            {
                Identificacion = personaInput.Identificacion,
                Nombres = personaInput.Nombres,
                Apellidos = personaInput.Apellidos,
                Ciudad = personaInput.Ciudad,
                Sexo = personaInput.Sexo,
                Edad = personaInput.Edad,
                Donacion = personaInput.Donacion
            };
            return persona;
        }
    }
}
