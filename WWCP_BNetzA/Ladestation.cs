/*
 * Copyright (c) 2014-2023 GraphDefined GmbH
 * This file is part of WWCP BNetzA <https://github.com/OpenChargingCloud/WWCP_BNetzA>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using Newtonsoft.Json.Linq;

using org.GraphDefined.Vanaheimr.Aegir;
using org.GraphDefined.Vanaheimr.Illias;

#endregion

namespace community.charging.open.protocols.bnetza
{
    public class Ladestation
    {

        public String                  Betreiber                { get; }
        public String                  Straße                   { get; }
        public String                  Hausnummer               { get; }
        public String                  Adresszusatz             { get; }
        public String                  Postleitzahl             { get; }
        public String                  Ort                      { get; }
        public String                  Bundesland               { get; }
        public String                  Kreis_kreisfreieStadt    { get; }
        public Latitude                Breitengrad              { get; }
        public Longitude               Längengrad               { get; }
        public String                  Inbetriebnahmedatum      { get; }
        public String                  Anschlussleistung        { get; }
        public String                  ArtDerLadeeinrichung     { get; }

        public IEnumerable<Ladepunkt>  Ladepunkte               { get; }

        /// <summary>
        /// 
        /// CC BY 4.0 Bundesnetzagentur.de
        /// https://creativecommons.org/licenses/by/4.0/deed.de
        /// ladesaeulenverordnung@bnetza.de
        /// </summary>
        /// <param name="Betreiber"></param>
        /// <param name="Straße"></param>
        /// <param name="Hausnummer"></param>
        /// <param name="Adresszusatz"></param>
        /// <param name="Postleitzahl"></param>
        /// <param name="Ort"></param>
        /// <param name="Bundesland"></param>
        /// <param name="Kreis_kreisfreieStadt"></param>
        /// <param name="Breitengrad"></param>
        /// <param name="Längengrad"></param>
        /// <param name="Inbetriebnahmedatum"></param>
        /// <param name="Anschlussleistung"></param>
        /// <param name="ArtDerLadeeinrichung"></param>
        /// <param name="Ladepunkte"></param>
        public Ladestation(String                  Betreiber,
                           String                  Straße,
                           String                  Hausnummer,
                           String                  Adresszusatz,
                           String                  Postleitzahl,
                           String                  Ort,
                           String                  Bundesland,
                           String                  Kreis_kreisfreieStadt,
                           Latitude                Breitengrad,
                           Longitude               Längengrad,
                           String                  Inbetriebnahmedatum,
                           String                  Anschlussleistung,
                           String                  ArtDerLadeeinrichung,
                           IEnumerable<Ladepunkt>  Ladepunkte)
        {

            this.Betreiber              = Betreiber;
            this.Straße                 = Straße;
            this.Hausnummer             = Hausnummer;
            this.Adresszusatz           = Adresszusatz;
            this.Postleitzahl           = Postleitzahl;
            this.Ort                    = Ort;
            this.Bundesland             = Bundesland;
            this.Kreis_kreisfreieStadt  = Kreis_kreisfreieStadt;
            this.Breitengrad            = Breitengrad;
            this.Längengrad             = Längengrad;
            this.Inbetriebnahmedatum    = Inbetriebnahmedatum;
            this.Anschlussleistung      = Anschlussleistung;
            this.ArtDerLadeeinrichung   = ArtDerLadeeinrichung;
            this.Ladepunkte             = Ladepunkte;

        }

        public Ladestation(String[] CSVDaten)
        {

            // Allgemeine Informationen; ; ; ; ; ; ; ; ; ; ; ; ; ; 1.Ladepunkt; ; ; 2.Ladepunkt; ; ; 3.Ladepunkt; ; ; 4.Ladepunkt; ;
            // Betreiber; Straße; Hausnummer; Adresszusatz; Postleitzahl; Ort; Bundesland; Kreis / kreisfreie Stadt; Breitengrad; Längengrad; Inbetriebnahmedatum; Anschlussleistung; Art der Ladeeinrichung; Anzahl Ladepunkte; Steckertypen1; P1[kW]; Public Key1; Steckertypen2; P2[kW]; Public Key2; Steckertypen3; P3[kW]; Public Key3; Steckertypen4; P4[kW]; Public Key4

            this.Betreiber              = CSVDaten[0];
            this.Straße                 = CSVDaten[1];
            this.Hausnummer             = CSVDaten[2];
            this.Adresszusatz           = CSVDaten[3];
            this.Postleitzahl           = CSVDaten[4];
            this.Ort                    = CSVDaten[5];
            this.Bundesland             = CSVDaten[6];
            this.Kreis_kreisfreieStadt  = CSVDaten[7];
            this.Breitengrad            = Latitude. Parse(CSVDaten[8].Trim().Replace(',', '.'));
            this.Längengrad             = Longitude.Parse(CSVDaten[9].Trim().Replace(',', '.'));
            this.Inbetriebnahmedatum    = CSVDaten[10];
            this.Anschlussleistung      = CSVDaten[11];
            this.ArtDerLadeeinrichung   = CSVDaten[12];


            var ladepunkte = new List<Ladepunkt>();

            if (CSVDaten[14].Trim().IsNotNullOrEmpty() ||
                CSVDaten[15].Trim().IsNotNullOrEmpty() ||
                CSVDaten[16].Trim().IsNotNullOrEmpty())
            {

                ladepunkte.Add(new Ladepunkt(
                                   CSVDaten[14].Trim(),
                                   CSVDaten[15].Trim(),
                                   CSVDaten[16].Trim()
                               ));

            }

            if (CSVDaten[17].Trim().IsNotNullOrEmpty() ||
                CSVDaten[18].Trim().IsNotNullOrEmpty() ||
                CSVDaten[19].Trim().IsNotNullOrEmpty())
            {

                ladepunkte.Add(new Ladepunkt(
                                   CSVDaten[17].Trim(),
                                   CSVDaten[18].Trim(),
                                   CSVDaten[19].Trim()
                               ));

            }

            if (CSVDaten[20].Trim().IsNotNullOrEmpty() ||
                CSVDaten[21].Trim().IsNotNullOrEmpty() ||
                CSVDaten[22].Trim().IsNotNullOrEmpty())
            {

                ladepunkte.Add(new Ladepunkt(
                                   CSVDaten[20].Trim(),
                                   CSVDaten[21].Trim(),
                                   CSVDaten[22].Trim()
                               ));

            }

            if (CSVDaten[23].Trim().IsNotNullOrEmpty() ||
                CSVDaten[24].Trim().IsNotNullOrEmpty() ||
                CSVDaten[25].Trim().IsNotNullOrEmpty())
            {

                ladepunkte.Add(new Ladepunkt(
                                   CSVDaten[23].Trim(),
                                   CSVDaten[24].Trim(),
                                   CSVDaten[25].Trim()
                               ));

            }

            this.Ladepunkte             = ladepunkte.ToArray();

        }

    }

}
