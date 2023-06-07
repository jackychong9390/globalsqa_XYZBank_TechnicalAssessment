using System;
using System.IO;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.Util.Collections;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;

public class DataReader
{
    // Return property value from config.properties file
    public static Properties GetConfigValue()
    {
        Properties propertyValue = null;

        try
        {
            propertyValue = new Properties();
            FileStream inputFile = new FileStream("./src/test/resources/config.properties", FileMode.Open);
            propertyValue.Load(inputFile);

        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.StackTrace);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.StackTrace);
        }

        return propertyValue;
    }

    // Read data from external spreadsheet
    public static string[][] GetSpreadSheetData(string workbookName)
    {
        string[][] dataSet = null;

        try
        {
            string dataSheetFilePath = Path.Combine("./datasheet/", workbookName + ".xlsx");
            FileStream fileInput = new FileStream(dataSheetFilePath, FileMode.Open);

            XSSFWorkbook workbook = new XSSFWorkbook(fileInput);
            XSSFSheet sheet = (XSSFSheet)workbook.GetSheetAt(0);

            int totalRows = sheet.LastRowNum;
            int totalColumns = sheet.GetRow(1).LastCellNum;

            dataSet = new string[totalRows][];

            for (int row = 1; row <= totalRows; row++)
            {
                XSSFRow rowData = (XSSFRow)sheet.GetRow(row);

                dataSet[row - 1] = new string[totalColumns];

                for (int column = 0; column < totalColumns; column++)
                {
                    XSSFCell columnData = (XSSFCell)rowData.GetCell(column);
                    CellType cellType = columnData.CellType;

                    switch (cellType)
                    {
                        case CellType.String:
                            string cellVal = columnData.StringCellValue;
                            dataSet[row - 1][column] = cellVal;
                            break;
                        case CellType.Numeric:
                            double cellValue = columnData.NumericCellValue;
                            dataSet[row - 1][column] = cellValue.ToString();
                            break;
                    }
                }
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("file not found" + e);
        }
        catch (IOException e)
        {
            Console.WriteLine("IOException" + e);
        }
        catch (EncryptedDocumentException e)
        {
            Console.WriteLine("EncryptedDocumentException" + e);
        }

        return dataSet;
    }
}
