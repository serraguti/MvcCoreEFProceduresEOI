using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcCoreEFProcedures.Data;
using MvcCoreEFProcedures.Models;

#region SQL SERVER
/*
CREATE PROCEDURE SP_ALL_ENFERMOS
AS
	SELECT * FROM ENFERMO
GO
CREATE PROCEDURE SP_FIND_ENFERMO
(@INSCRIPCION NVARCHAR(30))
AS
	SELECT * FROM ENFERMO
	WHERE INSCRIPCION = @INSCRIPCION
GO
CREATE PROCEDURE SP_DELETE_ENFERMO
(@INSCRIPCION NVARCHAR(30))
AS
    DELETE FROM ENFERMO
	WHERE INSCRIPCION = @INSCRIPCION
GO
*/
#endregion

namespace MvcCoreEFProcedures.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public List<Enfermo> GetEnfermos()
        {
            string sql = "SP_ALL_ENFERMOS";
            //PRIMERO LA CONSULTA Y DESPUES EXTRAER
            var consulta =
                this.context.Enfermos.FromSqlRaw(sql);
            //EXTRAEMOS LOS DATOS
            List<Enfermo> enfermos =
                consulta.AsEnumerable().ToList();
            return enfermos;
        }

        //PROCEDIMIENTOS CON PARAMETROS
        public Enfermo FindEnfermos(string inscripcion)
        {
            //LOS PARAMETROS SE SEPARAN CON UN ESPACIO DEL PROCEDIMIENTO
            //Y ENTRE COMAS ENTRE ELLOS
            // SP_PROCEDIMIENTO @PARAM1, @PARAM2, @PARAM3
            string sql = "SP_FIND_ENFERMO @INSCRIPCION";
            SqlParameter paminscripcion = new SqlParameter("@INSCRIPCION", inscripcion);
            //SI TUVIERAMOS MULTIPLES PARAMETROS...
            //var consulta = this.context.Entity.FromSqlRaw(sql, pam1, pam2, pam3);
            var consulta = this.context.Enfermos.FromSqlRaw(sql, paminscripcion);
            Enfermo enfermo = consulta.AsEnumerable().FirstOrDefault();
            return enfermo;
       }

        public void DeleteEnfermo(string inscripcion)
        {
            string sql = "SP_DELETE_ENFERMO @INSCRIPCION";
            SqlParameter paminscripcion = new SqlParameter("@INSCRIPCION", inscripcion);
            this.context.Database.ExecuteSqlRaw(sql, paminscripcion);
        }
    }
}
