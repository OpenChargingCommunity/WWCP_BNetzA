///*
// * Copyright (c) 2014-2023 GraphDefined GmbH
// * This file is part of WWCP BNetzA <https://github.com/OpenChargingCloud/WWCP_BNetzA>
// *
// * Licensed under the Apache License, Version 2.0 (the "License");
// * you may not use this file except in compliance with the License.
// * You may obtain a copy of the License at
// *
// *     http://www.apache.org/licenses/LICENSE-2.0
// *
// * Unless required by applicable law or agreed to in writing, software
// * distributed under the License is distributed on an "AS IS" BASIS,
// * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// * See the License for the specific language governing permissions and
// * limitations under the License.
// */

//#region Usings

//using System;
//using System.IO;
//using System.Linq;
//using System.Collections.Generic;

//using OfficeOpenXml;

//using org.GraphDefined.Vanaheimr.Illias;

//#endregion

//namespace org.GraphDefined.WWCP.BNetzA
//{

//    public class BNetzA_ExcelExporter
//    {

//        public BNetzA_ExcelExporter(RoamingNetwork                     RoamingNetwork,
//                                    ChargingStationOperator            ChargingStationOperator,
//                                    String                             CompanyName,
//                                    Func<String,             Boolean>  IncludeDataSource       = null,
//                                    Func<Brand, Boolean>               IncludeBrand            = null,
//                                    Func<ChargingStation,    Boolean>  IncludeChargingStation  = null,
//                                    String                             Filename                = "BNetzA-Export.xlsx")
//        {

//            if (IncludeDataSource      == null)
//                IncludeDataSource      = _ => true;

//            if (IncludeBrand           == null)
//                IncludeBrand           = _ => true;

//            if (IncludeChargingStation == null)
//                IncludeChargingStation = _ => true;


//            File.Delete(Filename);

//            using (var package = new ExcelPackage(new FileInfo(Filename)))
//            {

//                // Set some document properties
//                package.Workbook.Properties.Title     = "Ladepunktanzeige Bundesnetzagentur für " + CompanyName;
//                package.Workbook.Properties.Author    = "Achim Friedland <achim.friedland@graphdefined.com>";
//                package.Workbook.Properties.Comments  = "Generated by GraphDefined GmbH / Open Charging Cloud";
//                package.Workbook.Properties.Company   = CompanyName;

//                // Set some custom property values
//                //package.Workbook.Properties.SetCustomPropertyValue("Checked by",   "chargeIT mobility");
//                //package.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "chargeIT mobility Gateway");


//                var ExcelWorksheet = package.Workbook.Worksheets.Add("Ladestationen");

//                ExcelWorksheet.Cells[  1,  1,   3,  4].Merge            = true;
//                ExcelWorksheet.Cells[  1,  1,   3,  4].Style.Font.Bold  = true;
//                ExcelWorksheet.Cells[  1,  1,   3,  4].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
//                ExcelWorksheet.Cells[  1,  1,   3,  4].Style.VerticalAlignment   = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
//                ExcelWorksheet.Cells[  1,  1,   3,  4].Style.Font.Size           = 14;
//                ExcelWorksheet.Cells[  1,  1,   3,  4].Style.Border.Left.  Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[  1,  1,   3,  4].Style.Border.Top.   Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[  1,  1,   3,  4].Style.Border.Right. Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[  1,  1,   3,  4].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[  1,  1].Value = "Ladepunktanzeige Bundesnetzagentur";

//                var row = 5;

//                ExcelWorksheet.Cells[row,    1].Value = "Betreibernummer";
//                ExcelWorksheet.Cells[row,    2].Value = "Name/Rechtsform";
//                ExcelWorksheet.Cells[row,    3].Value = "Strasse, Hausnummer";
//                ExcelWorksheet.Cells[row,    4].Value = "PLZ Ort";
//                ExcelWorksheet.Cells[row,    5].Value = "Name des/der Geschäftsführers/in";
//                ExcelWorksheet.Cells[row,    6].Value = "Anlagennummer des BDEW (freiwillig)";
//                ExcelWorksheet.Cells[row,    7].Value = "Tel. des Betreibers";
//                ExcelWorksheet.Cells[row,    8].Value = "Homepage";
//                ExcelWorksheet.Cells[row,    9].Value = "Ansprechpartner";
//                ExcelWorksheet.Cells[row,   10].Value = "Tel. des Ansprechpartners";
//                ExcelWorksheet.Cells[row,   11].Value = "E-Mailadresse";
//                ExcelWorksheet.Cells[row,   12].Value = "Einverständnis zur Veröffentlichung";

