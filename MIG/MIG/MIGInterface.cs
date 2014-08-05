/*
    This file is part of HomeGenie Project source code.

    HomeGenie is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    HomeGenie is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with HomeGenie.  If not, see <http://www.gnu.org/licenses/>.  
*/

/*
 *     Author: Generoso Martello <gene@homegenie.it>
 *     Project Homepage: http://homegenie.it
 */

using System;
using System.Collections.Generic;

namespace MIG
{
    public interface MIGInterface
    {
        /// <summary>
        /// interface identifier domain (eg. HomeAutomation.ZWave, Controllers.Kinect)
        /// that should be usually automatically calculated from namespace
        /// </summary>
        string Domain { get; }
        //List<InterfaceModule> GetModules();
        /// <summary>
        /// all input data coming from connected device
        /// is routed via InterfacePropertyChangedAction event
        /// </summary>
        event Action<InterfacePropertyChangedAction> InterfacePropertyChangedAction;
        /// <summary>
        /// entry point for sending commands (control/configuration)
        /// to the connected device. 
        /// </summary>
        /// <param name="command">MIG interface command</param>
        /// <returns></returns>
        object InterfaceControl(MIGInterfaceCommand command);
        /// <summary>
        /// wait for completition of all queued interface commands 
        /// </summary>
        //TODO: deprecate this
        void WaitOnPending();
        /// <summary>
        /// this value can be actively polled to detect
        /// current interface connection state
        /// </summary>
        bool IsConnected { get; }
        /// <summary>
        /// connect to the device interface / perform all setup
        /// </summary>
        /// <returns>a boolean indicating if the connection was succesful</returns>
        bool Connect();
        /// <summary>
        /// disconnect the device interface / perform everything needed for shutdown/cleanup
        /// </summary>
        void Disconnect();
        /// <summary>
        /// this return true if the device has been found in the system (probing)
        /// </summary>
        /// <returns></returns>
        bool IsDevicePresent();
    }

    public class InterfaceModule
    {
        public string Domain { get; set; }
        public string Address { get; set; }
        public string ModuleType { get; set; }
        public dynamic CustomData { get; set; }
    }

    public class InterfacePropertyChangedAction
    {
        public string Domain { get; set; }
        public string SourceId { get; set; }
        public string SourceType { get; set; }
        public string Path { get; set; }
        public object Value { get; set; }
    }

    public class InterfaceConnectedStateChangedAction
    {
        public bool Connected { get; internal set; }
    }

}

