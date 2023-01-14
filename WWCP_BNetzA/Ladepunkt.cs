/*
 * Copyright (c) 2014-2023 GraphDefined GmbH
 * This file is part of WWCP BNetzA <https://github.com/OpenChargingCloud/WWCP_BNetzA>
 *
 * Licensed under the Affero GPL license, Version 3.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.gnu.org/licenses/agpl.html
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
    public class Ladepunkt
    {

        public String     Steckertypen             { get; }
        public String     Leistung_kW              { get; }
        public String     PublicKey                { get; }


        public Ladepunkt(String  Steckertypen,
                            String  Leistung_kW,
                            String  PublicKey)
        {

            this.Steckertypen  = Steckertypen;
            this.Leistung_kW   = Leistung_kW;
            this.PublicKey     = PublicKey;

        }

    }

}