//                ExcelWorksheet.Cells[row, 1, row, 12].Style.Font.Bold   = true;
//                ExcelWorksheet.Cells[row, 1, row, 12].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(255, 255, 255, 255));
//                ExcelWorksheet.Cells[row, 1, row, 12].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
//                ExcelWorksheet.Cells[row, 1, row, 12].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 79, 129, 189));

//                row++;
//                ExcelWorksheet.Cells[row,  1].Value = "6136";
//                ExcelWorksheet.Cells[row,  2].Value = "chargeIT mobility GmbH";

//                var a = ChargingStationOperator.Brands.ToArray();
//                var b = ChargingStationOperator.ChargingStationGroups.ToArray();

//                ExcelWorksheet.Cells[row, 2].Value = ChargingStationOperator.Brands?.Where(brand => IncludeBrand(brand)).Select(brand => brand?.Name?.FirstText()).OrderBy(brand => brand).AggregateWith(";");
//                row++;
//                row++;

//                ExcelWorksheet.Cells[row,  1, row,  4].Merge            = true;
//                ExcelWorksheet.Cells[row,  1, row,  4].Style.Font.Bold  = true;
//                ExcelWorksheet.Cells[row,  1, row,  4].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
//                ExcelWorksheet.Cells[row,  1, row,  4].Style.Border.Left.  Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row,  1, row,  4].Style.Border.Top.   Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row,  1, row,  4].Style.Border.Right. Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row,  1, row,  4].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row,  1].Value = "Daten zur Anzeige";

//                ExcelWorksheet.Cells[row,  5, row, 12].Merge            = true;
//                ExcelWorksheet.Cells[row,  5, row, 12].Style.Font.Bold  = true;
//                ExcelWorksheet.Cells[row,  5, row, 12].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
//                ExcelWorksheet.Cells[row,  5, row, 12].Style.Border.Left.  Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row,  5, row, 12].Style.Border.Top.   Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row,  5, row, 12].Style.Border.Right. Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row,  5, row, 12].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row,  5].Value = "Angaben zur Ladeeinrichtung";

//                ExcelWorksheet.Cells[row, 13, row, 22].Merge            = true;
//                ExcelWorksheet.Cells[row, 13, row, 22].Style.Font.Bold  = true;
//                ExcelWorksheet.Cells[row, 13, row, 22].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
//                ExcelWorksheet.Cells[row, 13, row, 22].Style.Border.Left.  Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row, 13, row, 22].Style.Border.Top.   Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row, 13, row, 22].Style.Border.Right. Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row, 13, row, 22].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row, 13].Value = "1. Ladepunkt";

//                ExcelWorksheet.Cells[row, 23, row, 32].Merge            = true;
//                ExcelWorksheet.Cells[row, 23, row, 32].Style.Font.Bold  = true;
//                ExcelWorksheet.Cells[row, 23, row, 32].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
//                ExcelWorksheet.Cells[row, 23, row, 32].Style.Border.Left.  Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row, 23, row, 32].Style.Border.Top.   Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row, 23, row, 32].Style.Border.Right. Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row, 23, row, 32].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row, 23].Value = "2. Ladepunkt";

//                ExcelWorksheet.Cells[row, 33, row, 42].Merge            = true;
//                ExcelWorksheet.Cells[row, 33, row, 42].Style.Font.Bold  = true;
//                ExcelWorksheet.Cells[row, 33, row, 42].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
//                ExcelWorksheet.Cells[row, 33, row, 42].Style.Border.Left.  Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row, 33, row, 42].Style.Border.Top.   Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row, 33, row, 42].Style.Border.Right. Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row, 33, row, 42].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row, 33].Value = "3. Ladepunkt";

//                ExcelWorksheet.Cells[row, 43, row, 52].Merge            = true;
//                ExcelWorksheet.Cells[row, 43, row, 52].Style.Font.Bold  = true;
//                ExcelWorksheet.Cells[row, 43, row, 52].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
//                ExcelWorksheet.Cells[row, 43, row, 52].Style.Border.Left.  Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row, 43, row, 52].Style.Border.Top.   Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row, 43, row, 52].Style.Border.Right. Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row, 43, row, 52].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
//                ExcelWorksheet.Cells[row, 43].Value = "4. Ladepunkt";

//                row++;
//                ExcelWorksheet.Cells[row,  1].Value = "Datum der Anzeige";
//                ExcelWorksheet.Cells[row,  2].Value = "Name/Rechtsform";
//                ExcelWorksheet.Cells[row,  3].Value = "Betreibernummer";
//                ExcelWorksheet.Cells[row,  4].Value = "Ladesäulen-ID";

