using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaPentagono.Modelos;

namespace PentagonoTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CrearPaciente()
        {
            Paciente paciente = new Paciente();
            paciente.nombre = "Erick";
            paciente.apellido = "Guzman";
            paciente.fecha_nacimiento = "10/10/1994";
            paciente.estatura = 1.70F;
            paciente.peso = 190;

            Assert.AreEqual(paciente.Save(), true);
        }

        [TestMethod]
        public void CrearEspecialidad()
        {
            Especialidad especialidad = new Especialidad();
            especialidad.nombre = "Infectología";
            Assert.AreEqual(especialidad.Save(), true);
        }



        [TestMethod]
        public void CrearMedico()
        {
            Medico medico = new Medico();
            medico.nombre = "Leonel";
            medico.apellido = "Aguero";
            medico.id_especialidad = 6;

            Assert.AreEqual(medico.Save(), true);
        }

        [TestMethod]
        public void CrearCita()
        {
            CitaMedica citaMedica = new CitaMedica();
            citaMedica.id_paciente = 1;
            citaMedica.id_medico = 1;
            citaMedica.fecha_hora = "2022/09/15 15:30:00";
            Assert.AreEqual(citaMedica.Save(), true);
        }

        [TestMethod]
        public void CerrarCita()
        {
            CitaMedica citaMedica = new CitaMedica();
            citaMedica.id = 23;
            Assert.AreEqual(citaMedica.Terminar(), true);
        }

        [TestMethod]
        public void AgregarDiagnostico()
        {
            Historial historial = new Historial();
            historial.id_cita_medica = 23;
            historial.diagnostico = "El paciente se encuentra contagiado de Covid 19";
            Assert.AreEqual(historial.Save(), true);
        }





    }
}
