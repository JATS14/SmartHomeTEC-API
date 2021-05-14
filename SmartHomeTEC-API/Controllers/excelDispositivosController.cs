using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Excel;    
using Microsoft.Extensions.Logging;
using SmartHomeTEC_API.API;
using Range = Microsoft.Office.Interop.Excel.Range;


namespace SmartHomeTEC_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class excelDispositivosController : ControllerBase
    {
        [HttpPost]
        [Route("subirExcelDispositivos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta subirExcelDispositivos(IFormFile excel)
        {
            Console.WriteLine("Se recibio un archivo del POST");
            try
            {   
                var result = new StringBuilder();
                var reader = new StreamReader(excel.OpenReadStream());
                
                while (reader.Peek() >= 0){
                    result.AppendLine(reader.ReadLine()); 
                }
                
                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine(result[i]);
                }
                
                
                return new respuesta("exito");
            }
            catch (Exception)
            {
                return new respuesta("error");
            }
        }
        
    }
}               /*
                Application app = new Application();
                Workbook lobroexcel = excel;
                Worksheet hojadeCalculo = (Worksheet)lobroexcel.Worksheets.get_Item(1);
                Range rango = hojadeCalculo.UsedRange;
                */


//Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
/*
MemoryStream stream = new MemoryStream();
excel.CopyTo(stream);
stream.Position = 0;
var reader = ExcelReaderFactory.CreateReader(stream);

while (reader.Read()) 
{
    Console.WriteLine("Numero Serie = " + reader.GetValue(0).ToString()+", Nombre = " + reader.GetValue(1).ToString()+ ", Precio = "+ reader.GetValue(2).ToString());
}
*/