//                ExcelWorksheet.Cells[row,  5].Value = "Datum des Aufbaus/öffentlich Werdens";
//                ExcelWorksheet.Cells[row,  6].Value = "Datum der geplanten Inbetriebnahme";
//                ExcelWorksheet.Cells[row,  7].Value = "Straße, Hausnummer";
//                ExcelWorksheet.Cells[row,  8].Value = "PLZ Ort";
//                ExcelWorksheet.Cells[row,  9].Value = "Längengrad (Dezimalgrad)";
//                ExcelWorksheet.Cells[row, 10].Value = "Breitengrad (Dezimalgrad)";
//                ExcelWorksheet.Cells[row, 11].Value = "Anschlussleistung (kW)";
//                ExcelWorksheet.Cells[row, 12].Value = "Anzahl Ladepunkte";

//                for (var i = 0; i < 4; i++)
//                {
//                    ExcelWorksheet.Cells[row, 10*i + 13].Value = "Art des LP (" + (i + 1) + ")";
//                    ExcelWorksheet.Cells[row, 10*i + 14].Value = "AC Steckdose Typ 2 (" + (i + 1) + ")";
//                    ExcelWorksheet.Cells[row, 10*i + 15].Value = "AC Kupplung Typ 2 (" + (i + 1) + ")";
//                    ExcelWorksheet.Cells[row, 10*i + 16].Value = "DC Kupplung Combo (" + (i + 1) + ")";
//                    ExcelWorksheet.Cells[row, 10*i + 17].Value = "AC Schuko (" + (i + 1) + ")";
//                    ExcelWorksheet.Cells[row, 10*i + 18].Value = "AC CEE 5 polig (" + (i + 1) + ")";
//                    ExcelWorksheet.Cells[row, 10*i + 19].Value = "AC CEE 3 polig (" + (i + 1) + ")";
//                    ExcelWorksheet.Cells[row, 10*i + 20].Value = "DC CHAdeMO (" + (i + 1) + ")";
//                    ExcelWorksheet.Cells[row, 10*i + 21].Value = "Sonstige Stecker (" + (i + 1) + ")";
//                    ExcelWorksheet.Cells[row, 10*i + 22].Value = "Nennleistung [kW] (" + (i + 1) + ")";
//                }

//                ExcelWorksheet.Cells[row, 53].Value = "Schlüsselnummer (Ladestationstyp)";

//                ExcelWorksheet.Cells[row, 1, row, 53].Style.Font.Bold = true;
//                ExcelWorksheet.Cells[row, 1, row, 53].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(255, 255, 255, 255));
//                ExcelWorksheet.Cells[row, 1, row, 53].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
//                ExcelWorksheet.Cells[row, 1, row, 53].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 79, 129, 189));

//                var RowStart = row + 1;
//                var Today    = DateTime.Now;

//                foreach (var station in RoamingNetwork.ChargingStations.OrderBy(station => station.Id))
//                {

//                    //if (!IncludeDataSource(station.DataSource) ||

//                    //    station.ChargingPool.Description.FirstText().Contains("Messestandort") ||
//                    //    station.ChargingPool.Description.FirstText().Contains("Teststandort")  ||
//                    //    station.ChargingPool.Description.FirstText().Contains("Messebox")      ||
//                    //    station.ChargingPool.Description.FirstText().Contains("Testbox")       ||

//                    //    station.             Description.FirstText().Contains("Messestandort") ||
//                    //    station.             Description.FirstText().Contains("Teststandort")  ||
//                    //    station.             Description.FirstText().Contains("Messebox")      ||
//                    //    station.             Description.FirstText().Contains("Testbox")       ||

//                    //    station.Brand?.Name.FirstText() == "chargeIT Messe"       ||
//                    //    station.Brand?.Name.FirstText() == "Belectric Italia srl" ||
//                    //    station.Brand?.Name.FirstText() == "Belectric France"     ||
//                    //    station.Brand?.Name.FirstText() == "chargeIT Lager"       ||
//                    //    station.Brand?.Name.FirstText() == "solid GmbH"           ||
//                    //    station.Brand?.Name.FirstText() == "Ladeverbund Franken+" ||
//                    //    station.Brand?.Name.FirstText() == "Hubject GmbH")

//                    //    continue;

//                    if (IncludeChargingStation(station)            &&
//                        IncludeDataSource     (station.DataSource) &&
//                        station.Brands.Any(brand => IncludeBrand(brand)))
//                    {

//                        row++;

