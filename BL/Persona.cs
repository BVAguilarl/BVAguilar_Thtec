using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Persona
    {
        public static ML.Result AddPersona(ML.Persona persona)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BVAguilar_ThtecEntities context = new DL.BVAguilar_ThtecEntities())
                {
                    persona.FechaDeAlta = DateTime.Now;
                    DateTime fechaNacimiento = DateTime.ParseExact(persona.FechaDeNacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                    var query = context.AddPersona(persona.Nombre,
                                                   persona.ApellidoPaterno,
                                                   persona.ApellidoMaterno,
                                                   persona.Telefono,
                                                   persona.Correo,
                                                   persona.Contraseña,
                                                   fechaNacimiento,
                                                   persona.FechaDeAlta);
                    context.SaveChanges();

                    if (query != 0)
                    {
                        result.Correct = true;
                        result.ErrorMessage = "Se registro correctamente los datos de la persona";
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudieron registrar los datos de la persona";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result UpdatePersona(ML.Persona persona)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BVAguilar_ThtecEntities context = new DL.BVAguilar_ThtecEntities())
                {
                    DateTime fechaNacimiento = DateTime.ParseExact(persona.FechaDeNacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                    var query = context.UpdatePersona(persona.IdPersona,
                                                      persona.Nombre,
                                                      persona.ApellidoPaterno,
                                                      persona.ApellidoMaterno,
                                                      persona.Telefono,
                                                      persona.Correo,
                                                      persona.Contraseña,
                                                      fechaNacimiento,
                                                      persona.FechaDeAlta);
                    if (query != 0)
                    {
                        result.Correct = true;
                        result.ErrorMessage = "Se actualizaron correctamente los datos de la persona";
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudieron actualizar los datos de la persona";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result DeletePersona(int IdPersona)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BVAguilar_ThtecEntities context = new DL.BVAguilar_ThtecEntities())
                {
                    var query = context.DeletePersona(IdPersona);

                    if (query != 0)
                    {
                        result.Correct = true;
                        result.ErrorMessage = "Se eliminaron correctamente los datos de la persona";
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudieron eliminar los datos de la persona";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result GetAllPersona()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BVAguilar_ThtecEntities context = new DL.BVAguilar_ThtecEntities())
                {
                    var query = context.GetAllPersona().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.Persona persona = new ML.Persona();

                            persona.IdPersona = item.IdPersona;
                            persona.Nombre = item.Nombre;
                            persona.ApellidoPaterno = item.ApellidoPaterno;
                            persona.ApellidoMaterno = item.ApellidoMaterno;
                            persona.Telefono = item.Telefono;
                            persona.Correo = item.Correo;
                            persona.Contraseña = item.Contraseña;
                            persona.FechaDeNacimiento = (item.FechaDeNacimiento.HasValue  ? item.FechaDeNacimiento.Value : DateTime.MinValue).ToString("MM/dd/yyyy");
                            persona.FechaDeAlta = item.FechaDeAlta.HasValue ? item.FechaDeAlta.Value : DateTime.MinValue;

                            result.Objects.Add(persona);
                        }
                        
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudieron consultar los datos de la tabla Persona";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result GetByIdPersona(int IdPersona)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BVAguilar_ThtecEntities context = new DL.BVAguilar_ThtecEntities())
                {
                    var query = context.GetByIdPersona(IdPersona).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Persona persona = new ML.Persona();

                        persona.IdPersona = query.IdPersona;
                        persona.Nombre = query.Nombre;
                        persona.ApellidoPaterno = query.ApellidoPaterno;
                        persona.ApellidoMaterno = query.ApellidoMaterno;
                        persona.Telefono = query.Telefono;
                        persona.Correo = query.Correo;
                        persona.Contraseña = query.Contraseña;
                        persona.FechaDeNacimiento = (query.FechaDeNacimiento.HasValue ? query.FechaDeNacimiento.Value : DateTime.MinValue).ToString("MM/dd/yyyy");
                        persona.FechaDeAlta = query.FechaDeAlta.HasValue ? query.FechaDeAlta.Value : DateTime.MinValue;

                        result.Object = persona;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudieron consultar los datos de la persona";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
