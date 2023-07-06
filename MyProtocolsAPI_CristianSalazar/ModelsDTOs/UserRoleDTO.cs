namespace MyProtocolsAPI_CristianSalazar.ModelsDTOs
{
    public class UserRoleDTO
    {
        //un DTO ( data transfer object) sirve para dos funciones:
        //1. Simplificar la estructura de los json que se envian y llegan a los endpoint de los controllers
        //quitando composiciones innecesarias que solo harian que los json sean muy pesados o que muestren
        //info que no se desea ver(puede ser por seguridad)

        //2. Ocultar la estructura real de los modelos y por tanto de las tablas de BD a los programadores
        // /de las apps, paginas web o por apps de escritorio.

        //tomando en cuenta el segundo ejemplo y solo manera de ejemplo, este DTO tendra los nombres de propiedades
        //en español
        public int IDRolUsuario { get; set; }
        public string DescripcionRol { get; set; } = null!;









    }
}