//                        ExcelWorksheet.Cells[row,  1].Value = Today;//.Day + ". " + Today.Month + ". " + Today.Year;
//                        ExcelWorksheet.Cells[row,  2].Value = station.Brands?.Where(brand => IncludeBrand(brand)).Select(brand => brand?.Name?.FirstText()).OrderBy(brand => brand).AggregateWith(";");
//                        ExcelWorksheet.Cells[row,  4].Value = station.Id.ToString();
//                        ExcelWorksheet.Cells[row,  7].Value = String.Concat(station.Address.Street,     " ", station.Address.HouseNumber);
//                        ExcelWorksheet.Cells[row,  8].Value = String.Concat(station.Address.PostalCode, " ", station.Address.City.FirstText());
//                        ExcelWorksheet.Cells[row,  9].Value = station.GeoLocation.Value.Longitude.Value;
//                        ExcelWorksheet.Cells[row, 10].Value = station.GeoLocation.Value.Latitude. Value;

//                        ExcelWorksheet.Cells[row, 12].Value = station.EVSEs.Count();
//                        // Normalladepunkt mit einer Ladeleistung von höchstens 22 kW
//                        // Schnellladepunkt mit einer Ladeleistung von mehr als 22 kW


//                        station.ForEachCounted((evse, number) => {

//                            switch (evse.SocketOutlets.First().Plug)
//                            {

//                                case PlugTypes.Type2Outlet:
//                                    ExcelWorksheet.Cells[row, (Int32) ( 3 + 10 * number)].Value = "AC";
//                                    ExcelWorksheet.Cells[row, (Int32) ( 4 + 10 * number)].Value = true;
//                                    break;

//                                case PlugTypes.Type2Connector_CableAttached:
//                                    ExcelWorksheet.Cells[row, (Int32) ( 3 + 10 * number)].Value = "AC";
//                                    ExcelWorksheet.Cells[row, (Int32) ( 5 + 10 * number)].Value = true;
//                                    break;

//                                case PlugTypes.CCSCombo2Plug_CableAttached:
//                                    ExcelWorksheet.Cells[row, (Int32) ( 3 + 10 * number)].Value = "DC";
//                                    ExcelWorksheet.Cells[row, (Int32) ( 6 + 10 * number)].Value = true;
//                                    break;

//                                case PlugTypes.TypeFSchuko:
//                                    ExcelWorksheet.Cells[row, (Int32) ( 3 + 10 * number)].Value = "AC";
//                                    ExcelWorksheet.Cells[row, (Int32) ( 7 + 10 * number)].Value = true;
//                                    break;

//                                case PlugTypes.CEE5:
//                                    ExcelWorksheet.Cells[row, (Int32) ( 3 + 10 * number)].Value = "AC";
//                                    ExcelWorksheet.Cells[row, (Int32) ( 8 + 10 * number)].Value = true;
//                                    break;

//                                case PlugTypes.CEE3:
//                                    ExcelWorksheet.Cells[row, (Int32) ( 3 + 10 * number)].Value = "AC";
//                                    ExcelWorksheet.Cells[row, (Int32) ( 9 + 10 * number)].Value = true;
//                                    break;

//                                case PlugTypes.CHAdeMO:
//                                    ExcelWorksheet.Cells[row, (Int32) ( 3 + 10 * number)].Value = "DC";
//                                    ExcelWorksheet.Cells[row, (Int32) (10 + 10 * number)].Value = true;
//                                    break;

//                                default:
//                                    ExcelWorksheet.Cells[row, (Int32) (11 + 10 * number)].Value = evse.SocketOutlets.First().Plug.ToString();
//                                    break;

//                            }

//                            ExcelWorksheet.Cells[row, (Int32) (12 + 10 * number)].Value                     = evse.MaxPower;
//                            ExcelWorksheet.Cells[row, (Int32) (12 + 10 * number)].Style.Numberformat.Format = "#.0";

//                        });

//                        ExcelWorksheet.Cells[row, 53].Value = station.ModelCode;

//                    }

//                }

//                ExcelWorksheet.Cells[RowStart,  1, row,  1].Style.Numberformat.Format = "dd. mm. yyyy";
//                ExcelWorksheet.Cells[RowStart,  9, row, 10].Style.Numberformat.Format = "#.######";
//                ExcelWorksheet.Cells[RowStart, 11, row, 53].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

//                ExcelWorksheet.Cells[5, 1, row, 53].AutoFitColumns(1);

//                // Save our new workbook and we are done!
//                package.Save();

//            }

//        }

//    }

//}
