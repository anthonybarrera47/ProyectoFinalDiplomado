using Enums;
using Extensores;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace Herramientas
{
    public static class Utils
    {
        public static void Alerta(System.Web.UI.Page page, TipoTitulo Titulo, TiposMensajes Mensaje, IconType iconType)
        {
            string TituloDescripcion = Titulo.GetDescription();
            string MensajeDescripcion = Mensaje.GetDescription();
            string iconTypeDescripcion = iconType.ToString();
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alert",
                            $"sweetalert('{TituloDescripcion}','{MensajeDescripcion}','{iconTypeDescripcion}')", true);
        }
        public static void ToastSweet(System.Web.UI.Page page, IconType iconType, TiposMensajes Mensaje)
        {
            string IconTypeDescripcion = iconType.ToString();
            string MensajeDescripcion = Mensaje.GetDescription();
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alert",
                            $"ToastSweetAlert('{IconTypeDescripcion}','{MensajeDescripcion}')", true);
        }
        public static void DialogResult(System.Web.UI.Page page, TipoTitulo Titulo, TiposMensajes Mensaje, IconType iconType)
        {
            string TituloDescripcion = Titulo.GetDescription();
            string MensajeDescripcion = Mensaje.GetDescription();
            string iconTypeDescripcion = iconType.ToString();
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alert",
                            $"DialogConfirm('{TituloDescripcion}','{MensajeDescripcion}','{iconTypeDescripcion}')", true);
        }
        public static void SweetAlert(dynamic ViewBag, TipoTitulo Titulo, TiposMensajes Mensaje, IconType iconType)
        {
            string TituloDescripcion = Titulo.GetDescription();
            string MensajeDescripcion = Mensaje.GetDescription();
            string iconTypeDescripcion = iconType.ToString();
            ViewBag.JSF = $"sweetalert('{TituloDescripcion}','{MensajeDescripcion}','{iconTypeDescripcion}');";
        }
        public static void ToastSweetMVC(dynamic ViewBag, IconType iconType, TiposMensajes Mensaje)
        {
            string IconTypeDescripcion = iconType.ToString();
            string MensajeDescripcion = Mensaje.GetDescription();
            ViewBag.JSF = $"ToastSweetAlert('{IconTypeDescripcion}','{MensajeDescripcion}')";
        }
        public static void MostrarModal(System.Web.UI.Page page, string NombreModal, string Titulo)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "Popup", $"{NombreModal}('{ Titulo }');", true);
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }

                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }
}
